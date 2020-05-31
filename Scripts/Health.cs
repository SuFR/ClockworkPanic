using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.VFX;

public class Health : MonoBehaviour
{

    [SerializeField] int health = 3;
    //[SerializeField] GameObject deathVFX;
    private bool isAlive = true;

    public void DealDamage(int damage)
    {
        health -= damage;
        //Debug.Log(health);
        if(health <= 0)
        {
            isAlive = false;  
        }
    }
    public bool IsAlive()
    {
        return isAlive;
    }
    public int GetHealth()
    {
        return health;
    }
    public void AddHealth(int hp)
    {
        health = health + hp;
    }

 
}
