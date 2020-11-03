using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject tittleMenu;
    public GameObject levelsMenu;
    public GameObject creditsMenu;
    public GameObject referencesMenu;


    private void Start()
    {
        AudioManager.instance.PlaySound("MenuMusic");
    }

    public void Back()
    {
        AudioManager.instance.PlaySound("Button");
        if (creditsMenu.activeInHierarchy)
        {
            creditsMenu.SetActive(false);
        }
        if (referencesMenu.activeInHierarchy)
        {
            referencesMenu.SetActive(false);
        }
        if (levelsMenu.activeInHierarchy)
        {
            levelsMenu.SetActive(false);
        }
        tittleMenu.SetActive(true);
    }


    public void GoCreditsMenu()
    {
        AudioManager.instance.PlaySound("Button");
        tittleMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void GoLevelsMenu()
    {
        AudioManager.instance.PlaySound("Button");
        tittleMenu.SetActive(false);
        levelsMenu.SetActive(true);
    }

    public void GoReferenceMenu()
    {
        AudioManager.instance.PlaySound("Button");
        tittleMenu.SetActive(false);
        referencesMenu.SetActive(true);
    }

    public void PlayGame()
    {
        AudioManager.instance.PlaySound("Button");
        AudioManager.instance.PauseSound("MenuMusic");
        SceneManager.LoadScene(1);
    }

    

    public void Quit()
    {
        AudioManager.instance.PlaySound("Button");
        Application.Quit();
    }
}
