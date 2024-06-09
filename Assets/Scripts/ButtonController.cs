using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void PauseButton()
    {
        Time.timeScale = 0.0f;
    }
    public void RePauseButton()
    {
        Time.timeScale = 1.0f;
    }
    public void SoundOn()
    {
        AudioListener.pause = true;
    }
    public void SoundOff()
    {

        AudioListener.pause = false;
    }
    public void RestartBut()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
    public void MenuBut()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    public void ExitBut()
    {
        Application.Quit();
    }
    public void StartBut()
    {
        SceneManager.LoadScene(1);
    }

}
