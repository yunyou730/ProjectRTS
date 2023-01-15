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

        private void Awake()
        {
            _material = GetComponent<MeshRenderer>().sharedMaterial;
        }

        public void SetSize(int rowCnt,int colCnt)
        {
            _rows = rowCnt;
            _cols = colCnt;
        }

        public void Refresh()
        {
            transform.localScale = new Vector3(_cols, _rows, 1);
            _material.SetFloat("_Width",_cols);
            _material.SetFloat("_Height",_rows);
            _material.SetColor("_OddColor",_oddColor);
            _material.SetColor("_EvenColor",_evenColor);
        }
    }
}
