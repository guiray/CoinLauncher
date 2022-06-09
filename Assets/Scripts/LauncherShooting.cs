using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherShooting : MonoBehaviour
{
    [SerializeField]
    private Rigidbody coin;
    [SerializeField]
    private Transform fireTransform;
    [SerializeField]
    private float minLaunchForce = 15f;
    [SerializeField]
    private float maxLaunchForce = 30f;
    [SerializeField]
    private float maxChargeTime = 0.75f;

    private float currentLaunchForce;
    private float chargeSpeed;
    private bool fired;

    void Start()
    {
        chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;
    }

    void Update()
    {
        if (currentLaunchForce >= maxLaunchForce && !fired)
        {
            //at max charge, not yet fired
            currentLaunchForce = maxLaunchForce;
            Fire(); 
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            //pressed fire for the first time
            fired = false;
            currentLaunchForce = minLaunchForce;
        }
        else if (Input.GetButton("Fire1") && !fired)
        {
            //holding fire button
            currentLaunchForce += chargeSpeed * Time.deltaTime;
        }
        else if (Input.GetButtonUp("Fire1") && !fired)
        {
            // released fire button
            Fire();
        }
        Debug.Log(currentLaunchForce);
    }

    private void Fire()
    {
        fired = true;

        Rigidbody coinInstance = Instantiate(coin, fireTransform.position, fireTransform.rotation) as Rigidbody;

        coinInstance.velocity = currentLaunchForce * fireTransform.forward;

        currentLaunchForce = minLaunchForce;
    }


}
