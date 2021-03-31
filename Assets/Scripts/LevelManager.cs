using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject finishGamePanel;
    public int levelCount = 1;
    public int minigameCount;
    public Text levelText;

    public void Start() {
      levelCount = 1;
      PlayerPrefs.SetInt("Levels", levelCount);
      PlayerPrefs.GetInt("Levels");
      levelCount = PlayerPrefs.GetInt("Levels");
      Level();

    }

    public void MinigameComplete() {
      minigameCount++;
      if(minigameCount == 3) {
        levelCount++;
        PlayerPrefs.SetInt("Levels", levelCount);
        PlayerPrefs.Save();
        finishGamePanel.SetActive(true);
        minigameCount = 0;
      }
    }

    public void NextLevel() {

      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void Level() {
      PlayerPrefs.GetInt("Levels");
      if(levelCount == 1) {
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow1>().simonSaysShow();
        FindObjectOfType<MiniGameShow5>().wireTaskShow();
        FindObjectOfType<MiniGameShow6>().numFindShow();
    }
      if(levelCount == 2){
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow2>().wireTaskShow();
        FindObjectOfType<MiniGameShow6>().simonSaysShow();
        FindObjectOfType<MiniGameShow4>().numFindShow();
      }
      if(levelCount == 3){
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow6>().wireTaskShow();
        FindObjectOfType<MiniGameShow1>().simonSaysShow();
        FindObjectOfType<MiniGameShow7>().numFindShow();
      }
      if(levelCount == 4){
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow5>().wireTaskShow();
        FindObjectOfType<MiniGameShow2>().simonSaysShow();
        FindObjectOfType<MiniGameShow3>().numFindShow();
      }
      if(levelCount == 5){
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow2>().wireTaskShow();
        FindObjectOfType<MiniGameShow3>().simonSaysShow();
        FindObjectOfType<MiniGameShow4>().numFindShow();
      }
      if(levelCount == 6){
        levelText.text = "Level " + levelCount.ToString();
        FindObjectOfType<MiniGameShow7>().wireTaskShow();
        FindObjectOfType<MiniGameShow2>().simonSaysShow();
        FindObjectOfType<MiniGameShow1>().numFindShow();
      }
    }


}
