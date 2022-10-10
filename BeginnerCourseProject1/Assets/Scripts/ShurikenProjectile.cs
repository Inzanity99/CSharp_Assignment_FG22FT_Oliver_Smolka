using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenProjectile : MonoBehaviour
{
    public Transform ShurikenSpawnLocation;
    public GameObject shurikenPrefab;
    public float shurikenSpeed = 10f;
    public bool hasFired;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && hasFired == false)
        {
            hasFired = false;
            var _shuriken = Instantiate(shurikenPrefab, ShurikenSpawnLocation.position, ShurikenSpawnLocation.rotation);
            _shuriken.GetComponent<Rigidbody>().velocity = ShurikenSpawnLocation.forward * shurikenSpeed;
        }

    }


}
