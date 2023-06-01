using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    [SerializeField] private Vector3 customCameraRotation = new Vector3();

    [SerializeField] private float rotMinX=-61f, rotMaxX=61f, rotMinY=-61f, rotMaxY=61f;

    [SerializeField] private Material skyboxMaterial;
  
    List<GameObject> AnchorPoints = new List<GameObject>();


    Camera mainCamera = null;
    private Vector3 prevCameraPosition = new Vector3();
    private Quaternion prevCameraRotation;
    

    private List<GameObject> _animalsOnStage;

    public GameData.Biomes stageBiome = GameData.Biomes.Mountains;

    public static System.Action OnStageLoad;
    private void OnEnable()
    {
      
        List<AnchorPointScript> objects = FindObjectsOfType<AnchorPointScript>().ToList();
        // Add each object with the component to the list
        

        for (int i = 0; i < animalsInCurrentBiom.Count; i++)
        {
            for (int j=0; j < objects.Count(); j++)
            {
                if (GameObject.ReferenceEquals(objects[j].animal, animalsInCurrentBiom[i]))
                {
                    Vector3 position = objects[j].gameObject.transform.position;
                    Quaternion rotation = objects[j].gameObject.transform.rotation;
                    GameObject tmp_animal = Instantiate(animalsInCurrentBiom[i], position, rotation, transform);
                    _animalsOnStage?.Add(tmp_animal);
                    objects.Remove(objects[j]);
                    continue;
                }
                
            }
        }
       
        SetCameraProperty();
        setCameraPos();
        setLevelPos();
        setCameraRorarion();
       
        // OnStageLoad?.Invoke();
    }

    private void SetCameraProperty()
    {
        if (skyboxMaterial!=null)
        {
            RenderSettings.skybox = skyboxMaterial;
            DynamicGI.UpdateEnvironment();
        }
        RotateCamera cameraRotator = FindObjectOfType<RotateCamera>();
        if (cameraRotator != null)
        {
            Debug.Log("Found script on " + cameraRotator.gameObject.name);
            cameraRotator.maxX = rotMaxX;
            cameraRotator.maxY = rotMaxY;
            cameraRotator.minX = rotMinX;
            cameraRotator.minY = rotMinY;
            cameraRotator.speed = 0.002f;
        }
        
        // Find the main camera in the scene
        mainCamera = Camera.main;
        // Remember prev pos and rotation
        prevCameraPosition = mainCamera.transform.position;
        prevCameraRotation = mainCamera.transform.rotation;
        
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
           // mainCamera.transform.rotation = customCameraRotation;
           // RotateCamera cameraRotator = FindObjectOfType<RotateCamera>();
            RotateCamera cameraRotator = FindObjectOfType<RotateCamera>();
            cameraRotator.SetCustomRotation(customCameraRotation);
            
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
