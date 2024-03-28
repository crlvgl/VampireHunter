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

    // Start is called before the first frame update
    void Start()
    {
        line = this.transform.Find("Line").gameObject;
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
                isAttacking = true;
                StartCoroutine(MeleeAttack());
                PlayerAnimation.melee = true;
            }
        }
        
        if (Input.GetMouseButton(1)) //|| Input.GetAxis("RightTrigger") > 0)
        {
            //Debug.Log(true);
            line.SetActive(true);
            aiming = true;
            if (!isAttacking && (Input.GetMouseButton(0) || Input.GetKeyDown("joystick button 2")))
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
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
        {
            PlayerAnimation.flip = true;
        }
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
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
        {
            PlayerAnimation.flip = true;
        }
        yield return new WaitForSeconds(0.5f);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse2d = new Vector2(mousePos.x, mousePos.y);
        __staticInfoClass.projectileDirection = (mouse2d - new Vector2(transform.position.x, transform.position.y)).normalized;
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
}
