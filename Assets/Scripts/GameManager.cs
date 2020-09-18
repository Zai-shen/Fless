﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameIsOver;
    private bool gameIsPaused;
    public bool GameIsPaused {
        get { return gameIsPaused; } 
        private set { gameIsPaused = value; } 
    }
    
    private float restartDelay = 2f;
    private AudioManager audioManager;
    public GameObject failLevelUI;

    public void LoadNextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevel(string lvlName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(lvlName);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        if (!gameIsOver)
        {
            Debug.Log("GAME OVER");
            gameIsOver = true;

            audioManager.Play("PlayerLost");
            failLevelUI.SetActive(true);
            Invoke("Restart", restartDelay);
        }
    }

    public void QuitApp()
    {
        Debug.Log("Quitting application");
        #if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void Restart()
    {
        Debug.Log("Restarting scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (audioManager == null)
        {
            audioManager = AudioManager.Instance;
        }

        Cursor.visible = false;

        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                Debug.Log("Home");
                Cursor.visible = true;
                audioManager.StopAllSounds();
                audioManager.PlayIfIsntAlreadyPlaying("Lvl0");
                break;
            case 1:
                Debug.Log("Game");
                audioManager.StopAllSoundsBut("Lvl1");
                audioManager.PlayIfIsntAlreadyPlaying("Lvl1");
                break;
            default:
                Debug.LogWarning("Unknown stage");
                break;
        } 
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown("r"))
        {
            Debug.Log("Restarting level");
            Restart();
        }
#if UNITY_EDITOR
        if (Input.GetKey("l"))
            {
                Debug.Log("Admin: Losing level");
                EndGame();
            }
        #endif
    }
}
