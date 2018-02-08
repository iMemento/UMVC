using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Client.UI.Common;

namespace Client.UI.Main
{
    [RequireComponent(typeof(MainPresenter))]

    public class MainController : MenuBaseController, IController
    {
        private MainPresenter presenter;

        void Start()
        {
            SetPresenter(GetComponent<MainPresenter>());
        }

        void Update()
        {

        }


        public void OnUserInput(string command, params object[] args)
        {
            // todo:
            // handle ui presenter input
            MainUIMenuManager.Instance.ChangeToMenu(MenuType.Chat);
        }

        private void SetPresenter(MainPresenter p)
        {
            presenter = p;
            presenter.RegisterIController(this);
        }

        public static MainController Create(RectTransform parent, Vector2 localPos)
        {
            // todo:
            // set correct ui prefab path

            var prefab = Resources.Load("todo: path to load") as GameObject;
            var go = Instantiate(prefab);

            var p = go.GetComponent<MainPresenter>();
            var ret = go.GetComponent<MainController>();

            p.SetParentAndPostion(parent, localPos);
            ret.SetPresenter(p);

            return ret;
        }
    }
}
