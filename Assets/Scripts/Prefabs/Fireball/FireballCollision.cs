using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCollision : MonoBehaviour
{
    public float projectileDamage = 20f; 
    public float fireBallExplosionTime = 1.5f;
    
    public GameObject gObject;
    
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collided) {
        GameObject effect = Instantiate(gObject, transform.position, Quaternion.identity);
        Destroy(effect, fireBallExplosionTime);
        Destroy(this.gameObject);
        if (collided.gameObject.tag == "Enemy") {
            EnemyProperties Enemy = collided.gameObject.GetComponent<EnemyProperties>();
            Enemy.health -= projectileDamage;
        }
    }
    

    // void OnTriggerEnter2D(Collider2D collider) {
    //     if (collider.gameObject.tag == "Enemy") {
    //         Destroy(this.gameObject);
    //         EnemyProperties Enemy = collider.gameObject.GetComponent<EnemyProperties>();
    //         Enemy.health -= projectileDamage;
    //     }
    // }
}
