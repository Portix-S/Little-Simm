using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionMenu : MonoBehaviour
{
    [Header("Serializables")]
    [SerializeField] GameObject faceMenu;
    [SerializeField] GameObject hoodMenu;
    [SerializeField] SpriteRenderer faceRenderer;
    [SerializeField] SpriteRenderer hoodRenderer;

    private GameObject currentMenu;



    public Sprite currentSprite;

    //List<GameObject> currentOptions;
    //[SerializeField] Sprite[] currentOptions;

    private void Start()
    {
        currentMenu = faceMenu;
        //ChangeMenu(faceMenu);
    }

    public void OpenFaceMenu()
    {
        if(currentMenu != faceMenu)
            ChangeMenu(faceMenu);
    }

    public void ChangeFace()
    {
        if (faceRenderer.sprite != currentSprite)
            faceRenderer.sprite = currentSprite;
    }
    
    public void OpenHoodMenu()
    {
        if(currentMenu != hoodMenu)
            ChangeMenu(hoodMenu);
    }

    public void ChangeHood()
    {
        if (hoodRenderer.sprite != currentSprite)
            hoodRenderer.sprite = currentSprite;
    }

    private void ChangeMenu(GameObject newMenu)
    {
        currentMenu.SetActive(false);
        currentMenu = newMenu;
        //currentOptions = new List<GameObject>();
        //currentOptions = currentMenu.GetComponentsInChildren<Sprite>();
        currentMenu.SetActive(true);
    }
}
