using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class UIManager : MonoBehaviour
{
      public RectTransform startGame, restartLevel;
      public GameObject nextLevel;

      public void StartGameUI() {
        startGame.DOAnchorPos(new Vector2(0,-1100),0.5f);
      }
      public void NextLevelUI() {
        nextLevel.SetActive(true);
      }
      public void RestartLevelUI() {
        restartLevel.DOAnchorPos(new Vector2(0,0), 0.15f);
      }


}
