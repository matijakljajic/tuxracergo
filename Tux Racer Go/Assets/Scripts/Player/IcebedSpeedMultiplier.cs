using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcebedSpeedMultiplier : MonoBehaviour
{
    private TuxController game;

    private void Start()
    {
        game = gameObject.GetComponent<TuxController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ice"))
        {
            game.moveSpeed = game.moveSpeed * 1.5f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ice"))
        {
            game.moveSpeed = game.moveSpeed / 1.5f;
        }
    }

}