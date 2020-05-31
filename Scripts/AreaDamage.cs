using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDamage : MonoBehaviour
{
    [SerializeField] float rad = 10;
    [SerializeField] int damage = 1;
    [SerializeField] GameObject deathVFX;
    public void AreaDamageEffect()
    {
        Vector3 location = new Vector3();
        location = transform.position;
        Collider[] objectInRange = Physics.OverlapSphere(location, rad);
        foreach(Collider col in objectInRange)
        {
            if (col.GetComponent<Health>() != null)
            {
                Health health = col.GetComponent<Health>();
               
                //Linear Falloff effect if we want to use that
                float proximity = (location - col.transform.position).magnitude;
                int effect = Mathf.RoundToInt(1 - (proximity / rad));
                health.DealDamage(damage * effect);
                Instantiate(deathVFX, location, transform.rotation);
                    
               
            }
            
        }
    }
  
}
