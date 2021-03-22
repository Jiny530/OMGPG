using UnityEngine;
using UnityEngine.UI;


public class StorageManager : MonoBehaviour
{
    [SerializeField] Text stick_text_current;
    [SerializeField] Text stick_text_total;
    [SerializeField] Text frame_text_current;
    [SerializeField] Text frame_text_total;
    [SerializeField] Text stone_text_current;
    [SerializeField] Text stone_text_total;
    [SerializeField] Image[] stick_covers = null;
    [SerializeField] Image[] stick_locks = null;
    [SerializeField] Image[] frame_covers = null;
    [SerializeField] Image[] frame_locks = null;
    [SerializeField] Image[] stone_covers = null;
    [SerializeField] Image[] stone_locks = null;
    
    int count_current = 0;
    int count_total = 0;

    public void storageManage(int index){
        
        switch (index){
            case 0: //스틱페이지
                count_current = 0;
                count_total = Data.acquired_stick.GetLength(0);
                for (int i = 0; i < count_total; i++)
                {
                    if (Data.acquired_stick[i] == true) {
                        stick_covers[i].enabled = false;
                        stick_locks[i].enabled = false;
                        count_current++;
                     }
                    else {
                        stick_covers[i].enabled = true;
                        stick_locks[i].enabled = true;
                     }
                }
                stick_text_total.text = count_total.ToString();
                stick_text_current.text = count_current.ToString();
                break;

            case 1: //프레임페이지
                count_current = 0;
                count_total = Data.acquired_frame.GetLength(0);
                for (int i = 0; i < count_total; i++)
                {
                    if (Data.acquired_frame[i] == true) {
                        frame_covers[i].enabled = false;
                        frame_locks[i].enabled = false;
                        count_current++;
                     }
                    else {
                        frame_covers[i].enabled = true;
                        frame_locks[i].enabled = true;
                     }
                }
                frame_text_total.text = count_total.ToString();
                frame_text_current.text = count_current.ToString();
                break;

            default: //돌페이지
                count_current = 0;
                count_total = Data.acquired_stone.GetLength(0);
                for (int i = 0; i < count_total; i++)
                {
                    if (Data.acquired_stone[i] == true) {
                        stone_covers[i].enabled = false;
                        stone_locks[i].enabled = false;
                        count_current++;
                     }
                    else {
                        stone_covers[i].enabled = true;
                        stone_locks[i].enabled = true;
                     }
                }
                stone_text_total.text = count_total.ToString();
                stone_text_current.text = count_current.ToString();
                break;
        }
    }

}
