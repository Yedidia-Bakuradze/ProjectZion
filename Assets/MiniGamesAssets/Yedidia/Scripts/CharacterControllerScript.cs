using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    private CharacterController characterController;

    // Set the speed at which the character moves
    public float moveSpeed = 5f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Move the character based on user input (you can modify this part based on your input system)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        Vector3 moveVector = transform.TransformDirection(moveDirection) * moveSpeed;

        // Apply gravity to the character
        moveVector.y += Physics.gravity.y * Time.deltaTime;

        // Perform raycasting to find the terrain height below the character
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Adjust the character's position to match the terrain height
            moveVector.y = hit.point.y;
        }

        // Move the character using the adjusted moveVector
        characterController.Move(moveVector * Time.deltaTime);
    }
}
