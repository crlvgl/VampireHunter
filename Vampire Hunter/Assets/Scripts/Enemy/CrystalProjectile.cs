using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalProjectile : MonoBehaviour
{
    private Vector2 direction;
    public float speed = 5f;
    public GameObject fangs;
    // Start is called before the first frame update
    void Start()
    {
        direction = __staticInfoClass.crystalProjectileDirection;
        fangs = GameObject.Find("Fangs 1").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.disableAllPause || PlayDialogue.disableAllDialogue)
        {
            return;
        }

        this.transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;

        if (Vector2.Distance(this.transform.position, fangs.transform.position) < 5.0f)
        {
            fangs.GetComponent<PlayerStatus>().health -= 10;
            Destroy(this.gameObject);
        }
        else if (Vector2.Distance(this.transform.position, new Vector2(fangs.transform.position.x, fangs.transform.position.y+2.0f)) < 5.0f)
        {
            fangs.GetComponent<PlayerStatus>().health -= 10;
            Destroy(this.gameObject);
        }
        else if (Vector2.Distance(this.transform.position, new Vector2(fangs.transform.position.x, fangs.transform.position.y-2.0f)) < 5.0f)
        {
            fangs.GetComponent<PlayerStatus>().health -= 10;
            Destroy(this.gameObject);
        }

        if (Vector2.Distance(this.transform.position, fangs.transform.position) > 400f)
        {
            Destroy(this.gameObject);
        }
    }
}
