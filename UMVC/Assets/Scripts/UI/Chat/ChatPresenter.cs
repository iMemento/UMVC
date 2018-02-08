using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Client.UI.Common;

namespace Client.UI.Chat
{
    public class ChatPresenter : MonoBehaviour, IPresenter
    {
        private IController ic;

        private RectTransform rectTransform;
        public RectTransform RectTransform
        {
            get
            {
                if (rectTransform == null)
                {
                    rectTransform = GetComponent<RectTransform>();
                }
                return rectTransform;
            }
        }

        void Start()
        {

        }

        void Update()
        {

        }

        public void OnClick()
        {
            ic.OnUserInput("command");
        }

        public void RegisterIController(IController c)
        {
            ic = c;
        }

        public void SetParentAndPostion(RectTransform parent, Vector2 localPos)
        {
            RectTransform.SetParent(parent);
            RectTransform.localPosition = localPos;

            // todo:
            // set anchors or what ever
        }
    }
}
