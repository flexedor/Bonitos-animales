using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StageController : MonoBehaviour
{
    [SerializeField] private List<AnimalData>animalsInCurrentBiom = new List<AnimalData>();
    private List<GameObject> _animalsOnStage;

    private void Awake()
    {
        foreach (var VARIABLE in animalsInCurrentBiom)
        {
            var position = transform.position;
            Vector3 place_to_spavn = new Vector3(position.x+Random.Range(-3,3),position.y,position.z+Random.Range(-3,3));
            GameObject tmp_animal = Instantiate(VARIABLE.AnimalPrefab, place_to_spavn, Quaternion.identity,transform);
            
            _animalsOnStage?.Add( tmp_animal);
        }
    }
}
