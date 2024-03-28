using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLine : MonoBehaviour
{
    public Transform line;
    private float angle;
    private Vector2 mouseCoordinates;
    public static bool controller = false;
    private Vector2 controllerDirtection;

    // Start is called before the first frame update
    void Start()
    {
        line = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.disableAllPause || PlayDialogue.disableAllDialogue)
        {
            return;
        }
        
        if (controller == false)
        {
            mouseCoordinates = Camera.main.ScreenToWorldPoint(Input.mousePosition) - line.position;
        
            angle = Mathf.Acos(mouseCoordinates.x / (Mathf.Sqrt(Mathf.Pow(mouseCoordinates.x, 2) + Mathf.Pow(mouseCoordinates.y, 2)))) * Mathf.Rad2Deg;

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
        else if (controller == true)
        {
            controllerDirtection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (controllerDirtection == Vector2.zero)
            {
                return;
            }
            angle = Mathf.Acos(controllerDirtection.x / (Mathf.Sqrt(Mathf.Pow(controllerDirtection.x, 2) + Mathf.Pow(controllerDirtection.y, 2)))) * Mathf.Rad2Deg;

            if (controllerDirtection.y >= 0)
            {
                line.rotation = Quaternion.Euler(0, 0, angle);
                __staticInfoClass.projectileAngle = angle;
            }
            else if (controllerDirtection.y < 0)
            {
                line.rotation = Quaternion.Euler(0, 0, -angle);
                __staticInfoClass.projectileAngle = -angle;
            }
        }
    }
}
