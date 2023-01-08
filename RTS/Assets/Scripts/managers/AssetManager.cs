using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rts.mgr
{
    public class AssetManager : IDisposable
    {
        private Dictionary<string, GameObject> _loadedGameObjectDict = new Dictionary<string, GameObject>();
        
        public GameObject LoadPrefab(string prefabPath)
        {
            if (!_loadedGameObjectDict.ContainsKey(prefabPath))
            {
                string realLoadPath = prefabPath.Replace(".prefab", "");
                GameObject prefab = Resources.Load<GameObject>(realLoadPath);
                _loadedGameObjectDict.Add(prefabPath,prefab);
            }
            return _loadedGameObjectDict[prefabPath];
        }
        
        public void Dispose()
        {
            _loadedGameObjectDict.Clear();   
            Resources.UnloadUnusedAssets();
        }
    }
}
