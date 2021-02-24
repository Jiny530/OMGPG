using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    [SerializeField] AudioSource[] bgms = null;
    [SerializeField] AudioSource[] pgMusics = null;

    void Start()
    {
        bgms[Data.selected_song].Play();
        pgMusics[Data.selected_song].Play();//이거 이렇게 틀어서 싱크가 맞을지는 모를 일..
    }
}
