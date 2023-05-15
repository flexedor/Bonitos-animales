using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public static System.Action<GameObject> AnimalToAdd;
    public static System.Action NextResqueLevel;
    private void OnCollisionEnter(Collision collision)
    {
        BrickScript brickScript = collision.gameObject.GetComponent<BrickScript>();
        AnimalScript animalScript = collision.gameObject.GetComponent<AnimalScript>();
        BracketScript bracketScript = collision.gameObject.GetComponent<BracketScript>();
        if (brickScript != null)
        {
            Destroy(brickScript.gameObject);
            Destroy(this.gameObject);
        }
        if (animalScript != null)
        {
            AnimalToAdd?.Invoke(collision.gameObject);
            NextResqueLevel?.Invoke();
        }

        if (bracketScript!=null)
        {
            Destroy(this.gameObject);
        }
      
    }
}
