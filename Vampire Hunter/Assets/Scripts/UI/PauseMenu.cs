using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool disableAllPause = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (this.transform.Find("SaveScreen").gameObject.activeSelf == false)
            {
                this.transform.Find("SaveScreen").gameObject.SetActive(true);
                disableAllPause = true;
            }
            else if (this.transform.Find("SaveScreen").gameObject.activeSelf == true)
            {
                this.transform.Find("SaveScreen").gameObject.SetActive(false);
                disableAllPause = false;
            }
        }
    }
}
