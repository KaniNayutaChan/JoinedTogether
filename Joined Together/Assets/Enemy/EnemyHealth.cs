using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            StartCoroutine(WinScene());
        }
    }

    IEnumerator WinScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(3);
    }
}
