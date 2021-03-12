using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    [SerializeField] AudioSource[] bgms = null;
    [SerializeField] AudioSource[] pgMusics = null;

    public AudioSource pgMusic;
    public AudioSource bgm;

    void Start()
    {
        pgMusic=pgMusics[Data.selected_song];
        bgm=bgms[Data.selected_song];
        pgMusics[Data.selected_song].Play(0);
        bgms[Data.selected_song].Play(0);
    }

    void Update(){
        bgm.timeSamples=pgMusic.timeSamples;
    }
}
