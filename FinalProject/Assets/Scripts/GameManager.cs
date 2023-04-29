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

    void Start()
    {
        inGameCanvas.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        StartTimer();
        NewQuestion();
        score = 0;
    }

    void Update()
    {
        HandleTimer();
        if (inGameCanvas.gameObject.activeSelf)
        {
            HandleInputs();
        }
        CheckForGameEnd();
    }

    public void StartTimer()
    {
        currentTime = startingTime;
        timerStarted = true;
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
        firstNumber = Random.Range(2, maxTimesTables);
        secondNumber = Random.Range(2, maxTimesTables);
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
            gameOverCanvas.transform.GetChild(1).GetComponent<TMP_Text>().text += score.ToString();
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

    private void HandleInputs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            input += "0";
            answerText.text = input;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            input += "1";
            answerText.text = input;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            input += "2";
            answerText.text = input;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            input += "3";
            answerText.text = input;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            input += "4";
            answerText.text = input;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            input += "5";
            answerText.text = input;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            input += "6";
            answerText.text = input;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            input += "7";
            answerText.text = input;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            input += "8";
            answerText.text = input;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            input += "9";
            answerText.text = input;
        }
        if (Input.GetKeyDown(KeyCode.Backspace) && input.Length > 0)
        {
            input = input.Substring(0, input.Length - 1);
            answerText.text = input;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckAnswer();
        }
    }
}
