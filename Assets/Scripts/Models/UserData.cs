using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{

    void OnServiceDataChanged()
    {
        NotificationCenter.DefaultCenter.PostNotification("UserDataChanged");
    }
}
