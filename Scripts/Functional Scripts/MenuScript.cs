using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gamePauseMenu;

    [SerializeField]
    private string nextScene;

    [SerializeField]
    private bool isPauseAllowed;

    // Update is called once per frame
    void Update()
    {
        if (isPauseAllowed)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gamePauseMenu.activeSelf == false)
                {
                    gamePauseMenu.SetActive(true);
                }
                else
                {
                    gamePauseMenu.SetActive(false);
                }
            }
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        if (gamePauseMenu.activeSelf == true)
            gamePauseMenu.SetActive(false);
        else
        {
            Debug.Log("How the heck did you press a putton that does not exist?!");
        }

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
