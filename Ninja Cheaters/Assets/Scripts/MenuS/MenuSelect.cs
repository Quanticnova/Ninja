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
    public GameObject modeSelectMenu;

    public Button playersJoinBtn;

    private void Start()
    {
        modeSelectMenu.SetActive(true);
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

    private void OnClickPlayerMenu()
    {
        if (currentButton && Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            if (!modeSelectMenu.activeInHierarchy)
            {
                Text buttonText = currentButton.GetComponentInChildren<Text>();
                buttonText.text = "Joined";
            }

        }
    }

    public void OnPlayerModeSelect()
    {
        if (currentButton && Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            Text buttonText = currentButton.GetComponentInChildren<Text>();
            if (buttonText.text == "2 Players")
            {
                playerPanel2.SetActive(true);
                modeSelectMenu.SetActive(false);
            }
            else if (buttonText.text == "3 Players")
            {
                playerPanel3.SetActive(true);
                modeSelectMenu.SetActive(false);
            }
            else if (buttonText.text == "4 Players")
            {
                playerPanel4.SetActive(true);
                modeSelectMenu.SetActive(false);
            }
        }
    }

    private void Join()
    {
        playersJoinBtn.gameObject.SetActive(true);
        playersJoinBtn.Select();
        transform.GetComponent<sc_Camera_Split>().MakeCameras();
    }

    private void JoinPlayerMenu()
    {
        if (playerPanel2.activeInHierarchy)
        {
            SpawnPlayers.maxPlayerCount = 2;
            sc_Camera_Split.numPlayers = 2;
            Join();
        }
        else if (playerPanel3.activeInHierarchy)
        {
            SpawnPlayers.maxPlayerCount = 3;
            sc_Camera_Split.numPlayers = 3;
            Join();
        }
        else if (playerPanel4.activeInHierarchy)
        {
            SpawnPlayers.maxPlayerCount = 4;
            sc_Camera_Split.numPlayers = 4;
            Join();
        }
        else
        {
            playersJoinBtn.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        JoinPlayerMenu();
        SelectButtons();
        OnClickPlayerMenu();
        OnPlayerModeSelect();
    }
}
