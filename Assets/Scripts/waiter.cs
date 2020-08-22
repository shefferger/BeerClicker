using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waiter : MonoBehaviour {

    public GameObject _waiter, beer, crendel;
    public Animation animWaiterGo;
    private bool isAvailToClick = false;
	// Use this for initialization
	void Start () {
		
	}

    public void OnMouseDown()
    {
        if (isAvailToClick)
            foodClick();
    }

    public void foodClick()
    {
        Debug.Log("food click");
        beer.SetActive(!beer.activeSelf);
        crendel.SetActive(!crendel.activeSelf);
        _game.donvalSt += 1 * PlayerPrefs.GetInt("waiter");
        _game.litresSt += _game.litresPerSecondSt * 20;
        isAvailToClick = false;
        PlayerPrefs.SetInt("bkrendels", _game.donvalSt);
    }

    // Update is called once per frame
    void Update () {
        if (PlayerPrefs.HasKey("waiter") && _game._circleSpeed >= 0 && _game._circleSpeed <= 0)
        {
            Transform t1 = _waiter.transform;
            t1.position = new Vector3(524f, -110f, 4f);
            
            _game._circleSpeed += 0.18f;
            animWaiterGo = GetComponent<Animation>();
            animWaiterGo.Play("waiter_go");
            beer.SetActive(!beer.activeSelf);
            crendel.SetActive(!crendel.activeSelf);

            isAvailToClick = true;
        }
	}


}
