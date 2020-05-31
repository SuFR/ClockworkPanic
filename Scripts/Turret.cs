using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] float rotateAngle = 180f;
    [SerializeField] float startAngle = -90f;
    
    [SerializeField] float rotateSpeedMultiplier = 50f;

    // Update is called once per frame
    void Update()
    {

        float angle = Mathf.PingPong(Time.time * rotateSpeedMultiplier, rotateAngle) + startAngle;
        transform.eulerAngles = new Vector3(0, angle, 0);
        //Debug.Log(angle);




    }
}
