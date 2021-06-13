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
    float attackRotation;

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
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    attackVelocity.x = -1;
                    attackVelocity.y = -1;
                    attackRotation = 135;
                    spawnAttack = true;
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    attackVelocity.x = 1;
                    attackVelocity.y = -1;
                    attackRotation = 225;
                    spawnAttack = true;
                }
                else
                {
                    attackVelocity.y = -1;
                    attackVelocity.x = 0;
                    attackRotation = 180;
                    spawnAttack = true;
                }
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    attackVelocity.y = 1;
                    attackVelocity.x = -1;
                    attackRotation = 45;
                    spawnAttack = true;

                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    attackVelocity.y = 1;
                    attackVelocity.x = 1;
                    attackRotation = 315;
                    spawnAttack = true;
                }
                else
                {
                    attackVelocity.y = 1;
                    attackVelocity.x = 0;
                    attackRotation = 0;
                    spawnAttack = true;
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    attackVelocity.y = 0;
                    attackVelocity.x = -1;
                    attackRotation = 90;
                    spawnAttack = true;

                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    attackVelocity.y = 0;
                    attackVelocity.x = 1;
                    attackRotation = 270;
                    spawnAttack = true;
                }
            }

            if (spawnAttack)
            {
                GameObject attack = Instantiate(Attack, transform.position, Quaternion.Euler(0,0,attackRotation));
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
