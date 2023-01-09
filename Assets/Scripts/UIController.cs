using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject animalMenu;
    [SerializeField] private Slider pet_slider;
    [SerializeField] private Slider clean_slider;
    [SerializeField] private Slider feed_slider;
    [SerializeField] private Text NameOfAnimal;

    private AnimalScript _currentAnimalScript;
    private void Awake()
    {
        AnimalScript.onColition += SetDataToAnimalUI;
    }

    private void OnDestroy()
    {
        AnimalScript.onColition -= SetDataToAnimalUI;
    }

    private void SetDataToAnimalUI(AnimalScript obj)
    {
        _currentAnimalScript = obj;
        RenewData();
    }
    
    private void RenewData()
    {
        animalMenu.SetActive(true);
        NameOfAnimal.text = _currentAnimalScript.Name;
        
        pet_slider.value = _currentAnimalScript.Pet;
        clean_slider.value = _currentAnimalScript.Clean;
        feed_slider.value = _currentAnimalScript.Feed;

        
    }

    public void FeedCurrentAnimal()
    {
        _currentAnimalScript.FeedAnimal(10);
        RenewData();
    }
    public void PetCurrentAnimal()
    {
        _currentAnimalScript.PetAnimal(10);
        RenewData();
    }
    public void CleanCurrentAnimal()
    {
        _currentAnimalScript.CleanAnimal(10);
        RenewData();
    }
    
}
