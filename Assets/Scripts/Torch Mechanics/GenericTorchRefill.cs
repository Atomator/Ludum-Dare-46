using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GenericTorchRefill : MonoBehaviour
{
    public Light2D torchLight2D;
    public CircleCollider2D torchCircleCollider2D;

    public float torchRange = 2f;
    public float timeBetweenRefills = 1f;
    public float refillAmount = 0.2f;
    public float minimumLight = 0f;

    public bool isEnabled = true;

    private bool inumFinished = false;

        // Start is called before the first frame update
    void Start()
    {
        torchLight2D = this.GetComponent<Light2D>();

        this.gameObject.AddComponent<CircleCollider2D>();
        torchCircleCollider2D = this.GetComponent<CircleCollider2D>();

        torchCircleCollider2D.radius = torchRange;
        torchCircleCollider2D.isTrigger = true;
        torchLight2D.pointLightOuterRadius = torchRange;
    }

    void OnTriggerStay2D(Collider2D collided) {
        if (isEnabled && !inumFinished && (collided.gameObject.tag == "Player" || collided.gameObject.tag == "Payload") && torchLight2D.pointLightOuterRadius > 0) {
            inumFinished = true;
            StartCoroutine(torchLightRefill(collided.gameObject));
        }
    }

        // Update is called once per frame
    IEnumerator torchLightRefill(GameObject collided)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(timeBetweenRefills);

        //Code to be used to detect both playload and player
        if (false) {
            print("This is placeholder code");
        }

        else {
            string childName = collided.name + "Torch";
            Light2D collidedTorch = collided.transform.Find(childName).GetComponent<Light2D>();
            GenericTorch torchInfo = collided.transform.Find(childName).GetComponent<GenericTorch>();

            if (collidedTorch.pointLightOuterRadius < torchInfo.torchRangeMax && torchLight2D.pointLightOuterRadius - refillAmount > minimumLight) {
                if (collidedTorch.pointLightOuterRadius + refillAmount > 3) {
                    collidedTorch.pointLightOuterRadius = torchInfo.torchRangeMax;
                } else {
                    collidedTorch.pointLightOuterRadius += refillAmount;
                }
                torchLight2D.pointLightOuterRadius -= refillAmount;
                torchCircleCollider2D.radius -= refillAmount;
            }
        }

        inumFinished = false;
    }

}
