using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    bool spawn = true;
    [SerializeField] float minSpawnDelay = 0.5f;
    [SerializeField] float maxSpawnDelay = 2f;
    [SerializeField] Enemy attackerPrefab;

	
	IEnumerator Start ()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            Spawn(attackerPrefab);
        }
        
	}

    private void Spawn(Enemy myAttacker)
    {
        Enemy newAttacker = Instantiate(myAttacker, transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0)) as Enemy;
        newAttacker.transform.parent = transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
