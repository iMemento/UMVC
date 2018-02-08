using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Client.UI.Common;

namespace Client.UI.Main
{
    [RequireComponent(typeof(GameTopBarPresenter))]

    public class GameTopBarController : MonoBehaviour, IController
    {
        private GameTopBarPresenter presenter;

        void Start()
        {
            SetPresenter(GetComponent<GameTopBarPresenter>());
        }

        void Update()
        {

        }


        public void OnUserInput(string command, params object[] args)
        {
            // todo:
            // handle ui presenter input

            MainUIMenuManager.Instance.Back();
        }

        private void SetPresenter(GameTopBarPresenter p)
        {
            presenter = p;
            presenter.RegisterIController(this);
        }

        public static GameTopBarController Create(RectTransform parent, Vector2 localPos)
        {
            // todo:
            // set correct ui prefab path

            var prefab = Resources.Load("todo: path to load") as GameObject;
            var go = Instantiate(prefab);

            var p = go.GetComponent<GameTopBarPresenter>();
            var ret = go.GetComponent<GameTopBarController>();

            p.SetParentAndPostion(parent, localPos);
            ret.SetPresenter(p);

            return ret;
        }
    }
}
