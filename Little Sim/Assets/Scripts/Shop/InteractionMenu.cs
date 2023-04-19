using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionMenu : MonoBehaviour
{
    [Header("Serializables")]
    [SerializeField] GameObject faceMenu;
    [SerializeField] GameObject hoodMenu;
    [SerializeField] SpriteRenderer faceRenderer;
    [SerializeField] SpriteRenderer hoodRenderer;
    [SerializeField] TextMeshProUGUI priceText;
    
    private GameObject currentMenu;
    private Sprite enterFace;
    private Sprite enterHood;
    private bool isBuyingFace;
    private bool isBuyingHood;
    private bool payed;
    private int totalPrice;


    public bool isBuyingSomething;

    public Sprite currentSprite;

    //List<GameObject> currentOptions;
    //[SerializeField] Sprite[] currentOptions;

    private void Start()
    {
        currentMenu = faceMenu;
        //ChangeMenu(faceMenu);
    }
    private void Update()
    {
        // Changes price
        priceText.text = "Buy   " + totalPrice;

        // Check if is trying the same item as they entered with
        if(faceRenderer.sprite == enterFace && isBuyingFace)
        {
            isBuyingFace = false;
            totalPrice -= 10;
        }

        // Checks if is buying some item 
        if (isBuyingFace || isBuyingHood)
            isBuyingSomething = true;
        else if ((!isBuyingFace && !isBuyingHood) || payed)
            isBuyingSomething = false;
        
    }

    public void OpenFaceMenu()
    {
        if(currentMenu != faceMenu)
            ChangeMenu(faceMenu);
    }

    public void ChangeFace()
    {
        if (faceRenderer.sprite != currentSprite)
        {
            faceRenderer.sprite = currentSprite;
            if(!isBuyingFace)
            {
                isBuyingFace = true;
                totalPrice += 10;
            }
        }
        /*
        else if(faceRenderer.sprite == enterFace)
        {
            if(isBuyingFace)
            {
                isBuyingFace = false;
                totalPrice -= 10;
            }
        }
        //*/
    }
    
    public void OpenHoodMenu()
    {
        if(currentMenu != hoodMenu)
            ChangeMenu(hoodMenu);
    }

    public void ChangeHood()
    {
        if (hoodRenderer.sprite != currentSprite)
        {
            hoodRenderer.sprite = currentSprite;
        }
    }

    private void ChangeMenu(GameObject newMenu)
    {
        currentMenu.SetActive(false);
        currentMenu = newMenu;
        //currentOptions = new List<GameObject>();
        //currentOptions = currentMenu.GetComponentsInChildren<Sprite>();
        currentMenu.SetActive(true);
    }

    public void BuyClothes()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().Pay(totalPrice))
        {
            SaveClothes();
            payed = true;
            priceText.text = "Buy   " + totalPrice;
        }
    }

    public void SaveClothes()
    {
        payed = false;
        enterFace = faceRenderer.sprite;
        enterHood = hoodRenderer.sprite;
    }

    public void RestoreClothes()
    {
        faceRenderer.sprite = enterFace;
        hoodRenderer.sprite = enterHood;
    }
}
