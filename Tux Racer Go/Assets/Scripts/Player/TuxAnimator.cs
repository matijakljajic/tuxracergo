using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuxAnimator : MonoBehaviour
{

    private GameObject player;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject;
        playerAnimator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // Steering is animated
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerAnimator.SetTrigger("startRightSlide");
        } else if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnimator.SetTrigger("stopRightSlide");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            playerAnimator.SetTrigger("startLeftSlide");
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnimator.SetTrigger("stopLeftSlide");
        }

        // Speeding down/up is animated
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnimator.SetTrigger("startSpeedingUp");
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnimator.SetTrigger("stopSpeedingUp");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnimator.SetTrigger("startSlowingDown");
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnimator.SetTrigger("stopSlowingDown");
        }

    }
}
