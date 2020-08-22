
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animVeki : MonoBehaviour {
    public Animation eyes_blink;
    void Start()
    {
        StartCoroutine(Co_WaitForSeconds(5f));
    }

    private IEnumerator Co_WaitForSeconds(float value)
    {
        // Do something before
        eyes_blink = GetComponent<Animation>();
        eyes_blink.Play("eyes_blink");
        yield return new WaitForSeconds(value);
        StartCoroutine(Co_WaitForSeconds(Random.Range(4, 12)));
    }
}
