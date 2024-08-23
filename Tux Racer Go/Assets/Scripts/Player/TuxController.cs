using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

/// <summary>
/// Physics based control system for our player.
/// </summary>
public class TuxController : MonoBehaviour
{
    private Rigidbody player;

    [SerializeField] public float worldSpeed;
    [SerializeField] public float moveSpeed;

    private bool isGrounded;

    void Start()
    {
        player = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Can't turn but can accelerate / break mid-air because I think it's like that in the original Tux Racer.

        if (isGrounded)
        {
            HandleTurning();
        }

        HandleAcceleration();
        HandleBreaking();

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

    private void HandleAcceleration()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.AddForce(Vector3.forward * moveSpeed);
        }
    }

    private void HandleBreaking()
    {
        if (Input.GetKey(KeyCode.S))
        {
            player.AddForce(Vector3.back * (worldSpeed / 2));
        }
    }

    private void HandleTurning()
    {
        if (Input.GetKey(KeyCode.D))
        {
            player.AddForce(Vector3.right * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.AddForce(Vector3.left * moveSpeed);
        }
    }

    private void ModifyGravity() 
    {
        player.AddForce(Vector3.down * 1500);
    }

    private void FakeSlope()
    {
        player.AddForce(Vector3.forward * worldSpeed);
    }

}
