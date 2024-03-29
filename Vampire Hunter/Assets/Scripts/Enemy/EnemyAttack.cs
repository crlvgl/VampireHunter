using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public static bool isAttacking = false;
    public float attackRange = 0.5f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.disableAllPause == true || PlayDialogue.disableAllDialogue == true)
        {
            return;
        }

        if (!isAttacking)
        {
            if (Vector3.Distance(player.transform.position, this.transform.position) < attackRange)
            {
                isAttacking = true;
                StartCoroutine(Attack());
            }
        }
    }

    IEnumerator Attack()
    {
        player.GetComponent<PlayerStatus>().health -= 10;
        EnemyAnimation.attack = true;
        EnemyAnimation.idle = false;
        EnemyAnimation.walk_down = false;
        EnemyAnimation.walk_left = false;
        EnemyAnimation.walk_right = false;
        EnemyAnimation.walk_up = false;
        yield return new WaitForSeconds(0.5f);
        EnemyAnimation.attack = false;
        EnemyAnimation.idle = true;
        yield return new WaitForSeconds(0.4f);
        isAttacking = false;
    }
}
