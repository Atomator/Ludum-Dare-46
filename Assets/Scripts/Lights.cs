using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Lights : MonoBehaviour
{
    public Light2D lightSource;
    public CircleCollider2D lightCollider;

    public float lightRange = 2f;
    public float timeToRefill = 1f;
    public float refillAmount = 0.2f;

    private bool inumFinished = false;

    
    // Start is called before the first frame update
    void Start()
    {
        lightSource = this.GetComponent<Light2D>();
        this.gameObject.AddComponent<CircleCollider2D>();
        lightCollider = this.GetComponent<CircleCollider2D>();
        lightCollider.radius = lightRange/5;
        lightSource.pointLightOuterRadius = lightRange;
        lightCollider.isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D other) {
        print(other.gameObject.name);
        if (!inumFinished && (other.gameObject.tag == "Player" || other.gameObject.tag == "Payload") && lightSource.pointLightOuterRadius > 0) {
            inumFinished = true;
            StartCoroutine(drainLight(other.gameObject));
        }
    }


    // Update is called once per frame
    IEnumerator drainLight(GameObject toRefill)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(timeToRefill);

        //After we have waited 5 seconds print the time again

        if (toRefill.gameObject.tag == "Player") {
            if (toRefill.gameObject.GetComponent<TorchLight>().torch.pointLightOuterRadius < toRefill.gameObject.GetComponent<TorchLight>().torchMax) {
                if (toRefill.gameObject.GetComponent<TorchLight>().torch.pointLightOuterRadius + refillAmount > toRefill.gameObject.GetComponent<TorchLight>().torchMax) {
                    toRefill.gameObject.GetComponent<TorchLight>().torch.pointLightOuterRadius = toRefill.gameObject.GetComponent<TorchLight>().torchMax;
                } else {
                    toRefill.gameObject.GetComponent<TorchLight>().torch.pointLightOuterRadius += refillAmount;
                }
                lightSource.pointLightOuterRadius -= refillAmount;
                lightCollider.radius -= refillAmount/5;
            }
        }

        if (toRefill.gameObject.tag == "Payload") {
            if (toRefill.gameObject.GetComponent<Light2D>().pointLightOuterRadius < toRefill.gameObject.GetComponent<PayLoadLight>().lightRange) {
                if (toRefill.gameObject.GetComponent<Light2D>().pointLightOuterRadius + refillAmount > toRefill.gameObject.GetComponent<PayLoadLight>().lightRange) {
                    toRefill.gameObject.GetComponent<Light2D>().pointLightOuterRadius = toRefill.gameObject.GetComponent<PayLoadLight>().lightRange;
                } else {
                    toRefill.gameObject.GetComponent<Light2D>().pointLightOuterRadius += refillAmount;
                }
                lightSource.pointLightOuterRadius -= refillAmount;
                lightCollider.radius -= refillAmount/5;
            }
        }

        inumFinished = false;
    }
}
