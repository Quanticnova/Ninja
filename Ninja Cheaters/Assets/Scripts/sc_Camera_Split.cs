using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_Camera_Split : MonoBehaviour
{   // Splits cameras, screens for each player based on number of players [2,4]
    // must: make settings for 2,
    // 3,
    // 4 players, then
    // position them correctly.
    public int numPlayers = 0;

    public Camera camPlayer01;
    public Camera camPlayer02;
    public Camera camPlayer03;
    public Camera camPlayer04;

    public GameObject camDefault;



    private void Start()
    {
        numPlayers = 3;
        MakeCameras();
    }

    void Update ()
    {
        ValidateNumPlayers();
	}



    void MakeCameras()
    {   // check number of players and assign cameras
        if (numPlayers == 2)
        {   // 2 player setting. On 1, 2. Off 3, 4. Split screen vertically
            camPlayer01.enabled = true;
            camPlayer02.enabled = true;
            camPlayer03.enabled = false;
            camPlayer04.enabled = false;

            camPlayer01.rect = new Rect(0f, 0f, 0.5f, 1f);    // left
            camPlayer02.rect = new Rect(0.5f, 0f, 0.5f, 1f);    // right
            SwitchOffDefault();
        } else 
        if (numPlayers == 3)
        {   // 3 player setting. On 1, 2, 3. Off 4. Split screen vertically, horizontally and center bottom camera
            camPlayer01.enabled = true;
            camPlayer02.enabled = true;
            camPlayer03.enabled = true;
            camPlayer04.enabled = false;

            camPlayer01.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);    // top left corner
            camPlayer02.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);    // top right corner
            camPlayer03.rect = new Rect(0.25f, 0f, 0.5f, 0.5f);    // bottom center
            SwitchOffDefault();
        } else
        if (numPlayers == 4)
        {   // 4 player setting. On 1, 2, 3, 4. Split screen vertically, horizontally as a grid
            camPlayer01.enabled = true;
            camPlayer02.enabled = true;
            camPlayer03.enabled = true;
            camPlayer04.enabled = true;

            camPlayer01.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);    // top left corner
            camPlayer02.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);    // top right corner
            camPlayer03.rect = new Rect(0f, 0f, 0.5f, 0.5f);    // bottom left corner
            camPlayer04.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);    // bottom right corner
            SwitchOffDefault();
        }
    }

    void SwitchOffDefault()
    {
        camDefault = GameObject.FindGameObjectWithTag("MainCamera");
        camDefault.GetComponent<Camera>().enabled = false;
    }

    void ValidateNumPlayers()
    {   // check if there is an error in the number of players detected
        if (numPlayers > 4 || numPlayers < 2)
        {
            Debug.Log("ERROR: Wrong number of players detected");
        }
    }

    void FindCameras()
    {   // WIP, finds cameras corresponding to each player

    }
}