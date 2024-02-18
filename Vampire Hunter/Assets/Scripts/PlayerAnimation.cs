using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public static bool walk;
    public static bool dash;
    public static bool idle;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(walk + " " + dash + " " + idle);
        if (walk)
        {
            animator.SetBool("Walking_Unarmed_Left", true);
            animator.SetBool("Idle_Unarmed", false);
            animator.SetBool("Dash_Unarmed", false);
        }
        else if(dash)
        {
            animator.SetBool("Walking_Unarmed_Left", false);
            animator.SetBool("Idle_Unarmed", false);
            animator.SetBool("Dash_Unarmed", true);
        }
        else if(idle)
        {
            animator.SetBool("Walking_Unarmed_Left", false);
            animator.SetBool("Idle_Unarmed", true);
            animator.SetBool("Dash_Unarmed", false);
        }
    }
}
