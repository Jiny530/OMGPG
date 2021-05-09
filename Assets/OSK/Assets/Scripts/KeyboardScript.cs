using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class KeyboardScript : MonoBehaviour
{

    public TMP_InputField TextField;
    public GameObject EngLayoutSml, EngLayoutBig, SymbLayout, RankingUI, completeUI;
    public static GameObject ui;
    
    void Start()
    {
        
    }

    public void alphabetFunction(string alphabet)
    {


        TextField.text=TextField.text + alphabet;

    }

    public void BackSpace()
    {

        if(TextField.text.Length>0) TextField.text= TextField.text.Remove(TextField.text.Length-1);

    }

    public void CloseAllLayouts()
    {

        EngLayoutSml.SetActive(false);
        EngLayoutBig.SetActive(false);
        SymbLayout.SetActive(false);

    }

    public void ShowLayout(GameObject SetLayout)
    {

        CloseAllLayouts();
        SetLayout.SetActive(true);

    }

    public void close()
    {
        //텍스트필드 내용 저장
        if (TextField.text.Length > 0)
        {
            // 유저 닉네임변수 = TextField.text;
            RectTransform rect = ui.GetComponent<RectTransform>();
            rect.position = new Vector3((float)-2.7, 18, 0);
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, 545);
            CloseAllLayouts();
            completeUI.SetActive(false);
            RankingUI.SetActive(true);
        }
        
        //ui 원상복귀, 끄고, 랭킹저장, 랭킹 ui 띄우기
        

    }

    public void uiStretch()
    {
        RectTransform rect = ui.GetComponent<RectTransform>();
        rect.position = new Vector3((float)-2.7, (float)-102.5, 0);
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, 785);

    }

}
