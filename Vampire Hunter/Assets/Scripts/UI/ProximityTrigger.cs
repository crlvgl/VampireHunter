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
        if (Vector2.Distance(this.transform.position, player.transform.position) <= treshhold)
        {
            this.transform.Find("Canvas").gameObject.SetActive(true);
            this.transform.GetComponent<SceneManager>().enabled = true;
        }
        else
        {
            this.transform.Find("Canvas").gameObject.SetActive(true);
            this.transform.GetComponent<SceneManager>().enabled = false;
        }
    }
}
