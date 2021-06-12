using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensePlayer : Player
{
    [Space]
    public GameObject Skill;
    Vector2 attackVelocity;
    public float attackSpeed;
    public float attackCooldown;
    float currentAttackCooldown;
    float attackDamage;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (currentAttackCooldown < 0)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                attackVelocity.y = -1;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                attackVelocity.y = 1;
            }
            else
            {
                attackVelocity.y = 0;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                attackVelocity.x = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                attackVelocity.x = 1;
            }
            else
            {
                attackVelocity.x = 0;
            }

            GameObject skill = Instantiate(Skill, transform.position, transform.rotation);
            skill.GetComponent<Rigidbody2D>().velocity = attackVelocity * attackSpeed;
            currentAttackCooldown = attackCooldown;
        }
    }

    protected override void CallTimers()
    {
        base.CallTimers();

        if(currentAttackCooldown >= 0)
        {
            currentAttackCooldown -= Time.deltaTime;
        }
    }
}
