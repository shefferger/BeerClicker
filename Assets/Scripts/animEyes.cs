using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animEyes : MonoBehaviour {
    public Animation eyes_move;
    void Start () {
        StartCoroutine(Co_WaitForSeconds2(8f));
    }

    private IEnumerator Co_WaitForSeconds2(float value)
    {
        // Do something before
        eyes_move = GetComponent<Animation>();
        switch (Random.Range(0, 2))
        {
            case 0:
                eyes_move.Play("eyes_move");
                break;
            case 1:
                eyes_move.Play("eyes_move2");
                break;
        }
        yield return new WaitForSeconds(value);
        StartCoroutine(Co_WaitForSeconds2(Random.Range(8, 28)));
    }
}
