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
            string[] telemetryVals = new string[90]; // DEFINES THE SIZE OF THE ARRAY. MUST CHANGE IF OUT OF BOUNDS (n + 1)
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("acpmf_physics"))
                {
                    using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor())
                    {
                        // Define the size of the data structure representing telemetry data
                        int dataSize = Marshal.SizeOf(typeof(PhysicsTelemetry));

                        // Allocate a byte array to hold the data
                        byte[] data = new byte[dataSize];

                        // Read data from the memory-mapped file into the byte array
                        accessor.ReadArray(0, data, 0, dataSize);

                        // Convert the byte array to a TelemetryData object
                        PhysicsTelemetry telemetryData = ByteArrayToStructure<PhysicsTelemetry>(data);



                        // MOE Parameters and array assignments
                        if (telemetryData.steerAngle <= 0.0003 && telemetryData.steerAngle >= -0.001)
                        {
                            telemetryData.steerAngle = 0;
                        }

                        


                        // SPAGEPHYSICSFILE DATA DISPLAY
                        telemetryVals[0] = "PID: " + telemetryData.packetID;
                        telemetryVals[1] = "Gas: " + Math.Round(telemetryData.gas, 3).ToString("F3");
                        telemetryVals[2] = "Brake: " + Math.Round(telemetryData.brake, 3).ToString("F3");
                        telemetryVals[3] = "Fuel: " + telemetryData.fuel;
                        telemetryVals[4] = "Gear: " + telemetryData.gear;
                        telemetryVals[5] = "RPM: " + telemetryData.rpm;
                        telemetryVals[6] = "Steering: " + Math.Round(telemetryData.steerAngle, 4);
                        telemetryVals[7] = "Speed: " + Truncate(telemetryData.speedKmh.ToString(), 4);
                        telemetryVals[8] = "Velocity <XYZ>";
                        telemetryVals[9] = "<"  + Math.Round(telemetryData.velocity[0], 5).ToString("F3") + ", "
                                                + Math.Round(telemetryData.velocity[1], 5).ToString("F3") + ", " 
                                                + Math.Round(telemetryData.velocity[2], 5).ToString("F3") + ">";
                        telemetryVals[10] = "Acceleration <XYZ>";
                        telemetryVals[11] = "<" + Math.Round(telemetryData.accel[0], 5).ToString("F3") + ", " 
                                                + Math.Round(telemetryData.accel[1], 5).ToString("F3") + ", " 
                                                + Math.Round(telemetryData.accel[2], 5).ToString("F3") + ">";
                        telemetryVals[12] = "Slip [F L/R]:  " + Truncate(telemetryData.slip[0].ToString("F4"), 4) + " / " + Truncate(telemetryData.slip[1].ToString("F4"), 4);
                        telemetryVals[13] = "Slip [R L/R]:  " + Truncate(telemetryData.slip[2].ToString("F4"), 4) + " / " + Truncate(telemetryData.slip[3].ToString("F4"), 4);
                        telemetryVals[14] = "Pres [F L/R]: " + Truncate(telemetryData.pres[0].ToString("F4"), 5) + " / " + Truncate(telemetryData.pres[1].ToString("F4"), 5);
                        telemetryVals[15] = "Pres [R L/R]: " + Truncate(telemetryData.pres[2].ToString("F4"), 5) + " / " + Truncate(telemetryData.pres[3].ToString("F4"), 5);
                        telemetryVals[16] = "Angular Speed";
                        telemetryVals[17] = "[F L/R]: " + Math.Round(telemetryData.angspeed[0], 2).ToString("F2") + " / " + Math.Round(telemetryData.angspeed[1], 2).ToString("F2");
                        telemetryVals[18] = "[R L/R]: " + Math.Round(telemetryData.angspeed[2], 2).ToString("F2") + " / " + Math.Round(telemetryData.angspeed[3], 2).ToString("F2");
                        telemetryVals[19] = "Tire Temperature";
                        telemetryVals[20] = "[F L/R]: "+ Truncate(telemetryData.temp[0].ToString(), 5) + " / " + Truncate(telemetryData.temp[1].ToString(), 5);
                        telemetryVals[21] = "[R L/R]: " + Truncate(telemetryData.temp[2].ToString(), 5) + " / " + Truncate(telemetryData.temp[3].ToString(), 5);
                        telemetryVals[22] = "Suspension Travel";
                        telemetryVals[23] = "[F L/R]: " + Truncate(telemetryData.sust[0].ToString(), 5) + " / " + Truncate(telemetryData.sust[1].ToString(), 5);
                        telemetryVals[24] = "[R L/R]: " + Truncate(telemetryData.sust[2].ToString(), 5) + " / " + Truncate(telemetryData.sust[3].ToString(), 5);
                        telemetryVals[25] = "TC On: " + telemetryData.tcon;
                        telemetryVals[26] = "Heading: " + Truncate(telemetryData.heading.ToString(), 5);
                        telemetryVals[27] = "Pitch: " + Truncate(telemetryData.pitch.ToString(), 5);
                        telemetryVals[28] = "Roll: " + Truncate(telemetryData.roll.ToString(), 5);
                        telemetryVals[29] = "Car damage [Frnt]: " + telemetryData.carDamage[0];
                        telemetryVals[30] = "Car damage [Rear]: " + telemetryData.carDamage[1];
                        telemetryVals[31] = "Car damage [Left]: " + telemetryData.carDamage[2];
                        telemetryVals[32] = "Car damage [Rght]: " + telemetryData.carDamage[3];
                        telemetryVals[33] = "Car damage [Cntr]: " + telemetryData.carDamage[4];
                        telemetryVals[34] = "Pit Limiter: " + telemetryData.pitlimit;
                        telemetryVals[35] = "ABS Level: " + telemetryData.absOn;
                        telemetryVals[36] = "Autoshifter: " + telemetryData.autoshifterOn;
                        telemetryVals[37] = "Turbo Boost: " + Math.Round(telemetryData.turboBoost, 3);
                        telemetryVals[38] = "Air Temp: " + Math.Round(telemetryData.airTemp, 1);
                        telemetryVals[39] = "Road Temp: " + Math.Round(telemetryData.roadTemp, 2);
                        telemetryVals[40] = "Local Angular Velocity <XYZ> ";
                        telemetryVals[41] = "<" + Math.Round(telemetryData.localAngVel[0], 3) + ", "
                                                + Math.Round(telemetryData.localAngVel[1], 3) + ", "
                                                + Math.Round(telemetryData.localAngVel[2], 3) + ">";
                        telemetryVals[42] = "FinalFF: " + Math.Round(telemetryData.finalFF, 3);
                        telemetryVals[43] = "BrakeTemp [F L/R]: " + Truncate(telemetryData.braketemp[0].ToString(), 5) + " / " + Truncate(telemetryData.braketemp[1].ToString(), 5);
                        telemetryVals[44] = "BrakeTemp [R L/R]: " + Truncate(telemetryData.braketemp[2].ToString(), 5) + " / " + Truncate(telemetryData.braketemp[3].ToString(), 5);
                        telemetryVals[45] = "Clutch: " + Math.Round(telemetryData.clutch, 3);
                        telemetryVals[46] = "Is AI On: " + telemetryData.isAIcontrolled;
                        telemetryVals[47] = "Tire Contact Point (XYZ)";
                        telemetryVals[48] = "[FL]: (" + Math.Round(telemetryData.tirecontactfl[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirecontactfl[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirecontactfl[2], 2).ToString("F2") + ")";
                        telemetryVals[49] = "[FR]: (" + Math.Round(telemetryData.tirecontactfr[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirecontactfr[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirecontactfr[2], 2).ToString("F2") + ")";
                        telemetryVals[50] = "[RL]: (" + Math.Round(telemetryData.tirecontactrl[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirecontactrl[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirecontactrl[2], 2).ToString("F2") + ")";
                        telemetryVals[51] = "[RR]: (" + Math.Round(telemetryData.tirecontactrr[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirecontactrr[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirecontactrr[2], 2).ToString("F2") + ")";
                        telemetryVals[52] = "Tire Contact Norm (XYZ)";
                        telemetryVals[53] = "[FL]: (" + Math.Round(telemetryData.tirenormfl[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirenormfl[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirenormfl[2], 2).ToString("F2") + ")";
                        telemetryVals[54] = "[FR]: (" + Math.Round(telemetryData.tirenormfr[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirenormfr[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirenormfr[2], 2).ToString("F2") + ")";
                        telemetryVals[55] = "[RL]: (" + Math.Round(telemetryData.tirenormrl[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirenormrl[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirenormrl[2], 2).ToString("F2") + ")";
                        telemetryVals[56] = "[RR]: (" + Math.Round(telemetryData.tirenormrr[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirenormrr[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirenormrr[2], 2).ToString("F2") + ")";
                        telemetryVals[57] = "Tire Contact Heading (XYZ)";
                        telemetryVals[58] = "[FL]: (" + Math.Round(telemetryData.tireheadfl[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tireheadfl[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tireheadfl[2], 2).ToString("F2") + ")";
                        telemetryVals[59] = "[FR]: (" + Math.Round(telemetryData.tireheadfr[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tireheadfr[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tireheadfr[2], 2).ToString("F2") + ")";
                        telemetryVals[60] = "[RL]: (" + Math.Round(telemetryData.tireheadrl[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tireheadrl[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tireheadrl[2], 2).ToString("F2") + ")";
                        telemetryVals[61] = "[RR]: (" + Math.Round(telemetryData.tireheadrr[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tireheadrr[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tireheadrr[2], 2).ToString("F2") + ")";
                        telemetryVals[62] = "Brake Bias: " + Math.Round(telemetryData.brakeBias, 4);
                        telemetryVals[63] = "Local Velocity <XYZ>";
                        telemetryVals[64] = "<" + Math.Round(telemetryData.localVel[0], 5).ToString("F3") + ", "
                        + Math.Round(telemetryData.localVel[1], 5).ToString("F3") + ", "
                        + Math.Round(telemetryData.localVel[2], 5).ToString("F3") + ">";
                        telemetryVals[65] = "Slip Ratio";
                        telemetryVals[66] = "[F L/R]: " + Math.Round(telemetryData.slipRatio[0], 2).ToString("F2") + " / " + Math.Round(telemetryData.slipRatio[1], 2).ToString("F2");
                        telemetryVals[67] = "[R L/R]: " + Math.Round(telemetryData.slipRatio[2], 2).ToString("F2") + " / " + Math.Round(telemetryData.slipRatio[3], 2).ToString("F2");
                        telemetryVals[68] = "Slip Angle";
                        telemetryVals[69] = "[F L/R]: " + Math.Round(telemetryData.slipAngle[0], 2).ToString("F2") + " / " + Math.Round(telemetryData.slipAngle[1], 2).ToString("F2");
                        telemetryVals[70] = "[R L/R]: " + Math.Round(telemetryData.slipAngle[2], 2).ToString("F2") + " / " + Math.Round(telemetryData.slipAngle[3], 2).ToString("F2");
                        telemetryVals[71] = "Water Temp: " + Math.Round(telemetryData.waterTemp, 2);
                        telemetryVals[72] = "Brake Pressure";
                        telemetryVals[73] = "[F L/R]: " + Math.Round(telemetryData.brakePressure[0], 2).ToString("F2") + " / " + Math.Round(telemetryData.brakePressure[1], 2).ToString("F2");
                        telemetryVals[74] = "[R L/R]: " + Math.Round(telemetryData.brakePressure[2], 2).ToString("F2") + " / " + Math.Round(telemetryData.brakePressure[3], 2).ToString("F2");
                        telemetryVals[75] = "Front Brake Cpd: " + telemetryData.frontbrakeCompound;
                        telemetryVals[76] = "Rear Brake Cmpd: " + telemetryData.rearbrakeCompound;
                        telemetryVals[77] = "Pad Life";
                        telemetryVals[78] = "[F L/R]: " + Math.Round(telemetryData.padLife[0], 2).ToString("F2") + " / " + Math.Round(telemetryData.padLife[1], 2).ToString("F2");
                        telemetryVals[79] = "[R L/R]: " + Math.Round(telemetryData.padLife[2], 2).ToString("F2") + " / " + Math.Round(telemetryData.padLife[3], 2).ToString("F2");
                        telemetryVals[80] = "Disc Life";
                        telemetryVals[81] = "[F L/R]: " + Math.Round(telemetryData.discLife[0], 2).ToString("F2") + " / " + Math.Round(telemetryData.discLife[1], 2).ToString("F2");
                        telemetryVals[82] = "[R L/R]: " + Math.Round(telemetryData.discLife[2], 2).ToString("F2") + " / " + Math.Round(telemetryData.discLife[3], 2).ToString("F2");
                        telemetryVals[83] = "Ignition Status: " + telemetryData.ignition;
                        telemetryVals[84] = "Stater Status: " + telemetryData.starter;
                        telemetryVals[85] = "Engine Running: " + telemetryData.engineRunning;
                        telemetryVals[86] = "Curb Vib: " + Math.Round(telemetryData.curbVibFFB, 3);
                        telemetryVals[87] = "Slip Vib: " + Math.Round(telemetryData.slipVibFFB, 3);
                        telemetryVals[88] = "G Vib: " + Math.Round(telemetryData.gVibFFB, 3);
                        telemetryVals[89] = "ABS Vib: " + Math.Round(telemetryData.absVibFFB, 3);
                        // End of SPagePhysicsFile
                    }
                }
            }
            catch (FileNotFoundException)
            {
                System.Console.WriteLine("Memory-mapped file not found.");
                telemetryVals[0] = "Waiting for telemetry input.\r\nPlease begin a session.";
            }
            catch (Exception)
            {
                telemetryVals[0] = "Waiting for telemetry input.\r\nPlease begin a session.";
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
    public struct PhysicsTelemetry
    {
        public int packetID;
        public float gas;
        public float brake;
        public float fuel;
        public int gear;
        public int rpm;
        public float steerAngle;
        public float speedKmh;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public float[] velocity; // Velocity
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public float[] accel; // Acceleration
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] slip; // Wheelslip
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] ignoredValues1; // Skipped fields
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] pres; // Tire pressure
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] angspeed; // Tire angular speed
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] public float[] ignoredValues2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] temp; // Core Tire temps
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] ignoredValues3;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] sust; // Suspension Travel
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] public float[] ignoredValues4;
        public float tcon;
        public float heading;
        public float pitch;
        public float roll;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] public float[] ignoredValues5;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)] public float[] carDamage;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] public float[] ignoredValues6;
        public int pitlimit;
        public float absOn;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public float[] ignoredValues7;
        public int autoshifterOn;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public float[] ignoredValues8;
        public float turboBoost;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public float[] ignoredValues9;
        public float airTemp;
        public float roadTemp;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public float[] localAngVel;
        public float finalFF;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)] public float[] ignoredValues10;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] braketemp;
        public float clutch;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)] public float[] ignoredValues11; // This made me so mad. I had size assigned to three forever and had problems with data below it.
        public int isAIcontrolled;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public float[] tirecontactfl;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public float[] tirecontactfr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public float[] tirecontactrl;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public float[] tirecontactrr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public float[] tirenormfl;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public float[] tirenormfr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public float[] tirenormrl;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public float[] tirenormrr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public float[] tireheadfl;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public float[] tireheadfr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public float[] tireheadrl;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public float[] tireheadrr;
        public float brakeBias;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public float[] localVel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)] public float[] ignoredValues12;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] slipRatio;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] slipAngle;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)] public float[] ignoredValues13;
        public float waterTemp;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] brakePressure;
        public int frontbrakeCompound;
        public int rearbrakeCompound;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] padLife;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] discLife;
        public int ignition;
        public int starter;
        public int engineRunning;
        public float curbVibFFB; // Curb Vibration FFB
        public float slipVibFFB; // Slip Vibration FFB
        public float gVibFFB; // G Force Vibration FFB
        public float absVibFFB; // Brake ABS Vibration FFB

        // End of the SPagePhysicsFile variables

    }
}
