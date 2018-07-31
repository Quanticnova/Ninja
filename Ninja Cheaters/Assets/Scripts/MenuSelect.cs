using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuSelect : MonoBehaviour {

    public static GameObject currentButton;     // ref SpawnPlayers
    public static Text buttonText;
    private AxisEventData currentAxis;
    public static bool joinedGame;

    public GameObject playerPanel2, playerPanel3, playerPanel4;

    private void Start()
    {
        playerPanel2.SetActive(false);
        playerPanel3.SetActive(false);
        playerPanel4.SetActive(false);
    }

    private void SelectButtons()    // analog stick movement
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

    private void OnClick()
    {
        if (currentButton && Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            Text buttonText = currentButton.GetComponentInChildren<Text>();
            buttonText.text = "Joined";
        }
    }

    private void JoinPlayerMenu()
    {
        if (playerPanel2.activeInHierarchy)
        {
            SpawnPlayers.maxPlayerCount = 2;
        }
        else if (playerPanel3.activeInHierarchy)
        {
            SpawnPlayers.maxPlayerCount = 3;
        }
        else if (playerPanel4.activeInHierarchy)
        {
            SpawnPlayers.maxPlayerCount = 4;
        }
    }

    private void Update()
    {
        JoinPlayerMenu();
        SelectButtons();
        OnClick();
    }
}
