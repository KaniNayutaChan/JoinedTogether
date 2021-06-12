using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 velocity;

    [Space]
    public float maxHealth;
    [HideInInspector] public float currentHealth;

    [Space]
    public float movementSpeed;
    public float dashSpeed;
    public float dashDuration;
    float startDashDuration;
    public float dashCooldown;
    float startDashCooldown;
    float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        currentSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        CallTimers();

        if (PlayerManager.instance.currentPlayer != this.gameObject)
            return;

        CheckForMove();
        CheckForDash();
    }

    void CallTimers()
    {
        if(startDashCooldown >= 0)
        {
            startDashCooldown -= Time.deltaTime;
        }

        if(startDashDuration >= 0)
        {
            startDashDuration -= Time.deltaTime;
        }
        else
        {
            currentSpeed = movementSpeed;
        }
    }

    void CheckForMove()
    {
        if(Input.GetKey(KeyCode.W))
        {
            velocity.y = 1;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            velocity.y = -1;
        }
        else
        {
            velocity.y = 0;
        }

        if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            velocity.x = 1;
        }
        else
        {
            velocity.x = 0;
        }

        rb.velocity = velocity * currentSpeed;
    }

    void CheckForDash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (startDashCooldown < 0)
            {
                currentSpeed = dashSpeed;
                startDashDuration = dashDuration;
                startDashCooldown = dashCooldown;
            }
        }
    }
}

