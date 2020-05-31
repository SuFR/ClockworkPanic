using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateForwardDirection : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField] float launchTime;
    [SerializeField] float lifeTime = 4.0f;
    
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY;
        
        launchTime = Time.time;
    }

    void LateUpdate()
    {
       
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
                Debug.Log("Arrow Destroyed");
                Destroy(gameObject);

        }
        else
        {
            transform.right = rigidBody.velocity;
            gameObject.transform.Rotate(-90, 0, 0);
        }
       
        
    }
}
