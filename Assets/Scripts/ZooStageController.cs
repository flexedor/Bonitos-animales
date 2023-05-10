using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZooStageController : MonoBehaviour
{
    [SerializeField] private List<GameObject>animalsInCurrentBiom = new List<GameObject>();
   
    [SerializeField] private bool IsCustomCameraCoordsIsOn = false;
    [SerializeField] private Vector3 customCameraPosition = new Vector3();

    [SerializeField] private bool IsCustomLevelCoordsIsOn = false;
    [SerializeField] private Vector3 customStagePosition = new Vector3();

    [SerializeField] private bool IsCustomCameraRotationIsOn = false;
    [SerializeField] private Quaternion customCameraRotation = new Quaternion();

    Camera mainCamera = null;
    private Vector3 prevCameraPosition = new Vector3();
    private Quaternion prevCameraRotation;

    private List<GameObject> _animalsOnStage;



    private void OnEnable()
    {
        foreach (var VARIABLE in animalsInCurrentBiom)
        {
            var position = transform.position;
            Vector3 place_to_spavn = new Vector3(position.x+Random.Range(-2,3),position.y+0.5f,position.z+Random.Range(-2,3));
            GameObject tmp_animal = Instantiate(VARIABLE, place_to_spavn,  Quaternion.identity,transform);
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
        if (IsCustomCameraCoordsIsOn)
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

}
