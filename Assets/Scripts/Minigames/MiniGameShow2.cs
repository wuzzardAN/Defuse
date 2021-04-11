using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameShow2 : MonoBehaviour
{
  public GameObject simonSays;
  public GameObject numFind;
  public GameObject wireTask;
  public GameObject sliderTask;


  public void simonSaysShow() {
    simonSays.SetActive(true);

  }

  public void numFindShow() {
    numFind.SetActive(true);

  }

  public void wireTaskShow() {
    wireTask.SetActive(true);
  }

  public void sliderTaskShow() {
    sliderTask.SetActive(true);
  }

}
