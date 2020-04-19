using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerControlPayload : MonoBehaviour
{
    public Transform payloadMarker;
    public GenericTorchRefill torchRefilling;

    private Vector2 worldMousePosition;
    
    // Start is called before the first frame updat
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire2")) {
            worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            payloadMarker.position = worldMousePosition;

        }

        if ((Input.GetKeyDown(KeyCode.E))) {
            torchRefilling.isEnabled = !torchRefilling.isEnabled;
        }

    }
}
