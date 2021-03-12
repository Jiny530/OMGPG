using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{

    public AudioSource theAudio;
    public AudioSource PGAudio;
    public AudioSource BackgroundAudio;

    [SerializeField] public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        theAudio = GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject);
    }

    public void PlaySE() {
        theAudio.Play();
    }

    public void SetPGVolume(float volume)
    {
        PGAudio.volume = volume;
    }

    public void SetBackgroundVolume(float volume)
    {
        BackgroundAudio.volume = volume;
    }

    public void SetButtonVolume(float volume)
    {
        theAudio.volume = volume;
    }
}
