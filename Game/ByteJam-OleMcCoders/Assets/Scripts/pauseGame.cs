using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseGame : MonoBehaviour
{
    public bool gamePaused = false;
    public GameObject pauseMenu;

    void Start()
    {

        if (gamePaused == false)
        {
            Time.timeScale = 0;
            gamePaused = true;
            // Cursor.visible = true;
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
            //  Cursor.visible = false;
            gamePaused = false;
            Time.timeScale = 1;

        }

    }


      public  void Pause() {
            Time.timeScale = 0;
            gamePaused = true;
            // Cursor.visible = true;
            pauseMenu.SetActive(true);
        }

       public void unpause()
        {
            pauseMenu.SetActive(false);
            //  Cursor.visible = false;
            gamePaused = false;
            Time.timeScale = 1;
        }
    }

