using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public Animator animator;
    public int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        PauseMenu.disableAllPause = true;
        PlayerAnimation.death = true;
        PlayerAnimation.walk_left = false;
        PlayerAnimation.walk_right = false;
        PlayerAnimation.walk_up = false;
        PlayerAnimation.walk_down = false;
        PlayerAnimation.idle = false;
        PlayerAnimation.melee = false;
        PlayerAnimation.ranged = false;
        PlayerAnimation.dash = false;
        yield return new WaitForSeconds(1.45f);
        animator.enabled = false;
        Respawn.respawn = true;
    }
}
