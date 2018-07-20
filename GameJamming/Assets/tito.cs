using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tito : MonoBehaviour {
    public static int hp=6;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        --hp;
        if(hp==0)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
