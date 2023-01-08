using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using rts.mgr;

namespace rts
{
    public class Entry : MonoBehaviour
    {
        public static Entry Instance = null;
        
        public AssetManager AssetManager { get; set; }
        public MenuManager MenuManager { get; set; }
        
        public Game Game { set; get; }
        

        protected Transform _menuRoot = null;
        
        private void Awake()
        {
            Instance = this;
            _menuRoot = transform.Find("[menu_root]");
            
            AssetManager = new AssetManager();
            MenuManager = new MenuManager(_menuRoot);
            Game = new Game();
        }
        
        private void Start()
        {
            MenuManager.OpenMenu("MenuMapSetting");
        }
        
        private void OnDestroy()
        {
            Game?.Dispose();
            MenuManager?.Dispose();
            AssetManager?.Dispose();
            Instance = null;
        }

        void Update()
        {
            Game?.OnUpdate(Time.deltaTime);
        }
    }
}
