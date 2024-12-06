using UnityEngine;
using UnityEngine.InputSystem;

namespace UFF
{
    public class InputKeyboard : MonoBehaviour
    {
        private bool _a1 = false;
        private float _a2 = 0;
        private bool _moveLeft = false;

        public bool A1 { get { return _a1; } }
        public float A2 { get { return _a2; } }

        private PlayerActions _actions;
        private void Awake()
        {
            _actions = new PlayerActions();
            _actions.Enable();

            _actions.Player.A1.started += OnA1;
            _actions.Player.A1.canceled += OnA1;
            _actions.Player.A2.performed += OnA2;
        }

        private void OnDestroy()
        {
            _actions.Player.A1.started -= OnA1;
            _actions.Player.A1.canceled -= OnA1;
            _actions.Player.A2.performed -= OnA2;

            _actions.Disable();
        }

        private void OnA1(InputAction.CallbackContext ctx)
        {
            _a1 = ctx.ReadValueAsButton();
        }

        private void OnA2(InputAction.CallbackContext ctx)
        {
            _a2 = ctx.ReadValue<float>();
            if (_a2 < 0) _moveLeft = true;
        }
    }
}
