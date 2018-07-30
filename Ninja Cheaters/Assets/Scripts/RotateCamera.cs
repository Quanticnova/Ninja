using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public GameObject target;
    private GameObject menus;
    public float rotateSpeed = 5, height = 5; float maxRotateSpeed;
    float horizontal, vertical; // axis

    Vector3 offset;
    Quaternion rotation;

    void Start()
    {
        maxRotateSpeed = rotateSpeed;

        //target = GameObject.FindGameObjectWithTag("Player");
        menus = GameObject.FindGameObjectWithTag("playerSelect");

        // offset = target.transform.position - transform.position;
    }

    void getRotation()
    {
        horizontal = Input.GetAxis("RightStickX") * rotateSpeed;  // direction and speed
        vertical = Input.GetAxis("RightStickY") * rotateSpeed;

        /*float desiredAngle = target.transform.eulerAngles.y;    // facing player y
        rotation = Quaternion.Euler(0, desiredAngle, 0);*/
    }

    void setRotation()
    {
        //transform.position = target.transform.position - (rotation * offset);   // angle of camera:player
        target.transform.Rotate(0, horizontal, 0);  

        //transform.LookAt(target.transform);
    }

    void LateUpdate()
    {
        if (!menus.activeInHierarchy)
        {
            transform.rotation = target.transform.rotation;
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y + height, target.transform.position.z);

            getRotation();
            setRotation();
        }
    }
}
