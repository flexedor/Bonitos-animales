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
    [SerializeField] private GameObject LevelButton;
    [SerializeField] private GameObject GridWithLevels;
    [SerializeField] private GameController GameController;
    [SerializeField] private GameObject ResquingMisssionControls;
    [SerializeField] private GameObject LevelMenu;
    [SerializeField] private GameObject GameOverCanvas;


    private AnimalScript _currentAnimalScript;
  
    private void Awake()
    {
        AnimalScript.onColition += SetDataToAnimalUI;
        LevelButtonScript.onClickLevel += OnRessquingLevelChoosing;
        CannonScript.OnOutOfBalls += GameOver;
        for (int i = 0; i< GameController.resquingStages.Count; i++ ) {

            GameObject currentButton =  Instantiate(LevelButton);
            Text buttonText= currentButton.GetComponentInChildren<Text>();
            String CurrentLevel = (i+1).ToString();
            buttonText.text = CurrentLevel;
            currentButton.name="Level"+ CurrentLevel;
            LevelButtonScript levelButtonScript = currentButton.GetComponentInChildren<LevelButtonScript>();
            levelButtonScript.LevelInt = i;
            currentButton.transform.SetParent(GridWithLevels.transform);
        }

    }
    private void OnRessquingLevelChoosing(int level)
    {
        ResquingMisssionControls.SetActive(true);
        LevelMenu.SetActive(false);
    }

    private void OnDestroy()
    {
        AnimalScript.onColition -= SetDataToAnimalUI;
        LevelButtonScript.onClickLevel -= OnRessquingLevelChoosing;
        CannonScript.OnOutOfBalls -= GameOver;
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

    private void GameOver()
    {
        GameOverCanvas.SetActive(true);
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
