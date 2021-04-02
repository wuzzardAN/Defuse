using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject finishGamePanel;
    public GameObject restartLevelPanel;
    public int levelCount = 0;
    public int minigameCount;
    public Text levelText;
    public int minigameFull;
    public float timeRemaining;
    public bool timerIsRunning = false;
    public Text timeText;

    public void Start() {
      PlayerPrefs.GetInt("Levels");
      levelCount = PlayerPrefs.GetInt("Levels");
      Level();
      minigameCount = 0;
      timerIsRunning = true;
      Time.timeScale = 0;
    }
    //This is so stupit but its worked
    public void ChanceTimeScale() {
      Time.timeScale = 1;
    }
    //Minigame Counter
    public void MinigameComplete() {
      minigameCount++;
      if(minigameCount == minigameFull) {
        levelCount++;
        PlayerPrefs.SetInt("Levels", levelCount);
        PlayerPrefs.Save();
        finishGamePanel.SetActive(true);
        Time.timeScale = 0;
      }
    }
    //Timer
    public void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                restartLevelPanel.SetActive(true);
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    //UI Button Scripts
    public void RestartLevel() {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel() {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //Level Design
    public void Level() {
      PlayerPrefs.GetInt("Levels");
      if(levelCount == 0) {
        levelCount++;
        Debug.Log("level1");
        PlayerPrefs.SetInt("Levels", levelCount);

      }
      if(levelCount == 1) {
        timeRemaining = 70;
        minigameFull = 1;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow5>().wireTaskShow();
    }
      if(levelCount == 2){
        timeRemaining = 80;
        minigameFull = 2;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow2>().wireTaskShow();
        FindObjectOfType<MiniGameShow6>().simonSaysShow();
      }
      if(levelCount == 3){
        timeRemaining = 95;
        minigameFull = 3;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow6>().wireTaskShow();
        FindObjectOfType<MiniGameShow1>().simonSaysShow();
        FindObjectOfType<MiniGameShow7>().numFindShow();
      }
      if(levelCount == 4){
        timeRemaining = 70;
        minigameFull = 3;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow5>().wireTaskShow();
        FindObjectOfType<MiniGameShow2>().simonSaysShow();
        FindObjectOfType<MiniGameShow3>().numFindShow();
      }
      if(levelCount == 5){
        timeRemaining = 91;
        minigameFull = 2;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow3>().simonSaysShow();
        FindObjectOfType<MiniGameShow4>().numFindShow();
      }
      if(levelCount == 6){
        timeRemaining = 76;
        minigameFull = 2;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow7>().wireTaskShow();
        FindObjectOfType<MiniGameShow1>().numFindShow();
      }
    }


}
