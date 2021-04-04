using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int levelCount = 0;
    public int minigameCount;
    public int minigameFull;
    public int coin;
    public float timeRemaining;
    public bool timerIsRunning = false;
    public Text levelText;
    public Text timeText;
    public Image progressFillImage;



    public void Start() {
      coin = PlayerPrefs.GetInt("Coin");
      levelCount = PlayerPrefs.GetInt("Levels");
      Bomb1Level();
      minigameCount = 0;
      timerIsRunning = true;
      Time.timeScale = 0;
      progressFillImage.fillAmount = 0f;
    }
    //This is so stupit but its worked
    public void ChanceTimeScale() {
      Time.timeScale = 1;
    }
    //Minigame Counter
    public void MinigameComplete() {
      minigameCount++;
      UpdateLevelProgress();
      if(minigameCount == minigameFull) {
        levelCount++;
        PlayerPrefs.SetInt("Levels", levelCount);
        PlayerPrefs.Save();
        FindObjectOfType<UIManager>().NextLevelUI();
        Time.timeScale = 0;
        coin = coin + 100;
        PlayerPrefs.SetInt("Coin", coin);
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
                FindObjectOfType<UIManager>().RestartLevelUI();
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

    public void UpdateLevelProgress() {
      float val = (((float) minigameFull) - ((float) minigameFull - minigameCount)) / ((float) minigameFull);
      progressFillImage.fillAmount = val;
    }
    //UI Button Scripts
    public void RestartLevel() {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel() {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //Level Design
    public void Bomb1Level() {
      PlayerPrefs.GetInt("Levels");
      if(levelCount == 0) {
        levelCount++;
        Debug.Log("level1");
        PlayerPrefs.SetInt("Levels", levelCount);

      }
      if(levelCount == 1) {
        timeRemaining = 35;
        minigameFull = 1;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow5>().wireTaskShow();
    }
      if(levelCount == 2){
        timeRemaining = 45;
        minigameFull = 2;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow2>().wireTaskShow();
        FindObjectOfType<MiniGameShow6>().simonSaysShow();
      }
      if(levelCount == 3){
        timeRemaining = 50;
        minigameFull = 3;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow6>().wireTaskShow();
        FindObjectOfType<MiniGameShow2>().simonSaysShow();
        FindObjectOfType<MiniGameShow7>().numFindShow();
      }
      if(levelCount == 4){
        timeRemaining = 55;
        minigameFull = 3;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow5>().wireTaskShow();
        FindObjectOfType<MiniGameShow2>().simonSaysShow();
        FindObjectOfType<MiniGameShow3>().numFindShow();
      }
      if(levelCount == 5){
        timeRemaining = 30;
        minigameFull = 2;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow3>().simonSaysShow();
        FindObjectOfType<MiniGameShow4>().numFindShow();
      }
      if(levelCount == 6){
        timeRemaining = 20;
        minigameFull = 2;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow7>().wireTaskShow();
        FindObjectOfType<MiniGameShow2>().numFindShow();
      }
      if(levelCount == 7){
        timeRemaining = 26;
        minigameFull = 2;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow2>().wireTaskShow();
        FindObjectOfType<MiniGameShow5>().numFindShow();
      }
      if(levelCount == 8){
        timeRemaining = 10;
        minigameFull = 1;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow2>().wireTaskShow();
      }
      if(levelCount == 9){
        timeRemaining = 45;
        minigameFull = 3;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow2>().wireTaskShow();
        FindObjectOfType<MiniGameShow5>().numFindShow();
        FindObjectOfType<MiniGameShow3>().simonSaysShow();

      }
      if(levelCount == 10){
        timeRemaining = 40;
        minigameFull = 3;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow5>().wireTaskShow();
        FindObjectOfType<MiniGameShow7>().numFindShow();
        FindObjectOfType<MiniGameShow2>().simonSaysShow();

      }if(levelCount == 11){
        timeRemaining = 40;
        minigameFull = 3;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow2>().wireTaskShow();
        FindObjectOfType<MiniGameShow5>().numFindShow();
        FindObjectOfType<MiniGameShow4>().simonSaysShow();

      }

    }


}
