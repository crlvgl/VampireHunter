using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public static bool walk_left; // is the other way around, i messed up the names
    public static bool walk_right;  // is the other way around, i messed up the names
    public static bool walk_up;
    public static bool walk_down;
    public static bool dash;
    public static bool idle;

    SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(walk_left + " " + walk_up + " " + walk_down + " " + dash + " " + idle);
        if (walk_left || walk_right)
        {
            animator.SetBool("Walking_Unarmed_Left", true);
            animator.SetBool("Walking_Unarmed_Up", false);
            animator.SetBool("Walking_Unarmed_Down", false);
            animator.SetBool("Idle_Unarmed", false);
            animator.SetBool("Dash_Unarmed", false);
        }
        else if (walk_up)
        {
            animator.SetBool("Walking_Unarmed_Left", false);
            animator.SetBool("Walking_Unarmed_Up", true);
            animator.SetBool("Walking_Unarmed_Down", false);
            animator.SetBool("Idle_Unarmed", false);
            animator.SetBool("Dash_Unarmed", false);
        }
        else if (walk_down)
        {
            animator.SetBool("Walking_Unarmed_Left", false);
            animator.SetBool("Walking_Unarmed_Up", false);
            animator.SetBool("Walking_Unarmed_Down", true);
            animator.SetBool("Idle_Unarmed", false);
            animator.SetBool("Dash_Unarmed", false);
        }
        else if(idle)
        {
            animator.SetBool("Walking_Unarmed_Left", false);
            animator.SetBool("Walking_Unarmed_Up", false);
            animator.SetBool("Walking_Unarmed_Down", false);
            animator.SetBool("Idle_Unarmed", true);
            animator.SetBool("Dash_Unarmed", false);
        }
        else if(dash)
        {
            animator.SetBool("Walking_Unarmed_Left", false);
            animator.SetBool("Walking_Unarmed_Up", false);
            animator.SetBool("Walking_Unarmed_Down", false);
            animator.SetBool("Idle_Unarmed", false);
            animator.SetBool("Dash_Unarmed", true);
        }
        if (walk_right)
        {
            sprite.flipX = true;
            Debug.Log("works");
        }
        else
        {
            sprite.flipX = false;
        }
    }
}
