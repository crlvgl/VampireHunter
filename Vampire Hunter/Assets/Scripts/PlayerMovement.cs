using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // access Rigidbody of Player
    Rigidbody2D body;

    // variables
    float horizontal;
    float vertical;
    bool sprint;
    bool dash;
    
    // modifiable variables
    public float moveLimiter = 0.7f;
    public float sprintModifier = 2.0f;
    public float dashModifier = 50.0f;
    public float runSpeed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        // access Rigidbody
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // get WASD/Arrow/Controller inputs !!controller currently not recommended!!
        // remove 1 for up/right, -1 for down/left
        // dynamic return values for controllers
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        // get true for sprint and dash
        sprint = Input.GetKey("left shift");
        dash = Input.GetKeyDown("left ctrl");
    }

    void FixedUpdate()
    {
        // if two axes are triggered simultaniously, values get reduced to avoid double speed on axis
        // not needed for controllers, so when controllers shuold be used, solution needed
        // thank me later for extra work, future me
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        // if dash is true, movement gets multipied once
        if (dash)
        {
            body.velocity = new Vector2(horizontal * runSpeed * dashModifier, vertical * runSpeed * dashModifier);
            Debug.Log("dash");
        }
        // if sprint is true, movement gets multiplied constantly
        else if (sprint)
        {
            body.velocity = new Vector2(horizontal * runSpeed * sprintModifier, vertical * runSpeed * sprintModifier);
            Debug.Log("sprint");
        }
        // anything else will trigger normal movement
        else
        {
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
    }
}
