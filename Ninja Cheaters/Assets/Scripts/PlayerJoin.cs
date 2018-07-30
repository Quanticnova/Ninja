using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerJoin : MonoBehaviour {

    public static GameObject currentButton;
    private AxisEventData currentAxis;

    private void SelectButtons()
    {
        currentAxis = new AxisEventData(EventSystem.current);
        currentButton = EventSystem.current.currentSelectedGameObject;

        if (Input.GetAxis("Horizontal") > 0)     // move right
        {
            currentAxis.moveDir = MoveDirection.Right;
            //ExecuteEvents.Execute(currentButton, currentAxis, ExecuteEvents.moveHandler);
        }
        else if (Input.GetAxis("Horizontal") < 0)    // move left
        {
            currentAxis.moveDir = MoveDirection.Left;
            //ExecuteEvents.Execute(currentButton, currentAxis, ExecuteEvents.moveHandler);
        }
    }

    private void Update()
    {
        SelectButtons();
    }
}
