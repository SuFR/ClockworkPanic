using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float projectileSpeed;

    //how many times the projectile can bounce off a wall before getting destroyed
    [SerializeField] int numberOfBounces;

    private GameObject prefabOfThis;


    public void Shoot(GameObject prefab) {
        prefabOfThis = prefab;
        GetComponent<Rigidbody>().AddForce(transform.right * -projectileSpeed);
    }

    //Gets the tag of the object that the projectile collided with and decides what to do from there
    private void OnTriggerEnter(Collider collider) {
        GameObject collidedObject = collider.gameObject;
        string tag = collidedObject.tag;

        switch (tag) {
            case "Wall":
                WallCollision(collidedObject);
                break;
            case "Shield":
                ShieldCollision(collidedObject);
                break;
            case "Enemy":
                EnemyCollison(collidedObject);
                break;
            case "Player":
                PlayerCollision(collidedObject);
                break;
        }
    }

    private void PlayerCollision(GameObject collidedObject) {
        
    }

    private void WallCollision(GameObject objectCollidedWith) {
        if (numberOfBounces == 0) {
            Destroy(gameObject);
        } else {
            Bounce(objectCollidedWith);
            numberOfBounces--;
        }
    }

    private void ShieldCollision(GameObject objectCollidedWith) {
        ShootProjectile shieldShoot = objectCollidedWith.GetComponentInChildren<ShootProjectile>();
        shieldShoot.SetProjectile(prefabOfThis);
        Destroy(gameObject);
        shieldShoot.Shoot();
    }

    private void EnemyCollison(GameObject objectCollidedWith) {
        
    }

    private void Bounce(GameObject objectCollidedWith) {

    }

}
