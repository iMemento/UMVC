using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.UI.Common
{
    public interface IPresenter
    {
        void RegisterIController(IController c);
        void SetParentAndPostion(RectTransform parent, Vector2 localPos);
    }
}
