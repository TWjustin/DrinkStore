using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int money = 1000;
    public Text moneyText;
    
    void Start()
    {
        moneyText.text = money.ToString();
    }
    
    public void Transaction(int value)
    {
        money += value;
        moneyText.text = money.ToString();
    }
}
