using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bond : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;

    LineRenderer lineRenderer;

    // Use this for initialization
    void Start()
    {
        lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject1 != null && gameObject2 != null)
        {
            lineRenderer.SetPosition(0, gameObject1.transform.position);
            lineRenderer.SetPosition(1, gameObject2.transform.position);
        }
    }
}