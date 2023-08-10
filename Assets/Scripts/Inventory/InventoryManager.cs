using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<Slot> slots = new List<Slot>();
    public GameObject slotPrefab;
    public Transform itemContent;

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(Item itemToAdd)
    {
        Slot existingSlot = FindSlotByItem(itemToAdd);

        if (existingSlot != null)
        {
            existingSlot.AddItem(itemToAdd);
        }
        else
        {
            GameObject obj = Instantiate(slotPrefab, itemContent);
            Slot newSlot = obj.AddComponent<Slot>();
            newSlot.Initialize(itemToAdd);
            slots.Add(newSlot);
        }
    }

    private Slot FindSlotByItem(Item item)
    {
        return slots.Find(slot => slot.Item.id == item.id);
    }

    /*
    public void Remove(Item item)
    {
        items.Remove(item);
    }*/
}
