using UnityEngine;

public class Steering : MonoBehaviour
{

    private Vector3 movementInput;

    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody playerBody;
    [Space]
    [SerializeField] private Transform playerFeet;
    [SerializeField] private LayerMask floorMask;
    [Space]
    [SerializeField] private float steeringSpeed;
    [SerializeField] private float accelerationMax;
    [SerializeField] private float jumpForce;

    // Update is called once per frame
    private void Update()
    {
        movementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        steerTux();
    }

    private void steerTux()
    {

        Animator animator = player.GetComponent<Animator>();

        // animation check
        if (movementInput.x > 0f)
        {
            animator.Play("SlideToRight");
        }
        else if (movementInput.x < 0f)
        {
            animator.Play("SlideToLeft");
        }
        else
        {
            animator.Play("Slide");
        }

        // moving Tux in a way that we don't change his falling speed if we accelerate
        float movementX = movementInput.x * steeringSpeed;
        float movementZ = (Mathf.Abs(movementInput.z) + movementInput.z) / 2 * accelerationMax;
        playerBody.velocity = new Vector3(movementX, playerBody.velocity.y, movementZ);

        // jump implementation
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.CheckSphere(playerFeet.position, 1f, floorMask))
            {
                playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

}
