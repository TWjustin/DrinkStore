using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{
    public PlantItem selectedPlant;
    public bool isPlanting = false;
    public int money = 1000;
    public Text moneyText;
    
    public GameObject storePanel;
    
    void Start()
    {
        moneyText.text = money.ToString();
    }

    public void SelectPlant(PlantItem newPlant)
    {
        selectedPlant = newPlant;
        isPlanting = true;
        storePanel.SetActive(false);
    }

    public void Deselect()
    {
        selectedPlant = null;
        isPlanting = false;
    }

    public void Transaction(int value)
    {
        money += value;
        moneyText.text = money.ToString();
    }
}
