using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        // Generate a plane that intersects the transform's position with an upwards normal.
        Vector3 enemyPosition = transform.position;

        // Determine the target rotation.  This is the rotation if the transform looks at the target point.
        Quaternion targetRotation = Quaternion.LookRotation(enemyPosition - GetComponent<PlayerController>().transform.position);

        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
       
    }
}

