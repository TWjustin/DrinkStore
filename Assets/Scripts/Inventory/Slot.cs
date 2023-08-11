using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Slot : MonoBehaviour
{
    public Item Item { get; private set; }
    public Sprite Icon => Item.icon;
    public int Count { get; private set; }
    
    public void Initialize(Item item)
    {
        Item = item;
        Count = 1;
    }

    public void AddNum()
    {
        Count++;
    }
}
