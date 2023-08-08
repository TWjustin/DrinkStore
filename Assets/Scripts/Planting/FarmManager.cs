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
    
    GameObject selectedIcon;
    
    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = money.ToString();
    }

    public void SelectPlant(PlantItem newPlant)
    {
        if (selectedPlant == newPlant)
        {
            Debug.Log("Deselect" + selectedPlant.plant.plantName);
            if (selectedIcon != null)
            {
                Destroy(selectedIcon);
            }
            selectedPlant = null;
            isPlanting = false;
        }
        else
        {
            if (selectedIcon != null)
            {
                Destroy(selectedIcon);
            }
            selectedPlant = newPlant;
            selectedIcon = Instantiate(selectedPlant.selectedIcon, selectedPlant.transform.GetChild(0).transform);
            Debug.Log("Select" + selectedPlant.plant.plantName);
            isPlanting = true;
        }
    }

    public void Transaction(int value)
    {
        money += value;
        moneyText.text = money.ToString();
    }
}
