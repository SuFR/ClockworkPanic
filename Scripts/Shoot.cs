using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    
    public GameObject projectile;
    public float shootForce;
    public Transform firePoint;
    public float shotInterval = .5f;
   
  


    // Use this for initialization
    void Start()
    {

        firePoint = transform.Find("FirePoint");
        InvokeRepeating("ShootProjectile", 1.0f, shotInterval);
  

    }

    public void SetSpeedofShot(float x)
    {
        shotInterval = x;
    }
    public void ShootProjectile()
    {
        GameObject shot = GameObject.Instantiate(projectile, firePoint.position, firePoint.rotation);
        shot.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
    }
    
}