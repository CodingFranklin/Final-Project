using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour
{

    [SerializeField] GameObject current;
    [SerializeField] GameObject max;

    [SerializeField] float energyPerFood;

    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();


        current = GameObject.Find("Current Energy");
        max = GameObject.Find("Max Energy");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EatFood()
    {
        if (playerMovement.currentEnergy + energyPerFood >= playerMovement.maxEnergy)
        {
            playerMovement.currentEnergy = playerMovement.maxEnergy;
        }
        else
        {
            playerMovement.currentEnergy += energyPerFood;
        }

        UpdateEnergyBar();
    }

    public void UpdateEnergyBar()
    {
        RectTransform currentRect = current.GetComponent<RectTransform>();
        RectTransform maxRect = max.GetComponent<RectTransform>();

        float percentage = playerMovement.currentEnergy / playerMovement.maxEnergy;

        float newWidth = maxRect.sizeDelta.x * percentage;

        currentRect.sizeDelta = new Vector2(newWidth, currentRect.sizeDelta.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
            EatFood();
        }
    }
}
