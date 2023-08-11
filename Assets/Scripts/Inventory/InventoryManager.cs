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
        bool foundSlot = false;
        
        foreach (var slot in slots)
        {
            if (slot.Item == itemToAdd)
            {
                slot.AddNum();
                foundSlot = true;
                return;
            }
        }
        
        if (!foundSlot)
        {
            GameObject obj = Instantiate(slotPrefab, itemContent);
            Slot newSlot = obj.GetComponent<Slot>();
            newSlot.Initialize(itemToAdd);
            slots.Add(newSlot);
        }
    }

    /*
    public void Remove(Item item)
    {
        items.Remove(item);
    }*/
}
