using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WatchTorchForDeath : MonoBehaviour
{
    private GenericTorch genericTorch;
    public Animator transition;

    void Start () {
        genericTorch = this.gameObject.GetComponent<GenericTorch>();
    }

    // Update is called once per frame
    void Update()
    {
        if (genericTorch.currentLight <= 0.1) {

        }
    }
}
