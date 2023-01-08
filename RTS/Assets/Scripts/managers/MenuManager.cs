using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace rts.mgr
{
    public class MenuManager : IDisposable
    {
        private Transform _menuRoot = null;
        private Dictionary<string, GameObject> _openMenuDict = new Dictionary<string, GameObject>();
        
        private Dictionary<string, string> _menuKeyResDict = new Dictionary<string, string>
        {
            {"MenuMapSetting","Prefabs/Menu/Menu_MapSetting.prefab"},
        };
        
        public MenuManager(Transform menuRoot)
        {
            _menuRoot = menuRoot;
        }
        
        public void OpenMenu(string menuKey)
        {
            if (_openMenuDict.ContainsKey(menuKey))
            {
                Debug.LogWarning("menuKey " + menuKey + " has already opened");
                return;
            }
            Debug.Assert(_menuKeyResDict.ContainsKey(menuKey),"MenuKey " + menuKey + " not config in MenuManager");

            string menuResPath = _menuKeyResDict[menuKey];
            GameObject prefab = Entry.Instance.AssetManager.LoadPrefab(menuResPath);
            Debug.Assert(prefab != null,"Menu Prefab " + menuResPath + " is null");
            
            GameObject menuGO = GameObject.Instantiate(prefab);
            Debug.Assert(_menuKeyResDict.ContainsKey(menuKey),"menuResPath " + menuResPath + " not config in MenuManager");
            
            
            menuGO.transform.SetParent(_menuRoot);
            _openMenuDict.Add(menuKey,menuGO);
        }

        public void CloseMenu(string menuKey)
        {
            if (_openMenuDict.ContainsKey(menuKey))
            {
                GameObject menuGO = _openMenuDict[menuKey];
                GameObject.Destroy(menuGO);
                _openMenuDict.Remove(menuKey);
            }
        }

        public void CloseAll()
        {
            foreach (var menuGO in _openMenuDict.Values)
            {
                GameObject.Destroy(menuGO);
            }
            _openMenuDict.Clear();
        }

        public void Dispose()
        {
            CloseAll();
            _menuRoot = null;
        }
    }
}
