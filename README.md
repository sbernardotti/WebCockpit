# WebCockpit

WebCockpit is a .NET Core web API wrapper for SimConnect.

---

# Requirements

.NET Core 3.1

# Usage

First run MSFS and then

```
dotnet run --project .\WebCockpit\WebCockpit.API\WebCockpit.API.csproj --urls http://<ip>:<port>
```

You can send data to the simulator:

```
GET http://<ip>:<port>/API/Write?event=<KEY_EVENT_NAME>&data=<uint>
```

Example (Set autopilot heading bug to 175deg)

```
GET http://localhost:8080/API/Write?event=KEY_HEADING_BUG_SET&data=175
```

You can see the [Complete list of events ids.](http://www.prepar3d.com/SDKv2/LearningCenter/utilities/variables/event_ids.html)

NOTE: Only a few events added. You can add more on Enums/SimEvents.cs

# Working example

webcockpit-autopilot-example(https://github.com/sbernardotti/webcockpit-autopilot-example/)

# IMPORTANT

- TODO: Read data from the simulator.
- Some events may not work on MSFS 2020.
