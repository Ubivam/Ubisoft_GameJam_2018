using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMeshCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//gameObject.AddComponent<
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("clicked");
            DestroyImmediate(gameObject.GetComponent<MeshCollider>());
            gameObject.AddComponent<MeshCollider>();
        }
    }
}
