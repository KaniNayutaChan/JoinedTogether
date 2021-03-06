using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [HideInInspector] public float damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Arena"))
        {
            Destroy(gameObject, 0.05f);
        }

        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject, 0.05f);
            collision.GetComponent<EnemyHealth>().health -= damage;
        }
    }
}
