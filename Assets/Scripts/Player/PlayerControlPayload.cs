using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerControlPayload : MonoBehaviour
{
    public Transform payloadMarker;
    
    public GameObject payloadTorch;
    
    private Color payloadDefault;

    public Color payloadHealing;

    private Light2D payloadTorchLight;

    private Vector2 worldMousePosition;
    private bool isHealing = true;
    
    // Start is called before the first frame updat
    // Update is called once per frame
    
    void Start() {
        payloadTorchLight = payloadTorch.GetComponent<Light2D>();
        payloadDefault = payloadTorchLight.color;
        payloadTorchLight.color = payloadHealing;
    }
    
    void Update()
    {
        
        if (Input.GetButtonDown("Fire2")) {
            worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            payloadMarker.position = worldMousePosition;

        }

        if ((Input.GetKeyDown(KeyCode.E))) {
            payloadTorch.GetComponent<GenericTorchRefill>().isEnabled = !payloadTorch.GetComponent<GenericTorchRefill>().isEnabled;
            isHealing = !isHealing;

            if (isHealing) {
                payloadTorchLight.color = payloadHealing;
            } else {
                payloadTorchLight.color = payloadDefault;
            }

        }

    }
}
