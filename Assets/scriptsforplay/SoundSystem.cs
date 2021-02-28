using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    [SerializeField] AudioSource[] bgms = null;
    [SerializeField] AudioSource[] pgMusics = null;

    void Start()
    {
        pgMusics[Data.selected_song].Play(0);
        bgms[Data.selected_song].Play(0);
    }
}
