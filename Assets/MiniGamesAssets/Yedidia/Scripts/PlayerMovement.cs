using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;

    [SerializeField] private float speedRate = 12f;
    [SerializeField] private float boostRate = 24f;
    [SerializeField] private float gravity = -9.81f * 2;
    [SerializeField] private float jumpHeight = 3f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    private Vector3 velocity;
    private Vector3 move;

    public static PlayerMovement Instance;
    private float speed;
    private bool isGrounded;
    public int points;
    private bool isJumped;


    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        Instance = this;
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;
        speed = (Input.GetKey(KeyCode.LeftShift)) ? boostRate : speedRate;
        _characterController.Move(move * (speed * Time.deltaTime));

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            isJumped = true;
        }
        else
        {
            isJumped = false;
        }

        velocity.y += gravity * Time.deltaTime;

        _characterController.Move(velocity * Time.deltaTime);
    }


    public bool IsPlayerMoving()
    {
        return move != Vector3.zero;
    }

    public bool IsPlayerOnBoostMove()
    {
        return speed == boostRate;
    }

    public bool IsPlayerJumping()
    {
        return isJumped;
    }
}
