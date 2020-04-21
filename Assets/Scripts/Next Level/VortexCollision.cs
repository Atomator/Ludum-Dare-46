using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class VortexCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public bool collidingPlayer = false;
    public bool collidingPayload = false;

    public string levelName;

    public Animator transition;

    void OnTriggerStay2D(Collider2D collided) {
        if (collided.gameObject.tag == "Player") {
            collidingPlayer = true;
        }

        if (collided.gameObject.tag == "Payload") {
            collidingPayload = true;
        }
    }

    void Update () {
        if (collidingPlayer && collidingPayload) {
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel() {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelName);
    }

}

