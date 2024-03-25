using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick button 3"))
        {
            if (!isAttacking)
            {
                isAttacking = true;
                StartCoroutine(MeleeAttack());
                PlayerAnimation.melee = true;
            }
        }
        else if (Input.GetMouseButtonDown(1) || Input.GetKeyDown("10th Axis"))
        {
            if (!isAttacking)
            {
                isAttacking = true;
                StartCoroutine(RangedAttack());
                PlayerAnimation.ranged = true;
            }
        }
    }

    IEnumerator MeleeAttack()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Melee Attack");
        isAttacking = false;
    }

    IEnumerator RangedAttack()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Ranged Attack");
        isAttacking = false;
    }
}
