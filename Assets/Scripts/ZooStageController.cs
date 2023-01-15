using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZooStageController : MonoBehaviour
{
    [SerializeField] private List<GameObject>animalsInCurrentBiom = new List<GameObject>();
    private List<GameObject> _animalsOnStage;

    private void Awake()
    {
        foreach (var VARIABLE in animalsInCurrentBiom)
        {
            var position = transform.position;
            Vector3 place_to_spavn = new Vector3(position.x+Random.Range(-2,3),position.y+0.5f,position.z+Random.Range(-2,3));
            GameObject tmp_animal = Instantiate(VARIABLE, place_to_spavn,  Quaternion.identity,transform);
            
            _animalsOnStage?.Add( tmp_animal);
        }
    }
}
