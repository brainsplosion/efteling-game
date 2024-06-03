using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Button[] menuButtons;
    [SerializeField] private GameObject skillTreePanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private CameraManager cameraManager;
    private bool showMenu = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (showMenu == true)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        //pausing the game
         menuPanel.SetActive(true);
        showMenu = true;

        Cursor.lockState = CursorLockMode.Confined;
        playerController.enabled = false;
        cameraManager.enabled = false;

        ResetButtonStates();
    }
    public void Continue()
    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
        showMenu = false;
    
        Cursor.lockState = CursorLockMode.Locked;
        playerController.enabled = true;
        cameraManager.enabled = true;
        //Other behaviors: locking back mouse, enable camera, enable movement and aiming

        ResetButtonStates();
    }
    
    public void Options()
    {
        //Redirects to another panel
        menuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }
    
    public void SkillTree()
    {
        //Redirects to another panel
        menuPanel.SetActive(false);
        showMenu = false;
        skillTreePanel.SetActive(true);
    }

    public void BackOne()
    {
        //Redirects to another panel
        skillTreePanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void BackTwo()
    {
        //Redirects to another panel
        optionsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void Exit()
    {
        //Exits the game
        Application.Quit();
    }

    public void ResetButtonStates()
    {
        // Gather every gameObject that contains a Button component and is a child of the menuPanel.
        menuButtons = menuPanel.GetComponentsInChildren<Button>();

        // Now, go through every button in the list of menuButtons, and turn them off and on.
        foreach (Button button in menuButtons)
        {
            button.interactable = false;
            button.interactable = true;
        }
    }
}