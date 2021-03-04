using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class play_song : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource[] songlist;
    public GameObject panel;
    public Text title;
    public Text score;
    public Image image;

    void Start()
    {
        Data.selected_song = -1;
    }

    // -1로 시작한다고 가정
    public void playSong(int i)
    {
        int nowSong = Data.selected_song;

        if (nowSong != -1) // 이전에 노래를 선택했을 경우
        {
            if (nowSong != i) //같은노래를 선택한게 아니면 
            {
                if (nowSong != 0) songlist[nowSong].Stop();
                if (i != 0) songlist[i].Play(); // 자유연주모드는 재생할 노래 없음
                Data.selected_song = i;

                //패널을 새로 바뀐 노래 정보로 업데이트
                panel.SetActive(true);
                panel_info(i);
            }
            else //같은노래이면
            {
                if (i != 0) songlist[nowSong].Stop(); // 노래 멈춤
                Data.selected_song = -1; //선택하기 전으로 돌아감

                //패널 없애기
                panel.SetActive(false);
            }
        }
        else //이전에 뭔가 선택한 적이 없을 경우
        {
            if (i!=0) songlist[i].Play(); //자유연주모드 아니면 노래재생

            Data.selected_song = i;
            //패널에 선택된 노래에 대한 정보 올리기
            panel_info(i);
            //패널 띄우기
            panel.SetActive(true);



        }
        
    }


    void panel_info(int i)
    {
        // 노래에 대한 정보 입력 (score, image, title) -> best_scores, song_list
        title.GetComponent<Text>().text = Data.song_list[i];
        image.GetComponent<Image>().sprite = Resources.Load<Sprite>(Data.song_list[i]); ;
        score.GetComponent<Text>().text = Data.best_scores[i].ToString();
    }


    public void stopSong() //이거는 x버튼 누를때 노래 멈추는거. 지금은 쓸모없음
    {
        songlist[Data.selected_song].Stop();
        Data.selected_song = 0;
    }



}
