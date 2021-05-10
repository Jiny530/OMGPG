using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class KeyboardScript : MonoBehaviour
{

    public GameObject TextField;
    public GameObject EngLayoutSml, EngLayoutBig, SymbLayout, RankingUI, completeUI;
    public static GameObject ui;
    private TextMeshProUGUI TMPtext;
    RectTransform rect;
    void Start()
    {
        TMPtext = TextField.GetComponent<TextMeshProUGUI>();

        rect = completeUI.GetComponent<RectTransform>();
        //rect.position = new Vector3((float)-2.7, (float)-102.5, 0);
        //rect.sizeDelta = new Vector2(rect.sizeDelta.x, 785);
    }

    public void alphabetFunction(string alphabet)
    {

        if (TMPtext.text == "Enter Name") TMPtext.text = "";
        TMPtext.text=TMPtext.text + alphabet;

    }

    public void BackSpace()
    {

        if(TMPtext.text.Length>0) TMPtext.text= TMPtext.text.Remove(TMPtext.text.Length-1);

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
        if (TMPtext.text.Length > 0)
        {
            Debug.Log("들어옴");
            // 유저 닉네임변수 = TMPtext.text;
            //rect.position = new Vector3((float)-2.7, 18, 0);
            completeUI.SetActive(false);
            RankingUI.SetActive(true);
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, 545);
            CloseAllLayouts();
        }
        Debug.Log("뭐임");
        
        //ui 원상복귀, 끄고, 랭킹저장, 랭킹 ui 띄우기
        

    }

    public void uiStretch()
    {
        //rect.position = new Vector3((float)-2.7, (float)-102.5, 0);
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, 785);

    }

}
