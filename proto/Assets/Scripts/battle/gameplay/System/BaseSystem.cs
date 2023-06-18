using System.Collections;
using System.Collections.Generic;
using System.Threading;
using ayy.go;
using UnityEngine;

namespace ayy
{
    public abstract class BaseSystem
    {
        protected Battle _battle = null;
        
        public BaseSystem(Battle battle)
        {
            _battle = battle;
        }

        public abstract void OnStart();
        public abstract void OnUpdate();
        public abstract void OnLogicTick();
        public abstract void OnDestroy();

    }    
}

