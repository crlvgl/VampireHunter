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
    bool evade;
    bool controller = false;
    
    // modifiable variables
    public float moveLimiter = 0.7f;
    public float sprintModifier = 2.0f;
    public float evadeModifier = 50.0f;
    public float runSpeed = 20.0f;
    public string inputType = "keyboard"; // keyboard or controller

    // Start is called before the first frame update
    void Start()
    {
        // access Rigidbody
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // get WASD/Arrow/Controller inputs
        // 1 for up/right, -1 for down/left
        // dynamic return values for controllers
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
        // determine if controller or keyboard is used
        if (controller == false && ((vertical > 0 && vertical < 1) || (horizontal > 0 && horizontal < 1)))
        {
            controller = true;
            inputType = "controller";
        }
        // differentiate between controller and keyboard inputs
        if (inputType == "controller")
        {
            // get true for sprint and evade if triggered
            sprint = Input.GetKey("joystick button 0");
            evade = Input.GetKeyDown("joystick button 4");
        }
        else if (inputType == "keyboard")
        {
            // get true for sprint and evade if triggered
            sprint = Input.GetKey("left shift");
            evade = Input.GetKeyDown("left ctrl");
        }
    }

    void FixedUpdate()
    {
        if (inputType == "keyboard")
        {
            // if two axes are triggered simultaniously, values get reduced to avoid double speed on axis
            // not needed for controllers
            if (horizontal != 0 && vertical != 0)
            {
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }
        }
        // if evade is true, movement gets multipied once
        if (evade)
        {
            body.velocity = new Vector2(horizontal * runSpeed * evadeModifier, vertical * runSpeed * evadeModifier);
        }
        // if sprint is true, movement gets multiplied constantly
        else if (sprint)
        {
            body.velocity = new Vector2(horizontal * runSpeed * sprintModifier, vertical * runSpeed * sprintModifier);
        }
        // anything else will trigger normal movement
        else
        {
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
        
    }
}
