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
    public int minigameFull;

    public void Start() {
      PlayerPrefs.GetInt("Levels");
      levelCount = PlayerPrefs.GetInt("Levels");
      Level();
      minigameCount = 0;

    }

    public void MinigameComplete() {
      minigameCount++;
      if(minigameCount == minigameFull) {
        levelCount++;
        PlayerPrefs.SetInt("Levels", levelCount);
        PlayerPrefs.Save();
        finishGamePanel.SetActive(true);
      }
    }

    public void NextLevel() {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Level() {
      PlayerPrefs.GetInt("Levels");
      if(levelCount == 0) {
        minigameFull = 2;
        levelText.text = "LEVEL 01";
        FindObjectOfType<MiniGameShow1>().simonSaysShow();
        FindObjectOfType<MiniGameShow5>().wireTaskShow();
    }
      if(levelCount == 1){
        minigameFull = 3;
        levelText.text = "LEVEL 02";
        FindObjectOfType<MiniGameShow2>().wireTaskShow();
        FindObjectOfType<MiniGameShow6>().simonSaysShow();
        FindObjectOfType<MiniGameShow4>().numFindShow();
      }
      if(levelCount == 2){
        minigameFull = 3;
        levelText.text = "LEVEL 03";
        FindObjectOfType<MiniGameShow6>().wireTaskShow();
        FindObjectOfType<MiniGameShow1>().simonSaysShow();
        FindObjectOfType<MiniGameShow7>().numFindShow();
      }
      if(levelCount == 3){
        minigameFull = 3;
        levelText.text = "LEVEL 04";
        FindObjectOfType<MiniGameShow5>().wireTaskShow();
        FindObjectOfType<MiniGameShow2>().simonSaysShow();
        FindObjectOfType<MiniGameShow3>().numFindShow();
      }
      if(levelCount == 4){
        minigameFull = 3;
        levelText.text = "LEVEL 05";
        FindObjectOfType<MiniGameShow2>().wireTaskShow();
        FindObjectOfType<MiniGameShow3>().simonSaysShow();
        FindObjectOfType<MiniGameShow4>().numFindShow();
      }
      if(levelCount == 5){
        minigameFull = 3;
        levelText.text = "LEVEL 06";
        FindObjectOfType<MiniGameShow7>().wireTaskShow();
        FindObjectOfType<MiniGameShow2>().simonSaysShow();
        FindObjectOfType<MiniGameShow1>().numFindShow();
      }
    }


}
