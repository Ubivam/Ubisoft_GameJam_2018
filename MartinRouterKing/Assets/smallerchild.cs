using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class smallerchild : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void haha()
    {
        SceneManager.LoadScene("options");
    }

    public void hehe()
    {
        Application.Quit();
    }


}
