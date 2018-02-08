# UMVC
===
MVC Pattern Framework for Unity3d GUI System

![Diagram](/Pic/Diagram.png)

### Model

* Holds no view data nor view state data.
* Is accessed by the `Controller` and other `Models` only
* Will trigger events to notify external system of changes.

### View
* UGUI Prefabs

### Presenter
* Each Presenter corresponds to a View
* Holds references to elements needed for drawing
* Receive User Input
* Notify `Controller` when an user input
* This script is a UI refresh operation function set

### Controller

* Controls view flow.
* Holds the application state needed for that view
* Will trigger events to notify external system of changes.
* Handles events either triggered by the player in the `View` or triggered by the `Models` 
* Each Controller corresponds to a Presenter and holds the reference of it's `Presenter`   
* Holds the references of the small `Controllers` under this controller

### NotificationCenter
* A notification dispatch mechanism that enables the broadcast of information to registered observers.
* Add observer in `Controllers`
* Post notifications in `Models`

```
    void Start()
    {
        NotificationCenter.DefaultCenter.AddObserver(this, "UserDataChanged", UserDataChanged);
    }
    void OnDestroy()
    {
        NotificationCenter.DefaultCenter.RemoveObserver(this, "UserDataChanged");
    }
```

### Create Controller and Presenter frome Template
![Diagram](/Pic/EditorTool.png)