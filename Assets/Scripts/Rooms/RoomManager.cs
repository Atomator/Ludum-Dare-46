using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


//  [CustomEditor(typeof(RoomManager))]
//  public class RoomManagerEditor : Editor
//  {
//    override public void OnInspectorGUI()
//    {
//      var RoomManager = target as RoomManager;
 
//      RoomManager.isFinalLevel = GUILayout.Toggle(RoomManager.isFinalLevel, "Is Final Room");
     
//      if(RoomManager.isFinalLevel) {
//         RoomManager.roomEnemies = (GameObject) EditorGUILayout.ObjectField("Room Enemies", RoomManager.roomEnemies, typeof(GameObject), true);
//         RoomManager.levelPortal = (GameObject) EditorGUILayout.ObjectField("Exit Portal", RoomManager.levelPortal, typeof(GameObject), true);
//         var levelNameVar = EditorGUILayout.TextField("Next Level", RoomManager.levelName);
//         RoomManager.levelName = levelNameVar;

//      } else {
//         RoomManager.roomEnemies =  (GameObject) EditorGUILayout.ObjectField("Room Enemies", RoomManager.roomEnemies, typeof(GameObject), true);
//         RoomManager.exitDoorsRoom =  (GameObject) EditorGUILayout.ObjectField("Room Exit Doors", RoomManager.exitDoorsRoom, typeof(GameObject), true);
//      }
       
    
//     serializedObject.ApplyModifiedProperties();

//    }
//  }

public class RoomManager : MonoBehaviour
{
    public GameObject roomEnemies;

    public GameObject exitDoorsRoom;
    public GameObject levelPortal;

    public bool isFinalLevel;
    public string levelName;

    private float transitionTime = 1f;

    private bool ran = false;

    void Start()
    {
        roomEnemies.SetActive(false);
        if (isFinalLevel) {
            levelPortal.GetComponent<VortexCollision>().levelName = levelName;
            levelPortal.SetActive(false);   
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!ran && roomEnemies.transform.childCount == 0 && !isFinalLevel) {
            StartCoroutine(removeDoors());
        }

        else if (!ran && roomEnemies.transform.childCount == 0 && isFinalLevel) {
            levelPortal.SetActive(true);
        }

    }

    IEnumerator removeDoors() {
        exitDoorsRoom.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(2);
        exitDoorsRoom.SetActive(false);
        ran = true;
    }

    void OnTriggerEnter2D(Collider2D collided) {
        if (collided.gameObject.tag == "Player" || collided.gameObject.tag == "Payload") {
            roomEnemies.SetActive(true);
        }
    }
}
