using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar instance;
    Image image;
    [HideInInspector] public Player currentPlayer;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            image = GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlayer != null)
            image.fillAmount = currentPlayer.currentHealth / currentPlayer.maxHealth;
    }
}
