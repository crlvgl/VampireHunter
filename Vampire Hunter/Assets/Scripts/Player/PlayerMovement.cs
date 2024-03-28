using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to move the player character.
/// The character can be controlled with a keyboard or a controller.
/// The character can walk, walk faster, sprint and evade.
/// </summary>

public class PlayerMovement : MonoBehaviour
{
    // access Rigidbody of Player
    Rigidbody2D body;

    // variables
    float horizontal; // horizontal value of left joystick / A D keys
    float vertical; // vertical value of left joystick / W S keys
    bool sprint = false; // boolean with sprint option
    bool evade = false; // boolean with evasion option, 2 frames (doubles)
    bool evadeAgain = false; // boolean to deactivade evasion next frame
    int evadeCount; // amount of remaining evasion frames
    bool walk = false; // boolean with walking option
    private bool tempDisableAnim = true;
    
    // modifiable variables
    public float moveLimiter = 0.7f; // movement speed limiter for keyboard inputs
    public float walkModifier = 0.5f; // modifier for walking speed from normal speed
    public float sprintModifier = 2.0f; // modifier for sprinting speed from normal speed
    public float evadeModifier = 50.0f; // modifier for evasion speed from normal speed
    public int evadeFrames = 2; // amount of frames to evade
    public float runSpeed = 20.0f; // normal walking speed
    public bool controller = false; // input type; false = keyboard, true = controller

    // Start is called before the first frame update
    void Start()
    {
        // access Rigidbody
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.disableAllPause == true || PlayerCombat.isAttacking == true || PlayerCombat.aiming == true || PlayDialogue.disableAllDialogue == true)
        {
            return;
        }

