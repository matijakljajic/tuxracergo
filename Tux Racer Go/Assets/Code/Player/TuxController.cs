using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

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
            handleTurning();
        }

        handleAcceleration();
        handleBreaking();

        fakeSlope();
        modifyGravity();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.contacts.Length > 0)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    private void handleAcceleration()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.AddForce(Vector3.forward * moveSpeed);
        }
    }

    private void handleBreaking()
    {
        if (Input.GetKey(KeyCode.S))
        {
            player.AddForce(Vector3.back * (worldSpeed / 2));
        }
    }

    private void handleTurning()
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

    private void modifyGravity() 
    {
        player.AddForce(Vector3.down * 1500);
    }

    private void fakeSlope()
    {
        player.AddForce(Vector3.forward * worldSpeed);
    }

}
