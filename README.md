# ACCTele 1.3.3.1 (Alpha)
### An open-source realtime telemetry project designed for Assetto Corsa Competizione
#### Created by Rylan Markwardt


ACCTele is designed to pull the shared memory from Assetto Corsa Competizione (ACC).

The program is currently a lightweight executable with plans to develop into a fully-fledged telemetry application with the following:

 - save functionality
 - modular interface
 - clear representation of data

If you have any recommendations, please add them to the GitHub repo... however that works. I'm new to GitHub. But I'll find it!

In the interest of ensuring future development of this project, necessary documentation like ACCSharedMemoryDocumentation.pdf will be provided as part of the source code so anyone can easily iterate on the project.

To change what telemetry is present in the main application console, open memory_reader.cs
and complete the following:

	Inside public struct TelemetryData, define a new public var with the datatype of the value 
	you are adding (can be found in ACCSharedMemoryDocumentation.pdf). Be sure to define your 
	variable in the position it would appear in the memory structure - for example, fuel is in
	position 4, so if you only want fuel, you need to omit the first three entries (see 
	memory_reader.cs for an example of how this is executed).

	Inside public string[] ReadFromSharedMemory(), set your array size according to your struct.
	Then find the TELEMETRY DATA DISPLAY comment to see where you add your strings. A Truncate()
	function has been provided to remove some ~unnecessary~ precision from the values.
	
	Pretty sure radar guns don't tell you that you were going 214.2984372645 Km/H.


### Supported Telemetry Parameters (v1.3.3.1)
	- Packet ID
	- Gas
	- Brake
	- Fuel
	- Gear
	- RPM
	- Steering Angle
	- Speed (KmH)
	- Velocity (x,y,z) m/s
	- Acceleration (x,y,z) G's
	- Wheelslip
	- Wheel Angular Speed
	- Tire Temps
	- Suspension Travel
	- Traction Control
	- Heading
	- Pitch
	- Roll

Several parameters are planned for addition in the future.
