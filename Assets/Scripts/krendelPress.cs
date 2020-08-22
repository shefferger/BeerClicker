using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class krendelPress : MonoBehaviour
{
    public GameObject adPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick1()
    {
        if (!_game.menust && !_game.shopst && !_game.optionst && !_game.teleSt)
            adPanel.SetActive(!adPanel.activeSelf);
    }
}
