using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPlayers : MonoBehaviour {

    GameObject selectedButton;
    public GameObject player;
    public static int playerCount = 1, maxPlayerCount = 4, controllerCount = 1;

    Vector3 spawnPoint = Vector3.zero;      // link to spawn script

    void Start ()
    {
        selectedButton = MenuSelect.currentButton;
        //player = GameObject.FindGameObjectWithTag("Player");
	}

    private void setPlayerName()
    {
        // click on button to execute command
        if (MenuSelect.currentButton && Input.GetKeyDown(KeyCode.JoystickButton1))     // X
        {
            if (playerCount > 0 && playerCount <= maxPlayerCount)
            {
                player.name = "Player " + playerCount;
                Instantiate(player, Vector3.zero, Quaternion.identity);
                playerCount++;
            }
        }
    }

    private void setControllerName()
    {
        if (MenuSelect.currentButton && Input.GetKeyDown(KeyCode.JoystickButton1))     // X
        {
            if (controllerCount > 0 && controllerCount < 5)
            {
                for (int i = 0; i < 4; i = 4)
                {
                    print(Input.GetJoystickNames()[i] + " " + controllerCount + " has selected a thing");
                    controllerCount++;
                }
            }
        }
    }
	
	void Update ()
    {
        setPlayerName();
        setControllerName();
    }
}
