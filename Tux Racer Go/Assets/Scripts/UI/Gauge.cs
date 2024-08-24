using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Text text;
    [SerializeField] Image image;

    // Update is called once per frame
    void Update()
    {
        int value = (int) Mathf.Round(rb.velocity.magnitude / 2);
        text.text = value.ToString();
        image.fillAmount = value / 200f;
    }
}
