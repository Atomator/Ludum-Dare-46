using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GenericTorch : MonoBehaviour
{
    public float torchRangeMax = 2f;

    private Light2D genericTorch;

    void Start () {
        genericTorch = this.gameObject.GetComponent<Light2D>();
        genericTorch.pointLightOuterRadius = torchRangeMax;
    }

}
