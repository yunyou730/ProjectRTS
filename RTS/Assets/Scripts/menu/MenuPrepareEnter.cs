using System;
using System.Collections;
using System.Collections.Generic;
using rts.chess;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace rts.menu
{
    public class MenuPrepareEnter : MonoBehaviour
    {
        private Button _btnEnterGame = null;
        private TMP_Text _txtEnter = null;
        private TMP_InputField _txtMapWidth = null;
        private TMP_InputField _txtMapHeight = null;

        private void Awake()
        {
            _btnEnterGame = transform.Find("Button_EnterGame").GetComponent<Button>();
            _txtEnter = _btnEnterGame.transform.Find("Text (TMP)").GetComponent<TMP_Text>();
            _txtMapWidth = transform.Find("Input_MapWidth").GetComponent<TMP_InputField>();
            _txtMapHeight = transform.Find("Input_MapHeight").GetComponent<TMP_InputField>();
        }

        void Start()
        {
            _txtMapWidth.text = "50";
            _txtMapHeight.text = "60";

            _btnEnterGame.onClick.AddListener(this.OnClickEnter);
            _txtEnter.text = "Create Game";
        }

        private void OnClickEnter()
        {
            Entry.Instance.MenuManager.CloseMenu("MenuMapSetting");

            int mapWidth = 50;
            int mapHeight = 60;
            if (Int32.TryParse(_txtMapWidth.text, out mapWidth) && Int32.TryParse(_txtMapHeight.text,out mapHeight))
            {
            }
        
            ChessInfo ci = new ChessInfo(1,mapWidth,mapHeight);
            Entry.Instance.Game.StartChess(ci);
        }

    }
    
}
