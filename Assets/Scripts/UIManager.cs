using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
      public Text coinText, level2UnlockText, level3UnlockText;
      public RectTransform startGame, restartLevel;
      public GameObject simonSaysPanel, wireTaskPanel, numMatchPanel, nextLevel;
      public int selectedLevel, coinMenu;


      public void Start() {
        coinText.text = PlayerPrefs.GetInt("Coin").ToString();
        coinMenu = PlayerPrefs.GetInt("Coin");
      }
      public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      }


      public void StartGameUI() {
        startGame.DOAnchorPos(new Vector2(0,-1100),0.5f);
      }
      public void NextLevelUI() {
        nextLevel.SetActive(true);
        simonSaysPanel.SetActive(false);
        numMatchPanel.SetActive(false);
        wireTaskPanel.SetActive(false);
      }
      public void RestartLevelUI() {
        restartLevel.DOAnchorPos(new Vector2(0,0), 0.15f);
        nextLevel.SetActive(false);
        simonSaysPanel.SetActive(false);
        numMatchPanel.SetActive(false);
        wireTaskPanel.SetActive(false);
      }


}
