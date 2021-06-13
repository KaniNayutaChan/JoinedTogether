using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public GameObject Ball;
    GameObject ball;
    public GameObject handPos;
    LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        ball = Instantiate(Ball, transform.position, transform.rotation);
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.05F;
        lineRenderer.endWidth = 0.05F;
        lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            StartCoroutine(WinScene());
        }

        lineRenderer.SetPosition(0, handPos.transform.position);
        lineRenderer.SetPosition(1, ball.transform.position);
    }

    IEnumerator WinScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(3);
    }
}
