using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selected_thema : MonoBehaviour
{
    public GameObject[] content;

    //해당 이미지를 클릭하면 나머지는 비활성화, 선택된것만 활성화, 변수에 해당 인덱스 저장
    //선택된 이미지를 한번 더 클릭시 비활성화, 변수에 -1 저장

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
        }            
    }
}

