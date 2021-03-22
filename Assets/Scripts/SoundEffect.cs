using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffect : MonoBehaviour
{

    public static AudioSource buttonAudio;

    // [SerializeField] public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        buttonAudio = GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject);   
    }

    public void PlaySE() {
        buttonAudio.volume = Data.volumes[2];
        buttonAudio.Play();
    }

    
}
