using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private string prefix;

    void Update()
    {
        gameObject.GetComponent<Text>().text = string.Concat(prefix, gameManager.herringCollected.ToString());
    }

}
