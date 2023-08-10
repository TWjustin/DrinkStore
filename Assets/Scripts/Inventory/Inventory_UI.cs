using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    public Transform itemContent;
    public GameObject inventorySlot;
    
    public void UpdateInventoryUI()
    {
        List<Slot> slots = InventoryManager.Instance.slots;
        
        // 清空内容再重新显示
        foreach (Slot slot in itemContent.GetComponentsInChildren<Slot>())
        {
            Destroy(slot.gameObject);
        }

        foreach (var slot in slots)
        {
            GameObject obj = Instantiate(inventorySlot, itemContent);
            var itemIcon = obj.transform.GetChild(1).GetComponent<Image>();
            itemIcon.sprite = slot.Icon;
            var numText = obj.transform.GetChild(0).GetComponent<Text>();
            numText.text = slot.Count.ToString();
        }
    }
}
