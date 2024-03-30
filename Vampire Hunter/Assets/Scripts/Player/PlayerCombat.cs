using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public static bool isAttacking = false;
    public static bool aiming = false;
    private Vector3 mousePos;
    private Vector2 mouse2d;
    [Tooltip("Time between shots, must be at least 0.6")]
    public float timeBetweenShots = 1f;
    public GameObject line;
    public GameObject projectile;
    private bool controller = false;
    private float distanceToKill = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        line = this.transform.Find("Line").gameObject;

        if (__staticInfoClass.projectileScale != 0)
        {
            distanceToKill = distanceToKill * 15;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.disableAllPause || PlayDialogue.disableAllDialogue)
        {
            return;
        }
        if ((Input.GetMouseButton(0) || Input.GetKey("joystick button 2")) && !aiming)
        {
            if (!isAttacking)
            {
                if (Input.GetMouseButton(0))
                {
                    controller = false;
                }
                else if (Input.GetKey("joystick button 2"))
                {
                    controller = true;
                }
                isAttacking = true;
                StartCoroutine(MeleeAttack());
                PlayerAnimation.melee = true;
            }
        }
        
        if (Input.GetMouseButton(1) || Input.GetAxis("RightTrigger") >  0)
        {
            line.SetActive(true);
            if (Input.GetMouseButton(1))
            {
                AimLine.controller = false;
            }
            else if (Input.GetAxis("RightTrigger") > 0)
            {
                AimLine.controller = true;
            }
            aiming = true;
            if (!isAttacking && (Input.GetMouseButton(0) || Input.GetKey("joystick button 2")))
            {
                isAttacking = true;
                StartCoroutine(RangedAttack());
                PlayerAnimation.ranged = true;
            }
        }
        else
        {
            line.SetActive(false);
            aiming = false;
        }
    }

    IEnumerator MeleeAttack()
    {
        yield return new WaitForSeconds(0.1f);
        PlayerAnimation.ranged = false;
        PlayerAnimation.melee = true;
        PlayerAnimation.walk_left = false;
        PlayerAnimation.walk_right = false;
        PlayerAnimation.walk_up = false;
        PlayerAnimation.walk_down = false;
        PlayerAnimation.idle = false;
        PlayerAnimation.dash = false;
        if ((Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x && !controller) || (Input.GetAxis("Horizontal") < 0 && controller))
        {
            PlayerAnimation.flip = true;
        }
        DoMeleeDamage();
        yield return new WaitForSeconds(0.6f);
        PlayerAnimation.ranged = false;
        PlayerAnimation.melee = false;
        PlayerAnimation.walk_left = false;
        PlayerAnimation.walk_right = false;
        PlayerAnimation.walk_up = false;
        PlayerAnimation.walk_down = false;
        PlayerAnimation.idle = true;
        PlayerAnimation.dash = false;
        yield return new WaitForSeconds(0.26f);
        PlayerAnimation.flip = false;
        isAttacking = false;
    }

    IEnumerator RangedAttack()
    {
        PlayerAnimation.ranged = true;
        PlayerAnimation.melee = false;
        PlayerAnimation.walk_left = false;
        PlayerAnimation.walk_right = false;
        PlayerAnimation.walk_up = false;
        PlayerAnimation.walk_down = false;
        PlayerAnimation.idle = false;
        PlayerAnimation.dash = false;
        if ((Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x && !AimLine.controller) || (Input.GetAxis("Horizontal") < 0 && AimLine.controller))
        {
            PlayerAnimation.flip = true;
        }
        yield return new WaitForSeconds(0.5f);
        if (!AimLine.controller)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse2d = new Vector2(mousePos.x, mousePos.y);
            __staticInfoClass.projectileDirection = (mouse2d - new Vector2(transform.position.x, transform.position.y)).normalized;
        }
        else if (AimLine.controller)
        {
            __staticInfoClass.projectileDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }
        GameObject newProjectile = Instantiate(projectile, this.transform.position, Quaternion.Euler(0, 0, __staticInfoClass.projectileAngle));
        yield return new WaitForSeconds(0.1f);
        PlayerAnimation.ranged = false;
        PlayerAnimation.melee = false;
        PlayerAnimation.walk_left = false;
        PlayerAnimation.walk_right = false;
        PlayerAnimation.walk_up = false;
        PlayerAnimation.walk_down = false;
        PlayerAnimation.idle = true;
        PlayerAnimation.dash = false;
        yield return new WaitForSeconds(0.03f);
        PlayerAnimation.flip = false;
        yield return new WaitForSeconds(timeBetweenShots-0.6f);
        isAttacking = false;
    }

    void DoMeleeDamage()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (Vector2.Distance(enemy.transform.position, this.transform.position) < distanceToKill)
            {
                enemy.GetComponent<EnemyStatus>().health -= 20;
            }
        }
    }
}
