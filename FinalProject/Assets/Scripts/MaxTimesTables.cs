using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxTimesTables : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TMP_Text timesTablesText;

    private AudioSource audioSource;
    [SerializeField] private AudioClip keyClip;

    private string input;

    void Start()
    {
        audioSource = gameManager.GetComponent<AudioSource>();
    }

    void Update()
    {
        HandleInputs();
    }

    private void CheckInput()
    {
        if (input.Length > 3)
        {
            input = input.Substring(0, input.Length - 1);
        }

        timesTablesText.text = input;
        gameManager.maxTimesTables = int.Parse(input);
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
            timesTablesText.text = input;
            if (input != "")
            {
                gameManager.maxTimesTables = int.Parse(input);
            }
            else
            {
                gameManager.maxTimesTables = 0;
            }
            audioSource.PlayOneShot(keyClip);
        }
    }
}
