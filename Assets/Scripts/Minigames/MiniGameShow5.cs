using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameShow5 : MonoBehaviour
{
  public GameObject simonSays;
  public GameObject numFind;
  public GameObject wireTask;


  public void simonSaysShow() {
    simonSays.SetActive(true);

  }

  public void numFindShow() {
    numFind.SetActive(true);

  }

  public void wireTaskShow() {
    wireTask.SetActive(true);
  }

}
