using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    public GameObject sceneManager;
    private GameObject interact;
    public GameObject fangs;

    // Start is called before the first frame update
    void Start()
    {
        interact = this.transform.Find("Interact").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(this.transform.position, fangs.transform.position) <= 10.0f)
        {
            interact.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 1"))
            {
                sceneManager.SetActive(true);
                Destroy(this.gameObject);
            }
        }        
    }
}
