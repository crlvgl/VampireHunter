using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRandomDialogue : MonoBehaviour
{
    public Transform fangs;
    public float treshhold = 3.0f;
    public string trigger;
    public int randomLength = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.disableAllPause || PlayDialogue.disableAllDialogue)
        {
            return;
        }

        if (Vector2.Distance(this.transform.position, fangs.position) < treshhold && !this.transform.GetComponent<DialoguePopulator>().copied)
        {
            this.transform.Find("Interact").gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 1"))
            {
                StartCoroutine(Talk());
            }
        }
        else
        {
            this.transform.Find("Interact").gameObject.SetActive(false);
        }
    }

    IEnumerator Talk()
    {
        __staticInfoClass.dialogueTrigger = trigger;
        __staticInfoClass.randomLength = randomLength;
        PlayDialogue.random = true;
        yield return new WaitForSeconds(0.1f);
        PlayDialogue.InitiateDialogue();
    }
}
