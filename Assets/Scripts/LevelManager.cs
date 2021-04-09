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
    public int bomb;
    public int boost1, boost2;
    public float timeRemaining;
    public bool timerIsRunning = false;
    public Text levelText;
    public Text bomb1timeText, bomb2timeText;
    public Image progressFillImage;
    public GameObject bomb1,bomb2,bomb3;



    public void Start() {
      boost1 = PlayerPrefs.GetInt("Boost1");
      boost2 = PlayerPrefs.GetInt("Boost2");
      coin = PlayerPrefs.GetInt("Coin");
      levelCount = PlayerPrefs.GetInt("Levels");
      Level();
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
    public void Update(){
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

    //Boosts
    public void Add10Sec() {
      if(boost1 >= 1) {
        timeRemaining = timeRemaining + 10;
        boost1 = boost1 - 1;
        PlayerPrefs.SetInt("Boost1", boost1);
      }

    }
    public void SlowTime() {
      if(boost2 >= 1) {
        boost2 = boost2 - 1;
        Time.timeScale = 0.5f;
        PlayerPrefs.SetInt("Boost2", boost2);
      }

    }
    public void CompleteTask() {
      FindObjectOfType<SimonSays>().ClosePanel();
      FindObjectOfType<WireTask>().ClosePanel();
      FindObjectOfType<NumberMatch>().ButtonOrderPanelClose();
    }

    void DisplayTime(float timeToDisplay){
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        bomb1timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        bomb2timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void UpdateLevelProgress() {
      float val = (((float) minigameFull) - ((float) minigameFull - minigameCount)) / ((float) minigameFull);
      progressFillImage.fillAmount = val;
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
        bomb1.SetActive(true);
        timeRemaining = 35;
        minigameFull = 1;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow5>().wireTaskShow();
    }
      if(levelCount == 2){
        bomb1.SetActive(true);
        timeRemaining = 45;
        minigameFull = 2;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow2>().wireTaskShow();
        FindObjectOfType<MiniGameShow6>().simonSaysShow();
      }
      if(levelCount == 3){
        bomb2.SetActive(true);
        timeRemaining = 50;
        minigameFull = 3;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow5>().wireTaskShow();
        FindObjectOfType<MiniGameShow2>().simonSaysShow();
        FindObjectOfType<MiniGameShow3>().numFindShow();
      }
      if(levelCount == 4){
        bomb1.SetActive(true);
        timeRemaining = 55;
        minigameFull = 3;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow5>().wireTaskShow();
        FindObjectOfType<MiniGameShow2>().simonSaysShow();
        FindObjectOfType<MiniGameShow3>().numFindShow();
      }
      if(levelCount == 5){
        bomb2.SetActive(true);
        timeRemaining = 30;
        minigameFull = 2;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow2>().simonSaysShow();
        FindObjectOfType<MiniGameShow4>().numFindShow();
      }
      if(levelCount == 6){
        bomb1.SetActive(true);
        timeRemaining = 20;
        minigameFull = 2;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow7>().wireTaskShow();
        FindObjectOfType<MiniGameShow2>().numFindShow();
      }
      if(levelCount == 7){
        bomb2.SetActive(true);
        timeRemaining = 26;
        minigameFull = 2;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow2>().wireTaskShow();
        FindObjectOfType<MiniGameShow5>().numFindShow();
      }
      if(levelCount == 8){
        bomb2.SetActive(true);
        timeRemaining = 10;
        minigameFull = 1;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow2>().wireTaskShow();
      }
      if(levelCount == 9){
        bomb1.SetActive(true);
        timeRemaining = 45;
        minigameFull = 3;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow2>().wireTaskShow();
        FindObjectOfType<MiniGameShow5>().numFindShow();
        FindObjectOfType<MiniGameShow3>().simonSaysShow();

      }
      if(levelCount == 10){
        bomb2.SetActive(true);
        timeRemaining = 40;
        minigameFull = 3;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow5>().wireTaskShow();
        FindObjectOfType<MiniGameShow3>().numFindShow();
        FindObjectOfType<MiniGameShow2>().simonSaysShow();

      }
      if(levelCount == 11){
        bomb2.SetActive(true);
        timeRemaining = 40;
        minigameFull = 3;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow2>().wireTaskShow();
        FindObjectOfType<MiniGameShow5>().numFindShow();
        FindObjectOfType<MiniGameShow4>().simonSaysShow();

      }
      if(levelCount == 12){
        bomb2.SetActive(true);
        timeRemaining = 35;
        minigameFull = 2;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow3>().wireTaskShow();
        FindObjectOfType<MiniGameShow5>().numFindShow();

      }
      if(levelCount == 13){
        bomb1.SetActive(true);
        timeRemaining = 35;
        minigameFull = 2;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow3>().simonSaysShow();
        FindObjectOfType<MiniGameShow5>().numFindShow();

      }
      if(levelCount == 14){
        bomb2.SetActive(true);
        timeRemaining = 35;
        minigameFull = 2;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow4>().simonSaysShow();
        FindObjectOfType<MiniGameShow5>().numFindShow();

      }
      if(levelCount == 15){
        bomb1.SetActive(true);
        timeRemaining = 45;
        minigameFull = 3;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow4>().simonSaysShow();
        FindObjectOfType<MiniGameShow5>().numFindShow();
        FindObjectOfType<MiniGameShow6>().wireTaskShow();

      }
      if(levelCount == 16){
        bomb1.SetActive(true);
        timeRemaining = 45;
        minigameFull = 3;
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow4>().simonSaysShow();
        FindObjectOfType<MiniGameShow5>().numFindShow();
        FindObjectOfType<MiniGameShow6>().wireTaskShow();

      }

    }


}
