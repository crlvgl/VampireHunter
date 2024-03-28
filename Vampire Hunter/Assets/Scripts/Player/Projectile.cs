using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 direction;
    public float speed = 5f;
    private List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        direction = __staticInfoClass.projectileDirection;

        enemies = new List<GameObject>();
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemies.Add(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.disableAllPause || PlayDialogue.disableAllDialogue)
        {
            return;
        }
        
        this.transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;

        CheckDamage();
    }

    void CheckDamage()
    {
        foreach (GameObject enemy in enemies)
        {
            if (Vector2.Distance(this.transform.position, enemy.transform.position) < 0.5f)
            {
                enemy.GetComponent<EnemyStatus>().health -= 25;
                Destroy(this.gameObject);
            }
        }
    }
}
