using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace acctele
{
    public class Memory_reader
    {
        // Method to read telemetry data from shared memory
        public string[] ReadFromSharedMemory(string filename, int arraysize)
        {
            string[] telemetryVals = new string[arraysize]; // Defines Array size (size defined in consolewindow.cs)
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting(filename))
                {
                    using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor())
                    {
                        // SPAGEFILEPHYSICS DATA DISPLAY
                        if (filename == "acpmf_physics")
                        {
                            // Define data structure, allocate byte array, read data, and convert array to obj
                            int dataSize = Marshal.SizeOf(typeof(PhysicsTelemetry));
                            byte[] data = new byte[dataSize];
                            accessor.ReadArray(0, data, 0, dataSize);
                            PhysicsTelemetry telemetryData = ByteArrayToStructure<PhysicsTelemetry>(data);

                            int ind = 0;

                            telemetryVals[ind] = "PID: " + telemetryData.packetID; ind++;
                            telemetryVals[ind] = "Gas: " + Math.Round(telemetryData.gas, 3).ToString("F3"); ind++;
                            telemetryVals[ind] = "Brake: " + Math.Round(telemetryData.brake, 3).ToString("F3"); ind++;
                            telemetryVals[ind] = "Fuel: " + telemetryData.fuel; ind++;
                            telemetryVals[ind] = "Gear: " + telemetryData.gear; ind++;
                            telemetryVals[ind] = "RPM: " + telemetryData.rpm; ind++;
                            telemetryVals[ind] = "Steering: " + Math.Round(telemetryData.steerAngle, 4); ind++;
                            telemetryVals[ind] = "Speed: " + Truncate(telemetryData.speedKmh.ToString(), 4); ind++;
                            telemetryVals[ind] = "Velocity <XYZ>"; ind++;
                            telemetryVals[ind] = "<" + Math.Round(telemetryData.velocity[0], 5).ToString("F3") + ", "
                                                    + Math.Round(telemetryData.velocity[1], 5).ToString("F3") + ", "
                                                    + Math.Round(telemetryData.velocity[2], 5).ToString("F3") + ">"; ind++;
                            telemetryVals[ind] = "Acceleration <XYZ>"; ind++;
                            telemetryVals[ind] = "<" + Math.Round(telemetryData.accG[0], 5).ToString("F3") + ", "
                                                    + Math.Round(telemetryData.accG[1], 5).ToString("F3") + ", "
                                                    + Math.Round(telemetryData.accG[2], 5).ToString("F3") + ">"; ind++;
                            telemetryVals[ind] = "Slip [F L/R]:  " + Truncate(telemetryData.wheelSlip[0].ToString("F4"), 4) + " / " + Truncate(telemetryData.wheelSlip[1].ToString("F4"), 4); ind++;
                            telemetryVals[ind] = "Slip [R L/R]:  " + Truncate(telemetryData.wheelSlip[2].ToString("F4"), 4) + " / " + Truncate(telemetryData.wheelSlip[3].ToString("F4"), 4); ind++;
                            telemetryVals[ind] = "Pres [F L/R]: " + Truncate(telemetryData.wheelPressure[0].ToString("F4"), 5) + " / " + Truncate(telemetryData.wheelPressure[1].ToString("F4"), 5); ind++;
                            telemetryVals[ind] = "Pres [R L/R]: " + Truncate(telemetryData.wheelPressure[2].ToString("F4"), 5) + " / " + Truncate(telemetryData.wheelPressure[3].ToString("F4"), 5); ind++;
                            telemetryVals[ind] = "Angular Speed"; ind++;
                            telemetryVals[ind] = "[F L/R]: " + Math.Round(telemetryData.wheelAngularSpeed[0], 2).ToString("F2") + " / " + Math.Round(telemetryData.wheelAngularSpeed[1], 2).ToString("F2"); ind++;
                            telemetryVals[ind] = "[R L/R]: " + Math.Round(telemetryData.wheelAngularSpeed[2], 2).ToString("F2") + " / " + Math.Round(telemetryData.wheelAngularSpeed[3], 2).ToString("F2"); ind++;
                            telemetryVals[ind] = "Tire Temperature"; ind++;
                            telemetryVals[ind] = "[F L/R]: " + Truncate(telemetryData.TyreCoreTemp[0].ToString(), 5) + " / " + Truncate(telemetryData.TyreCoreTemp[1].ToString(), 5); ind++;
                            telemetryVals[ind] = "[R L/R]: " + Truncate(telemetryData.TyreCoreTemp[2].ToString(), 5) + " / " + Truncate(telemetryData.TyreCoreTemp[3].ToString(), 5); ind++;
                            telemetryVals[ind] = "Suspension Travel"; ind++;
                            telemetryVals[ind] = "[F L/R]: " + Truncate(telemetryData.suspensionTravel[0].ToString(), 5) + " / " + Truncate(telemetryData.suspensionTravel[1].ToString(), 5); ind++;
                            telemetryVals[ind] = "[R L/R]: " + Truncate(telemetryData.suspensionTravel[2].ToString(), 5) + " / " + Truncate(telemetryData.suspensionTravel[3].ToString(), 5); ind++;
                            telemetryVals[ind] = "TC On: " + telemetryData.tc; ind++;
                            telemetryVals[ind] = "Heading: " + Truncate(telemetryData.heading.ToString(), 5); ind++;
                            telemetryVals[ind] = "Pitch: " + Truncate(telemetryData.pitch.ToString(), 5); ind++;
                            telemetryVals[ind] = "Roll: " + Truncate(telemetryData.roll.ToString(), 5); ind++;
                            telemetryVals[ind] = "Car damage [Frnt]: " + telemetryData.carDamage[0]; ind++;
                            telemetryVals[ind] = "Car damage [Rear]: " + telemetryData.carDamage[1]; ind++;
                            telemetryVals[ind] = "Car damage [Left]: " + telemetryData.carDamage[2]; ind++;
                            telemetryVals[ind] = "Car damage [Rght]: " + telemetryData.carDamage[3]; ind++;
                            telemetryVals[ind] = "Car damage [Cntr]: " + telemetryData.carDamage[4]; ind++;
                            telemetryVals[ind] = "Pit Limiter: " + telemetryData.pitLimiterOn; ind++;
                            telemetryVals[ind] = "ABS Level: " + telemetryData.abs; ind++;
                            telemetryVals[ind] = "Autoshifter: " + telemetryData.autoshifterOn; ind++;
                            telemetryVals[ind] = "Turbo Boost: " + Math.Round(telemetryData.turboBoost, 3); ind++;
                            telemetryVals[ind] = "Air Temp: " + Math.Round(telemetryData.airTemp, 1); ind++;
                            telemetryVals[ind] = "Road Temp: " + Math.Round(telemetryData.roadTemp, 2); ind++;
                            telemetryVals[ind] = "Local Angular Velocity <XYZ> "; ind++;
                            telemetryVals[ind] = "<" + Math.Round(telemetryData.localAngularVel[0], 3) + ", "
                                                    + Math.Round(telemetryData.localAngularVel[1], 3) + ", "
                                                    + Math.Round(telemetryData.localAngularVel[2], 3) + ">"; ind++;
                            telemetryVals[ind] = "FinalFF: " + Math.Round(telemetryData.finalFF, 3); ind++;
                            telemetryVals[ind] = "BrakeTemp [F L/R]: " + Truncate(telemetryData.brakeTemp[0].ToString(), 5) + " / " + Truncate(telemetryData.brakeTemp[1].ToString(), 5); ind++;
                            telemetryVals[ind] = "BrakeTemp [R L/R]: " + Truncate(telemetryData.brakeTemp[2].ToString(), 5) + " / " + Truncate(telemetryData.brakeTemp[3].ToString(), 5); ind++;
                            telemetryVals[ind] = "Clutch: " + Math.Round(telemetryData.clutch, 3); ind++;
                            telemetryVals[ind] = "Is AI On: " + telemetryData.isAIcontrolled; ind++;
                            telemetryVals[ind] = "Tire Contact Point (XYZ)"; ind++;
                            telemetryVals[ind] = "[FL]: (" + Math.Round(telemetryData.tirecontactfl[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirecontactfl[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirecontactfl[2], 2).ToString("F2") + ")"; ind++;
                            telemetryVals[ind] = "[FR]: (" + Math.Round(telemetryData.tirecontactfr[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirecontactfr[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirecontactfr[2], 2).ToString("F2") + ")"; ind++;
                            telemetryVals[ind] = "[RL]: (" + Math.Round(telemetryData.tirecontactrl[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirecontactrl[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirecontactrl[2], 2).ToString("F2") + ")"; ind++;
                            telemetryVals[ind] = "[RR]: (" + Math.Round(telemetryData.tirecontactrr[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirecontactrr[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirecontactrr[2], 2).ToString("F2") + ")"; ind++;
                            telemetryVals[ind] = "Tire Contact Norm (XYZ)"; ind++;
                            telemetryVals[ind] = "[FL]: (" + Math.Round(telemetryData.tirenormfl[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirenormfl[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirenormfl[2], 2).ToString("F2") + ")"; ind++;
                            telemetryVals[ind] = "[FR]: (" + Math.Round(telemetryData.tirenormfr[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirenormfr[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirenormfr[2], 2).ToString("F2") + ")"; ind++;
                            telemetryVals[ind] = "[RL]: (" + Math.Round(telemetryData.tirenormrl[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirenormrl[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirenormrl[2], 2).ToString("F2") + ")"; ind++;
                            telemetryVals[ind] = "[RR]: (" + Math.Round(telemetryData.tirenormrr[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirenormrr[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tirenormrr[2], 2).ToString("F2") + ")"; ind++;
                            telemetryVals[ind] = "Tire Contact Heading (XYZ)"; ind++;
                            telemetryVals[ind] = "[FL]: (" + Math.Round(telemetryData.tireheadfl[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tireheadfl[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tireheadfl[2], 2).ToString("F2") + ")"; ind++;
                            telemetryVals[ind] = "[FR]: (" + Math.Round(telemetryData.tireheadfr[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tireheadfr[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tireheadfr[2], 2).ToString("F2") + ")"; ind++;
                            telemetryVals[ind] = "[RL]: (" + Math.Round(telemetryData.tireheadrl[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tireheadrl[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tireheadrl[2], 2).ToString("F2") + ")"; ind++;
                            telemetryVals[ind] = "[RR]: (" + Math.Round(telemetryData.tireheadrr[0], 2).ToString("F2") + ", " + Math.Round(telemetryData.tireheadrr[1], 2).ToString("F2") + ", " + Math.Round(telemetryData.tireheadrr[2], 2).ToString("F2") + ")"; ind++;
                            telemetryVals[ind] = "Brake Bias: " + Math.Round(telemetryData.brakeBias, 4); ind++;
                            telemetryVals[ind] = "Local Velocity <XYZ>"; ind++;
                            telemetryVals[ind] = "<" + Math.Round(telemetryData.localVelocity[0], 5).ToString("F3") + ", "
                            + Math.Round(telemetryData.localVelocity[1], 5).ToString("F3") + ", "
                            + Math.Round(telemetryData.localVelocity[2], 5).ToString("F3") + ">"; ind++;
                            telemetryVals[ind] = "Slip Ratio"; ind++;
                            telemetryVals[ind] = "[F L/R]: " + Math.Round(telemetryData.slipRatio[0], 2).ToString("F2") + " / " + Math.Round(telemetryData.slipRatio[1], 2).ToString("F2"); ind++;
                            telemetryVals[ind] = "[R L/R]: " + Math.Round(telemetryData.slipRatio[2], 2).ToString("F2") + " / " + Math.Round(telemetryData.slipRatio[3], 2).ToString("F2"); ind++;
                            telemetryVals[ind] = "Slip Angle"; ind++;
                            telemetryVals[ind] = "[F L/R]: " + Math.Round(telemetryData.slipAngle[0], 2).ToString("F2") + " / " + Math.Round(telemetryData.slipAngle[1], 2).ToString("F2"); ind++;
                            telemetryVals[ind] = "[R L/R]: " + Math.Round(telemetryData.slipAngle[2], 2).ToString("F2") + " / " + Math.Round(telemetryData.slipAngle[3], 2).ToString("F2"); ind++;
                            telemetryVals[ind] = "Water Temp: " + Math.Round(telemetryData.waterTemp, 2); ind++;
                            telemetryVals[ind] = "Brake Pressure"; ind++;
                            telemetryVals[ind] = "[F L/R]: " + Math.Round(telemetryData.brakePressure[0], 2).ToString("F2") + " / " + Math.Round(telemetryData.brakePressure[1], 2).ToString("F2"); ind++;
                            telemetryVals[ind] = "[R L/R]: " + Math.Round(telemetryData.brakePressure[2], 2).ToString("F2") + " / " + Math.Round(telemetryData.brakePressure[3], 2).ToString("F2"); ind++;
                            telemetryVals[ind] = "Front Brake Cpd: " + telemetryData.frontBrakeCompound; ind++;
                            telemetryVals[ind] = "Rear Brake Cmpd: " + telemetryData.rearBrakeCompound; ind++;
                            telemetryVals[ind] = "Pad Life"; ind++;
                            telemetryVals[ind] = "[F L/R]: " + Math.Round(telemetryData.padLife[0], 2).ToString("F2") + " / " + Math.Round(telemetryData.padLife[1], 2).ToString("F2"); ind++;
                            telemetryVals[ind] = "[R L/R]: " + Math.Round(telemetryData.padLife[2], 2).ToString("F2") + " / " + Math.Round(telemetryData.padLife[3], 2).ToString("F2"); ind++;
                            telemetryVals[ind] = "Disc Life"; ind++;
                            telemetryVals[ind] = "[F L/R]: " + Math.Round(telemetryData.discLife[0], 2).ToString("F2") + " / " + Math.Round(telemetryData.discLife[1], 2).ToString("F2"); ind++;
                            telemetryVals[ind] = "[R L/R]: " + Math.Round(telemetryData.discLife[2], 2).ToString("F2") + " / " + Math.Round(telemetryData.discLife[3], 2).ToString("F2"); ind++;
                            telemetryVals[ind] = "Ignition Status: " + telemetryData.ignitionOn; ind++;
                            telemetryVals[ind] = "Stater Status: " + telemetryData.starterEngineOn; ind++;
                            telemetryVals[ind] = "Engine Running: " + telemetryData.isEngineRunning; ind++;
                            telemetryVals[ind] = "Curb Vib: " + Math.Round(telemetryData.kerbVibration, 3); ind++;
                            telemetryVals[ind] = "Slip Vib: " + Math.Round(telemetryData.slipVibrations, 3); ind++;
                            telemetryVals[ind] = "G Vib: " + Math.Round(telemetryData.gVibrations, 3); ind++;
                            telemetryVals[ind] = "ABS Vib: " + Math.Round(telemetryData.absVibrations, 3);
                        }
                        // SPAGEFILEGRAPHIC DATA DISPLAY
                        if (filename == "acpmf_graphics")
                        {
                            // Define data structure, allocate byte array, read data, and convert array to obj
                            int dataSize = Marshal.SizeOf(typeof(GraphicTelemetry));
                            byte[] data = new byte[dataSize];
                            accessor.ReadArray(0, data, 0, dataSize);
                            GraphicTelemetry telemetryData = ByteArrayToStructure<GraphicTelemetry>(data);

                            // Preps the time wchars for printing. They're... not pretty.
                            string currentTimeStr = Regex.Replace(new string(telemetryData.currentTime), @"[^0-9:\-.]", "");
                            string lastTimeStr = Regex.Replace(new string(telemetryData.lastTime), @"[^0-9:\-.]", "");
                            string bestTimeStr = Regex.Replace(new string(telemetryData.bestTime), @"[^0-9:\-.]", "");
                            string splitTimeStr = Regex.Replace(new string(telemetryData.split), @"[^0-9:\-.]", "");
                            string deltaLapTimeStr = Regex.Replace(new string(telemetryData.deltaLapTime), @"[^0-9:\-.]", "");
                            string estLapTimeStr = Regex.Replace(new string(telemetryData.estimatedLapTime), @"[^0-9:\-.]", "");
                            string tireCompoundStr = Regex.Replace(new string(telemetryData.tyreCompound), @"[^A-Za-z_]", "");
                            string trackStatusStr = Regex.Replace(new string(telemetryData.trackStatus), @"[^A-Za-z_]", "");
                            // Overflow, placeholder and MOE correction
                            if (telemetryData.iLastTime >= (2^31 - 1)) // Uses 32-bit overflow minus one
                            {
                                telemetryData.iLastTime = 0;
                                lastTimeStr = "-:--:---";
                            }
                            if (telemetryData.iBestTime >= (2^31 - 1))
                            {
                                telemetryData.iLastTime = 0;
                                bestTimeStr = "-:--:---";
                            }
                            if (telemetryData.iEstimatedLapTime >= (2^31 - 1))
                            {
                                telemetryData.iEstimatedLapTime = 0;
                                estLapTimeStr = "-:--:---";
                            }
                            if (telemetryData.driverStintTimeLeft <= -100)
                            {
                                telemetryData.driverStintTimeLeft = 0;
                                telemetryData.driverStintTotalTimeLeft = 0;
                            }

                            int ind = 0;

                            telemetryVals[ind] = "PID: " + telemetryData.packetID; ind++;
                            telemetryVals[ind] = "Session Status: " + telemetryData.status; ind++;
                            telemetryVals[ind] = "Session Type: " + telemetryData.session; ind++;
                            telemetryVals[ind] = "Lap Info (MM:SS:ms)"; ind++;
                            telemetryVals[ind] = "[C]: " + currentTimeStr; ind++;
                            telemetryVals[ind] = "[L]: " + lastTimeStr; ind++;
                            telemetryVals[ind] = "[B]: " + bestTimeStr; ind++;
                            telemetryVals[ind] = "[S]: " + splitTimeStr; ind++;
                            telemetryVals[ind] = "Laps Completed: " + telemetryData.completedLaps; ind++;
                            telemetryVals[ind] = "Position: " + telemetryData.position; ind++;
                            telemetryVals[ind] = "Lap Info"; ind++;
                            telemetryVals[ind] = "[C]: " + ((float)telemetryData.iCurrentTime / 1000) + "s"; ind++;
                            telemetryVals[ind] = "[L]: " + ((float)telemetryData.iLastTime / 1000) + "s"; ind++;
                            telemetryVals[ind] = "[B]: " + ((float)telemetryData.iBestTime / 1000) + "s"; ind++;
                            telemetryVals[ind] = "Session Time Left: " + telemetryData.sessionTimeLeft; ind++;
                            telemetryVals[ind] = "Dist. Trav: " + telemetryData.distanceTraveled; ind++;
                            telemetryVals[ind] = "In Pit: " + telemetryData.isInPit; ind++;
                            telemetryVals[ind] = "Sector Ind: " + telemetryData.currentSectorIndex; ind++;
                            telemetryVals[ind] = "Last: " + ((float)telemetryData.lastSectorTime / 1000) + "s"; ind++;
                            telemetryVals[ind] = "[Tire Compound]:"; ind++;
                            telemetryVals[ind] = tireCompoundStr; ind++;
                            
                            int ind_old = ind;
                            telemetryVals[ind] = "Car Coordinates (XYZ)"; ind++;
                            foreach (CarNo car in telemetryData.carno)
                            {
                                if (car.posx != 0)
                                {
                                    telemetryVals[ind] = "[" + (ind - ind_old) + "]: ("
                                        + Math.Round(car.posx, 2).ToString() + ", "
                                        + Math.Round(car.posy, 2).ToString() + ", " 
                                        + Math.Round(car.posz, 2).ToString() + ")";
                                    ind++;
                                }
                            }

                            ind_old = ind;
                            telemetryVals[ind] = "AllCarIDs"; ind++;
                            foreach (int car in telemetryData.carID)
                            {
                                if (car != 0)
                                {
                                    telemetryVals[ind] = "[" + (ind - ind_old).ToString() + "]: " + car.ToString();
                                    ind++;
                                }
                            }

                            telemetryVals[ind] = "Player CarID: " + telemetryData.playerCarID; ind++;
                            telemetryVals[ind] = "Penalty: " + telemetryData.penaltyTime; ind++;
                            telemetryVals[ind] = "Flag: " + telemetryData.flag; ind++;
                            telemetryVals[ind] = "PenType: " + telemetryData.penalty; ind++;
                            telemetryVals[ind] = "Ideal Line: " + telemetryData.idealLineOn; ind++;
                            telemetryVals[ind] = "In PitLane: " + telemetryData.isInPitLate; ind++;
                            telemetryVals[ind] = "Fric C @Line: " + telemetryData.surfaceGrip; ind++;
                            telemetryVals[ind] = "Mandatory Pit Done: " + telemetryData.mandatoryPitDone; ind++;
                            telemetryVals[ind] = "Windspeed: " + telemetryData.windSpeed; ind++;
                            telemetryVals[ind] = "Wind Dir: " + telemetryData.windDirection; ind++;
                            telemetryVals[ind] = "Is Setup Vis: " + telemetryData.isSetupMenuVisible; ind++;
                            telemetryVals[ind] = "MainDisp Ind: " + telemetryData.mainDisplayIndex; ind++;
                            telemetryVals[ind] = "SecdDisp Ind: " + telemetryData.secondaryDisplayIndex; ind++;
                            telemetryVals[ind] = "TC Level: " + telemetryData.TC; ind++;
                            telemetryVals[ind] = "TC Cut Lev:" + telemetryData.TCCUT; ind++;
                            telemetryVals[ind] = "EngineMap: " + telemetryData.EngineMap; ind++;
                            telemetryVals[ind] = "ABS Level: " + telemetryData.ABS; ind++;
                            telemetryVals[ind] = "Fuel/Lap: " + telemetryData.fuelXLap; ind++;
                            telemetryVals[ind] = "Rainlights: " + telemetryData.rainLights; ind++;
                            telemetryVals[ind] = "FlashingLights: " + telemetryData.flashingLights; ind++;
                            telemetryVals[ind] = "LightStage: " + telemetryData.lightsStage; ind++;
                            telemetryVals[ind] = "Exhaust Temp: " + telemetryData.exhaustTemperature; ind++;
                            telemetryVals[ind] = "Wiper Stage: " + telemetryData.wiperLV; ind++;
                            telemetryVals[ind] = "Stint Time Left"; ind++;
                            telemetryVals[ind] = "[Totl]: " + telemetryData.driverStintTimeLeft.ToString("F2"); ind++;
                            telemetryVals[ind] = "[Stnt]: " + telemetryData.driverStintTotalTimeLeft.ToString("F2"); ind++;
                            telemetryVals[ind] = "Raintires On: " + telemetryData.rainTyres; ind++;
                            telemetryVals[ind] = "Session Ind: " + telemetryData.sessionIndex; ind++;
                            telemetryVals[ind] = "Fuel Used: " + telemetryData.usedFuel; ind++;
                            telemetryVals[ind] = "Lap Info"; ind++;
                            telemetryVals[ind] = "Delta: " + deltaLapTimeStr; ind++;
                            telemetryVals[ind] = "Est  : " + estLapTimeStr; ind++;
                            telemetryVals[ind] = "Delta(ms): " + telemetryData.iDeltaLapTime; ind++;
                            telemetryVals[ind] = "Est(ms)  : " + telemetryData.iEstimatedLapTime; ind++;
                            telemetryVals[ind] = "Delta Positive: " + telemetryData.isDeltaPositive; ind++;
                            telemetryVals[ind] = "Split (ms): " + telemetryData.iSplit; ind++;
                            telemetryVals[ind] = "Is Lap Valid: " + telemetryData.isValidLap; ind++;
                            telemetryVals[ind] = "Est Fuel Left (Laps)"; ind++;
                            telemetryVals[ind] = telemetryData.fuelEstimatedLaps.ToString(); ind++;
                            telemetryVals[ind] = "Track Status: "; ind++;
                            telemetryVals[ind] = trackStatusStr; ind++;
                            telemetryVals[ind] = "Missing Pit: " + telemetryData.missingMandatoryPits; ind++;
                            telemetryVals[ind] = "Time of Day (s)"; ind++;
                            telemetryVals[ind] = telemetryData.Clock.ToString(); ind++;
                            telemetryVals[ind] = "Left Blinker: " + telemetryData.directionLightsLeft; ind++;
                            telemetryVals[ind] = "Right Blinker: " + telemetryData.directionLightsRight; ind++;
                            telemetryVals[ind] = "Global Yellow : " + telemetryData.GlobalYellow; ind++;
                            telemetryVals[ind] = "Global Yellow1: " + telemetryData.GlobalYellow1; ind++;
                            telemetryVals[ind] = "Global Yellow2: " + telemetryData.GlobalYellow2; ind++;
                            telemetryVals[ind] = "Global Yellow3: " + telemetryData.GlobalYellow3; ind++;
                            telemetryVals[ind] = "Global White  : " + telemetryData.GlobalWhite; ind++;
                            telemetryVals[ind] = "Global Green  : " + telemetryData.GlobalGreen; ind++;
                            telemetryVals[ind] = "Global Checkrd: " + telemetryData.GlobalChequered; ind++;
                            telemetryVals[ind] = "Global Red    : " + telemetryData.GlobalRed; ind++;
                            telemetryVals[ind] = "MFD Tireset: " + telemetryData.mfdTyreSet; ind++;
                            telemetryVals[ind] = "MFD FuelToAdd: " + telemetryData.mfdFueltoAdd; ind++;
                            telemetryVals[ind] = "MFD Tire Pressure"; ind++;
                            telemetryVals[ind] = "[F L/R]: " + Math.Round(telemetryData.mfdTyrePressureLF, 1).ToString("F1") + " / " + Math.Round(telemetryData.mfdTyrePressureRF, 1).ToString("F1"); ind++;
                            telemetryVals[ind] = "[R L/R]: " + Math.Round(telemetryData.mfdTyrePressureLR, 1).ToString("F1") + " / " + Math.Round(telemetryData.mfdTyrePressureRR, 1).ToString("F1"); ind++;
                            telemetryVals[ind] = "TrackGrip: " + telemetryData.trackGripStatus; ind++;
                            telemetryVals[ind] = "Rain Now  : " + telemetryData.rainIntensity; ind++;
                            telemetryVals[ind] = "Rain In 10: " + telemetryData.rainIntensityIn10min; ind++;
                            telemetryVals[ind] = "Rain In 30: " + telemetryData.rainIntensityIn30min; ind++;
                            telemetryVals[ind] = "Current Tireset: " + telemetryData.currentTyreSet; ind++;
                            telemetryVals[ind] = "Strat Tireset: " + telemetryData.strategyTyreSet; ind++;
                            telemetryVals[ind] = "Gap Times (ms)"; ind++;
                            telemetryVals[ind] = "[AHead]: " + telemetryData.gapAhead; ind++;
                            telemetryVals[ind] = "[BHind]: " + telemetryData.gapBehind; ind++;
                        }
                        //  SPAGEFILESTATIC DATA DISPLAY
                        if (filename == "acpmf_static")
                        {
                            int dataSize = Marshal.SizeOf(typeof(StaticTelemetry));
                            byte[] data = new byte[dataSize];
                            accessor.ReadArray(0, data, 0, dataSize);
                            StaticTelemetry telemetryData = ByteArrayToStructure<StaticTelemetry>(data);

                            string smVersionStr = Regex.Replace(new string(telemetryData.smVersion), @"[^0-9:\-.]", "");
                            string acVersionStr = Regex.Replace(new string(telemetryData.acVersion), @"[^0-9:\-.]", "");
                            string carModelStr = Regex.Replace(new string(telemetryData.carModel), @"[^A-Za-z0-9_]", "");
                            string trackNameStr = Regex.Replace(new string(telemetryData.track), @"[^A-Za-z0-9_]", "");
                            string playerNameStr = Regex.Replace(new string(telemetryData.playerName), @"[^A-Za-z0-9_]", "");
                            string playerSurnameStr = Regex.Replace(new string(telemetryData.playerSurname), @"[^A-Za-z0-9_]", "");
                            string playerNickStr = Regex.Replace(new string(telemetryData.playerNick), @"[^A-Za-z0-9_]", "");
                            string dryTirenameStr = Regex.Replace(new string(telemetryData.dryTyresName), @"[^A-Za-z0-9_]", "");
                            string wetTirenameStr = Regex.Replace(new string(telemetryData.wetTyresName), @"[^A-Za-z0-9_]", "");



                            int ind = 0;
                            telemetryVals[ind] = "SMemVersion: " + smVersionStr; ind++;
                            telemetryVals[ind] = "ACCVersion: " + acVersionStr; ind++;
                            telemetryVals[ind] = "Session Count: " + telemetryData.numberOfSessions; ind++;
                            telemetryVals[ind] = "Car count: " + telemetryData.numCars; ind++;
                            telemetryVals[ind] = "Car model: " + carModelStr; ind++;
                            telemetryVals[ind] = "Track: " + trackNameStr; ind++;
                            telemetryVals[ind] = "Name: " + playerNameStr; ind++;
                            telemetryVals[ind] = "Surname: " + playerSurnameStr; ind++;
                            telemetryVals[ind] = "Nickname: " + playerNickStr; ind++;
                            telemetryVals[ind] = "Sector count: " + telemetryData.sectorCount; ind++;
                            telemetryVals[ind] = "Max RPM: " + telemetryData.maxRPM; ind++;
                            telemetryVals[ind] = "Max Fuel: " + telemetryData.maxFuel; ind++;
                            telemetryVals[ind] = "Penalties on: " + telemetryData.penaltiesEnabled; ind++;
                            telemetryVals[ind] = "Fuel BurnRate: " + telemetryData.aidFuelRate; ind++;
                            telemetryVals[ind] = "Tire WearRate: " + telemetryData.aidTireRate; ind++;
                            telemetryVals[ind] = "Damage Rate  : " + telemetryData.aidMechanicalDamage; ind++;
                            telemetryVals[ind] = "Tire Blankets Allowed: " + telemetryData.AllowTyreBlankets; ind++;
                            telemetryVals[ind] = "Stability Aid: " + telemetryData.aidStability; ind++;
                            telemetryVals[ind] = "Autoclutch Aid: " + telemetryData.aidAutoclutch; ind++;
                            telemetryVals[ind] = "Autoblip (Always True): " + telemetryData.aidAutoBlip; ind++;
                            telemetryVals[ind] = "Pit Window Open : " + telemetryData.PitWindowStart; ind++;
                            telemetryVals[ind] = "Pit Window Close: " + telemetryData.PitWindowEnd; ind++;
                            telemetryVals[ind] = "Tirename (Dry)"; ind++;
                            telemetryVals[ind] = dryTirenameStr; ind++;
                            telemetryVals[ind] = "Tirename (Wet)"; ind++;
                            telemetryVals[ind] = wetTirenameStr;
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                System.Console.WriteLine("Memory-mapped file not found.");
                telemetryVals[0] = "Waiting for telemetry input.\r\nPlease begin a session.";
            }
            catch (Exception ex)
            {
                telemetryVals[0] = "Error interpreting data.\r\n" + ex;
            }
            return telemetryVals;
        }

        private string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public string ClockFilter(char[] input)
        {
            StringBuilder filtered = new StringBuilder();
            foreach (char c in input)
            {
                // Check if the character is a digit or a colon
                if (char.IsDigit(c) || c == ':')
                {
                    filtered.Append(c);
                }
            }
            return filtered.ToString();
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
    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
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
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public float[] accG; // Acceleration
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] wheelSlip; // Wheelslip
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] ignoredValues1; // Skipped fields
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] wheelPressure; // Tire pressure
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] wheelAngularSpeed; // Tire angular speed
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] public float[] ignoredValues2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] TyreCoreTemp; // Core Tire temps
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] ignoredValues3;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] suspensionTravel; // Suspension Travel
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] public float[] ignoredValues4;
        public float tc;
        public float heading;
        public float pitch;
        public float roll;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] public float[] ignoredValues5;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)] public float[] carDamage;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] public float[] ignoredValues6;
        public int pitLimiterOn;
        public float abs;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public float[] ignoredValues7;
        public int autoshifterOn;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public float[] ignoredValues8;
        public float turboBoost;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public float[] ignoredValues9;
        public float airTemp;
        public float roadTemp;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public float[] localAngularVel;
        public float finalFF;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)] public float[] ignoredValues10;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] brakeTemp;
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
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public float[] localVelocity;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)] public float[] ignoredValues12;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] slipRatio;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] slipAngle;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)] public float[] ignoredValues13;
        public float waterTemp;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] brakePressure;
        public int frontBrakeCompound;
        public int rearBrakeCompound;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] padLife;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public float[] discLife;
        public int ignitionOn;
        public int starterEngineOn;
        public int isEngineRunning;
        public float kerbVibration; // Curb Vibration FFB
        public float slipVibrations; // Slip Vibration FFB
        public float gVibrations; // G Force Vibration FFB
        public float absVibrations; // Brake ABS Vibration FFB

        // End of the SPagePhysicsFile variables

    }

    public enum ACC_STATUS
    {
        ACC_OFF = 0,
        ACC_REPLAY = 1,
        ACC_LIVE = 2,
        ACC_PAUSE = 3
    }
    public enum ACC_SESSION_TYPE
    {
        ACC_UNKNOWN = -1,
        ACC_PRACTICE = 0,
        ACC_QUALIFY = 1,
        ACC_RACE = 2,
        ACC_HOTLAP = 3,
        ACC_TIMEATTACK = 4,
        ACC_DRIFT = 5,
        ACC_DRAG = 6,
        ACC_HOTSTINT = 7,
        ACC_HOTSTINTSUPERPOLE = 8
    }
    public enum ACC_FLAG_TYPE
    {
        ACC_NO_FLAG = 0,
        ACC_BLUE_FLAG = 1,
        ACC_YELLOW_FLAG = 2,
        ACC_BLACK_FLAG = 3,
        ACC_WHITE_FLAG = 4,
        ACC_CHECKERED_FLAG = 5,
        ACC_PENALTY_FLAG = 6,
        ACC_GREEN_FLAG = 7,
        ACC_ORANGE_FLAG = 8
    }
    public enum ACC_PEN_TYPE
    {
        ACC_None = 0,
        ACC_DriveThrough_Cutting = 1,
        ACC_StopAndGo_10_Cutting = 2,
        ACC_StopAndGo_20_Cutting = 3,
        ACC_StopAndGo_30_Cutting = 4,
        ACC_Disqualified_Cutting = 5,
        ACC_RemoveBestLaptime_Cutting = 6,
        ACC_DriveThrough_PitSpeeding = 7,
        ACC_StopAndGo_10_PitSpeeding = 8,
        ACC_StopAndGo_20_PitSpeeding = 9,
        ACC_StopAndGo_30_PitSpeeding = 10,
        ACC_Disqualified_PitSpeeding = 11,
        ACC_RemoveBestLaptime_PitSpeeding = 12,
        ACC_Disqualified_IgnoredMandatoryPit = 13,
        ACC_PostRaceTime = 14,
        ACC_Disqualified_Trolling = 15,
        ACC_Disqualified_PitEntry = 16,
        ACC_Disqualified_PitExit = 17,
        ACC_Disqualified_Wrongway = 18,
        ACC_DriveThrough_IgnoredDriverStint = 19,
        ACC_Disqualified_IgnoredDriverStint = 20,
        ACC_Disqualified_ExceededDriverStintLimit = 21
    }
    public enum ACC_TRACK_GRIP_STATUS
    {
        ACC_GREEN = 0,
        ACC_FAST = 1,
        ACC_OPTIMUM = 2,
        ACC_GREASY = 3,
        ACC_DAMP = 4,
        ACC_WET = 5,
        ACC_FLOODED = 6
    }
    public enum ACC_RAIN_INT
    {
        ACC_NO_RAIN = 0,
        ACC_DRIZZLE = 1,
        ACC_LIGHT_RAIN = 2,
        ACC_MEDIUM_RAIN = 3,
        ACC_HEAVY_RAIN = 4,
        ACC_THUNDERSTORM = 5
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
    public struct GraphicTelemetry
    {
        public int packetID;
        public ACC_STATUS status;
        public ACC_SESSION_TYPE session;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)] public char[] currentTime; // used to init wchar_t vars
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)] public char[] lastTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)] public char[] bestTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)] public char[] split;
        public int completedLaps;
        public int position;
        public int iCurrentTime;
        public int iLastTime;
        public int iBestTime;
        public float sessionTimeLeft;
        public float distanceTraveled;
        public int isInPit;
        public int currentSectorIndex;
        public int lastSectorTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] public float[] ignoredValues1; // inactive even through green.
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)] public char[] tyreCompound;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)] public float[] ignoredValues2;
        public float normalizedCarPosition;
        public int activeCars;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)] public CarNo[] carno;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)] public int[] carID;
        public int playerCarID;
        public float penaltyTime;
        public ACC_FLAG_TYPE flag;
        public ACC_PEN_TYPE penalty;
        public int idealLineOn;
        public int isInPitLate;
        public float surfaceGrip;
        public int mandatoryPitDone;
        public float windSpeed;
        public float windDirection;
        public int isSetupMenuVisible;
        public int mainDisplayIndex;
        public int secondaryDisplayIndex;
        public int TC;
        public int TCCUT;
        public int EngineMap;
        public int ABS;
        public float fuelXLap;
        public int rainLights;
        public int flashingLights;
        public int lightsStage;
        public float exhaustTemperature;
        public int wiperLV;
        public int driverStintTotalTimeLeft;
        public int driverStintTimeLeft;
        public int rainTyres;
        public int sessionIndex;
        public float usedFuel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)] public char[] deltaLapTime;
        public int iDeltaLapTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)] public char[] estimatedLapTime;
        public int iEstimatedLapTime;
        public int isDeltaPositive;
        public int iSplit;
        public int isValidLap;
        public float fuelEstimatedLaps;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)] public char[] trackStatus;
        public int missingMandatoryPits;
        public float Clock;
        public int directionLightsLeft;
        public int directionLightsRight;
        public int GlobalYellow;
        public int GlobalYellow1;
        public int GlobalYellow2;
        public int GlobalYellow3;
        public int GlobalWhite;
        public int GlobalGreen;
        public int GlobalChequered;
        public int GlobalRed;
        public int mfdTyreSet;
        public float mfdFueltoAdd;
        public float mfdTyrePressureLF;
        public float mfdTyrePressureRF;
        public float mfdTyrePressureLR;
        public float mfdTyrePressureRR;
        public ACC_TRACK_GRIP_STATUS trackGripStatus;
        public ACC_RAIN_INT rainIntensity;
        public ACC_RAIN_INT rainIntensityIn10min;
        public ACC_RAIN_INT rainIntensityIn30min;
        public int currentTyreSet;
        public int strategyTyreSet;
        public int gapAhead;
        public int gapBehind;
    }
    public struct CarNo
    {
        public float posx;
        public float posy;
        public float posz;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
    public struct StaticTelemetry
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)] public char[] smVersion;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)] public char[] acVersion;
        public int numberOfSessions;
        public int numCars;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)] public char[] carModel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)] public char[] track;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)] public char[] playerName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)] public char[] playerSurname;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)] public char[] playerNick;
        public int sectorCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public float[] ignoredValues1;
        public int maxRPM;
        public float maxFuel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)] public float[] ignoredValues2;
        public int penaltiesEnabled;
        public float aidFuelRate;
        public float aidTireRate;
        public float aidMechanicalDamage;
        public float AllowTyreBlankets;
        public float aidStability;
        public int aidAutoclutch;
        public int aidAutoBlip;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 45)] public float[] ignoredValues3;
        public int PitWindowStart;
        public int PitWindowEnd;
        public int isOnline;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)] public char[] dryTyresName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)] public char[] wetTyresName;
    }
}
