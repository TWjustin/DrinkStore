using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    bool isPlanted = false;
    SpriteRenderer plant;
    BoxCollider2D plantCollider;
    
    int plantStage = 0;
    private float timer;
    
    PlantObject selectedPlant;
    
    FarmManager fm;
    
    private void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        fm = transform.parent.parent.GetComponent<FarmManager>();
    }

    private void Update()
    {
        if (isPlanted)
        {
            timer -= Time.deltaTime;

            if (timer < 0 && plantStage < selectedPlant.plantStages.Length - 1)
            {
                plantStage++;
                UpdatePlant();
                timer = selectedPlant.timeBtwStages;
            }
        }
    }

    private void OnMouseDown()
    {
        if (isPlanted)
        {
            if (plantStage == selectedPlant.plantStages.Length - 1 && !fm.isPlanting)
            {
                Harvest();
            }
        }
        else if (fm.isPlanting && fm.selectedPlant.plant.price <= fm.money)
        {
            Plant(fm.selectedPlant.plant);
        }
    }

    void Harvest()
    {
        Debug.Log("Harvest");
        isPlanted = false;
        plant.gameObject.SetActive(false);
        
        InventoryManager.Instance.AddItem(selectedPlant.harvestItem);    //
    }

    void Plant(PlantObject newPlant)
    {
        selectedPlant = newPlant;
        Debug.Log("Planted");
        isPlanted = true;
        
        fm.Transaction(-selectedPlant.price);
        
        plantStage = 0;
        UpdatePlant();
        timer = selectedPlant.timeBtwStages;
        plant.gameObject.SetActive(true);
    }
    
    void UpdatePlant()
    {
        plant.sprite = selectedPlant.plantStages[plantStage];
        plantCollider.size = plant.sprite.bounds.size;
        plantCollider.offset = new Vector2(0, plant.sprite.bounds.size.y / 2);
    }
}
