using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemies : MonoBehaviour
{
    public List<GameObject> enemies;
    public List<GameObject> ranged;
    public GameObject fangs;
    public GameObject blankies;
    private SpriteRenderer blankiesR;
    public GameObject stopProgression;
    private bool deactivate = false;
    public float fadeSpeed = 0.35f;
    public int killTreshhold;

    // Start is called before the first frame update
    void Start()
    {
        blankiesR = blankies.transform.GetComponent<SpriteRenderer>();
        stopProgression = this.transform.Find("collider").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(this.transform.position, fangs.transform.position) < 8.0f && __staticInfoClass.killed >= killTreshhold)
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.transform.GetComponent<EnemyAttack>().enabled = true;
                enemy.transform.GetComponent<EnemyStatus>().enabled = true;
                enemy.transform.GetComponent<ClickAgentController>().enabled = true;
            }

            if (ranged.Count > 0)
            {
                foreach (GameObject enemy in ranged)
                {
                    enemy.transform.GetComponent<EnemyStatus>().enabled = true;
                }
            }

            if (blankiesR.color.a > 0)
            {
                blankiesR.color = new Color(0.0f, 0.0f, 0.0f, (blankiesR.color.a - Time.deltaTime * fadeSpeed));
            }
            else
            {
                deactivate = true;
            }

            Debug.Log(__staticInfoClass.killed);
            Debug.Log(Vector2.Distance(this.transform.position, fangs.transform.position));
        }

        if (deactivate)
        {
            Destroy(blankies);
            Destroy(stopProgression);
            Destroy(this.gameObject);
        }
    }
}
