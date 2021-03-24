using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageSoundEffect : MonoBehaviour
{
    [SerializeField] AudioSource buttonAudio;
    [SerializeField] AudioSource errorAudio;

    public void clickableButton(){
        buttonAudio.volume = Data.volumes[2];
        buttonAudio.Play();
    }

    public void unclickableButton(){
        errorAudio.volume = Data.volumes[2];
        errorAudio.Play();
    }

}
