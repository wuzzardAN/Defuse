using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTask : MonoBehaviour
{

    public GameObject sliderTask;
    public int slider1Value, slider2Value, slider3Value;
    public Slider slider1, slider2, slider3;
    public Image light1, light2, light3;
    Color32 green = new Color32(4, 204, 0, 255);

    public void Start() {
      slider1Value = Random.Range(0, 9);
      slider2Value = Random.Range(0, 9);
      slider3Value = Random.Range(0, 9);

      slider1.value = slider1Value;
      slider2.value = slider2Value;
      slider3.value = slider3Value;

    }

    public void Update() {

      if(slider1.value == 10) {
        light1.GetComponent<Image>().color = green;
      }
      if(slider3.value == 10) {
        light3.GetComponent<Image>().color = green;
      }
      if(slider2.value == 10) {
        light2.GetComponent<Image>().color = green;
      }

      StartCoroutine(WinCondition());


    }

    public IEnumerator WinCondition() {
      if(slider1.value == 10 && slider2.value == 10 && slider3.value == 10){
        yield return new WaitForSeconds(0.8f);
        StartCoroutine(PanelClose());
      }
    }

    public IEnumerator PanelClose() {
      yield return new WaitForSeconds(0.8f);
      sliderTask.SetActive(false);
      FindObjectOfType<MinigameController>().LayerDefault();
      FindObjectOfType<LevelManager>().MinigameComplete();

    }

    public void SliderTaksOpen() {
      sliderTask.SetActive(true);
    }


}
