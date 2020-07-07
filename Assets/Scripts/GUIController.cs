using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        
        coinsText.text = BinaryPersistanceManager.totalCoins.ToString();
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
