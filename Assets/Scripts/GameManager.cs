using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    [HideInInspector] public Timer timer;

    private void Awake() {
        if (_instance != null) {
            Destroy(gameObject);
            return;
        }
        if (SceneManager.GetActiveScene().name != "Menu") {
            SceneManager.LoadScene("Menu");
            return;
        }

        _instance = this;
        
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if(timer) timer.UpdateTimer();
    }

    public void EndGame() {
        endGameCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public GameObject endGameCanvas;
    public void OnMenuReturnButton() {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        endGameCanvas.SetActive(false);
    }
}
