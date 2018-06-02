using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

    [SerializeField]
    Rigidbody playerRB;

    public void SetPlayer(Rigidbody rb)
    {
        playerRB = rb;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        Vector3 pos = playerRB.transform.position;
        if (transform.position.y + transform.localScale.y / 0.614 > pos.y) 
        {
            pos.y = transform.position.y + transform.localScale.y / 0.614f;
        }

        playerRB.transform.position = pos;
        Vector3 vel = new Vector3(playerRB.velocity.x, Time.deltaTime * 10, playerRB.velocity.z);

        playerRB.velocity = vel;


    }

    private void OnCollisionStay(Collision collision)
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }
}
