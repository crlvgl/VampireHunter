using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public static bool isAttacking = false;
    public static bool aiming = false;
    private Vector3 mousePos;
    private Vector2 mouse2d;
    public float timeBetweenShots = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.disableAllPause || PlayDialogue.disableAllDialogue)
        {
            return;
        }
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick button 2")) && !aiming)
        {
            if (!isAttacking)
            {
                isAttacking = true;
                StartCoroutine(MeleeAttack());
                PlayerAnimation.melee = true;
            }
        }
        
        if (Input.GetMouseButton(1) || Input.GetKey("10th Axis"))
        {
            aiming = true;
            if (!isAttacking && (Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick button 2")))
            {
                isAttacking = true;
                StartCoroutine(RangedAttack());
                PlayerAnimation.ranged = true;
            }
        }
        else
        {
            aiming = false;
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
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse2d = new Vector2(mousePos.x, mousePos.y);
        __staticInfoClass.projectileDirection = (mouse2d - new Vector2(transform.position.x, transform.position.y)).normalized;
        yield return new WaitForSeconds(timeBetweenShots);
        isAttacking = false;
    }
}
