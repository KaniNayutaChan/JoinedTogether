using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball instance;
    [HideInInspector] public Vector2 destination;
    public int speed;
    [HideInInspector] public bool hasCollided = false;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Shield"))
        {
            destination.Set(transform.position.x, transform.position.y);
            hasCollided = true;
        }
    }
}
