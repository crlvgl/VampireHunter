using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prologue : MonoBehaviour
{
    private bool hasStarted = false;
    private bool moveCamera = false;
    public float deadZone;
    public float camSpeed = 1.0f;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            StartCoroutine(cameraMover());
        }

        if (moveCamera && this.transform.position.y >= deadZone)
        {
            this.transform.position += new Vector3(0f, -camSpeed * Time.deltaTime, 0f);
        }
        else if (moveCamera && this.transform.position.y < deadZone)
        {
            player.GetComponent<PlayerMovement>().enabled = true;
            this.transform.GetComponent<PauseMenu>().enabled = true;
        }
    }

    IEnumerator cameraMover()
    {
        yield return new WaitForSeconds(3.0f);
        moveCamera = true;
    }
}
