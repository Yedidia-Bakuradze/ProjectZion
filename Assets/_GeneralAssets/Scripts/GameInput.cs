using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;

namespace _GeneralAssets.Scripts
{
    public class GameInput : MonoBehaviour
    {
        private PlayerInputActions _playerInputActions;
        [SerializeField] private bool _isFastMode = false;

        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.MapPlayer.Enable();
        }

        private void Start()
        {
            _playerInputActions.MapPlayer.FastMode.performed += FastMode_Performed;
            _playerInputActions.MapPlayer.FastMode.canceled += FastMode_Canceled;
        }

        private void OnDestroy()
        {
            _playerInputActions.MapPlayer.FastMode.performed -= FastMode_Performed;
            _playerInputActions.MapPlayer.FastMode.canceled -= FastMode_Canceled;
            _playerInputActions.MapPlayer.Disable();
        }

        private void FastMode_Performed(InputAction.CallbackContext obj)
        {
            _isFastMode = true;
        }
        private void FastMode_Canceled(InputAction.CallbackContext obj)
        {
            _isFastMode = false;
        }

        /// <summary>
        /// Returns the input vector which effects the position of the player's transform.
        /// Also, it has an Out variable that indicates rather the player uses the boost mode. 
        /// </summary>
        /// <param name="IsFastMode"></param>
        /// <returns></returns>
        public Vector2 GetNormalizedMovementVector(out bool IsFastMode)
        {
            Vector2 inputDirection = _playerInputActions.MapPlayer.Move.ReadValue<Vector2>();
            IsFastMode = _isFastMode;            
            inputDirection = inputDirection.normalized;
            return inputDirection;
        }
    }
}
