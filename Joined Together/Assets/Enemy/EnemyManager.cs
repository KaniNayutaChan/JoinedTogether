using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public GameObject enemy;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void SpawnEnemy()
    {
        PlayerManager.instance.currentHealth = PlayerManager.instance.maxHealth;
        Instantiate(enemy, new Vector2(0, 3), transform.rotation);
    }
}
