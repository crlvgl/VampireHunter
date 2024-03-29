using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public static bool respawn = false;
    public GameObject respawnScreen;

    // Start is called before the first frame update
    void Start()
    {
        respawnScreen = this.transform.Find("Main Camera").gameObject.transform.Find("RespawnScreen").gameObject;
        respawnScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (respawn)
        {
            respawnScreen.SetActive(true);
        }
    }
}
