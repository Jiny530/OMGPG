using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    [SerializeField] Text best_score = null;
    
    public void UpdateBestScore(){

        best_score.text = Data.best_scores[Data.selected_song].ToString();

    }

}
