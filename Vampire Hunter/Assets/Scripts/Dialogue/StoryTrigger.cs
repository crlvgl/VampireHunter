using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TriggerStory());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TriggerStory()
    {
        yield return new WaitForSeconds(5.0f);
        PlayBetterDialogue.enableDialogueSingle = true;
    }
}
