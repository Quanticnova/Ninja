using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPlayers : MonoBehaviour {

    GameObject selectedButton;
    public GameObject player;
    public GameObject[] Players;
    public static int playerCount = 1, maxPlayerCount = 4, controllerCount = 1;

    Vector3 spawnPoint = Vector3.zero;      // link to spawn script
    public GameObject[] spawnPoints;

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
                player.layer = 8 + playerCount;
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
                //Instantiate(player, spawnPoint, Quaternion.identity);
                Instantiate(Players[playerCount - 1], spawnPoint, Quaternion.identity);//Set players 1 to 4
                playerCount++;
            }
            else if (playerCount >= maxPlayerCount)
            {
                transform.GetComponent<MenuSelect>().playersJoinBtn.gameObject.SetActive(false);
                transform.GetComponent<MenuSelect>().playerPanel2.SetActive(false);
                transform.GetComponent<MenuSelect>().playerPanel3.SetActive(false);
                transform.GetComponent<MenuSelect>().playerPanel4.SetActive(false);
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
