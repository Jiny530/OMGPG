using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selected_thema : MonoBehaviour
{
    public GameObject[] sticks;
    public GameObject[] frames;
    public GameObject[] stones;

    //해당 이미지를 클릭하면 나머지는 비활성화, 선택된것만 활성화, 변수에 해당 인덱스 저장
    //선택된 이미지를 한번 더 클릭시 비활성화, 변수에 -1 저장
    /*
    public void select(int index){

        
        for (int i = 0; i < 5; i++){
            content[i].SetActive(false);  
        }
        if (Data.stone == index){
            Data.stone = -1;
        }
        else{
            content[index].SetActive(true); 
            Data.stone = index;
            Data.frame = index;
        }            
    }*/
    public void panel_select(int index)
    {
        switch (index)
        {
            case 0: //스틱페이지
                for (int i = 0; i < 6; i++)
                {
                    sticks[i].SetActive(false);
                }
                sticks[Data.stick].SetActive(true);
                break;

            case 1: //프레임페이지
                for (int i = 0; i < 6; i++)
                {
                    frames[i].SetActive(false);
                }
                frames[Data.frame].SetActive(true);
                break;

            default: //돌페이지
                for (int i = 0; i < 6; i++)
                {
                    stones[i].SetActive(false);
                }
                stones[Data.stone].SetActive(true);
                break;
        }
    }
    public void stick_select(int index)
    {
        if (index < 4){
            sticks[Data.stick].SetActive(false);
            Data.stick = index;
            sticks[index].SetActive(true);
        }
    }

    public void frame_select(int index)
    {
        if (index < 4){
            frames[Data.frame].SetActive(false);
            Data.frame = index;
            frames[index].SetActive(true);
        }
    }

    public void stone_select(int index)
    {
        if (index < 4){
            stones[Data.stone].SetActive(false);
            Data.stone = index;
            stones[index].SetActive(true);
        }
    }

    void Start(){
        panel_select(0);
    }

}
