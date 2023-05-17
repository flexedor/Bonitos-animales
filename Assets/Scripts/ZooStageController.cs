using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ZooStageController : MonoBehaviour
{
    [SerializeField] private List<GameObject>animalsInCurrentBiom = new List<GameObject>();
    [SerializeField] private GameData gameData;

    [SerializeField] private bool isCustomCameraCoordsIsOn = false;
    [SerializeField] private Vector3 customCameraPosition = new Vector3();

    [SerializeField] private bool IsCustomLevelCoordsIsOn = false;
    [SerializeField] private Vector3 customStagePosition = new Vector3();

    [SerializeField] private bool IsCustomCameraRotationIsOn = false;
    [SerializeField] private Quaternion customCameraRotation = new Quaternion();

  
    List<GameObject> AnchorPoints = new List<GameObject>();


    Camera mainCamera = null;
    private Vector3 prevCameraPosition = new Vector3();
    private Quaternion prevCameraRotation;


    private List<GameObject> _animalsOnStage;

    public GameData.Biomes stageBiome = GameData.Biomes.Mountains;

    private void OnEnable()
    {
        AnchorPointScript[] objects = FindObjectsOfType<AnchorPointScript>();

        // Add each object with the component to the list
        foreach (AnchorPointScript objectWithComponent in objects) {
            AnchorPoints.Add(objectWithComponent.gameObject);
        }

        for (int i = 0; i < animalsInCurrentBiom.Count; i++)
        {
            if (i < 0 || i >= AnchorPoints.Count) continue;
            Vector3 position = AnchorPoints[i].transform.position;
            GameObject tmp_animal = Instantiate(animalsInCurrentBiom[i], position,  Quaternion.identity,transform);
            _animalsOnStage?.Add( tmp_animal);



        }
        // Find the main camera in the scene
        mainCamera = Camera.main;
        // Remember prev pos and rotation
        prevCameraPosition = mainCamera.transform.position;
        prevCameraRotation = mainCamera.transform.rotation;
        
        setCameraPos();
        setLevelPos();
        setCameraRorarion();
    }
    
    private void OnDisable()
    {
        //set position and rotation back
        if (mainCamera)
        {
            mainCamera.transform.position = prevCameraPosition;
            mainCamera.transform.rotation = prevCameraRotation;
        }
    }
    private void setCameraPos()
    {
        if (isCustomCameraCoordsIsOn)
        {
            mainCamera.transform.position = customCameraPosition;
          
        }
    }
    private void setCameraRorarion()
    {
        if (IsCustomCameraRotationIsOn)
        {
            mainCamera.transform.rotation = customCameraRotation;
        }
    }
    private void setLevelPos()
    {
        if (IsCustomLevelCoordsIsOn)
        {
            this.gameObject.transform.position = customStagePosition;
        }
    }
    public void addAnimal(GameObject animalToAdd)
    {
        AnimalScript animalComponent = animalToAdd.GetComponent<AnimalScript>();
        if (animalComponent!=null)
        {
            if (animalComponent.animalBiome== stageBiome) {
                // Create a copy of the GameObject
                for(int i = 0; i < gameData.animals.Count; i++)
                {
                    AnimalScript animalComponentinData = gameData.animals[i].GetComponent<AnimalScript>();
                    if (animalComponent.Name== animalComponentinData.Name)
                    {
                       
                        animalsInCurrentBiom.Add(gameData.animals[i]);
                    }
                }
              
            }
           
        }
        else
        {
            Debug.Log("No animal script in object");
        }
      
    }  

}
