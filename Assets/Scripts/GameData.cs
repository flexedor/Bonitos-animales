using UnityEngine;
using UnityEngine.Serialization;
using System;
using System.Collections.Generic;
[CreateAssetMenu]
public class GameData : ScriptableObject
{
    public enum Biomes
    {
        Mountains,
        Savannah,
        Beach,
        Winter,
        Canyon
    }
    [SerializeField]
    public List<GameObject> animals = new List<GameObject>(); 
   
}
