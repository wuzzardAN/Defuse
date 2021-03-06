using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    public GameObject simonSaysPrefabs;
    public GameObject numFindPrefabs;
    public GameObject wireTaskPrefabs;
    public GameObject sliderTaskPrefabs;

    public GameObject simonSaysPanel;
    public GameObject numMatchPanel;
    public GameObject wireTaskPanel;
    public GameObject sliderTaskPanel;

    private float range = 100f;

    public void Start() {
      LayerIgnoreRay();
    }
    //Starting Game With Button
    public void StartGame() {
      FindObjectOfType<LevelManager>().ChanceTimeScale();
        simonSaysPrefabs = GameObject.FindGameObjectWithTag("SimonSays");
        numFindPrefabs = GameObject.FindGameObjectWithTag("NumberFind");
        wireTaskPrefabs = GameObject.FindGameObjectWithTag("WireTask");
        sliderTaskPrefabs = GameObject.FindGameObjectWithTag("SliderTask");
        FindObjectOfType<UIManager>().StartGameUI();
        LayerDefault();

    }


    //Raycast hit and disable collider
    public void Update()
    {
        if(Input.GetMouseButtonDown(0)){

            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, range))
            {
                if (hit.collider.tag == "SimonSays")
                {
                    simonSaysPanel.SetActive(true);
                    simonSaysPrefabs.GetComponent<Collider>().enabled = false;
                    LayerIgnoreRay();
                }
                if (hit.collider.tag == "NumberFind") {
                    numMatchPanel.SetActive(true);
                    LayerIgnoreRay();
                    numFindPrefabs.GetComponent<Collider>().enabled = false;
                }
                if (hit.collider.tag == "WireTask") {
                    wireTaskPanel.SetActive(true);
                    LayerIgnoreRay();
                    wireTaskPrefabs.GetComponent<Collider>().enabled = false;
                }
                if(hit.collider.tag == "SliderTask") {
                  sliderTaskPanel.SetActive(true);
                  LayerIgnoreRay();
                  sliderTaskPrefabs.GetComponent<Collider>().enabled = false;
                }


            }
        }
    }
    //also stupit script but its work
    public void LayerIgnoreRay() {
        numFindPrefabs.layer = 2;
        simonSaysPrefabs.layer = 2;
        wireTaskPrefabs.layer = 2;
        sliderTaskPrefabs.layer = 2;
    }
    public void LayerDefault() {
        numFindPrefabs.layer = 0;
        simonSaysPrefabs.layer = 0;
        wireTaskPrefabs.layer = 0;
        sliderTaskPrefabs.layer = 0;
    }


}
