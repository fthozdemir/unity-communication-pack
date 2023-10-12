# TUIO, ~~Websocket~~, ~~SerialPort~~ Client for Unity

TUIO part of this package provides the functionality to use TUIO 1.1 or 2.0 in you Unity projects. It is based on [TuioUnityClient](https://github.com/InteractiveScapeGmbH/TuioUnityClient), an opensource implementation based on [TuioNet](https://github.com/InteractiveScapeGmbH/TuioNet)


### Installation instructions

Import package from repo releases to your Unity project

## TUIO Client

### Overview 

A TUIO Client package to enable the easy creation of apps and games that interface with TUIO capable hardware and software for tangible input.

### Package contents

The Editor and Runtime folders contain key scripts for the Unity editor and runtime respectively. The Samples~ folder contains a simple reference implementation for TUIO 1.1 or TUIO 2.0 that visualizes the cursors and objects as coloured squares.

### Requirements

You will require a TUIO source connected to your device or as a source you can use this excelent simulator [TUIOSimulator](https://github.com/gregharding/TUIOSimulator) by Greg Harding.

Assume this package is built to run from Unity 2020.3 upwards. Only tested in Unity 2022.3.

**Important:** By default the windows firewall blocks network communication of the Unity Editor. In order to receive UDP messages from other devices in your local network you need to allow it in the windows firewall settings.

### Dependencies
- TextMesh Pro for displaying debugging information like id, position or angle.

### Limitations

TUIO 1.1 support is currently limited to 2Dobj, 2Dcur and 2Dblb messages.</br>
**Important:** 25Dobj, 25Dcur, 25Dblb, 3Dobj, 3Dcur, 3Dblb and custom messages are all ignored.

TUIO 2.0 support is currently limited to FRM, ALV, TOK, PTR, BND and SYM messages.</br> 
**Important:** T3D, P3D, B3D, CHG, OCG, ICG, SKG, S3D, SVG, ARG, RAW, CTL, DAT, SIG, ALA, COA, LIA, LLA, LTA and custom messages are all ignored.

This package has been tested M1 mac, Windows and Displax device, but should be compatible across all platforms included linux.

## Workflows

### Working with Tags

- Create a TUIO 1.1 Manager or TUIO 2.0 Manager in your scene using GameObject > TUIO in the main Unity window or Right Click > TUIO in the Hierarchy.
- Create ```TagController```. Simple add TagController script to any game object in scene. If you want to see UI for object do not forget to include ```Canvas```, ```Canvas Scaler``` and ```Graphic Raycaster``` to where the controller is.
- Create a Tag(TUIO 1.1 Object) game object. [See the Create a Tag Section](#create-tag)
- Add your tag to the ```TagPrefabList``` in your ```Tag Controller```
- Drag and drop to any ```OnStartEvents, OnUpdateEvents, OnRemoveEvents``` to you the tag from Unity Editor or simple you can delegate desired events to your Tag(s) accessing from the TagController.
  

#### Create Tuio Manager
- Create a TUIO Manager Settings object in your Assets folder using Right Click > TUIO in the Project window. Reference the created TUIO Manager Settings asset from the TUIO 1.1 Manager or TUIO 2.0 Manager in the Hierarchy.

- Set the desired TUIO Manager Settings. 
   - Exp for Displax : Select UDP and set Websocket Adress 127.0.0.1 .Udp port -> 3333. Websocket Port -> 3333
  

#### Create a Tag
- Create a game object with ```Tag.cs``` which is also ```Tuio11ObjectBehaviour.cs``` required.
- Set the id of your tag from ```Tuio11ObjectBehaviour``` section. This is TUIO id of your tag. *You may see 0, 1, ... 6 in simulations, but in Displax it may be 202, 203, ... 303 etc.*
- Set image source, and activeness from Tag Component as you desired.
- Add *DebugText*.prefab if you wish to see position, Id, and angle in canvas. *Also do not forget to add include Canvas, Canvas Scaler and Graphic Raycaster to your Tag Controller.
- You also may add any function from a script of a game object as an event in any count for start (when tag added ), update(when object changed position or angle) or remove(when object removed from table). 
-  **It is strongly recommended that you look at the ```ExampleTagEvents.cs``` for examples**

### Working with Tuio
Create scripts that implement the Tuio11Listener or Tuio20Listener interface and subscribe them to the manager using ```Tuio11Manager.Instance.AddTuio11Listener(this)``` or ```Tuio20Manager.Instance.AddTuio20Listener(this)```. Use the
appropriate callbacks to implement your own TUIO application. Within the sample projects examples are given with the ```Tuio11Visualizer.cs``` and ```Tuio20Visualizer.cs``` which spawn simple Cursor/Pointer or Objects/Tokens. 

GameObjects which should appear as Cursors/Pointers and Objects/Tokens need an appropriate script attached to them the following are included in this package:
- ```Tuio11CursorBehaviour.cs```
- ```Tuio11ObjectBehaviour.cs```
- ```Tuio20PointerBehaviour.cs```
- ```Tuio20TokenBehaviour.cs```

### Reference

| **Field** | **Format** | **Description** |
|--|--|--|
|Tuio Connection Type | Websocket / UDP | The connection type to use
| Udp Port | 0 - 9999 | The local port to receive UDP messages on |
| Websocket Address | IPv4 address   | The remote address to connect to websocket server
| Websocket Port | 0 - 9999 | The remote port to connect to the websocket server |


### Samples ✨
Sample scenes can be imported from the TuioUnityClient/Samples/ .Right now there are there basic sample scenes for TUIO 1.1, TUIO 2.0 and Tags

