using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensePlayer : Player
{
    public GameObject shieldEmpty;
    public GameObject shield;
    float shieldRotation;
    public float maxShieldLength;
    public float shieldLengthMultiplier;
    Vector3 shieldLength = new Vector3();

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


        float length = maxShieldLength - Vector2.Distance(transform.position, PlayerManager.instance.player1.transform.position) * shieldLengthMultiplier;
        if(length < 0.1f)
        {
            length = 0.1f;
        }
        shieldLength.Set(length, 0.3f, 1);
        shield.transform.localScale = shieldLength;
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
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                shieldRotation = 135;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                shieldRotation = 225;
            }
            else
            {
                shieldRotation = 180;
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                shieldRotation = 45;

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                shieldRotation = 315;
            }
            else
            {
                shieldRotation = 0;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                shieldRotation = 90;

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                shieldRotation = 270;
            }
        }

        shieldEmpty.transform.rotation = Quaternion.Euler(0, 0, shieldRotation);
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
