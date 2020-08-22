using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tailClick : MonoBehaviour {
    public Animation breath;
    public GameObject tail, menu, shop, opt, lch, tele, adP;
    private void Start()
    {
        InvokeRepeating("_breath", 1.0f, 3.5f);
    }
    private void OnMouseDown()
    {
        if (!menu.activeSelf && !shop.activeSelf && !opt.activeSelf && !lch.activeSelf && !tele.activeSelf && !adP.activeSelf)
        {
            animDrink.clickedT1 = true;
            _game.onTailClick();
            _game._circleSpeed += 0.18f;
        }
    }
    private void OnMouseUp()
    {
        if (!menu.activeSelf && !shop.activeSelf && !opt.activeSelf && !lch.activeSelf && !tele.activeSelf && !adP.activeSelf)
        {
            animDrink.clickedT2 = true;
        }
    }
    private void _breath()
    {
        breath = GetComponent<Animation>();
        breath.Play("tail_breath");
    }
}
