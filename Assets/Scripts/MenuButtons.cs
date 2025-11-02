using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButtons : MonoBehaviour
{
  public void OnExitPressed()
    {
        Application.Quit();
    }
    public void OnStartPressed()
    {
        SceneManager.LoadScene("AR");
    }
}
