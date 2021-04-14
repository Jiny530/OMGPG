using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{/*
    [SerializeField] GameObject Level_completed;
    [SerializeField] GameObject Level_failed;
    [SerializeField] GameObject PG;
    [SerializeField] GameObject laser;
    [SerializeField] GameObject gaktoe;
    [SerializeField] Transform leaserPos;

    public Text finalScore;
    public Text bestScore;
    public Text newReward;
    //public Image image;
    public Toggle left;
    public Toggle center;
    public Toggle right;
    public Vector3 tmp;
    
    void Start(){
        PG.SetActive(true);
        gaktoe.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (NoteManager.finished)
        {
            SetBoard();
            Level_completed.SetActive(true);
            PG.SetActive(false);
            gaktoe.SetActive(false);
            laser.transform.localPosition=leaserPos.localPosition;
            laser.SetActive(true);
        }
        
    }

    private void SetBoard()
    {
        finalScore.text = PlayerInput.playScore.ToString();
        if (PlayerInput.playScore > Data.best_scores[Data.selected_song])
        {
            Data.best_scores[Data.selected_song] = PlayerInput.playScore;
        }
        bestScore.text = Data.best_scores[Data.selected_song].ToString();
        if(PlayerInput.playScore>0.6*Data.max_scores[Data.selected_song] && Data.best_scores[Data.selected_song]<0.6*Data.max_scores[Data.selected_song])//&&아직 획득되지 않은 아이템이면 이라는 조건 필요.
        {
            newReward.enabled = true;
           // image.enabled = true;
            switch (Data.reward_type[Data.selected_song])
            {
                case 0://frame
                    Data.acquired_frame[Data.reward_index[Data.selected_song]] = true;
                    break;
                case 1://stone
                    Data.acquired_stone[Data.reward_index[Data.selected_song]] = true;
                    break;
                case 2://stick
                    Data.acquired_stick[Data.reward_index[Data.selected_song]] = true;
                    break;
                case 3://info
                    Data.acquired_info[Data.reward_index[Data.selected_song]] = true;
                    break;
            }
        }
        if(PlayerInput.playScore > 0.5 * Data.max_scores[Data.selected_song])
        {
            left.isOn = true;
            if(PlayerInput.playScore > 0.7 * Data.max_scores[Data.selected_song])
            {
                right.isOn = true;
                if (PlayerInput.playScore > 0.9 * Data.max_scores[Data.selected_song])
                {
                    center.isOn = true;
                }
            }
        }
    }*/
}
