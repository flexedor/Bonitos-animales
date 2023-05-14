using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public static System.Action<GameObject> AnimalToAdd;
    private void OnCollisionEnter(Collision collision)
    {
        BrickScript brickScript = collision.gameObject.GetComponent<BrickScript>();
        AnimalScript animalScript = collision.gameObject.GetComponent<AnimalScript>();
        if (brickScript != null)
        {
            Destroy(brickScript.gameObject);
            Destroy(this.gameObject);
        }
        if (animalScript != null)
        {
            AnimalToAdd?.Invoke(collision.gameObject);
        }
      
    }
}
