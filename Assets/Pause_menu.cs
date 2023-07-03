using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_menu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject text;
    public GameObject win;
    public GameObject crosshair;
    public GameObject score;
    public Weapon playerWeapon;

    void Awake()
    {
        //playerWeapon = GetComponent<Weapon>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
            
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;

        text.SetActive(true);
        win.SetActive(true);
        crosshair.SetActive(true);
        score.SetActive(true);

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audio in audios)
        {
            audio.UnPause();
        }

        //playerWeapon.enabled = true;
        playerWeapon.GetComponent<Weapon>().enabled = true;

        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        text.SetActive(false);
        win.SetActive(false);
        crosshair.SetActive(false);
        score.SetActive(false);

        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        
        foreach (AudioSource audio in audios)
        {
            audio.Pause();
        }

        //playerWeapon.enabled = false;
        playerWeapon.GetComponent<Weapon>().enabled = false;



        GameIsPaused = true;
    }

    public void OpenOptions()
    {
        Debug.Log("options");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
