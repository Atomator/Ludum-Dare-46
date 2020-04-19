using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class EnemyProperties : MonoBehaviour
{
    
    public float health = 100f;

    public float timeBetweenAttacks = 2f;
    
    public float enemyDamage = 0.2f;

    private bool inumFinished = false;


    void Update() {
        if (health < 0) {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D collided) {
        print("6");
        if (!inumFinished && (collided.gameObject.tag == "Player" || collided.gameObject.tag == "Payload")) {
            inumFinished = true;
            StartCoroutine(takeDamage(collided.gameObject));
        }
    }

    IEnumerator takeDamage(GameObject collided)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.

        string childName = collided.name + "Torch";
        Light2D collidedTorch = collided.transform.Find(childName).GetComponent<Light2D>();
        GenericTorch torchInfo = collided.transform.Find(childName).GetComponent<GenericTorch>();

        if (collidedTorch.pointLightOuterRadius > 0) {
            collidedTorch.pointLightOuterRadius -= enemyDamage;
        }

        yield return new WaitForSeconds(timeBetweenAttacks);

        inumFinished = false;

    }
}
