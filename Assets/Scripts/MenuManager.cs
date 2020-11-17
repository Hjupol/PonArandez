using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject tittleMenu;
    public GameObject levelsMenu;
    public GameObject creditsMenu;
    public GameObject referencesMenu;


    public Text level1MaxSeeds;
    public Text level2MaxSeeds;

    private void Start()
    {
        AudioManager.instance.PlaySound("MenuMusic");
    }

    private void Update()
    {
        level1MaxSeeds.text = "Max seeds: " + BinaryPersistanceManager.maxCoins[1].ToString();
        level2MaxSeeds.text = "Max seeds: " + BinaryPersistanceManager.maxCoins[2].ToString();
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

    public void PlayLevel1()
    {
        AudioManager.instance.PlaySound("Button");
        AudioManager.instance.PauseSound("MenuMusic");
        SceneManager.LoadScene(1);
    }

    public void PlayLevel2()
    {
        AudioManager.instance.PlaySound("Button");
        AudioManager.instance.PauseSound("MenuMusic");
        SceneManager.LoadScene(2);
    }


    public void Quit()
    {
        AudioManager.instance.PlaySound("Button");
        Application.Quit();
    }
}
