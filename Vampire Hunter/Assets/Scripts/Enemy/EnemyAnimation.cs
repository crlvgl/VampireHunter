using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer sprite;

    public static bool walk_left; // this time the correct way
    public static bool walk_right;
    public static bool walk_up;
    public static bool walk_down;
    public static bool idle;
    public static bool death;
    public static bool flip;
    public static bool attack;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        sprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (walk_left || walk_right)
        {
            if (walk_left)
            {
                flip = true;
            }
            else
            {
                flip = false;
            }

            SetFalse1("rLeft");
        }
        else if (walk_up)
        {
            SetFalse1("rUp");
        }
        else if (walk_down)
        {
            SetFalse1("rDown");
        }
        else if (idle)
        {
            SetFalse1("Idle");
        }
        else if (death)
        {
            SetFalse1("Death");
        }
        else if (attack)
        {
            SetFalse1("Attack");
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

    void SetFalse1(string trueAnimation)
    {
        animator.SetBool(trueAnimation, true);

        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            if (parameter.name != trueAnimation)
            {
                animator.SetBool(parameter.name, false);
            }
        }
    }
}
