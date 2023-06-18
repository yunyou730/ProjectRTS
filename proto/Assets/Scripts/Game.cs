using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  ayy
{
    public class Game : MonoBehaviour
    {
        private BattleManager _battleManager = null;
        void Start()
        {
            _battleManager = new BattleManager();
            _battleManager.StartMockBattle();
        }
        
        void Update()
        {
            if (_battleManager != null)
            {
                _battleManager.OnUpdate();
            }
        }

        private void OnDestroy()
        {
            
        }
    }

}
