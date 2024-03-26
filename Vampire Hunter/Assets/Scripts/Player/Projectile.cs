using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 direction;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        direction = __staticInfoClass.projectileDirection;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.disableAllPause || PlayDialogue.disableAllDialogue)
        {
            return;
        }
        
        this.transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
    }
}
