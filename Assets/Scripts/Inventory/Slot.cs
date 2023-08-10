using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Slot : MonoBehaviour
{
    public Item Item { get; private set; }
    public Sprite Icon => Item.icon;
    public int Count { get; private set; }

    public Slot(Item item)
    {
        Item = item;
        Count = 1;
    }
    
    public void Initialize(Item item)
    {
        Item = item;
        Count = 1;

        // 在这里进行其他初始化操作
    }

    public void AddItem(Item item)
    {
        Count++;
    }
}
