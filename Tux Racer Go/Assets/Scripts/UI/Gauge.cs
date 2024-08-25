using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] TuxController tux;

    [SerializeField] Text text;
    [SerializeField] Image speedGauge;
    [SerializeField] Image jumpGauge;

    // Update is called once per frame
    void Update()
    {
        int speedVal = (int) Mathf.Round(rb.velocity.magnitude / 2);
        float jumpVal = tux.chargeTime;

        text.text = speedVal.ToString();
        speedGauge.fillAmount = speedVal / 200f;
        jumpGauge.fillAmount = jumpVal / 3f;
    }
}
