using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Script to controll agent movement
/// requires NavMesh with Navigation Surface and Navigation CollectSource2D
/// requires onjects with Navigation Modifier and declaration as (not) walkable
/// requires agent with NavMeshAgent
/// </summary>

public class ClickAgentController : MonoBehaviour
{
    // variables
     Vector3 target = new Vector3(0, 0, 0); // target coordinates for movement
     Vector3 targetPosition; // current coordinates of target
     Vector3 ownPosition; // own coordinates
     float targetDistance; // distance between agent and target
     Vector3 spawnPosition; // coordinates of agents spawn
     float spawnDistance; // distance between agent and agents spawn
     private float angle;

     // modifiable variables
     public float treshold = 10.0f; // maximal distance between agent and target for pursuit
     public string targetName = "player"; // targets Unity object name
     public float pursuitRadius = 50.0f; // radius for agent to pursue target

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
        // safe coordinates of agents spawn
        spawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.disableAllPause == true || PlayDialogue.disableAllDialogue == true || EnemyAttack.isAttacking == true)
        {
            return;
        }

        if (Mathf.Sqrt(Mathf.Pow(agent.velocity.x, 2) + Mathf.Pow(agent.velocity.y, 2)) > 0)
        {
            angle = Mathf.Abs(Mathf.Acos(agent.velocity.x / (Mathf.Sqrt(Mathf.Pow(agent.velocity.x, 2) + Mathf.Pow(agent.velocity.y, 2))))) * Mathf.Rad2Deg;

            if (agent.velocity.y >= this.transform.position.y)
            {
                if (angle <= 45)
                {
                    EnemyAnimation.walk_right = true;
                    EnemyAnimation.walk_left = false;
                    EnemyAnimation.walk_up = false;
                    EnemyAnimation.walk_down = false;
                    EnemyAnimation.idle = false;
                    EnemyAnimation.death = false;
                    EnemyAnimation.attack = false;
                }
                else if (angle > 45 && angle < 135)
                {
                    EnemyAnimation.walk_right = false;
                    EnemyAnimation.walk_left = false;
                    EnemyAnimation.walk_up = true;
                    EnemyAnimation.walk_down = false;
                    EnemyAnimation.idle = false;
                    EnemyAnimation.death = false;
                    EnemyAnimation.attack = false;
                }
                else if (angle >= 135)
                {
                    EnemyAnimation.walk_right = false;
                    EnemyAnimation.walk_left = true;
                    EnemyAnimation.walk_up = false;
                    EnemyAnimation.walk_down = false;
                    EnemyAnimation.idle = false;
                    EnemyAnimation.death = false;
                    EnemyAnimation.attack = false;
                }
            }
            else if (agent.velocity.y < this.transform.position.y)
            {
                if (angle <= 45)
                {
                    EnemyAnimation.walk_right = true;
                    EnemyAnimation.walk_left = false;
                    EnemyAnimation.walk_up = false;
                    EnemyAnimation.walk_down = false;
                    EnemyAnimation.idle = false;
                    EnemyAnimation.death = false;
                    EnemyAnimation.attack = false;
                }
                else if (angle > 45 && angle < 135)
                {
                    EnemyAnimation.walk_right = false;
                    EnemyAnimation.walk_left = false;
                    EnemyAnimation.walk_up = false;
                    EnemyAnimation.walk_down = true;
                    EnemyAnimation.idle = false;
                    EnemyAnimation.death = false;
                    EnemyAnimation.attack = false;
                }
                else if (angle >= 135)
                {
                    EnemyAnimation.walk_right = false;
                    EnemyAnimation.walk_left = true;
                    EnemyAnimation.walk_up = false;
                    EnemyAnimation.walk_down = false;
                    EnemyAnimation.idle = false;
                    EnemyAnimation.death = false;
                    EnemyAnimation.attack = false;
                }
            }
        }

        // get coordinates of target
        targetPosition = GameObject.Find(targetName).transform.position;
        // get own coordinates
        ownPosition = transform.position;
        // calculate distance between agent and target
        targetDistance = Vector3.Distance(targetPosition, ownPosition);
        // calculate distance between agent and spawn
        spawnDistance = Vector3.Distance(ownPosition, spawnPosition);

        // if target is in pursuit radius and closer than treshhold
        if (targetDistance <= treshold && spawnDistance <= pursuitRadius)
        {
            // set target to target position
            target = targetPosition;
            // move agent to target
            MoveAgent();
        }

        // if agent is too far from spawn or agent is too far from target and agent is not at spwan
        else if ((targetDistance > treshold || spawnDistance > pursuitRadius) && ownPosition != spawnPosition)
        {
            // set target to spawn position
            target = spawnPosition;
            // move agent to spawn
            MoveAgent();
        }
    }

    // move agent to defined target
    void MoveAgent()
    {
        // sets agent destination to x, y coordinates and keeps own z coordinate
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }
}
