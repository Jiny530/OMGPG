using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class click_Storage : MonoBehaviour
{
  public void SceneChange()
  {
    SceneManager.LoadScene("Storage");
  }
}
