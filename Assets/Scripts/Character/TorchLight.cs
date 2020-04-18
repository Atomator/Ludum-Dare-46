using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TorchLight : MonoBehaviour
{
    
    public GameObject fireballPrefab;
    public Light2D torch;
    public float fireballForce = 10f;
    public float fireballEnergyNeeded = 0.2f;

    public float torchMax = 2f;
    
    // Start is called before the first frame update
    
    void Start() {
        torch.pointLightOuterRadius = torchMax;
    }
    
    void Shoot()
    {
        var worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        var direction = worldMousePosition - this.transform.position;
        direction.Normalize();
        
        GameObject fireball = Instantiate(fireballPrefab, this.transform.position, this.transform.rotation);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * fireballForce, ForceMode2D.Impulse);

        StartCoroutine(DestroyFireball(fireball));

        if (torch.pointLightOuterRadius > 0) {
            torch.pointLightOuterRadius -= fireballEnergyNeeded;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    IEnumerator DestroyFireball(GameObject toDestroy)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);

        //After we have waited 5 seconds print the time again.
        Destroy(toDestroy);
    }
}
