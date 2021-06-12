using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensePlayer : Player
{
    [Space]
    public float dashDuration;
    protected float currentDashDuration;

    [Space]
    public GameObject Attack;
    Vector2 attackVelocity;
    public float attackSpeed;
    public float attackCooldown;
    float currentAttackCooldown;
    public float maxDamage;
    public float attackDamageMultiplier;
    public float maxAttackSize;
    public float minAttackSize;
    public float attackSizeMultiplier;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (PlayerManager.instance.currentPlayer == this.gameObject)
        {
            CheckForAttack();
        }
    }

    void CheckForAttack()
    {
        if (currentAttackCooldown < 0)
        {
            bool spawnAttack = false;

            if (Input.GetKey(KeyCode.DownArrow))
            {
                attackVelocity.y = -1;
                spawnAttack = true;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                attackVelocity.y = 1;
                spawnAttack = true;
            }
            else
            {
                attackVelocity.y = 0;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                attackVelocity.x = -1;
                spawnAttack = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                attackVelocity.x = 1;
                spawnAttack = true;
            }
            else
            {
                attackVelocity.x = 0;
            }

            if (spawnAttack)
            {
                GameObject attack = Instantiate(Attack, transform.position, transform.rotation);
                attack.GetComponent<Rigidbody2D>().velocity = attackVelocity * attackSpeed;

                float damage = maxDamage - Vector2.Distance(transform.position, PlayerManager.instance.player2.transform.position) * attackDamageMultiplier;
                attack.GetComponent<Attack>().damage = damage;

                float size = maxAttackSize - Vector2.Distance(transform.position, PlayerManager.instance.player2.transform.position) * attackSizeMultiplier;
                if(size < minAttackSize)
                {
                    size = minAttackSize;
                }
                attack.transform.localScale = new Vector3(size, size, 1);

                currentAttackCooldown = attackCooldown;
            }
        }
    }

    protected override void Dash()
    {
        if (Input.GetKey(KeyCode.W))
        {
            velocity.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
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

        rb.velocity = dashSpeed * velocity;
        currentDashDuration = dashDuration;
    }

    protected override void CallTimers()
    {
        base.CallTimers();

        if(currentAttackCooldown >= 0)
        {
            currentAttackCooldown -= Time.deltaTime;
        }

        if (currentDashDuration >= 0)
        {
            currentDashDuration -= Time.deltaTime;
        }
        else
        {
            currentSpeed = movementSpeed;
            isDashing = false;
        }
    }
}
