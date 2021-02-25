using UnityEngine;
using UnityEngine.UI;


public class StorageManager : MonoBehaviour
{ 
    [SerializeField] Image[] stones = null;
    [SerializeField] Image[] frames = null;
    [SerializeField] Image[] sticks = null;

    void Start()
    {
        for(int i = 0; i < stones.Length; i++)
        {
            stones[i].enabled = Data.acquired_stone[i];
        }
        for (int i = 0; i < frames.Length; i++)
        {
            frames[i].enabled = Data.acquired_frame[i];

        }
        for (int i = 0; i < sticks.Length; i++)
        {
            sticks[i].enabled = Data.acquired_stick[i];

        }
    }
}
