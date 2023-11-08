using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickAgentController : MonoBehaviour
{
     Vector3 target;
     Vector3 playerposition;
     Vector3 ownposition;
     float distance;
     public float treshold = 10.0f;

    // import agent component
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        // import agent component
        agent = GetComponent<NavMeshAgent>();
        // prevent Unity from turning agent out of 2d plane
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerposition = GameObject.Find("player").transform.position;
        ownposition = transform.position;
        distance = Vector3.Distance(playerposition, ownposition);
        Debug.Log("playerposition: "+ playerposition + "; ownposition: " + ownposition + "; distance: " + distance);
        if (distance <= treshold)
        {
            Debug.Log("should move");
            MoveAgent();
        }
    }

    void MoveAgent()
    {
        agent.SetDestination(new Vector3(playerposition.x, playerposition.y, transform.position.z));
    }
}
