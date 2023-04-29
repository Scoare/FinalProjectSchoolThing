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

    private AudioSource audioSource;
    [SerializeField] private AudioClip clickClip;

    void Start()
    {
        audioSource = gameManager.GetComponent<AudioSource>();
    }

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
        audioSource.PlayOneShot(clickClip);
    }

    public void RestartButton()
    {
        mainMenuCanvas.gameObject.SetActive(true);
        gameOverCanvas.gameObject.SetActive(false);
        audioSource.PlayOneShot(clickClip);
    }
}
