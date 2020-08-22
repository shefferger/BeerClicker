using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lhandAnim : MonoBehaviour {
    public Animation animLhand;
    void Start()
    {
        StartCoroutine(Co_WaitForSeconds(5f));
    }

    private IEnumerator Co_WaitForSeconds(float value)
    {
        // Do something before
        animLhand = GetComponent<Animation>();
        animLhand.Play("lhand");
        yield return new WaitForSeconds(value);
        StartCoroutine(Co_WaitForSeconds(Random.Range(15, 60)));
    }
}
