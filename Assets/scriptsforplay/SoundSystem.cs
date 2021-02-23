using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public static AudioSource[] audios;

    void Start()
    {
        audios = GameObject.Find("SoundSystem").GetComponents<AudioSource>();
        //여기에 음악 경로로 다 써놓기 Find 하지 않기 위해.
    }
}
