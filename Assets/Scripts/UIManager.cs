using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
      public Text coinText, boost1value, boost2value;
      public RectTransform startGame, restartLevel;
      public GameObject simonSaysPanel, wireTaskPanel, numMatchPanel, nextLevel;
      public int selectedLevel, coinMenu, boost1, boost2;


      public void Start() {
        coinText.text = PlayerPrefs.GetInt("Coin").ToString();
        coinMenu = PlayerPrefs.GetInt("Coin");
        boost1value.text = PlayerPrefs.GetInt("Boost1").ToString();
        boost1 = PlayerPrefs.GetInt("Boost1");
        boost2value.text = PlayerPrefs.GetInt("Boost2").ToString();
        boost2 = PlayerPrefs.GetInt("Boost2");


      }

      public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      }

      public void BuyBoost1() {
        if(coinMenu >= 550 ) {
          boost1 = boost1 + 1;
          coinMenu = coinMenu - 550;
          PlayerPrefs.SetInt("Coin", coinMenu);
          PlayerPrefs.SetInt("Boost1", boost1);
          boost1value.text = PlayerPrefs.GetInt("Boost1").ToString();
          coinText.text = PlayerPrefs.GetInt("Coin").ToString();
        }

      }
      public void BuyBoost2() {
        if(coinMenu >= 850 ) {
          boost2 = boost2 + 1;
          coinMenu = coinMenu - 850;
          PlayerPrefs.SetInt("Coin", coinMenu);
          PlayerPrefs.SetInt("Boost2", boost2);
          boost2value.text = PlayerPrefs.GetInt("Boost2").ToString();
          coinText.text = PlayerPrefs.GetInt("Coin").ToString();
        }

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
