using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    bool attack = true;

    [SerializeField] GameObject projectileObject;

    [SerializeField] float minTimeBetweenAttacks;
    [SerializeField] float maxTimeBetweenAttacks;

    [SerializeField] int numberOfshotsperAttack;
    [SerializeField] float timeBetweenShots;

    IEnumerator Start() {
        while (attack) {
            yield return new WaitForSeconds(Random.Range(minTimeBetweenAttacks, maxTimeBetweenAttacks));
            for (int i = 0; i < numberOfshotsperAttack; i++) {
                StartCoroutine(Attack(timeBetweenShots * i));
            }

        }
    }

    public void Shoot() {
        if (projectileObject != null) {
            Vector3 curRotation = transform.rotation.eulerAngles;
            Vector3 newRotation = projectileObject.transform.rotation.eulerAngles;
            newRotation = new Vector3(newRotation.x + curRotation.x, newRotation.y + curRotation.y, newRotation.z + curRotation.z);
            GameObject projectile = Instantiate(projectileObject, transform.position, Quaternion.Euler(newRotation));
            projectile.GetComponent<Projectile>().Shoot(projectileObject);
        }
    }

    public void SetProjectile(GameObject projectile) {
        projectileObject = projectile;
    }



    private IEnumerator Attack(float secondsUntilAttack) {
        yield return new WaitForSeconds(secondsUntilAttack);
        Shoot();
    }

}
