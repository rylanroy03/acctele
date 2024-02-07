using System;
using System.IO.MemoryMappedFiles;
using System.IO;
using System.Runtime.InteropServices;

namespace acctele
{
    public class Memory_reader
    {
        // Method to read telemetry data from shared memory
        public string[] ReadFromSharedMemory()
        {
            string[] telemetryVals = new string[34]; // DEFINES THE SIZE OF THE ARRAY. MUST CHANGE IF OUT OF BOUNDS
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("acpmf_physics"))
                {
                    using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor())
                    {
                        // Define the size of the data structure representing telemetry data
                        int dataSize = Marshal.SizeOf(typeof(TelemetryData));

                        // Allocate a byte array to hold the data
                        byte[] data = new byte[dataSize];

                        // Read data from the memory-mapped file into the byte array
                        accessor.ReadArray(0, data, 0, dataSize);

                        // Convert the byte array to a TelemetryData object
                        TelemetryData telemetryData = ByteArrayToStructure<TelemetryData>(data);

                        // MOE Parameters. Corrects erroneous data when at crossing points and thresholds.
                        if (telemetryData.acc3x <= 0.001 && telemetryData.acc3y <= 0.0015 && telemetryData.acc3z <= 0.001 && telemetryData.speedKmh <= 0.05)
                        {
                            telemetryData.velocity3x = 0;
                            telemetryData.velocity3y = 0;
                            telemetryData.velocity3z = 0;
                        }
                        if (telemetryData.steerAngle <= 0.0003 && telemetryData.steerAngle >= -0.001)
                        {
                            telemetryData.steerAngle = 0;
                        }

                        // Process the telemetry data as needed
                        // Example: Log or display telemetry data
                        telemetryVals[0] = "PID: " + telemetryData.packetID;
                        telemetryVals[1] = "Gas: " + telemetryData.gas;
                        telemetryVals[2] = "Brake: " + telemetryData.brake;
                        telemetryVals[3] = "Fuel: " + telemetryData.fuel;
                        telemetryVals[4] = "Gear: " + telemetryData.gear;
                        telemetryVals[5] = "RPM: " + telemetryData.rpm;
                        telemetryVals[6] = "Steering: " + Truncate(telemetryData.steerAngle.ToString(), 6);
                        telemetryVals[7] = "Speed: " + Truncate(telemetryData.speedKmh.ToString(), 4);
                        telemetryVals[8] = "Vel [X]: " + Truncate(telemetryData.velocity3x.ToString(), 5);
                        telemetryVals[9] = "Vel [Y]: " + Truncate(telemetryData.velocity3y.ToString(), 5);
                        telemetryVals[10] = "Vel [Z]: " + Truncate(telemetryData.velocity3z.ToString(), 5);
                        telemetryVals[11] = "Acc [X]: " + Truncate(telemetryData.acc3x.ToString(), 5);
                        telemetryVals[12] = "Acc [Y]: " + Truncate(telemetryData.acc3y.ToString(), 5);
                        telemetryVals[13] = "Acc [Z]: " + Truncate(telemetryData.acc3z.ToString(), 5);
                        telemetryVals[14] = "Slip [FL / FR]:  " + Truncate(telemetryData.slipfl.ToString(), 4) +
                            "  /  " + Truncate(telemetryData.slipfr.ToString(), 4);
                        telemetryVals[15] = "Slip [RL / RR]:  " + Truncate(telemetryData.sliprl.ToString(), 4) + 
                            "  /  " + Truncate(telemetryData.sliprr.ToString(), 4);
                        telemetryVals[16] = "Pres [FL / FR]: " + Truncate(telemetryData.presfl.ToString(), 5) + 
                            "  /  " + Truncate(telemetryData.presfr.ToString(), 5);
                        telemetryVals[17] = "Pres [RL / RR]: " + Truncate(telemetryData.presrl.ToString(), 5) + 
                            "  /  " + Truncate(telemetryData.presrr.ToString(), 5);
                        telemetryVals[18] = "Angular Speed [FL]: " + Truncate(telemetryData.angspeedfl.ToString(), 5);
                        telemetryVals[19] = "Angular Speed [FR]: " + Truncate(telemetryData.angspeedfr.ToString(), 5);
                        telemetryVals[20] = "Angular Speed [RL]: " + Truncate(telemetryData.angspeedrl.ToString(), 5);
                        telemetryVals[21] = "Angular Speed [RR]: " + Truncate(telemetryData.angspeedrr.ToString(), 5);
                        telemetryVals[22] = "Tire Temp [FL]: " + Truncate(telemetryData.tempfl.ToString(), 5);
                        telemetryVals[23] = "Tire Temp [FR]: " + Truncate(telemetryData.tempfr.ToString(), 5);
                        telemetryVals[24] = "Tire Temp [RL]: " + Truncate(telemetryData.temprl.ToString(), 5);
                        telemetryVals[25] = "Tire Temp [RR]: " + Truncate(telemetryData.temprr.ToString(), 5);
                        telemetryVals[26] = "Suspension [FL]: " + Truncate(telemetryData.sustfl.ToString(), 5);
                        telemetryVals[27] = "Suspension [FR]: " + Truncate(telemetryData.sustfr.ToString(), 5);
                        telemetryVals[28] = "Suspension [RL]: " + Truncate(telemetryData.sustrl.ToString(), 5);
                        telemetryVals[29] = "Suspension [RR]: " + Truncate(telemetryData.sustrr.ToString(), 5);
                        telemetryVals[30] = "TC On: " + telemetryData.tcon;
                        telemetryVals[31] = "Heading: " + Truncate(telemetryData.heading.ToString(), 5);
                        telemetryVals[32] = "Pitch: " + Truncate(telemetryData.pitch.ToString(), 5);
                        telemetryVals[33] = "Roll: " + Truncate(telemetryData.roll.ToString(), 5);
                        // Add more fields as needed
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Memory-mapped file not found.");
                telemetryVals[0] = "Waiting for telemetry...";
            }
            catch (Exception)
            {
                telemetryVals[0] = "Waiting for telemetry...";
            }
            return telemetryVals;
        }

        private string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        // Helper method to convert byte array to struct
        public static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
        {
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                return (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                handle.Free();
            }
        }
    }

    // Define the structure of telemetry data
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TelemetryData
    {
        public int packetID;
        public float gas;
        public float brake;
        public float fuel;
        public int gear;
        public int rpm;
        public float steerAngle;
        public float speedKmh;
        public float velocity3x; // Velocity
        public float velocity3y;
        public float velocity3z;
        public float acc3x; // Acceleration
        public float acc3y;
        public float acc3z;
        public float slipfl; // Wheelslip
        public float slipfr;
        public float sliprl;
        public float sliprr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] ignoredValues1; // Skipped fields
        public float presfl; // Tire pressure
        public float presfr;
        public float presrl;
        public float presrr;
        public float angspeedfl; // Tire angular speed
        public float angspeedfr;
        public float angspeedrl;
        public float angspeedrr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] public float[] ignoredValues2;
        public float tempfl; // Core Tire temps
        public float tempfr;
        public float temprl;
        public float temprr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] ignoredValues3;
        public float sustfl; // Suspension Travel
        public float sustfr;
        public float sustrl;
        public float sustrr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] public float[] ignoredValues4;
        public float tcon;
        public float heading;
        public float pitch;
        public float roll;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] public float[] ignoredValues5;
        public float carDamage1;
        public float carDamage2;
        public float carDamage3;
        public float carDamage4;
        public float carDamage5;
        // Add more fields as needed
    }
}
