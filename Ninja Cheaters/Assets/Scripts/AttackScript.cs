using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

    int scalingFramesLeft = 0;
    bool isAttacking = false;
    bool canAttack = true;
    public int player = 0;

    public float TimerBuffer = 2f;
    public float Timer = 0;


    public Vector3 targetAngle = new Vector3(0f, 180, 0f);

    private Vector3 currentAngle;

    public void Start()
    {
        currentAngle = transform.eulerAngles;
    }

    public void Update()
    {

        

        if(Input.GetKeyDown(KeyCode.S) && canAttack)
        {
            targetAngle = new Vector3(0f, transform.rotation.x + 180, 0f);
            isAttacking = true;
            scalingFramesLeft = 40;
            canAttack = false;
             Timer = Time.time + TimerBuffer;
            
        }

        if(Time.time > Timer)
        {
            canAttack = true;
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PlayerHit>().PlayerNum != player)
        {
            Destroy(collision.gameObject);
        }
    }
}
