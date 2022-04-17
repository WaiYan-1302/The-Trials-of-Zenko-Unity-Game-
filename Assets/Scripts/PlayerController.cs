using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    public GameObject pickupEffect;

    public float movementSpeed;

    private Animator animator;
    private bool isRunning = false;

    public Pause PauseScript;

    

    bool movingLeft = true;
    bool firstInput = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       

        if (GameManager.instance.gameStarted)
        {
            
            Move();
            CheckInput();
        }

        if (transform.position.y <= -2)
        {
            GameManager.instance.GameOver();
        }


    }

    void Move()
    {
        
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    void CheckInput()
    {
        //if first input, ignore it
        if (firstInput)
        {
            animator.SetBool("IsRunning", true);
            firstInput = false;
            
            return;
            // below mosueButton zero code won't be executed
        }

        if (Input.GetMouseButtonDown(0) && !PauseScript.isGamePaused)
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        if (movingLeft)
        {
            movingLeft = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);

        }

        else
        {
            movingLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Orb")
        {
            GameManager.instance.IncrementScore();

            Instantiate(pickupEffect, other.transform.position, pickupEffect.transform.rotation);

            other.gameObject.SetActive(false); 
        }
    }
}
