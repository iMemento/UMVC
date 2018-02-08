using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.UI.Common
{
    public class MenuBaseController : MonoBehaviour
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        public virtual void Refresh(params object[] args)
        {

        }

        public virtual void DestroySelf()
        {
            Destroy(gameObject);
        }

    }
}