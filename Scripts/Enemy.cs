using System.Diagnostics;
using UnityEngine;

using UnityEngine.AI;
 
public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] GameObject target;
 
    //[SerializeField] int radius = 10;   
    //[SerializeField] int scorePerHit = 12;
    //[SerializeField] int hitsLeft = 3;
    //[SerializeField] int explosionDamage = 10;
    private bool isDetonate = false;
    [SerializeField] float detonateTimer = 1.0f;
    private Health health;

    private AreaDamage areaDamage;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        health = GetComponent<Health>();
        areaDamage = GetComponent<AreaDamage>();
        agent = this.GetComponent<NavMeshAgent>();
        
        AddBoxCollider();
        
    }
    private void Update()
    {
        //Debug.Log(health.IsAlive());
        
        if(gameObject != null && target != null)
        {
            
            float dist = Vector3.Distance(target.transform.position, transform.position);
            if(dist < 5f)
            {
                isDetonate = true;
            }
            if (isDetonate)
            {
                agent.isStopped = true;
                detonateTimer -= Time.deltaTime;
                if (detonateTimer <= 0)
                {

                    areaDamage.AreaDamageEffect();
                    health.DealDamage(99999);
                    Destroy(gameObject);
                }
            }
           
            else if(!isDetonate)
            {
                
                 SetDestination();
                
            }
            
        }
        
        
    }
   
    void SetDestination()
    {
        
          agent.SetDestination(target.transform.position);

       
        
    }
    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }
    
    void OnParticleCollision(GameObject other)
    {
        if(gameObject != null)
        {
            UnityEngine.Debug.Log("Enemy Hit with Projectile");
            health.DealDamage(1);
        }
        

    }    
}

