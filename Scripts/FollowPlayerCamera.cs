using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed = 0.125f;
    [SerializeField] Vector3 rotation = new Vector3(45f,0f,0f); 
    [SerializeField] Vector3 offset = new Vector3(0f,20f,0f);
    void LateUpdate()
    {
        if(target != null)
        {
            //Vector3 desiredPosition = target.position + offset;
            //Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = target.position + offset;
            transform.rotation = Quaternion.Euler(rotation);
            transform.LookAt(target);
        }
        
    }
 
   
}
