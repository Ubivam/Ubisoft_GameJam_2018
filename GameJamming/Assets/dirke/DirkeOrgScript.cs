using UnityEngine;
using System;
using System.Collections;

public class DirkeOrgScript : MonoBehaviour {

    [SerializeField]
    private GameObject[] dirke;

    void Start() {
        foreach (GameObject d in dirke) {
            if (d.ToString().Contains("Crni")) {
                d.GetComponent<SpriteRenderer>().color = Color.black;
            }
        }
    }

	void Update () {
        bool[] inputs = InputManager.Instance.GetInputsAndClear();
        setColorByIndex(inputs);
	}

    public void setColorByIndex(bool[] inputs) {
        for (int i = 0; i < inputs.Length; ++i)
        {
            if (inputs[i])
            {
                dirke[i].GetComponent<SpriteRenderer>().color = Color.red;
                StartCoroutine(ChangeColor(i));
            }
                //} else
            //{
            //    dirke[i].GetComponent<SpriteRenderer>().color = dirke[i].ToString().Contains("Crni") ? Color.black : Color.white;
            //}
        }
    }

    IEnumerator ChangeColor(int index)
    {
        yield return new WaitForSeconds(.2f);
         dirke[index].GetComponent<SpriteRenderer>().color = dirke[index].ToString().Contains("Crni") ? Color.black : Color.white;

    }

}
