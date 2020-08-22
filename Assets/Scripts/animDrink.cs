using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animDrink : MonoBehaviour {
    public Animation tail_click;
    
    public static bool clickedT1 = false, clickedT2 = false;

    void Update () {
        if (clickedT1)
        {
            tail_click = GetComponent<Animation>();
            tail_click.Play("rhand1");
            clickedT1 = false;
        }
        if (clickedT2)
        {
            tail_click = GetComponent<Animation>();
            tail_click.Play("rhand2");
            clickedT2 = false;
        }
    }
}
