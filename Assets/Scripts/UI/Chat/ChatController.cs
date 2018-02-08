using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Client.UI.Common;

namespace Client.UI.Chat
{
    [RequireComponent(typeof(ChatPresenter))]

    public class ChatController : MenuBaseController, IController
    {
        private ChatPresenter presenter;

        void Start()
        {
            SetPresenter(GetComponent<ChatPresenter>());
        }

        void Update()
        {

        }


        public void OnUserInput(string command, params object[] args)
        {
            // todo:
            // handle ui presenter input
        }

        private void SetPresenter(ChatPresenter p)
        {
            presenter = p;
            presenter.RegisterIController(this);
        }

        public static ChatController Create(RectTransform parent, Vector2 localPos)
        {
            // todo:
            // set correct ui prefab path

            var prefab = Resources.Load("todo: path to load") as GameObject;
            var go = Instantiate(prefab);

            var p = go.GetComponent<ChatPresenter>();
            var ret = go.GetComponent<ChatController>();

            p.SetParentAndPostion(parent, localPos);
            ret.SetPresenter(p);

            return ret;
        }
    }
}
