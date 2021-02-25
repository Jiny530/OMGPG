using UnityEngine;
using UnityEngine.UI;


public class DictionaryManager : MonoBehaviour
{
    [SerializeField] Image[] infos = null;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < infos.Length; i++)
        {
            infos[i].enabled = Data.acquired_info[i];
        }
    }
}
