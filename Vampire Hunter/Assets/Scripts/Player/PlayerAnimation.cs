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
    public static bool melee;
    public static bool ranged;
    public static bool death;

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
            animator.SetBool("Walking_Left", true);
            animator.SetBool("Walking_Up", false);
            animator.SetBool("Walking_Down", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Dash", false);
            animator.SetBool("Melee", false);
            animator.SetBool("Ranged", false);
            animator.SetBool("Death", false);
        }
        else if (walk_up)
        {
            animator.SetBool("Walking_Left", false);
            animator.SetBool("Walking_Up", true);
            animator.SetBool("Walking_Down", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Dash", false);
            animator.SetBool("Melee", false);
            animator.SetBool("Ranged", false);
            animator.SetBool("Death", false);
        }
        else if (walk_down)
        {
            animator.SetBool("Walking_Left", false);
            animator.SetBool("Walking_Up", false);
            animator.SetBool("Walking_Down", true);
            animator.SetBool("Idle", false);
            animator.SetBool("Dash", false);
            animator.SetBool("Melee", false);
            animator.SetBool("Ranged", false);
            animator.SetBool("Death", false);
        }
        else if(idle)
        {
            animator.SetBool("Walking_Left", false);
            animator.SetBool("Walking_Up", false);
            animator.SetBool("Walking_Down", false);
            animator.SetBool("Idle", true);
            animator.SetBool("Dash", false);
            animator.SetBool("Melee", false);
            animator.SetBool("Ranged", false);
            animator.SetBool("Death", false);
        }
        else if(dash)
        {
            animator.SetBool("Walking_Left", false);
            animator.SetBool("Walking_Up", false);
            animator.SetBool("Walking_Down", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Dash", true);
            animator.SetBool("Melee", false);
            animator.SetBool("Ranged", false);
            animator.SetBool("Death", false);
        }
        else if (melee)
        {
            animator.SetBool("Walking_Left", false);
            animator.SetBool("Walking_Up", false);
            animator.SetBool("Walking_Down", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Dash", false);
            animator.SetBool("Melee", true);
            animator.SetBool("Ranged", false);
            animator.SetBool("Death", false);
        }
        else if (ranged)
        {
            animator.SetBool("Walking_Left", false);
            animator.SetBool("Walking_Up", false);
            animator.SetBool("Walking_Down", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Dash", false);
            animator.SetBool("Melee", false);
            animator.SetBool("Ranged", true);
            animator.SetBool("Death", false);
        }
        else if (death)
        {
            animator.SetBool("Walking_Left", false);
            animator.SetBool("Walking_Up", false);
            animator.SetBool("Walking_Down", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Dash", false);
            animator.SetBool("Melee", false);
            animator.SetBool("Ranged", false);
            animator.SetBool("Death", true);
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
