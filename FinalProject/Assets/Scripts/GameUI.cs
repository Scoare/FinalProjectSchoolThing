using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private Canvas inGameCanvas;
    [SerializeField] private Canvas mainMenuCanvas;
    [SerializeField] private Canvas gameOverCanvas;

    [SerializeField] private Button startButton;

    void Update()
    {
        if (gameManager.maxTimesTables < 2)
        {
            startButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            startButton.GetComponent<Button>().interactable = true;
        }
    }

    public void StartButton()
    {
        inGameCanvas.gameObject.SetActive(true);
        mainMenuCanvas.gameObject.SetActive(false);
        gameManager.StartGame();
    }

    public void RestartButton()
    {
        mainMenuCanvas.gameObject.SetActive(true);
        gameOverCanvas.gameObject.SetActive(false);
    }
}
