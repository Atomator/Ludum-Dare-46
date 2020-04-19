﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCollision : MonoBehaviour
{
    public float projectileDamage = 20f; 
    
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision) {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Enemy") {
            Destroy(this.gameObject);
            EnemyProperties Enemy = collider.gameObject.GetComponent<EnemyProperties>();
            Enemy.health -= projectileDamage;
        }
    }
}