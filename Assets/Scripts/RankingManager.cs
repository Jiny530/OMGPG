using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    [SerializeField] Text best_score = null;
    [SerializeField] Toggle[] stars_left;
    [SerializeField] Toggle[] stars_center;
    [SerializeField] Toggle[] stars_right;
    
    public void UpdateBestScore(){

        best_score.text = Data.best_scores[Data.selected_song].ToString();

    }

    public void UpdateStar(){
        for (int i=1; i<Data.song_list.Length; i++){
            if(Data.best_scores[i] > 0.5 * Data.max_scores[i])
            {
                stars_left[i-1].isOn = true;
                if(PlayerInput.playScore > 0.7 * Data.max_scores[i])
                {
                   stars_right[i-1].isOn = true;
                    if (PlayerInput.playScore > 0.9 * Data.max_scores[i])
                    {
                        stars_center[i-1].isOn = true;
                    }
                }
            }
        }

    }

    void Start(){
        UpdateStar();
    }

}
