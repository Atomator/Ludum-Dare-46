using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PayloadTorch: MonoBehaviour
{
    public Light2D lightSource;
    public CircleCollider2D lightCollider;

    public float lightRange = 2f;
    public float timeToRefill = 1f;
    public float refillAmount = 0.2f;

    private bool inumFinished = false;

    
}
