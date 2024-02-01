using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyAnimals : MonoBehaviour
{
    public Transform parent;
    public GameObject buyButton;
    public List<Vector2> pos = new List<Vector2>();
    private int i = 0;
    
    public void Spawn(AnimalItem animal)
    {
        if (i < pos.Count)
        {
            if (animal.price <= FindObjectOfType<MoneyManager>().money)
            {
                FindObjectOfType<MoneyManager>().Transaction(-animal.price);
                Instantiate(animal.animalPrefab, pos[i], Quaternion.identity, parent);
                i++;
                gameObject.SetActive(false);
                
                if (i == pos.Count)
                {
                    buyButton.SetActive(false);
                }
            }
        }
    }
}
