using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySelect : MonoBehaviour
{
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectDifficulty()
    {
        Destroy(GetComponentInParent<Canvas>().gameObject);
        PlayerManager.instance.maxHealth = health;
        PlayerManager.instance.currentHealth = health;
        PlayerManager.instance.StartFight();
    }
}
