# ACCTele 1.4.1.1 (Alpha)
### An open-source realtime telemetry project designed for Assetto Corsa Competizione
#### Created by Rylan Markwardt


ACCTele is designed to pull the shared memory from Assetto Corsa Competizione (ACC).

The program is currently a lightweight executable with plans to develop into a fully-fledged telemetry application.

The following are planned features:
 - save functionality
 - modular interface
 - clear representation of data

I recognize that right now it's really just a console that prints some memory out with some fancy coatings and expensive cherries... but the user experience is 95% of your retention. If it doesnt ~feel~ right, it will never ~be~ right.

If you have any recommendations, please add them to the GitHub repo... however that works. I'm new to GitHub. But I'll find it!

In the interest of ensuring future development of this project, necessary documentation like ACCSharedMemoryDocumentation.pdf will be provided as part of the source code so anyone can easily iterate on the project.

To change what telemetry is present in the main application console, open memory_reader.cs
and complete the following:

	You should now be able to simply comment out the lines of telemetry you don't want.
	I have not tested this yet though. Eventually a GUI element will be added to console for selecting
	displayed values.

	
### Supported Telemetry Parameters (v1.4.1.1)
See included PDF titled ACCSharedMemoryDocumentation(version).pdf for comprehensive list and explanation of variables.

	SPageFilePhysics
	- packetID
	- gas
	- brake
	- fuel
	- gear
	- rpm
	- steerAngle
	- speedKmh
	- velocity[3]
	- accG[3]
	- wheelSlip[4]
	- wheelPressure[4]
	- wheelAngularSpeed[4]
	- TyreCoreTemp[4]
	- suspensionTravel[4]
	- tc, tcon
	- heading
	- pitch
	- roll
	- carDamage[5]
	- pitLimiterOn, pitlimit
	- abs, absOn
	- autoshifterOn
	- turboBoost
	- airTemp
	- roadTemp
	- localAngularVel[3]
	- finalFF
	- brakeTemp[4]
	- clutch
	- isAIControlled
	- tyreContactPoint[4][3] (Separated into four arrays, will be changed to double struct)
	- tyreContactNormal[4][3] (Same as above)
	- tyreContactHeading[4][3] (Same as above)
	- brakeBias
	- localVelocity[3]
	- spipRatio[4]
	- slipAngle[4]
	- waterTemp
	- brakePressure[4]
	- frontBrakeCompound
	- rearBrakeCompound
	- padLife[4]
	- discLife[4]
	- ignitionOn
	- starterEngienOn
	- isEngineRunning
	- kerbVibration
	- slipVibrations
	- gVibrations
	- absVibrations

	SPageFileGraphic
	- packetID
	- status
	- session
	- currentTime[15]
	- lastTime[15]
	- bestTime[15]
	- split[15]
	- completedLaps
	- position
	- iCurrentTime
	- iLastTime
	- iBestTime
	- sessionTimeLeft
	- distanceTraveled
	- isInPit
	- currentSectorIndex
	- lastSectorTime
	- tyreCompound[33]
	- normalizedCarPosition
	- activeCars
	- carCoordinates[60][3] (Initialzied as struct array, CarNo[] with posx, posy, posz)
	- carID[60]
	- playerCarID
	- penaltyTime
	- flag
	- penalty
	- idealLineOn
	- isInPitLane
	- surfaceGrip
	- mandatoryPitDone
	- windSpeed
	- windDirection
	- isSetupMenuVisible
	- mainDisplayIndex
	- secondaryDisplayIndex ("Disply" on documentation, assumed erroneous and corrected.)
	- TC
	- TCCUT
	- EngineMap
	- ABS
	- fuelXLap
	- rainLights
	- flashingLights
	- lightsStage
	- exhaustTemperature
	- wiperLV
	- driverStintTotalTimeLeft
	- driverStintTimeLeft
	- rainTyres
	- sessionIndex
	- usedFuel
	- deltaLapTime[15]
	- iDeltaLapTime
	- estimatedLapTime[15]
	- iEstimatedLapTime
	- isDeltaPositive
	- iSplit
	- isValidLap
	- fuelEstimatedLaps
	- trackStatus[33]
	- missingMandatoryPits
	- Clock
	- directionLightsLeft
	- directionLightsRight
	- GlobalYellow
	- GlobalYellow1
	- GlobalYellow2
	- GlobalYellow3
	- GlobalWhite
	- GlobalGreen
	- GlobalChequered
	- GlobalRed
	- mfdTyreSet
	- mfdFuelToAdd
	- mfdTyrePressureLF
	- mfdTyrePressureRF
	- mfdTyrePressureLR
	- mfdTyrePressureRR
	- trackGripStatus
	- rainIntensity
	- rainIntensityIn10min
	- rainIntensityIn30min
	- currentTyreSet
	- strategyTyreSet
	- gapAhead
	- gapBehind

	SPageFileStatic
	- smVersion[15]
	- acVersion[15]
	- numberOfSessions
	- numCars
	- carModel[33]
	- track[33]
	- playerName[33]
	- playerSurname[33]
	- playerNick[33]
	- sectorCount
	- maxRpm
	- maxFuel
	- penaltiesEnabled
	- aidFuelRate
	- aidTireRate
	- aidMechanicalDamage
	- AllowTyreBlankets
	- aidStability
	- aidAutoclutch
	- aidAutoBlip
	- PitWindowStart
	- PitWindowEnd
	- isOnline
	- dryTyresName[33]
	- wetTyresName[33]