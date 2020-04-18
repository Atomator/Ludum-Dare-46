using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 100;
    public Rigidbody2D rb;

    public void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.transform.position + tempVect);
    }
    
    /* Another solution potentially better for detecting jumps and crouch and whatnot
     * public void Update()
     * {
     *      if (Input.GetKey(KeyCode.A))
     *          // A key has been pressed
     *      if (Input.GetKey(KeyCode.D))
     *          // D key has been pressed
     *      if (Input.GetKey(KeyCode.W))
     *          // W key has been pressed
     *      if (Input.GetKey(KeyCode.S))
     *          // S key has been pressed
     * }
     * Could use rb.AddForce(Vector3.<left/right>);
     */
}
