using UnityEngine;

namespace MapAssets.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float movingSpeed = 5f;
        [SerializeField] private float extraSpeed = 1.75f;
        [SerializeField] private bool IsFastMode;
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
            transform.position += GetDirectionVector(inputDirection);
        }

        private Vector3 GetDirectionVector(Vector2 inputVector)
        {
            Vector3 moveDirectionVector = new Vector3(inputVector.x,0f,inputVector.y)*(Time.deltaTime*movingSpeed);
            if (IsFastMode)
                moveDirectionVector *= extraSpeed;
            return moveDirectionVector;
        }
    }
}
