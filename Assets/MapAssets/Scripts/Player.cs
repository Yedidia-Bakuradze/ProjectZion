using UnityEngine;

namespace MapAssets.Scripts
{
    public class Player : MonoBehaviour
    {
        private void Update()
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

            inputDirection = inputDirection.normalized;
            Vector3 moveDirection = new Vector3(inputDirection.x,0f,inputDirection.y);
            transform.position += moveDirection*Time.deltaTime;

        }
    }
}
