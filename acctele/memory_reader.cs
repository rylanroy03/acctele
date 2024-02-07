using System;
using System.IO.MemoryMappedFiles;
using System.IO;
using System.Runtime.InteropServices;

namespace acctele
{
    public class memory_reader
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
                        telemetryVals[14] = "Wheelslip [FL]: " + Truncate(telemetryData.slipfl.ToString(), 4);
                        telemetryVals[15] = "Wheelslip [FR]: " + Truncate(telemetryData.slipfr.ToString(), 4);
                        telemetryVals[16] = "Wheelslip [RL]: " + Truncate(telemetryData.sliprl.ToString(), 4);
                        telemetryVals[17] = "Wheelslip [RR]: " + Truncate(telemetryData.sliprr.ToString(), 4);
                        telemetryVals[18] = "Pressure [FL]: " + Truncate(telemetryData.presfl.ToString(), 5);
                        telemetryVals[19] = "Pressure [FR]: " + Truncate(telemetryData.presfr.ToString(), 5);
                        telemetryVals[20] = "Pressure [RL]: " + Truncate(telemetryData.presrl.ToString(), 5);
                        telemetryVals[21] = "Pressure [RR]: " + Truncate(telemetryData.presrr.ToString(), 5);
                        telemetryVals[22] = "Angular Speed [FL]: " + Truncate(telemetryData.angspeedfl.ToString(), 5);
                        telemetryVals[23] = "Angular Speed [FR]: " + Truncate(telemetryData.angspeedfr.ToString(), 5);
                        telemetryVals[24] = "Angular Speed [RL]: " + Truncate(telemetryData.angspeedrl.ToString(), 5);
                        telemetryVals[25] = "Angular Speed [RR]: " + Truncate(telemetryData.angspeedrr.ToString(), 5);
                        telemetryVals[26] = "Tire Temp [FL]: " + Truncate(telemetryData.tempfl.ToString(), 5);
                        telemetryVals[27] = "Tire Temp [FR]: " + Truncate(telemetryData.tempfr.ToString(), 5);
                        telemetryVals[28] = "Tire Temp [RL]: " + Truncate(telemetryData.temprl.ToString(), 5);
                        telemetryVals[29] = "Tire Temp [RR]: " + Truncate(telemetryData.temprr.ToString(), 5);
                        telemetryVals[30] = "Suspension [FL]: " + Truncate(telemetryData.sustfl.ToString(), 5);
                        telemetryVals[31] = "Suspension [FR]: " + Truncate(telemetryData.sustfr.ToString(), 5);
                        telemetryVals[32] = "Suspension [RL]: " + Truncate(telemetryData.sustrl.ToString(), 5);
                        telemetryVals[33] = "Suspension [RR]: " + Truncate(telemetryData.sustrr.ToString(), 5);
                        // Add more fields as needed
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Memory-mapped file not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while reading from shared memory: " + ex.Message);
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
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] public float[] ignoredValues2; // Skipped fields
        public float tempfl; // Core Tire temps
        public float tempfr;
        public float temprl;
        public float temprr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] ignoredValues3; // Skipped fields
        public float sustfl; // Suspension Travel
        public float sustfr;
        public float sustrl;
        public float sustrr;
        // Add more fields as needed
    }
}
