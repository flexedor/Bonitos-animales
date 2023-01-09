using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalScript : MonoBehaviour
{
    public static System.Action<AnimalScript> onColition;
    [SerializeField]
    private int _feed;
    [SerializeField]
    private int _pet;
    [SerializeField]
    private int _clean;
    [SerializeField]
    private string _name;
    [SerializeField] 
    public GameData.Biomes animalBiome;

    private AnimalScript _instantiate;
    public int Feed
    {
        get => _feed;
        set
        {
            if (value is < 100 and > 0)
            {
                _feed = value;
            }
        }
    }

    public int Pet
    {
        get => _pet;
        set
        {
            if (value is <= 100 and > 0)
            {
                _pet = value;
            }
        }
    }

    public int Clean
    {
        get => _clean;
        set
        {
            if (value is < 100 and > 0)
            {
                _clean = value;
            }
        }
    }

    public string Name => _name;

    private void Awake()
    {
        _instantiate = this;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<pointer>()!=null)
        {
            onColition?.Invoke(_instantiate);
        }
    }

    public void FeedAnimal(int food)
    {
        Feed += food;
    }

    public void CleanAnimal(int clean)
    {
        Clean += clean;
    }

    public void PetAnimal(int pet)
    {
        Pet += pet;
    }

    
}
