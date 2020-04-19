using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1;

    public Animator animator;
    private bool moving;

    public void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h == 0 && v == 0) {
            moving = false;
        }
        else {
            moving = true;
        }
        

        animator.SetFloat("horizontalAxis", h);
        animator.SetFloat("verticalAxis", v);
        animator.SetBool("moving", moving);

        print("Horizontal: " + h);
        print("Vertical: " + v);

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        this.gameObject.GetComponent<Rigidbody2D>().MovePosition(this.gameObject.GetComponent<Rigidbody2D>().transform.position + tempVect);
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
