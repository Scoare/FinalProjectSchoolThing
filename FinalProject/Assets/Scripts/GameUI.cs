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
    [SerializeField] private Button tutorialButton;

    private AudioSource audioSource;
    [SerializeField] private AudioClip clickClip;

    void Start()
    {
        audioSource = gameManager.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (gameManager.maxTimesTables < 3)
        {
            startButton.interactable = false;
        }
        else
        {
            startButton.interactable = true;

            if (gameManager.tutorialStage == 2)
            {
                audioSource.PlayOneShot(gameManager.tutorialClips[5]);
                gameManager.tutorialStage = 3;

                StartCoroutine(TutorialImpatience());
            }
        }

        if(gameManager.tutorialStage == 0)
        {
            tutorialButton.interactable = true;
        }
    }

    private IEnumerator TutorialImpatience()
    {
        yield return new WaitForSeconds(10);
        if (gameManager.tutorialStage == 3)
        {
            audioSource.PlayOneShot(gameManager.tutorialClips[6]);
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

    public void TutorialButton()
    {
        tutorialButton.interactable = false;
        StartCoroutine(gameManager.StartTutorial());
    }
}
