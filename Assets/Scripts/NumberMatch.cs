using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberMatch : MonoBehaviour
{
    [SerializeField] int nextButton;
    [SerializeField] GameObject numMatchPanel;
    [SerializeField] GameObject[] myObjects;
    public Text m_text;


    void Start()
    {
        nextButton = 0;
    }

    private void OnEnable()
    {
        nextButton = 0;
        for (int i = 0; i < myObjects.Length; i++)
        {
            myObjects[i].transform.SetSiblingIndex(Random.Range(0, 9));

        }
    }

    public void ButtonOrder(int button)
    {
        if (button == nextButton)
        {
            nextButton++;
            Debug.Log("Next button" + nextButton);
        }
        else
        {
            Debug.Log("Failed");
            Debug.Log("Next button" + nextButton);
            nextButton = 0;
            OnEnable();
        }
        if (button == 9)
        {
            if (nextButton == 10)
            {
                Debug.Log("Pass");
                nextButton = 0;
                StartCoroutine(ButtonOrderPanelClose());
            }
        }
    }

    public IEnumerator ButtonOrderPanelClose()
    {
        FindObjectOfType<LevelManager>().MinigameComplete();
        m_text.text = "PASSED";
        m_text.color = Color.green;
        yield return new WaitForSeconds(0.5f);
        numMatchPanel.SetActive(false);
        FindObjectOfType<MinigameController>().LayerDefault();

    }
    public void ButtonOrderPanelOpen()
    {
        numMatchPanel.SetActive(true);
    }

}
