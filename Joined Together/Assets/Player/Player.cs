using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Vector2 velocity;
    [HideInInspector] public bool isDead = false;

    [Space]
    public float movementSpeed;
    protected float currentSpeed;
    [HideInInspector] public bool isDashing = false;

    [Space]
    public float dashSpeed;
    public float dashCooldown;
    protected float currentDashCooldown;

    [Space]
    public float invulnerableTime;
    float currentInvulnerableTime;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = movementSpeed;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (isDead)
            return;

        CallTimers();

        if (PlayerManager.instance.currentPlayer == this.gameObject)
        {
            if (!isDashing)
            {
                CheckForMove();
            }

            CheckForDash();
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
            if (currentDashCooldown < 0)
            {
                currentDashCooldown = dashCooldown;
                isDashing = true;
                Dash();
            }
        }
    }

    protected virtual void Dash()
    {

    }

    protected virtual void CallTimers()
    {
        if (currentDashCooldown >= 0)
        {
            currentDashCooldown -= Time.deltaTime;
        }

        if(currentInvulnerableTime >= 0)
        {
            currentInvulnerableTime -= Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Skill") || collision.CompareTag("Enemy"))
        {
            if (currentInvulnerableTime < 0)
            {
                PlayerManager.instance.currentHealth -= 1;
                currentInvulnerableTime = invulnerableTime;
            }
        }

    }
}

