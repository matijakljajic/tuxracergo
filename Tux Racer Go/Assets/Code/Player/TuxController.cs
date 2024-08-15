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

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        handleAcceleration();
        handleBreaking();
        handleTurning();
        modifyGravity();

    }

    private void handleAcceleration()
    {
        fakeSlope();

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
            player.AddRelativeForce(Vector3.right * moveSpeed * 0.5f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.AddRelativeForce(Vector3.left * moveSpeed * 0.5f);
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
