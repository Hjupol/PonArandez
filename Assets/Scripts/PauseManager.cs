using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static bool pauseOn;
    private GameObject pausePanel;
    public GameObject player;
    private GameObject deathPanel;
    public GameObject pauseButton;


    void Start()
    {
        pauseOn = false;
        pausePanel = GameObject.Find("PausePanel");

        deathPanel = GameObject.Find("DeathPanel");
        deathPanel.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        player = GameObject.Find("Minion");
    }

    void Update()
    {
        if (!player.activeInHierarchy)
        {
            deathPanel.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
        }
        else
        {

        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            ResumeGame();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoMenu();
        }
        if (!PauseManager.pauseOn)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        AudioManager.instance.PlaySound("Button");
        pauseOn = false;
        BinaryPersistanceManager.SaveScore(BinaryPersistanceManager.totalCoins);
        BinaryPersistanceManager.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void ResumeGame()
    {
        AudioManager.instance.PlaySound("Button");

        if (PauseManager.pauseOn)
        {
            PauseManager.pauseOn = false;
            Time.timeScale = 1;
        }
        else
        {
            PauseManager.pauseOn = true;
            Time.timeScale = 0;
        }
    }

    public void GoMenu()
    {
        AudioManager.instance.PlaySound("Button");
        AudioManager.instance.PauseSound("Music");
        pauseOn = false;
        BinaryPersistanceManager.SaveScore(BinaryPersistanceManager.totalCoins);
        BinaryPersistanceManager.ResetScore();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        AudioManager.instance.PlaySound("Button");

        BinaryPersistanceManager.SaveScore(BinaryPersistanceManager.totalCoins);
        BinaryPersistanceManager.ResetScore();
        Application.Quit();
    }
}
