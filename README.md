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
	- Packet ID
	- Gas
	- Brake
	- Fuel
	- Gear
	- RPM
	- Steering Angle
	- Speed (KmH)
	- Velocity[3]
	- Acceleration[3]
	- Wheelslip[4]
	- Wheel Angular Speed[4]
	- Tire Temps[4]
	- Suspension Travel[4]
	- Traction Control
	- Heading
	- Pitch
	- Roll
	- Car damage[5]
	- Pit Limiter Status
	- ABS
	- Autoshift Status
	- Turbo Boost
	- Air Temp
	- Road Temp
	- Local Angular Velocity[3]
	- Final Force Feedback
	- Brake Temps[4]
	- Clutch
	- AI Control Status
	- Tire Contact Point[4][X,Y,Z]
	- Tire Contact Normals[4][X,Y,Z]
	- Tire Contact Heading[4][X,Y,Z]
	- Brake Bias
	- Local Velocity[3]
	- Slip Ratio[4]
	- Slip Angle[4]
	- Water Temp
	- Brake Pressure[4]
	- Front Brake Compound
	- Rear Brake Compound
	- Pad Life[4]
	- Disc Life[4]
	- Ignition Status
	- Starter Status
	- Engine Running Status
	- FFB Curb Vibration
	- FFB Slip Vibration
	- FFB G-Force Vibration
	- FFB ABS Vibration