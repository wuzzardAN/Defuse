using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoMenuItems : MonoBehaviour
{
    [HideInInspector] public Image img;
    [HideInInspector] public Transform trans;

    //SettingsMenu reference
    InfoMenu infoMenu;

    //item button
    Button button;

    //index of the item in the hierarchy
    int index;

    void Awake ()
    {
        img = GetComponent<Image> ();
        trans = transform;

        infoMenu = trans.parent.GetComponent <InfoMenu> ();

        //-1 to ignore the main button
        index = trans.GetSiblingIndex () - 1;

        //add click listener
        button = GetComponent<Button> ();
        button.onClick.AddListener (OnItemClick);
    }

    void OnItemClick ()
    {
        infoMenu.OnItemClick (index);
    }

    void OnDestroy ()
    {
        //remove click listener to avoid memory leaks
        button.onClick.RemoveListener (OnItemClick);
    }
}
