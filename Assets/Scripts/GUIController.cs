using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    public Text coinsText;
    public Button powButton;


    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(SceneManager.GetActiveScene().buildIndex.ToString());
        coinsText.text = BinaryPersistanceManager.totalCoins[SceneManager.GetActiveScene().buildIndex].ToString();

        if (PlayerController.hasPowerUp)
        {
            powButton.gameObject.SetActive(true);
        }
        else if(!PlayerController.hasPowerUp)
        {
            powButton.gameObject.SetActive(false);
        }
    }

    public void ActivePowerUp()
    {
        PlayerController.ActivePowerUp(PowerUpController.collectedPU);
        
    }
}
