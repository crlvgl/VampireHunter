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
    public static bool flip;
    private bool thisScript;

    SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        Debug.Log(animator.runtimeAnimatorController.name);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(walk_left + " " + walk_up + " " + walk_down + " " + dash + " " + idle);
        if (walk_left || walk_right)
        {
            if (walk_right)
            {
                flip = true;
                thisScript = true;
            }
            else
            {
                flip = false;
            }
            animator.SetBool("Walking_Left", true);
            animator.SetBool("Walking_Up", false);
            animator.SetBool("Walking_Down", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Dash", false);
            if (animator.runtimeAnimatorController.name == "Fangs_Armed")
            {
                animator.SetBool("Melee", false);
                animator.SetBool("Ranged", false);
                animator.SetBool("Death", false);
            }
        }
        else if (walk_up)
        {
            if (thisScript)
            {
                flip = false;
            }
            animator.SetBool("Walking_Left", false);
            animator.SetBool("Walking_Up", true);
            animator.SetBool("Walking_Down", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Dash", false);
            if (animator.runtimeAnimatorController.name == "Fangs_Armed")
            {
                animator.SetBool("Melee", false);
                animator.SetBool("Ranged", false);
                animator.SetBool("Death", false);
            }
        }
        else if (walk_down)
        {
            if (thisScript)
            {
                flip = false;
            }
            animator.SetBool("Walking_Left", false);
            animator.SetBool("Walking_Up", false);
            animator.SetBool("Walking_Down", true);
            animator.SetBool("Idle", false);
            animator.SetBool("Dash", false);
            if (animator.runtimeAnimatorController.name == "Fangs_Armed")
            {
                animator.SetBool("Melee", false);
                animator.SetBool("Ranged", false);
                animator.SetBool("Death", false);
            }
        }
        else if(idle)
        {
            if (thisScript)
            {
                flip = false;
            }
            animator.SetBool("Walking_Left", false);
            animator.SetBool("Walking_Up", false);
            animator.SetBool("Walking_Down", false);
            animator.SetBool("Idle", true);
            animator.SetBool("Dash", false);
            if (animator.runtimeAnimatorController.name == "Fangs_Armed")
            {
                animator.SetBool("Melee", false);
                animator.SetBool("Ranged", false);
                animator.SetBool("Death", false);
            }
        }
        else if(dash)
        {
            if (thisScript)
            {
                flip = false;
            }
            animator.SetBool("Walking_Left", false);
            animator.SetBool("Walking_Up", false);
            animator.SetBool("Walking_Down", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Dash", true);
            if (animator.runtimeAnimatorController.name == "Fangs_Armed")
            {
                animator.SetBool("Melee", false);
                animator.SetBool("Ranged", false);
                animator.SetBool("Death", false);
            }
        }
        else if (melee)
        {
            animator.SetBool("Walking_Left", false);
            animator.SetBool("Walking_Up", false);
            animator.SetBool("Walking_Down", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Dash", false);
            if (animator.runtimeAnimatorController.name == "Fangs_Armed")
            {
                animator.SetBool("Melee", true);
                animator.SetBool("Ranged", false);
                animator.SetBool("Death", false);
            }
        }
        else if (ranged)
        {
            animator.SetBool("Walking_Left", false);
            animator.SetBool("Walking_Up", false);
            animator.SetBool("Walking_Down", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Dash", false);
            if (animator.runtimeAnimatorController.name == "Fangs_Armed")
            {
                animator.SetBool("Melee", false);
                animator.SetBool("Ranged", true);
                animator.SetBool("Death", false);
            }
        }
        else if (death)
        {
            flip = false;
            animator.SetBool("Walking_Left", false);
            animator.SetBool("Walking_Up", false);
            animator.SetBool("Walking_Down", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Dash", false);
            if (animator.runtimeAnimatorController.name == "Fangs_Armed")
            {
                animator.SetBool("Melee", false);
                animator.SetBool("Ranged", false);
                animator.SetBool("Death", true);
                StartCoroutine(Death());
            }
        }
        if (flip)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(3.010f);
    }
}
