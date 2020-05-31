using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    Rigidbody platform;
    [SerializeField] Vector3 movementVector = new Vector3(10f,10f,10f);
    [SerializeField] float period = 4f;

    float movementFactor; //0 not moved 1 fully
    Vector3 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon){return;}// protect against period is zero

        float cycles = Time.time / period; // grows from 0

        const float tau = Mathf.PI * 2f; // about 6.28
        float rawSinWave = Mathf.Sin(cycles * tau); //goes from -1 to +1
        

        movementFactor = rawSinWave / 2f + 0.5f;
        //print(movementFactor);
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
        
    }
}
