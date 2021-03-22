using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffect : MonoBehaviour
{

    [SerializeField] Slider PGSlider = null;
    [SerializeField] Slider BGSlider = null;
    [SerializeField] Slider BTNSlider = null;

    public AudioSource buttonAudio;

    // [SerializeField] public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        buttonAudio = GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject);
        PGSlider.value = Data.volumes[0];
        BGSlider.value = Data.volumes[1];
        BTNSlider.value = Data.volumes[2];
    }

    public void PlaySE() {
        buttonAudio.volume = Data.volumes[2];
        buttonAudio.Play();
    }

    public void SetPGVolume()
    {
        Data.volumes[0] = PGSlider.value;
    }

    public void TestPGVolume(){
        buttonAudio.volume = PGSlider.value;;
        buttonAudio.Play();
        buttonAudio.volume = BTNSlider.value;
    }

    public void SetBackgroundVolume()
    {
        Data.volumes[1] = BGSlider.value;
    }

    public void TestBGVolume(){
        buttonAudio.volume = BGSlider.value;
        buttonAudio.Play();
        buttonAudio.volume = BTNSlider.value;
    }

    public void SetButtonVolume()
    {
        Data.volumes[2] = BTNSlider.value;
    }

    public void TestBTNVolume(){
        buttonAudio.Play();
    }
}
