using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{
    public PlantItem selectedPlant;
    public bool isPlanting = false;

    public GameObject storePanel;

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
}
