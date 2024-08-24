using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] public GameManager gameManager;

    void Update()
    {
        gameObject.GetComponent<Text>().text = gameManager.herringCollected.ToString();
    }

}
