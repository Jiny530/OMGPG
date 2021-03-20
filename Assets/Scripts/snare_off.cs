using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snare_off : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void off(){
        transform.parent.gameObject.SetActive(false);
    }

    public void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = Data.speed[Data.selected_song];
    }
}
