using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool isAlive = true;
    [SerializeField] float runSpeed = 20.0f;
    [SerializeField] float winTimer = 100f;
    private float translate;
    private float straffe;
    private Health health;
    private TimeManager time;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        health = GetComponent<Health>();
        time = GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {

        isAlive = health.IsAlive();
        if (isAlive)
        {
            winTimer -= Time.unscaledDeltaTime;
            if (winTimer < 0)
            {
                Debug.Log("You Won!");

               
            }
        }
        if (!isAlive)
        {
            Debug.Log(isAlive + "You Died!");
        
        }

        translate = Input.GetAxis("Vertical") * runSpeed * Time.unscaledDeltaTime;
        straffe = Input.GetAxis("Horizontal") * runSpeed * Time.unscaledDeltaTime;
        transform.Translate(straffe, 0, translate);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
