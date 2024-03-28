using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLine : MonoBehaviour
{
    public Transform line;
    private float angle;
    private Vector2 mouseCoordinates;

    // Start is called before the first frame update
    void Start()
    {
        line = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        mouseCoordinates = Camera.main.ScreenToWorldPoint(Input.mousePosition) - line.position;
        
        angle = Mathf.Acos(mouseCoordinates.x / (1 + Mathf.Sqrt(Mathf.Pow(mouseCoordinates.x, 2) + Mathf.Pow(mouseCoordinates.y, 2)))) * Mathf.Rad2Deg;

        if (mouseCoordinates.y >= 0)
        {
            line.rotation = Quaternion.Euler(0, 0, angle);
            __staticInfoClass.projectileAngle = angle;
        }
        else if (mouseCoordinates.y < 0)
        {
            line.rotation = Quaternion.Euler(0, 0, -angle);
            __staticInfoClass.projectileAngle = -angle;
        }
    }
}
