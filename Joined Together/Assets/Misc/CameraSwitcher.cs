using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public float camSpeed;
    Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.instance.currentPlayer != null)
        {
            destination.Set(PlayerManager.instance.currentPlayer.transform.position.x, PlayerManager.instance.currentPlayer.transform.position.y, -10);
            transform.position = Vector3.Lerp(transform.position, destination, camSpeed * Time.deltaTime);
        }
    }
}
