using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
  // выход из игры 
  public void Exit()
  {
    Application.Quit();
  }
  // выход в главное меню
  public void MenuButton()
  {
    SceneManager.LoadScene(0);
    Time.timeScale = 1f;
  }
  public void StartButton()
  {
    SceneManager.LoadScene(1);
    Time.timeScale = 1f;
  }
  public void RestartLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    Time.timeScale = 1f;
  }
  public void Reset()
  {
    PlayerPrefs.SetFloat("record", 0);
  }
}
