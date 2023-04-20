using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public bool isPaused;

    private PlayerMovement playerMov;

    private void Start()
    {
        playerMov = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = true;
            playerMov.isOnPauseMenu = true;
            pauseMenu.SetActive(true);
        }
        else if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToGame();
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnToGame()
    {
        isPaused = false;
        playerMov.isOnPauseMenu = false;
        pauseMenu.SetActive(false);
    }
}
