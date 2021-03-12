using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    int selected_song, user_lev, user_ex, stick, stone, frame, dic_lev, volume;
    float sink;
    int[] top_score;


 /*   void select()
    {
        //selected = getComponent
    }*/
/*
    public void dataSave()
    {
        //데이터 저장
        PlayerPrefs.SetInt("selected_song", selected_song);
        PlayerPrefs.SetInt("user_lev", user_lev);
        PlayerPrefs.SetInt("user_ex", user_ex);
        PlayerPrefs.SetInt("stick", stick);
        PlayerPrefs.SetInt("stone", stone);
        PlayerPrefs.SetInt("frame", frame);
        PlayerPrefs.SetInt("dic_lev", dic_lev);
        PlayerPrefs.SetInt("volume", volume);
        PlayerPrefs.SetFloat("sink", sink);

        PlayerPrefs.SetInt("top_score_song_number0", top_score[0]);
        PlayerPrefs.SetInt("top_score_song_number1", top_score[1]);
        PlayerPrefs.SetInt("top_score_song_number2", top_score[2]);

        PlayerPrefs.Save();
    }*/

    public void go_Main()
    {
        //dataSave();
        SceneManager.LoadScene("RealMain");
    }

    public void go_Dictionary()
    {
        //dataSave();
        SceneManager.LoadScene("Dictionary");
    }

    public void go_Storage()
    {
        //dataSave();
        SceneManager.LoadScene("Storage");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

    public void go_Play()
    {
        //dataSave();
        SceneManager.LoadScene("Play");
    }

   /*public void re_Play()
    {
        //dataSave();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }*/

    public void go_Sync()
    {
        //dataSave();
        SceneManager.LoadScene("Sync");
    }

    public void go_Loading()
    {
        //dataSave();
        SceneManager.LoadScene("Loading");
    }

}