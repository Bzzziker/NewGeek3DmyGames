using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGames
{
    public abstract class BaseController
    {
        public bool IsActive { get; private set; }

        public virtual void On()
        {
            On(null);
        }

        public virtual void On(params BaseObjectScene[] obj)
        {
            IsActive = true;
        }

        public virtual void Off()
        {
            IsActive = false;
        }

        public void Switch()
        {
            if (!IsActive)
            {
                On();
            }
            else
            {
                Off();
            }
        }
    }
}