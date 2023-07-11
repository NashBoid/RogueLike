using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
  
  public void Scenes(int number)
  {
    SceneManager.LoadScene(number);
  }

  public void Exit()
  {
    Application.Quit();
  }

}
 