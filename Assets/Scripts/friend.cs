using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class friend : MonoBehaviour { 

    public GameObject _friend, friend_legs;
    public GameObject menu, shop, opt, lch, tele;
    public GameObject circleVremeniSutok;
    public Animation friend_anim;
    public static bool isSleep = true;

    void Start () {
        friend_anim = GetComponent<Animation>();
        friend_anim.Play("friend_sleep");
        isSleep = true;
    }

    public void OnMouseDown()
    {
        if (!menu.activeSelf && !shop.activeSelf && !opt.activeSelf && !lch.activeSelf && !tele.activeSelf && !isSleep)
        {
            friend_anim = GetComponent<Animation>();
            friend_anim.Play("friend_drink");
            _game.onFriendClick();
        }
    }

    // Update is called once per frame
    void Update () {
        //if НОЧЬ, то аним. проснулся
        //Debug.Log("update " + Math.Round(_game._circleSpeed, 2) + PlayerPrefs.HasKey("sosed"));
        if (_game._circleSpeed >= 179.9 && _game._circleSpeed <= 180.1 && PlayerPrefs.HasKey("sosed"))
        {

            _game._circleSpeed += 0.18f;
            Debug.Log("prosnis");
            StartCoroutine(wakeUp(16f));
        }
    }

    private IEnumerator wakeUp(float value)
    {
        friend_anim = GetComponent<Animation>();
        friend_anim.Play("friend_sleep2");
        isSleep = false;
        Debug.Log("prosnulsya");

        yield return new WaitForSeconds(value);
        goSleep();
    }

    public void goSleep()
    {
        Debug.Log("idu spat'");

        friend_anim = GetComponent<Animation>();
        friend_anim.Play("friend_sleep");
        isSleep = true;
    }

}
