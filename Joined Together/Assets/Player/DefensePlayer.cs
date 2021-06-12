using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensePlayer : Player
{
    public GameObject shield;
    float shieldRotation;

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
            CheckForShield();
        }
            
        StopDash();
    }

    protected override void Dash()
    {
        velocity = (PlayerManager.instance.player1.transform.position - transform.position).normalized;
        rb.velocity = velocity * dashSpeed;
    }

    void CheckForShield()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            shieldRotation = 180;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            shieldRotation = 0;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            shieldRotation = 90;

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            shieldRotation = 270;
        }

        shield.transform.rotation = Quaternion.Euler(0, 0, shieldRotation);
    }

    void StopDash()
    {
        if(isDashing)
        {
            if(Vector2.Distance(PlayerManager.instance.player1.transform.position, transform.position) < 0.5f)
            {
                isDashing = false;
            }
        }
    }
}
