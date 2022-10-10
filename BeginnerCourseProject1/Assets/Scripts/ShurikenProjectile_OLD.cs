using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShurikenProjectile_OLD : MonoBehaviour
{/*
    // Projectile object
    public GameObject shuriken;

    // Projectile force
    public float shootForce, upwardForce;

    // Shuriken stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int shurikenAmount, shurikenPerTap;
    public bool allowButtonHold;

    int shurikensLeft, shurikensShot;

    // Bools
    bool shooting, readyToShoot, reloading;

    // Reference
    public Camera fpsCam;
    public Transform attackPoint;

    // Graphics
    public GameObject muzzleFlash; // Yes, my shurikens are THAT amazing
    public TextMeshProUGUI shurikenDisplay;

    // Bug fixing
    public bool AllowInvoke = true;

    private void Awake()
    {
        // Make sure we have shurikens
        shurikensLeft = shurikenAmount;
        readyToShoot = true;
    }

    // Update is called once per frame
    private void Update()
    {
        MyInput();

        // Set Shuriken display
        if (shurikenDisplay != null)
            shurikenDisplay.SetText(shurikensLeft / shurikenPerTap + " / " + shurikenAmount / shurikenPerTap); // I am dividing the total amount by "perTap" because it makes more sense for the player to understand how many shots are left
    }

    private void MyInput()
    {
        // Check if player is allowed to hold down button and take corresponding input
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        // Reloading, if we have less shurikens than max and were not already reloading
        if (Input.GetKeyDown(KeyCode.R) && shurikensLeft < shurikenAmount && !reloading) 
            Reload();
        // Auto-reloading, when player presses shoot without any shurikens left
        if (readyToShoot && shooting && !reloading && shurikensLeft <= 0)
            Reload();

        // Shooting
        if (readyToShoot && shooting && !reloading && shurikensLeft > 0)
        {
            // Set shurikens to 0
            shurikensShot = 0;

            Shoot();
        }
    
    }

    private void Shoot()
    {
        readyToShoot = false;

        // Find the exact hit position using a raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        // Check if the ray cast hits something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); // Just a point far away from the player

        // Calculate direction from attackPoint(projectile spawn point) to targetPoint (A -> B = B-A)
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        // Calculate shuriken spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        // Re-calculate direction with weapon spread applied
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        // Instantiate bullet/projectile
        GameObject currentShuriken = Instantiate(shuriken, attackPoint.position, Quaternion.identity);
        // Rotate the shuriken towards shoot direction
        currentShuriken.transform.forward = directionWithSpread.normalized;

        // Add forces to shuriken
        currentShuriken.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentShuriken.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        // Instantiate muzzleflash
        if (muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        shurikensLeft--;
        shurikensShot++;

        // Invoke resetShot function (if not already invoked)
        if (AllowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            AllowInvoke = false;
        }

        // If more than one shurikensPerTap, make sure to repeat shoot function 
        if (shurikensShot < shurikenPerTap && shurikensLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        // Allow shooting and invoking again
        readyToShoot = true;
        AllowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime); 
    }

    private void ReloadFinished()
    {
        shurikensLeft = shurikenAmount;
        reloading = false;
    }

*/
}
