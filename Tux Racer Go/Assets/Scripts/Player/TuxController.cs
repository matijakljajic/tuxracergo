using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Physics based control system for our player.
/// </summary>
public class TuxController : MonoBehaviour
{
    private Rigidbody player;

    [SerializeField] public float worldSpeed;
    [SerializeField] public float moveSpeed;

    private bool isGrounded;

    private bool shouldJump = false;
    private bool isCharging = false;
    public float chargeTime = 0f;

    private bool shouldAccelerate = false;
    private bool shouldBreak = false;
    private bool shouldTurnLeft = false;
    private bool shouldTurnRight = false;

    private void Start()
    {
        player = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isCharging = true;
            chargeTime = 0f;
        }

        if (isCharging && Input.GetKey(KeyCode.E))
        {
            chargeTime += Time.deltaTime;
            chargeTime = Mathf.Clamp(chargeTime, 0, 3f);
        }

        if (isCharging && Input.GetKeyUp(KeyCode.E))
        {
            isCharging = false;
            shouldJump = true;
        }

        if (Input.GetKey(KeyCode.W))
            shouldAccelerate = true;
        if (Input.GetKey(KeyCode.S))
            shouldBreak = true;
        if (Input.GetKey(KeyCode.A))
            shouldTurnLeft = true;
        if (Input.GetKey(KeyCode.D))
            shouldTurnRight = true;
    }

    private void FixedUpdate()
    {
        HandleAccelerating();
        HandleBreaking();
        HandleTurning();
        HandleJumping();

        FakeSlope();
        ModifyGravity();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Ice"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    private void HandleAccelerating()
    {
        if (shouldAccelerate)
        {
            if (isGrounded)
            {
                player.AddForce(Vector3.forward * moveSpeed);
            }
            else
            {
                player.AddForce(Vector3.up * 900f);
            }
            shouldAccelerate = false;
        }
    }

    private void HandleBreaking()
    {
        if (shouldBreak && isGrounded)
        {
            player.AddForce(Vector3.back * (worldSpeed / 2f));
            shouldBreak = false;
        }
    }

    private void HandleTurning()
    {
        if (shouldTurnRight && isGrounded)
        {
            player.AddForce(Vector3.right * moveSpeed * 1.5f);
            shouldTurnRight = false;
        }
        if (shouldTurnLeft && isGrounded)
        {
            player.AddForce(Vector3.left * moveSpeed * 1.5f);
            shouldTurnLeft = false;
        }
    }

    private void HandleJumping()
    {
        if (shouldJump)
        {
            float jumpForce = (chargeTime / 3f) * 500f;

            if (isGrounded)
            {
                player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

            chargeTime = 0f;
            shouldJump = false;
        }
    }

    private void ModifyGravity() 
    {
        player.AddForce(Vector3.down * 1500f);
    }

    private void FakeSlope()
    {
        player.AddForce(Vector3.forward * worldSpeed);
    }

}
