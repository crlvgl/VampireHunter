using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCrystals : MonoBehaviour
{
    public float speed = 2f;
    public float movementRange = 1f;

    private Vector3 startingPosition;
    private float movement;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movement = Mathf.Sin(Time.time * speed) * movementRange;
        this.transform.position = new Vector3(startingPosition.x, startingPosition.y + movement, startingPosition.z);
    }
}
