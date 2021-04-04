using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Purse : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI coincountText;
    public int coinCount = 0;
    // Start is called before the first frame update
    private void Start()
    {
        
    }


    // Update is called once per frame
    public void addCoin(int amount)
    {
        coinCount += amount;
        coincountText.text = $"Coin: {coinCount}";
    }
    public void removeCoin(int amount)
    {
        coinCount -= amount;
        coincountText.text = $"Coin: {coinCount}";
    }
}