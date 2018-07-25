using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

    int scalingFramesLeft = 0;
    bool isAttacking = false;
    bool isShrinking = false;


    public Vector3 targetAngle = new Vector3(0f, 180, 0f);

    private Vector3 currentAngle;

    public void Start()
    {
        currentAngle = transform.eulerAngles;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) )
        {
            targetAngle = new Vector3(0f, transform.rotation.x + 180, 0f);
            isAttacking = true;
            scalingFramesLeft = 40;
            
        }

        if(isAttacking && scalingFramesLeft > 0)
        {
            currentAngle = new Vector3(
         Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime),
         Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime),
         Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime));
            transform.eulerAngles = currentAngle;
            scalingFramesLeft--;
            if(scalingFramesLeft == 0)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                currentAngle = new Vector3(0f, 0f, 0f);
            }

           
            
        }
      

    }
}
