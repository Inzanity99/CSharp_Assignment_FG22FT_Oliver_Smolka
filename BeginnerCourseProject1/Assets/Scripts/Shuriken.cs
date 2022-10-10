using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public float shurikenLife = 5;
    public int shurikenDamage = 20;

    void Awake()
    {
        Destroy(gameObject, shurikenLife);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        if(collision.gameObject.TryGetComponent<PlayerStats>(out PlayerStats playerComponent))
        {
            playerComponent.LooseHealth(20);
        }
        
     }
}
