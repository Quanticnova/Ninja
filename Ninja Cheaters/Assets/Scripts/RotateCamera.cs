using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public static GameObject target;
    private GameObject[] menus;
    public float rotateSpeed = 0.5f, height = 5f; float maxRotateSpeed;
    float horizontalRotation; // axis

    public string playerName;

    Vector3 offset;
    Quaternion rotation;

    void Start()
    {
        maxRotateSpeed = rotateSpeed;

        //target = GameObject.FindGameObjectsWithTag("Player");     // assign player number to camera number

        menus = GameObject.FindGameObjectsWithTag("playerSelect");

        // offset = target.transform.position - transform.position;
    }

    private void DefineAxes()       // Player rotation
    {
            if (playerName == "Player 1(Clone)")
            {
                horizontalRotation = Input.GetAxis("Player1RotateX") * rotateSpeed;
            }
            else if (playerName == "Player 2(Clone)")
            {
                horizontalRotation = Input.GetAxis("Player2RotateX") * rotateSpeed;
            }
            else if (playerName == "Player 3(Clone)")
            {
                horizontalRotation = Input.GetAxis("Player3RotateX") * rotateSpeed;
            }
            else if (playerName == "Player 4(Clone)")
            {
                horizontalRotation = Input.GetAxis("Player4RotateX") * rotateSpeed;
            }

    }

    void RotatePlayer()
    {
        //transform.position = target.transform.position - (rotation * offset);   // angle of camera:player
        target.transform.Rotate(0, horizontalRotation, 0);  

        //transform.LookAt(target.transform);
    }

    void LateUpdate()
    {
        target = GameObject.Find(playerName);
        DefineAxes();


        for (int i = 0; i < menus.Length; i ++)
        {
             if (!menus[i].activeInHierarchy && target != null)     // make sure player moves when menus are closed
             {
                 transform.rotation = target.transform.rotation;
                 transform.position = new Vector3(target.transform.position.x, target.transform.position.y + height, target.transform.position.z);

                 DefineAxes();
                 RotatePlayer();
             }
        }
    }
}
