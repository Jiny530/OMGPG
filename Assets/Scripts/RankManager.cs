using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class RankManager : MonoBehaviour
{
    public GameObject prefab; //랭킹패드
    public Transform parent; //랭킹패널
    //private GameObject name;
    //private GameObject score;
    public GameObject TextField;
    private TextMeshProUGUI TMPtext;
    int idx = 1;

    void Start()
    {
        TMPtext = TextField.GetComponent<TextMeshProUGUI>();
    }

    public void newRecord()
    {
        UserRank record = new UserRank();
        record.ID = TMPtext.text;
        record.score = PlayerInput.playScore;
        record.index = Data.userList.Count; //점수가 같을 경우 더 빠른점수를 상위랭크로 매길 때 사용
        Data.userList.Add(record);
        // 점수 내림차순 정렬 후 들어온 순서대로 오름차순 정렬
        Data.userList = Data.userList.OrderByDescending(x => x.score).ThenBy(x => x.index).ToList(); 

        foreach (var rank in Data.userList)
        {
            if (idx > 10) break;
            show_ranking(rank, idx);
            idx++;
        }
        idx = 1;
        
    }

    void show_ranking(UserRank u, int i)
    {
        GameObject myInstance = Instantiate(prefab, parent); //생성후 자리 어떻게 생기는지 과나
        var rank = myInstance.transform.GetChild(0).gameObject;
        rank.GetComponent<Text>().text = i.ToString();
        var name = myInstance.transform.GetChild(1).gameObject;
        name.GetComponent<Text>().text = u.ID;
        var score = myInstance.transform.GetChild(2).gameObject;
        score.GetComponent<Text>().text = "score : " + u.score.ToString();
    }
}