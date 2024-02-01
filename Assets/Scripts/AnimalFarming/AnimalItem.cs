using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Animal Item", menuName = "Animal Item")]
public class AnimalItem : ScriptableObject
{
    public int price;
    public GameObject animalPrefab;
}