        // get WASD/Arrow/Controller inputs
        // 1 for up/right, -1 for down/left
        // dynamic return values for controllers
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
        // determine if controller or keyboard is used (if keyboard and axis 0 < value < 1 = controller)
        if (controller == false && ((vertical > 0 && vertical < 1) || (horizontal > 0 && horizontal < 1)))
        {
            // set input type to controller
            controller = true;
        }
        // if controller and w a s d keys are used
        else if (controller == true && (Input.GetKeyDown("w") || Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d")))
        {
            // set input type to keyboard
            controller = false;
        }
        // get true for sprint and evade if triggered
        sprint = false;
        // for sprint
        if (Input.GetKey("joystick button 0") || Input.GetKey("left shift"))
        {
            sprint = true;
        }
        if (horizontal == 0 && vertical == 0)
        {
            PlayerAnimation.walk_left = false;
            PlayerAnimation.walk_right = false;
            PlayerAnimation.walk_up = false;
            PlayerAnimation.walk_down = false;
            PlayerAnimation.idle = true;
            PlayerAnimation.dash = false;
        }
        else
        {
            if (horizontal == 0)
            {
                if (vertical > 0)
                {
                    PlayerAnimation.walk_left = false;
                    PlayerAnimation.walk_right = false;
                    PlayerAnimation.walk_up = true;
                    PlayerAnimation.walk_down = false;
                    PlayerAnimation.idle = false;
                    PlayerAnimation.dash = false;
                }
                else if (vertical < 0)
                {
                    PlayerAnimation.walk_left = false;
                    PlayerAnimation.walk_right = false;
                    PlayerAnimation.walk_up = false;
                    PlayerAnimation.walk_down = true;
                    PlayerAnimation.idle = false;
                    PlayerAnimation.dash = false;
                }
            }
            else if (horizontal > 0)
            {
                if (vertical == 0)
                {
                    PlayerAnimation.walk_left = true;
                    PlayerAnimation.walk_right = false;
                    PlayerAnimation.walk_up = false;
                    PlayerAnimation.walk_down = false;
                    PlayerAnimation.idle = false;
                    PlayerAnimation.dash = false;
                }
                else if (vertical == 1)
                {
                    PlayerAnimation.walk_left = false;
                    PlayerAnimation.walk_right = false;
                    PlayerAnimation.walk_up = true;
                    PlayerAnimation.walk_down = false;
                    PlayerAnimation.idle = false;
                    PlayerAnimation.dash = false;
                }
                else if (vertical == -1)
                {
                    PlayerAnimation.walk_left = false;
                    PlayerAnimation.walk_right = false;
                    PlayerAnimation.walk_up = false;
                    PlayerAnimation.walk_down = true;
                    PlayerAnimation.idle = false;
                    PlayerAnimation.dash = false;
                }
                else
                {
                    if (45 >= Mathf.Abs(Mathf.Acos(horizontal / Mathf.Sqrt(Mathf.Pow(horizontal, 2) + Mathf.Pow(vertical, 2)))) * Mathf.Rad2Deg)
                    {
                        PlayerAnimation.walk_left = true;
                        PlayerAnimation.walk_right = false;
                        PlayerAnimation.walk_up = false;
                        PlayerAnimation.walk_down = false;
                        PlayerAnimation.idle = false;
                        PlayerAnimation.dash = false;
                    }
                    else
                    {
                        if (vertical > 0)
                        {
                            PlayerAnimation.walk_left = false;
                            PlayerAnimation.walk_right = false;
                            PlayerAnimation.walk_up = true;
                            PlayerAnimation.walk_down = false;
                            PlayerAnimation.idle = false;
                            PlayerAnimation.dash = false;
                        }
                        else if (vertical < 0)
                        {
                            PlayerAnimation.walk_left = false;
                            PlayerAnimation.walk_right = false;
                            PlayerAnimation.walk_up = false;
                            PlayerAnimation.walk_down = true;
                            PlayerAnimation.idle = false;
                            PlayerAnimation.dash = false;
                        }
                    }
                }
            }
            else if (horizontal < 0)
            {
                if (vertical == 0)
                {
                    PlayerAnimation.walk_left = false;
                    PlayerAnimation.walk_right = true;
                    PlayerAnimation.walk_up = false;
                    PlayerAnimation.walk_down = false;
                    PlayerAnimation.idle = false;
                    PlayerAnimation.dash = false;
                }
                else if (vertical == 1)
                {
                    PlayerAnimation.walk_left = false;
                    PlayerAnimation.walk_right = false;
                    PlayerAnimation.walk_up = true;
                    PlayerAnimation.walk_down = false;
                    PlayerAnimation.idle = false;
                    PlayerAnimation.dash = false;
                }
                else if (vertical == -1)
                {
                    PlayerAnimation.walk_left = false;
                    PlayerAnimation.walk_right = false;
                    PlayerAnimation.walk_up = false;
                    PlayerAnimation.walk_down = true;
                    PlayerAnimation.idle = false;
                    PlayerAnimation.dash = false;
                }
                else
                {
                    Debug.Log(horizontal + " " + vertical);
                    if (45 >= Mathf.Abs(Mathf.Acos((horizontal * -1) / Mathf.Sqrt(Mathf.Pow(horizontal, 2) + Mathf.Pow(vertical, 2)))) * Mathf.Rad2Deg)
                    {
                        PlayerAnimation.walk_left = false;
                        PlayerAnimation.walk_right = true;
                        PlayerAnimation.walk_up = false;
                        PlayerAnimation.walk_down = false;
                        PlayerAnimation.idle = false;
                        PlayerAnimation.dash = false;
                    }
                    else
                    {
                        if (vertical > 0)
                        {
                            PlayerAnimation.walk_left = false;
                            PlayerAnimation.walk_right = false;
                            PlayerAnimation.walk_up = true;
                            PlayerAnimation.walk_down = false;
                            PlayerAnimation.idle = false;
                            PlayerAnimation.dash = false;
                        }
                        else if (vertical < 0)
                        {
                            PlayerAnimation.walk_left = false;
                            PlayerAnimation.walk_right = false;
                            PlayerAnimation.walk_up = false;
                            PlayerAnimation.walk_down = true;
                            PlayerAnimation.idle = false;
                            PlayerAnimation.dash = false;
                        }
                    }
                }
            }
        }

        // for evade
        if ((Input.GetKeyDown("joystick button 4") || Input.GetKeyDown("left ctrl")) && evadeAgain == false)
        {
            evade = true;
            PlayerAnimation.walk_left = false;
            PlayerAnimation.walk_up = false;
            PlayerAnimation.walk_down = false;
            PlayerAnimation.idle = false;
            PlayerAnimation.dash = true;
        }
        // for walking
        // if key is pressed or player walks
        if (Input.GetKeyDown("joystick button 7") || Input.GetKeyDown("left alt") || evade || sprint)
        {
            // if player walks or sprints / evades
            if (walk || evade || sprint)
            {
                // stop walking
                walk = false;
            }
            // if player doesnt walk or sprint / evade
            else if (walk == false)
            {
                // start walking
                walk = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (PauseMenu.disableAllPause == true || PlayerCombat.isAttacking == true || PlayerCombat.aiming == true || PlayDialogue.disableAllDialogue == true)
        {
            body.velocity = new Vector2(0, 0);
            if (tempDisableAnim)
            {
                PlayerAnimation.walk_left = false;
                PlayerAnimation.walk_right = false;
                PlayerAnimation.walk_up = false;
                PlayerAnimation.walk_down = false;
                PlayerAnimation.idle = true;
                PlayerAnimation.dash = false;
                tempDisableAnim = false;
            }
            return;
        }

        tempDisableAnim = true;

        // if keyboard is used
        if (controller == false)
        {
            // if two axes are triggered simultaniously, values get reduced to avoid double speed on axis
            // not needed for controllers
            if (horizontal != 0 && vertical != 0)
            {
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }
        }
        // if evade is true, movement gets multipied for evade frames count
        if (evade || evadeAgain)
        {
            body.velocity = new Vector2(horizontal * runSpeed * evadeModifier, vertical * runSpeed * evadeModifier);

            evade = false; // set evade to false
            PlayerAnimation.walk_left = false;
            PlayerAnimation.walk_up = false;
            PlayerAnimation.walk_down = false;
            PlayerAnimation.idle = false;
            PlayerAnimation.dash = true;
            
            if (evadeAgain && evadeCount == 1) // if evaded last time
            {
                evadeAgain = false; // deactivate evadeAgain
            }
            else if (evadeAgain && evadeCount > 1) // if evaded between second and seconfd to last times
            {
                evadeCount -= 1; // reduce remaining evasions by 1
            }
            else if (evadeAgain == false) // if evaded first time
            {
                evadeAgain = true; // activate evadeAgain
                evadeCount = evadeFrames; // set remaining evasions
            }
        }
        // if sprint is true, movement gets multiplied constantly
        else if (sprint)
        {
            body.velocity = new Vector2(horizontal * runSpeed * sprintModifier, vertical * runSpeed * sprintModifier);
        }
        // while walk is true, movement gets multiplied constantly
        else if (walk)
        {
            body.velocity = new Vector2(horizontal * runSpeed * walkModifier, vertical * runSpeed * walkModifier);
        }
        // anything else will trigger normal movement
        else
        {
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
        
    }
}
