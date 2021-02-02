using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tmp_scoreBar : MonoBehaviour
{
    public Slider ScoreBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(/*점수를 얻을 일을 하면*/true){
            ScoreBar.value += 0.1f;
        }
    }
}
