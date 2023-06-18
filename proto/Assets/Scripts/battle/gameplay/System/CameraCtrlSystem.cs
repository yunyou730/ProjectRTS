using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ayy
{
    public class CameraCtrlSystem : BaseSystem
    {
        private Vector3 _offset = new Vector3(0, 20, -5);
        private GameObject _cameraGO = null;
        private int _lookingRow = 0;
        private int _looingCol = 0;
        private float _moveSpeed = 20.0f;
        private float _adjustOffsetSpeed = 20.0f;

        public CameraCtrlSystem(Battle battle, GameObject cameraGO) : base(battle)
        {
            _cameraGO = cameraGO;
        }

        public override void OnStart()
        {
            CameraFollowLookingTile();
        }

        public override void OnUpdate()
        {
            if (!HandleMoveByKeyBoard())
            {
                HandleMoveByMousePos();                
            }

            HandleAdjustOffset();
        }

        public override void OnLogicTick()
        {
        }

        public override void OnDestroy()
        {

        }

        protected void CameraFollowLookingTile()
        {
            Transform cameraTrans = _cameraGO.transform;
            Vector3 tilePos = BattleMetric.GetTilePosition(_lookingRow, _looingCol);
            Vector3 camPos = tilePos + _offset;
            cameraTrans.localPosition = camPos;
            cameraTrans.LookAt(tilePos);
        }

        protected bool HandleMoveByMousePos()
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 screenSize = new Vector2(Screen.width, Screen.height);

            Vector2 moveDir = Vector2.zero;
            if (mousePos.x >= 0 && mousePos.x < screenSize.x && mousePos.y >= 0 && mousePos.y < screenSize.y)
            {
                float thresX = screenSize.x * 0.1f;
                float thresY = screenSize.y * 0.1f;
                float thres = thresX < thresY ? thresX : thresY;

                if (mousePos.x <= thresX)
                {
                    moveDir += Vector2.left;
                }
                if (mousePos.x >= screenSize.x - thres)
                {
                    moveDir += Vector2.right;
                }
                if (mousePos.y <= thres)
                {
                    moveDir += Vector2.down;
                }
                if (mousePos.y >= screenSize.y - thres)
                {
                    moveDir += Vector2.up;
                }
            }
            return MoveByDir(moveDir);
        }

        protected bool HandleMoveByKeyBoard()
        {
            Vector2 moveDir = Vector2.zero;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveDir += Vector2.up;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                moveDir += Vector2.down;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveDir += Vector2.left;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                moveDir += Vector2.right;
            }
            return MoveByDir(moveDir);
        }
        
        protected bool MoveByDir(Vector2 moveDir)
        {
            if(moveDir.magnitude > float.Epsilon)
            {
                moveDir = moveDir.normalized * (Time.deltaTime * _moveSpeed);
                _cameraGO.transform.localPosition += new Vector3(moveDir.x,0,moveDir.y);
                return true;
            }

            return false;
        }

        protected void HandleAdjustOffset()
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if(Mathf.Abs(scroll) > float.Epsilon)
            {
                float offset = Time.deltaTime * _adjustOffsetSpeed;
                
                if (scroll > 0)
                {
                    _cameraGO.transform.localPosition -= (offset * _offset);
                }
                else
                {
                    _cameraGO.transform.localPosition += (offset * _offset);
                }
            }
        }
    }    
}

