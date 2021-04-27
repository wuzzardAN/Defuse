using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSays : MonoBehaviour
{

    [SerializeField] GameObject[] buttons;
    [SerializeField] GameObject[] lightArray;
    [SerializeField] GameObject[] rowLights;
    [SerializeField] int[] lightOrder;
    [SerializeField] GameObject simonSaysGamePanel;
    int level = 0;
    int buttonsclicked = 0;
    int colorOrderRunCount = 0;
    bool passed = false;
    bool won = false;

    Color32 red = new Color32(255, 39, 0, 255);
    Color32 green = new Color32(4, 204, 0, 255);
    Color32 invisible = new Color32(4, 204, 0, 0);
    Color32 white = new Color32(255, 255, 255, 255);

    public float lightSpeed;

    void Start() {
    }

    private void OnEnable()
    {
        level = 0;
        buttonsclicked = 0;
        colorOrderRunCount = -1;

        won = false;

        for (int i = 0; i < lightOrder.Length; i++)
        {
            lightOrder[i] = (Random.Range(0, 3));
            //Loop lightOrder
        }

        for (int i = 0; i < rowLights.Length; i++)
        {
            rowLights[i].GetComponent<Image>().color = white;

        }

        level = 1;

        StartCoroutine(ColorOrder());
    }

    public void ButtonClickOrder(int button)
    {
        buttonsclicked++;

        if (button == lightOrder[buttonsclicked - 1])
        {
            Debug.Log("Pass");
            passed = true;
        }
        else
        {
            Debug.Log("Failed");
            won = false;
            passed = false;
            StartCoroutine(ColorBlink(red));
        }
        if (buttonsclicked == level && passed == true && buttonsclicked != 4)
        {
            level++;
            passed = false;
            StartCoroutine(ColorOrder());
        }
        if (buttonsclicked == level && passed == true && buttonsclicked == 4)
        {
            won = true;
            StartCoroutine(ColorBlink(green));
        }
    }

    public void ClosePanel()
    {
        FindObjectOfType<MinigameController>().LayerDefault();
        FindObjectOfType<LevelManager>().MinigameComplete();
        simonSaysGamePanel.SetActive(false);
    }

    public void OpenPanel()
    {
        simonSaysGamePanel.SetActive(true);
    }

    IEnumerator ColorBlink(Color32 colorToBlink)
    {
        DisableInteractibleButtons();
        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < buttons.Length; i++)
            {

            }
            for (int i = 4; i < rowLights.Length; i++)
            {
                rowLights[i].GetComponent<Image>().color = colorToBlink;
            }

            yield return new WaitForSeconds(0.5f);

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<Image>().color = white;
            }
            for (int i = 0; i < rowLights.Length; i++)
            {
                rowLights[i].GetComponent<Image>().color = white;
            }

            yield return new WaitForSeconds(0.5f);

        }

        if (won == true)
        {
            ClosePanel();
        }
        EnableInteractibleButtons();
        OnEnable();

    }

    IEnumerator ColorOrder()
    {
        buttonsclicked = 0;
        colorOrderRunCount++;
        DisableInteractibleButtons();
        for (int i = 0; i <= colorOrderRunCount; i++)
        {
            if (level >= colorOrderRunCount)
            {
                lightArray[lightOrder[i]].GetComponent<Image>().color = invisible;
                yield return new WaitForSeconds(lightSpeed);
                lightArray[lightOrder[i]].GetComponent<Image>().color = green;
                yield return new WaitForSeconds(lightSpeed);
                lightArray[lightOrder[i]].GetComponent<Image>().color = invisible;
                rowLights[i].GetComponent<Image>().color = green;

            }
        }
        EnableInteractibleButtons();
    }

    void DisableInteractibleButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = false;
        }
    }

    void EnableInteractibleButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
        }
    }



}
