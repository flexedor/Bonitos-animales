using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorPointScript : MonoBehaviour
{
    [SerializeField] public GameObject animal;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    GameObject GetAnimal()
    {
        return animal;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
