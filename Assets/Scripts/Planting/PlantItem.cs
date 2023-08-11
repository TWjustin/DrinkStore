using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{
    public PlantObject plant;
    private FarmManager fm;
    
    public Text nameText;
    public Text priceText;
    public Image icon;

    void Start()
    {
        fm = FindObjectOfType<FarmManager>();
        InitializeUI();
    }

    public void BuyPlant()
    {
        fm.SelectPlant(this);
    }

    void InitializeUI()
    {
        nameText.text = plant.plantName;
        priceText.text = plant.price + "$";
        icon.sprite = plant.icon;
    }
}
