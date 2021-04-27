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
    
    //Starting Game With Button
    public void StartGame() 
    {
        FindObjectOfType<LevelManager>().ChanceTimeScale();
        sliderTaskPrefabs = GameObject.FindGameObjectWithTag("SliderTask");
        simonSaysPrefabs = GameObject.FindGameObjectWithTag("SimonSays");
        numFindPrefabs = GameObject.FindGameObjectWithTag("NumberFind");
        wireTaskPrefabs = GameObject.FindGameObjectWithTag("WireTask");
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
                    simonSaysPrefabs.GetComponent<Collider>().enabled = false;
                    simonSaysPanel.SetActive(true);
                    LayerIgnoreRay();
                }
                if (hit.collider.tag == "NumberFind") 
                {
                    LayerIgnoreRay();
                    numMatchPanel.SetActive(true);
                    numFindPrefabs.GetComponent<Collider>().enabled = false;
                }
                if (hit.collider.tag == "WireTask") 
                {
                    LayerIgnoreRay();
                    wireTaskPanel.SetActive(true);
                    wireTaskPrefabs.GetComponent<Collider>().enabled = false;
                }
                if(hit.collider.tag == "SliderTask") 
                {
                    LayerIgnoreRay();
                    sliderTaskPanel.SetActive(true);
                    sliderTaskPrefabs.GetComponent<Collider>().enabled = false;
                }


            }
        }
    }
    //also stupit script but its work
    public void LayerIgnoreRay()
    {
        sliderTaskPrefabs.layer = 2;
        numFindPrefabs.layer = 2;
        simonSaysPrefabs.layer = 2;
        wireTaskPrefabs.layer = 2;
    }
    public void LayerDefault() 
    {
        sliderTaskPrefabs.layer = 0;
        numFindPrefabs.layer = 0;
        simonSaysPrefabs.layer = 0;
        wireTaskPrefabs.layer = 0;
    }


}
