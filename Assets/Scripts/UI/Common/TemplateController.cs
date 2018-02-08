using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Client.UI.Common;

namespace Client.UI
{
    [RequireComponent(typeof(TemplatePresenter))]

    public class TemplateController : MonoBehaviour, IController
    {
        private TemplatePresenter presenter;

        void Start()
        {
            SetPresenter(GetComponent<TemplatePresenter>());
        }

        void Update()
        {

        }


        public void OnUserInput(string command, params object[] args)
        {
            // todo:
            // handle ui presenter input
        }

        private void SetPresenter(TemplatePresenter p)
        {
            presenter = p;
            presenter.RegisterIController(this);
        }

        public static TemplateController Create(RectTransform parent, Vector2 localPos)
        {
            // todo:
            // set correct ui prefab path

            var prefab = Resources.Load("todo: path to load") as GameObject;
            var go = Instantiate(prefab);

            var p = go.GetComponent<TemplatePresenter>();
            var ret = go.GetComponent<TemplateController>();

            p.SetParentAndPostion(parent, localPos);

            return ret;
        }
    }
}
