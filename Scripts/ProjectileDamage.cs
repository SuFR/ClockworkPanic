using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{

    [SerializeField] int damage = 1;

    private void OnTriggerEnter(Collider otherCollider)
    {
        GetComponent<SoundEffect>().PlaySoundEffect();
        Debug.Log("arrow hit");

        var health = otherCollider.GetComponent<Health>();

       // Debug.Log("I hit " + otherCollider.gameObject);

        if (health != null)
        {
            if(otherCollider.gameObject.tag == "Player" || otherCollider.gameObject.tag == "Enemy")
            {
                //Debug.Log("Damage Delt");
                health.DealDamage(damage);
                Destroy(gameObject);
            }
            if(otherCollider.gameObject.tag == "Shield")
            {
                Debug.Log("Hit Sheild No DMG!");
            }
                
        }
    }
}
