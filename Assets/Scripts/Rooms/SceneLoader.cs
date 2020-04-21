using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
 
 public class SceneLoader: MonoBehaviour {
 
      public Animator transition;
      public void LoadScene(string level)
      { 
         StartCoroutine(LoadSceneIenum(level));
      }

    IEnumerator LoadSceneIenum(string level) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(level);
    }
}

