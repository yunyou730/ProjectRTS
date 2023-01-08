using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Search;

namespace rts.chess.actor
{
    public class AChessboard : MonoBehaviour
    {
        [SerializeField] protected int _rows = 7;
        [SerializeField] protected int _cols = 5;
        [SerializeField] protected Color _oddColor = Color.white;
        [SerializeField] protected Color _evenColor = Color.black;

        private Material _material = null;
        
        void Start()
        {
            transform.localScale = new Vector3(_cols, _rows, 1);
            _material = GetComponent<MeshRenderer>().sharedMaterial;
            
            _material.SetFloat("_Width",_cols);
            _material.SetFloat("_Height",_rows);
            _material.SetColor("_OddColor",_oddColor);
            _material.SetColor("_EvenColor",_evenColor);
        }

        private void Update()
        {
            transform.localScale = new Vector3(_cols, _rows, 1);
            _material.SetFloat("_Width",_cols);
            _material.SetFloat("_Height",_rows);
        }
    }
}
