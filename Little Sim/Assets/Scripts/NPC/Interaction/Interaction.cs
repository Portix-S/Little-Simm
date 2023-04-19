using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] GameObject hintText;
    [SerializeField] GameObject interactionMenu;
    [SerializeField] GameObject canvasCamera;
    private bool onTrigger;
    private PlayerMovement playerScript;

    private void Update()
    {
        // Open Interaction Menu
        if(onTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
                SetMenuActive(!playerScript.isOnMenu);
            if (playerScript.isOnMenu && Input.GetKeyDown(KeyCode.Escape))
                SetMenuActive(false);
        }
    }

    private void SetMenuActive(bool onMenu)
    {
        playerScript.isOnMenu = !playerScript.isOnMenu;
        interactionMenu.SetActive(onMenu);
        canvasCamera.SetActive(onMenu);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerScript = collision.GetComponent<PlayerMovement>();
            onTrigger = true;
            hintText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            onTrigger = false;
            hintText.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
