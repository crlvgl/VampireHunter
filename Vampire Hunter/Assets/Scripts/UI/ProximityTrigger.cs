using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityTrigger : MonoBehaviour
{
    public GameObject player;
    public float treshhold;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.y - 10.0f), player.transform.position) <= treshhold)
        {
            this.transform.Find("Square").gameObject.SetActive(true);
            this.transform.GetComponent<SceneManager>().enabled = true;
        }
        else
        {
            this.transform.Find("Square").gameObject.SetActive(false);
            this.transform.GetComponent<SceneManager>().enabled = false;
        }
    }
}
