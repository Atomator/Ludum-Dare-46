using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public Transform roomEnemies;

    public GameObject exitDoorsRoom;

    private bool ran = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ran && roomEnemies.childCount == 0) {
            StartCoroutine(removeDoors());
        }
    }

    IEnumerator removeDoors() {
        exitDoorsRoom.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(2);
        exitDoorsRoom.SetActive(false);
        ran = true;
    }
}
