using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{

    public Text text_Loading;
    public Slider slider;
    private float time_loading = 5;
    private float time_current;
    private float time_start;
    private bool isEnded = true;

    void Start()
    {
        Reset_Loading();
    }

    void Update()
    {
        if (isEnded)
            return;
        Check_Loading();
    }

    private void Check_Loading()
    {
        time_current = Time.time - time_start;
        if (time_current < time_loading)
        {
            Set_FillAmount(time_current / time_loading);
        }
        else if (!isEnded)
        {
            End_Loading();
        }
    }

    private void End_Loading()
    {
        Set_FillAmount(1);
        isEnded = true;
        SceneManager.LoadScene("play");
    }

    private void Reset_Loading()
    {
        time_current = time_loading;
        time_start = Time.time;
        Set_FillAmount(0);
        isEnded = false;
    }
    private void Set_FillAmount(float _value)
    {
        slider.value = _value;
        string txt = (_value.Equals(1) ? "Finished.. " : "Loading.. ") + (_value).ToString("P");
        text_Loading.text = txt;
        Debug.Log(txt);
    }
}
