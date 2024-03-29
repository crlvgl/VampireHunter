using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
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
        EnemyAnimation.death = true;
        EnemyAnimation.walk_left = false;
        EnemyAnimation.walk_right = false;
        EnemyAnimation.walk_up = false;
        EnemyAnimation.walk_down = false;
        EnemyAnimation.idle = false;
        EnemyAnimation.attack = false;
        yield return new WaitForSeconds(1.45f);
        Destroy(this.gameObject);
    }
}
