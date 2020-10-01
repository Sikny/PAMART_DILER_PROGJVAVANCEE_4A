using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    public List<GameObject> possibleAgents = new List<GameObject>();

    [HideInInspector] public Timer timer;
    [HideInInspector] public bool isServing;
    [HideInInspector] public BaseMovement lPos;
    [HideInInspector] public BaseMovement rPos;
    public SoundManager soundManager;
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
        soundManager.Init();
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if(timer) timer.UpdateTimer();
    }

    public void EndGame()
    {
        _isFinished = true;
        soundManager.StopPlayingAllMusics();
        soundManager.Play("FinishTheme");
        endGameCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public bool IsFinished
    {
        get => _isFinished;
        set => _isFinished = value;
    }

    public GameObject endGameCanvas;
    private bool _isFinished;

    public void OnMenuReturnButton() {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        endGameCanvas.SetActive(false);
    }
}
