using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ayy
{
    public class ResourceManager
    {
        private Dictionary<string, Material> _materialMap = new Dictionary<string, Material>();


        public Material GetMaterial(string materialKey,string shaderPath)
        {
            if(!_materialMap.ContainsKey(materialKey))
            {
                Material material = new Material(Shader.Find(shaderPath));
                material.enableInstancing = true;    // @miao @temp, it's not affect on batching
                _materialMap.Add(materialKey,material);
            }
            return _materialMap[materialKey];
        }
    }

}
