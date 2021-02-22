using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snare_off : MonoBehaviour
{
    // Start is called before the first frame update
    void off(){
        transform.parent.gameObject.SetActive(false);
    }
}
