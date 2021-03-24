using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabController : MonoBehaviour
{
    private static TabController _instance = null;

    public static TabController Instance {
        get {
            if(_instance == null) {
                GameObject.FindObjectOfType<TabController>();

                if(_instance == null) {
                    Debug.LogError("There's no active TabController object");
                }
            }
            return _instance;
        }
    }

    TabButton tabButton;

    private void Start() {
        SelectedButton(transform.GetChild(0).GetComponent<TabButton>());
    }

    public void SelectedButton(TabButton _button) {

        if (tabButton != null) {
            tabButton.Deselect();
        }

        tabButton = _button;
        tabButton.Select();
    }
}
