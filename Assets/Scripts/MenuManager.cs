using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.soundManager.StopPlayingAllMusics();
        GameManager.Instance.soundManager.Play("MenuTheme");
    }

    public void OnPlayButton()
    {
        GameManager.Instance.isServing = false;
        SceneManager.LoadScene("Game");
    }
    
    public void OnExitButton() {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
