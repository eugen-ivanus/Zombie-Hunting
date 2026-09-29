using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 20f;
    public Vector3 SpawnPoint;


    public void TakeDamage (float amount)
    {
        health -= amount;

        if (health <= 0)
        {       
          transform.position = SpawnPoint;    
            
            health = 30f;

        }
    }
    
    
}
