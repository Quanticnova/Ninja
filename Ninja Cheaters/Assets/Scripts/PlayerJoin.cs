using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerJoin : MonoBehaviour {

    private GameObject currentButton;
    private AxisEventData currentAxis;

    private float timeBetweenInputs = 0.15f, timer = 0;

    private void Update()
    {
        if(timer == 0)
        {
            currentAxis = new AxisEventData(EventSystem.current);
            currentButton = EventSystem.current.currentSelectedGameObject;

            if (Input.GetAxis("HorizontalJoy") > 0)     // move right
            {
                currentAxis.moveDir = MoveDirection.Right;
                ExecuteEvents.Execute(currentButton, currentAxis, ExecuteEvents.moveHandler);
                timer = timeBetweenInputs;
            }
            else if (Input.GetAxis("HorizontalJoy") < 0)    // move left
            {
                currentAxis.moveDir = MoveDirection.Left;
                ExecuteEvents.Execute(currentButton, currentAxis, ExecuteEvents.moveHandler);
                timer = timeBetweenInputs;
            }
        }

        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
        }
    }
}
