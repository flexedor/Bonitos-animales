using UnityEngine;
using UnityEngine.Serialization;
using System;
using System.Collections.Generic;
[CreateAssetMenu]
public class GameData : ScriptableObject
{
    public enum Biomes
    {
        Desert,
        Iceland,
        Swamp,
        Forest,
        Ocean,
        Tundra,
        Savanna,
        Rainforest,
        Steppe
    }
    [SerializeField]
    public List<GameObject> animals = new List<GameObject>(); 
   
}
