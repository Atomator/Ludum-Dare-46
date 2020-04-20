using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEnemies : MonoBehaviour
{
    
    public GameObject enemies;

    void Start()
    {
        enemies.SetActive(false);
    }

    // Update is called once per frame    void OnCollisionEnter2D(Collision2D collided) {
    void OnTriggerEnter2D(Collider2D collided) {
        if (collided.gameObject.tag == "Player") {
            enemies.SetActive(true);
        }
    }
}
