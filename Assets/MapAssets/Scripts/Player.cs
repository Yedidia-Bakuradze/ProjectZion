using UnityEngine;
using UnityEngine.Serialization;

namespace MapAssets.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float movingSpeed = 5f;
        [SerializeField] private float boost = 1.75f;
        [SerializeField] private bool IsFastMode;
        [SerializeField] private float RotationSpeed = 10f;
        private void Update()
        {
            IsFastMode = false;
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

            inputDirection = inputDirection.normalized;
            Vector3 moveDirectionVector = new Vector3(inputDirection.x,0f,inputDirection.y);
            if (IsFastMode)
            {
                transform.position += moveDirectionVector * (Time.deltaTime * movingSpeed * boost);
            }
            else
            {
                transform.position += moveDirectionVector*(Time.deltaTime*movingSpeed);
            }
            
            transform.forward = Vector3.Slerp(transform.forward, moveDirectionVector,Time.deltaTime*RotationSpeed);
            
        }
        
    }
}
