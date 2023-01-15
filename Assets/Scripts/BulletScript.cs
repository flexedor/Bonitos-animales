using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        BrickScript collided = collision.gameObject.GetComponent<BrickScript>();
        if (collided!=null)
        {
            Destroy(collided.gameObject);
            Destroy(this.gameObject);
        }
      
    }
}
