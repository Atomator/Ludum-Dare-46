using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerControlPayload : MonoBehaviour
{
    public Rigidbody2D payloadDestination;
    public GenericTorchRefill torchRefilling;

    public bool frozen = false;
    public bool noRefill = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2")) {
            if (frozen) {
                payloadDestination.constraints = RigidbodyConstraints2D.None;
                frozen = !frozen;
            } else {
                payloadDestination.constraints = RigidbodyConstraints2D.FreezePosition;
                frozen = !frozen;
            }
        }

        if ((Input.GetKeyDown(KeyCode.E))) {
            torchRefilling.isEnabled = !torchRefilling.isEnabled;
        }
    }
}
