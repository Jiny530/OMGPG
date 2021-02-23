using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabPanel : MonoBehaviour
{

    public Dropdown myDropdown;
    public List<GameObject> contentsPanels;
    /*
    void Update()
    {
        switch (dropdown.value)
        {
            case 0:
                contentsPanels[0].GetComponent<ScrollRect>().setActive(true);
                //contentsPanels[1].setActive(false);
                //contentsPanels[2].setActive(false);
                break;
            case 1:
                //contentsPanels[1].setActive(true);
                //contentsPanels[0].setActive(false);
                //contentsPanels[2].setActive(false);
                break;
            case 2:
                //contentsPanels[2].setActive(true);
                //contentsPanels[0].setActive(false);
                //contentsPanels[1].setActive(false);
                break;
        }
    }
    */

    void Update()
    {
        int i = myDropdown.value;
        HandleValueChanged(i);
    }

    private void HandleValueChanged(int newValue)
    {
        switch (newValue)
        {
            case 0:
                Debug.Log("Basic panel!");
                contentsPanels[0].SetActive(true);
                contentsPanels[1].SetActive(false);
                contentsPanels[2].SetActive(false);
                break;
            case 1:
                Debug.Log("Advance panel!");
                contentsPanels[0].SetActive(false);
                contentsPanels[1].SetActive(true);
                contentsPanels[2].SetActive(false);
                break;
            case 2:
                Debug.Log("Advance Advance panel!");
                contentsPanels[0].SetActive(false);
                contentsPanels[1].SetActive(false);
                contentsPanels[2].SetActive(true);
                break;
        }
    }
}
