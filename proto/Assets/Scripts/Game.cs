using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  ayy
{
    public class Game : MonoBehaviour
    {
        
        public static Game Instance = null;

        private ResourceManager _resouceManager = null;
        private BattleManager _battleManager = null;
        
        void Awake()
        {
            Instance = this;
        }
        
        void Start()
        {
            _resouceManager = new ResourceManager();
            
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
            if (_battleManager != null)
            {
                _battleManager.OnDestroy();
            }
        }

        public ResourceManager GetResourceManager()
        {
            return _resouceManager;
        }
    }

}
