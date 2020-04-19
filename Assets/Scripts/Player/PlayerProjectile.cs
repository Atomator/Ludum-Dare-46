using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerProjectile : MonoBehaviour
{
    
    public GameObject fireballPrefab;
    public float fireballForce = 10f;
    public float fireballEnergyNeeded = 0.2f;

    public float timeToTillEvaporate = 0.2f;


    private Light2D playerTorch;


    void Start () {
        playerTorch = this.gameObject.GetComponent<Light2D>();
    }

    // Start is called before the first frame update
    void Shoot()
    {
        var worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        var localMousePosition = new Vector2(worldMousePosition.x, worldMousePosition.y);
        var localPlayerPosition = new Vector2(this.transform.position.x, this.transform.position.y);
        var direction = localMousePosition - localPlayerPosition;
        direction.Normalize();
        
        GameObject fireball = Instantiate(fireballPrefab, this.transform.position, this.transform.rotation);
        fireball.GetComponent<Rigidbody2D>().AddForce(direction * fireballForce, ForceMode2D.Impulse);
        StartCoroutine(DestroyFireball(fireball));

        if (playerTorch.pointLightOuterRadius > 0) {
            playerTorch.pointLightOuterRadius -= fireballEnergyNeeded;
        }
    }

    IEnumerator DestroyFireball(GameObject toDestroy)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(timeToTillEvaporate);

        //After we have waited 5 seconds print the time again.
        Destroy(toDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }
}
