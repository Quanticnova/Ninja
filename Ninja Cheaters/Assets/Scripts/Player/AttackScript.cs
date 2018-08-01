using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

    int scalingFramesLeft = 0;
    bool isAttacking = false;
    bool canAttack = true;
    public int player = 0;

    public float TimerBuffer = 1f;
    public float Timer = 0;


    public Vector3 targetAngle = new Vector3(0f, 180, 0f);

    private Vector3 currentAngle;

    public MeshRenderer Hilt;
    public MeshRenderer Sword;
    public MeshCollider Body;

    public void Start()
    {
        currentAngle = transform.eulerAngles;
        Hilt.enabled = false;
        Sword.enabled = false;
        Body.enabled = false;
    }

    public void Update()
    {

        

        if(Input.GetKeyDown(KeyCode.S) && canAttack)
        {
            Hilt.enabled = true;
            Sword.enabled = true;
            Body.enabled = true;
            targetAngle = new Vector3(0f, transform.rotation.x + 180, 0f);
            isAttacking = true;
            scalingFramesLeft = 15;
            canAttack = false;
             Timer = Time.time + TimerBuffer;
           // targetAngle.x = transform.rotation.x + 180;
            
        }

        if(Time.time > Timer)
        {
            canAttack = true;
        }


        if(isAttacking && scalingFramesLeft > 0)
        {
            currentAngle = new Vector3(
         Mathf.LerpAngle(currentAngle.x, targetAngle.x*2, Time.deltaTime),
         Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime),
         Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime));
            transform.eulerAngles = currentAngle;
            scalingFramesLeft--;
            if(scalingFramesLeft == 0)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                currentAngle = new Vector3(0f, 0f, 0f);
                Hilt.enabled = false;
                Sword.enabled = false;
                Body.enabled = false;
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
