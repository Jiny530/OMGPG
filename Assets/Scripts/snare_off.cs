using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snare_off : MonoBehaviour
{
    // Start is called before the first frame update
    void off(){
        gameObject.SetActive(false);
        print("비활성화");
    }
}
