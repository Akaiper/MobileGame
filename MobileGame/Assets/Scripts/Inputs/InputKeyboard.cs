using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace UFF
{
    public class InputKeyboard : MonoBehaviour
    {
        #region inputSystemNovo
    
        // private bool _a1 = false;
        // private float _a2 = 0;
        // private bool _moveLeft = false;

        // public bool A1 { get { return _a1; } }
        // public float A2 { get { return _a2; } }

        // //private PlayerActions _actions;
        // private void Awake()
        // {
        //     // _actions = new PlayerActions();
        //     // _actions.Enable();

        //     // _actions.Player.A1.started += OnA1;
        //     // _actions.Player.A1.canceled += OnA1;
        //     // _actions.Player.A2.performed += OnA2;
        // }

        // private void OnDestroy()
        // {
        //     // _actions.Player.A1.started -= OnA1;
        //     // _actions.Player.A1.canceled -= OnA1;
        //     // _actions.Player.A2.performed -= OnA2;

        //     // _actions.Disable();
        // }

        // private void OnA1(InputAction.CallbackContext ctx)
        // {
        //     // _a1 = ctx.ReadValueAsButton();
        // }

        // private void OnA2(InputAction.CallbackContext ctx)
        // {
        //     // _a2 = ctx.ReadValue<float>();
        //     // if (_a2 < 0) _moveLeft = true;
        // }

        #endregion

        public KeyCode[] rightButtons;
        public KeyCode[] leftButtons;
        public KeyCode[] upButtons;
        public KeyCode[] downButtons;

        public UnityEvent<Vector2> SendDirection;

        private bool vertical;
        private bool horizontal;

        private void Update()
        {
            CalcDirection();
        }

        private bool GetKeys(KeyCode[] keys)
        {
            foreach (KeyCode item in keys)
            {
                if(Input.GetKey(item))
                {
                    return true;
                }
            }
            return false;
        }

        private bool TestHorizontal()
        {   
            bool hbool;

            hbool = false;

            if(GetKeys(rightButtons) )
            {
                hbool = true;

                SendDirection?.Invoke(new Vector2(1,0));
            }

            if(GetKeys(leftButtons))
            {
                hbool = true;

                SendDirection?.Invoke(new Vector2(-1,0));
            }
            return hbool;
        }

        private bool TestVertical()
        {
           bool vbool;

            vbool = false;

            if(GetKeys(upButtons) )
            {
                vbool = true;

                SendDirection?.Invoke(new Vector2(0,1));
            }

            if(GetKeys(downButtons))
            {
                vbool = true;

                SendDirection?.Invoke(new Vector2(0,-1));
            }

            return vbool;
        }

        private void CalcDirection()
        {   

            if(!vertical)
            {
                horizontal = TestHorizontal();
            }

            if(!horizontal)
            {
                vertical = TestVertical();
            }

            
        }
    }
}
