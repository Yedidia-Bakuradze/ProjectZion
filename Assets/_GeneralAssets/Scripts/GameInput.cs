using System;
using UnityEngine;
using UnityEngine.TestTools;

namespace _GeneralAssets.Scripts
{
    public class GameInput : MonoBehaviour
    {

        public static GameInput Instance;

        private void Awake()
        {
            Instance = this;
        }

        public Vector2 GetNormalizedMovementVector(out bool IsFastMode)
        {
            Vector2 inputDirection = new Vector2();
            if (Input.GetKey(KeyCode.W))
            {
                inputDirection.y++;
            }
            if (Input.GetKey(KeyCode.A))
            {
                inputDirection.x--;
            }
            if (Input.GetKey(KeyCode.S))
            {
                inputDirection.y--;
            }
            if (Input.GetKey(KeyCode.D))
            {
                inputDirection.x++;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                IsFastMode = true;
            }
            else
            {
                IsFastMode = false;
            }
            
            inputDirection = inputDirection.normalized;
            return inputDirection;
        }
    }
}
