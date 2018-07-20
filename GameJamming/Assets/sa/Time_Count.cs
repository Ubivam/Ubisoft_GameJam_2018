using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class Time_Count : MonoBehaviour
{
    Text text;
    float Timer = 0;
    private void Start()
    {
        text = GetComponent<Text>();
        text.text = "0 s";
    }
    void Update()
    {
        Timer += Time.deltaTime;
        text.text = "" + System.Math.Round(Timer,0) +"s" ;

    }
}
    
