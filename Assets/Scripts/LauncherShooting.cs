using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherShooting : MonoBehaviour
{
    public Rigidbody coin;
    public Transform fireTransform;
    public float minLaunchForce = 15f;
    public float maxLaunchForce = 30f;
    public float maxChargeTime = 0.75f;

    //private string m_FireButton;
    private float currentLaunchForce;
    private float chargeSpeed;
    private bool fired;

    // Start is called before the first frame update
    void Start()
    {
        chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;
    }

    // Update is called once per frame
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

    void Fire()
    {
        fired = true;

        Rigidbody coinInstance = Instantiate(coin, fireTransform.position, fireTransform.rotation) as Rigidbody;

        coinInstance.velocity = currentLaunchForce * fireTransform.forward;

        currentLaunchForce = minLaunchForce;
    }


}
