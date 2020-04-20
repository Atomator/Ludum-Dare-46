using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class VortexCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public bool colliding = false;

    public int levelNumber = 2;

    public Animator transition;

    void OnTriggerStay2D(Collider2D collided) {
        if (collided.gameObject.tag == "Player") {
            colliding = true;
        } else {
            colliding = false;
        }
    }

    void Update () {
        if (colliding) {
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel() {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelNumber);
    }

}

