using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlotManager : MonoBehaviour
{
    bool isPlanted = false;
    SpriteRenderer plant;
    BoxCollider2D plantCollider;
    
    int plantStage = 0;
    private float timer;
    
    PlantObject selectedPlant;
    FarmManager fm;
    MoneyManager mm;

    private void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        fm = transform.parent.parent.GetComponent<FarmManager>();
        mm = FindObjectOfType<MoneyManager>();
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
        if (!IsPointerOverUI())
        {
            if (isPlanted)
            {
                if (plantStage == selectedPlant.plantStages.Length - 1 && !fm.isPlanting)
                {
                    Harvest();
                }
            }
            else if (fm.isPlanting && fm.selectedPlant.plant.price <= mm.money) //
            {
                Plant(fm.selectedPlant.plant);
            }
        }
    }
    
    private bool IsPointerOverUI()
    {
        if (EventSystem.current != null)
        {
            // 檢查觸摸點是否在 UI 元素上
            return EventSystem.current.IsPointerOverGameObject();
        }
        return false;
    }

    void Harvest()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
        
        // 自己加的
        InventoryManager.Instance.AddItem(selectedPlant.harvestItem);
    }

    void Plant(PlantObject newPlant)
    {
        selectedPlant = newPlant;
        isPlanted = true;
        
        mm.Transaction(-selectedPlant.price);   //
        
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
