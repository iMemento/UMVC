# UMVC
===
MVC Pattern Framework for Unity3d GUI System

### Model

* Holds no view data nor view state data.
* Is accessed by the `Controller` and other `Models` only
* Will trigger events to notify external system of changes.

### View
* UGUI Prefabs

### Controller

* Controls view flow.
* Holds the application state needed for that view
* Will trigger events to notify external system of changes.
* Handles events either triggered by the player in the `View` or triggered by the `Models` 

### Presenter
* Handle references to elements needed for drawing
* Receive User Input
* Notify `Controller` when an user input
* Refresh UI details

### NotificationCenter
