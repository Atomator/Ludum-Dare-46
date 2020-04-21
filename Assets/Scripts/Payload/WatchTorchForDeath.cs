using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;

public class WatchTorchForDeath : MonoBehaviour
{
    private Light2D genericTorch;
    public Animator transition;

    public float transitionTime = 1f;

    void Start () {
        genericTorch = this.gameObject.GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (genericTorch.pointLightOuterRadius <= 0.2) {
            // Death Scene
            StartCoroutine(LoadGameOver());
        }
    }

    IEnumerator LoadGameOver() {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("DeathScreen");
    }
}
