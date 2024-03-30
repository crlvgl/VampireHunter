using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public int health = 100;
    private int nihilHealth = 0;
    private GameObject artifact;

    // Start is called before the first frame update
    void Start()
    {
        if (this.name == "Crystal")
        {
            nihilHealth = Nihil.health / 4;
        }
        if (this.name == "SpecialVampir")
        {
            artifact = GameObject.Find("Artifact");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if (this.name == "Crystal")
            {
                Nihil.health -= nihilHealth;
                Destroy(this.gameObject);
            }
            else
            {
                StartCoroutine(Death());
            }
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
        __staticInfoClass.killed += 1;
        Debug.Log(__staticInfoClass.killed);
        artifact.SetActive(true);
        Destroy(this.gameObject);
    }
}
