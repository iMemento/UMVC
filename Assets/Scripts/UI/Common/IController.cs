using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.UI.Common
{
    public interface IController
    {
        void OnUserInput(string command, params object[] args);
    }
}
