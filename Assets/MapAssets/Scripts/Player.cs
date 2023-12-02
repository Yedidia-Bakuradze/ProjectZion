using _GeneralAssets.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace MapAssets.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float movingSpeed = 5f;
        [SerializeField] private float boost = 1.75f;
        [SerializeField] private bool IsRunning;
        [SerializeField] private bool IsWalking;
        [SerializeField] private float RotationSpeed = 10f;


        [SerializeField] private AnimationCurve _animationCurve;
        [SerializeField] private float time;
        [SerializeField] private LayerMask WhatIsGround;

        [SerializeField] private GameInput _gameInput;
        private void Update()
        {
            Vector3 inputDirection = _gameInput.GetNormalizedMovementVector(out IsRunning);
            Vector3 moveDirectionVector = new Vector3(inputDirection.x,0f,inputDirection.y);
            IsWalking = moveDirectionVector != Vector3.zero;
            if (IsRunning)
            {
                transform.position += moveDirectionVector * (Time.deltaTime * movingSpeed * boost);
            }
            else
            {
                transform.position += moveDirectionVector*(Time.deltaTime*movingSpeed);
            }
            
            transform.forward = Vector3.Slerp(transform.forward, moveDirectionVector,Time.deltaTime*RotationSpeed);
        }
        public bool GetIsPlayerWalking()
        {
            return IsWalking;
        }

        public bool GetIsPlayerRunning()
        {
            return IsRunning;
        }
    }
        
}
