using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private TuxController tux;

    [SerializeField] private Text text;
    [SerializeField] private Image speedGauge;
    [SerializeField] private Image jumpGauge;

    void Update()
    {
        int speedVal = (int) Mathf.Round(rb.velocity.magnitude / 2);
        float jumpVal = tux.chargeTime;

        text.text = speedVal.ToString();
        speedGauge.fillAmount = speedVal / 200f;
        jumpGauge.fillAmount = jumpVal / 3f;
    }
}
