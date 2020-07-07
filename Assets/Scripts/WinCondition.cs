using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    private GameObject winPanel;
    public Text coinsText;
    public GameObject pauseButton;
    public static bool winCondition;

    private void Start()
    {
        winPanel = GameObject.Find("WinPanel");
        pauseButton = GameObject.Find("PauseButton");
        winPanel.SetActive(false);
        winCondition = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.CompareTag("Player"))
        {
            winCondition = true;
            Time.timeScale = 0;
            winPanel.SetActive(true);
            coinsText.text = "Coins collected: "+ BinaryPersistanceManager.totalCoins.ToString();
            pauseButton.SetActive(false);
        }
    }
}
