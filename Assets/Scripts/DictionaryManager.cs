using UnityEngine;
using UnityEngine.UI;


public class DictionaryManager : MonoBehaviour
{
    [SerializeField] Text text_current;
    [SerializeField] Text text_total;
    [SerializeField] Image[] covers = null;
    [SerializeField] Image[] locks = null;

    // Start is called before the first frame update
    void Start()
    {

        int count_current = 0;
        int count_total = Data.acquired_info.GetLength(0);

        for (int i = 0; i < count_total; i++) {
            if (Data.acquired_info[i] == true) {
                covers[i].enabled = false;
                locks[i].enabled = false;
                count_current++;
            }
            else {
                covers[i].enabled = true;
                locks[i].enabled = true;
            }
        }

        text_total.text = count_total.ToString();
        text_current.text = count_current.ToString();
        
    }
}
