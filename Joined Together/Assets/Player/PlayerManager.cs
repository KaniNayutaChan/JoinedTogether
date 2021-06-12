using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public GameObject player1;
    public GameObject player2;
    [HideInInspector] public GameObject currentPlayer;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            currentPlayer = player2;
            SwitchPlayer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
        {
            SwitchPlayer();
        }
    }

    void SwitchPlayer()
    {
        currentPlayer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        currentPlayer.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

        if (currentPlayer == player1)
        {
            currentPlayer = player2;
        }
        else
        {
            currentPlayer = player1;
        }

        currentPlayer.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        HealthBar.instance.currentPlayer = currentPlayer.GetComponent<Player>();
    }
}
