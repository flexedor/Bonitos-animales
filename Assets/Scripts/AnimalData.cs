using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class AnimalData : ScriptableObject
{
   [SerializeField]
   private int _feed;
   [SerializeField]
   private int _pet;
   [SerializeField]
   private int _clean;
   [SerializeField]
   private string _name;
   [SerializeField]
   private GameObject _animalPrefab;

   [SerializeField] public GameData.Biomes animalBiome;
   public int Feed
   {
      get => _feed;
      set => _feed = value;
   }

   public int Pet
   {
      get => _pet;
      set => _pet = value;
   }

   public string Name => _name;

   public GameObject AnimalPrefab => _animalPrefab;
   
}
