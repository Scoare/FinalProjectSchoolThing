using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float currentTime = 0f;
    private float startingTime = 60f;
    private bool timerStarted;

    public int score;

    public int maxTimesTables;

    private int firstNumber;
    private int secondNumber;
    private int answer;

    private string input;

    [SerializeField] private Canvas inGameCanvas;
    [SerializeField] private Canvas mainMenuCanvas;
    [SerializeField] private Canvas gameOverCanvas;

    [SerializeField] private TMP_Text questionText;
    [SerializeField] private TMP_Text answerText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text scoreText;

    private AudioSource audioSource;

    [SerializeField] private AudioClip ringClip;
    [SerializeField] private AudioClip keyClip;

    [SerializeField] public AudioClip[] tutorialClips;

    [HideInInspector] public int tutorialStage = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        inGameCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        if(tutorialStage == 0)
        {
            StartTimer();
            NewQuestion();
            score = 0;
        }
        else
        {
            questionText.text = "";
            answerText.text = "";
            timerText.text = "60";
            scoreText.text = "0";

            tutorialStage = 4;
            StartCoroutine(ActualStartTutorial());
        }
    }

    public IEnumerator ActualStartTutorial()
    {
        audioSource.PlayOneShot(tutorialClips[7]);
        yield return new WaitForSeconds(15);
        audioSource.PlayOneShot(tutorialClips[8]);
        yield return new WaitForSeconds(2);
        audioSource.PlayOneShot(tutorialClips[9]);
        yield return new WaitForSeconds(6);
        audioSource.PlayOneShot(tutorialClips[10]);
        yield return new WaitForSeconds(6);

        tutorialStage = 0;
        StartGame();
    }

    public IEnumerator StartTutorial()
    {
        maxTimesTables = 0;

        tutorialStage = 1;
        audioSource.PlayOneShot(tutorialClips[0]);
        yield return new WaitForSeconds(19);
        audioSource.PlayOneShot(tutorialClips[1]);
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(tutorialClips[2]);
        yield return new WaitForSeconds(4);
        audioSource.PlayOneShot(tutorialClips[3]);
        yield return new WaitForSeconds(1);

        tutorialStage = 2;

        yield return new WaitForSeconds(10);
        if (maxTimesTables == 0 && tutorialStage == 2)
        {
            audioSource.PlayOneShot(tutorialClips[4]);
        }
    }

    void Update()
    {
        if(tutorialStage == 0)
        {
            HandleTimer();
            if (inGameCanvas.gameObject.activeSelf)
            {
                HandleInputs();
            }
            CheckForGameEnd();
        }
    }

    public void StartTimer()
    {
        currentTime = startingTime;
        timerStarted = true;
        audioSource.Play();
    }

    private void HandleTimer()
    {
        if (timerStarted)
        {
            currentTime -= 1 * Time.deltaTime;
            timerText.text = Mathf.FloorToInt(currentTime).ToString();
        }
    }

    private void NewQuestion()
    {
        firstNumber = Random.Range(1, maxTimesTables);
        secondNumber = Random.Range(1, maxTimesTables);
        answer = firstNumber * secondNumber;
        questionText.text = firstNumber + " x " + secondNumber;
    }

    private void CheckForGameEnd()
    {
        if(currentTime <= 0f && !mainMenuCanvas.gameObject.activeSelf && !gameOverCanvas.gameObject.activeSelf)
        {
            timerStarted = false;
            gameOverCanvas.gameObject.SetActive(true);
            inGameCanvas.gameObject.SetActive(false);
            gameOverCanvas.transform.GetChild(1).GetComponent<TMP_Text>().text = "Score: " + score.ToString();

            audioSource.Stop();
            audioSource.PlayOneShot(ringClip);
        }
    }

    private void CheckAnswer()
    {
        if (input == "" || int.Parse(input) != answer) return;

        score++;
        scoreText.text = score.ToString();
        NewQuestion();
        input = "";
        answerText.text = "";
    }

    private void CheckInput()
    {
        answerText.text = input;
        audioSource.PlayOneShot(keyClip);
    }

    private void HandleInputs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            input += "0";
            CheckInput();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            input += "1";
            CheckInput();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            input += "2";
            CheckInput();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            input += "3";
            CheckInput();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            input += "4";
            CheckInput();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            input += "5";
            CheckInput();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            input += "6";
            CheckInput();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            input += "7";
            CheckInput();
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            input += "8";
            CheckInput();
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            input += "9";
            CheckInput();
        }
        if (Input.GetKeyDown(KeyCode.Backspace) && input.Length > 0)
        {
            input = input.Substring(0, input.Length - 1);
            CheckInput();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckAnswer();
            CheckInput();
        }
    }
}
