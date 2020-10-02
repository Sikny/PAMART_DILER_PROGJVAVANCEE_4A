using System.Collections;
using System.Collections.Generic;
using Movement;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour {
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    public List<GameObject> possibleAgents = new List<GameObject>();

    public TextMeshProUGUI popUp;
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
    
    public void EndGame() {
        if (_isFinished) return;
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

    public void TogglePopUp()
    {
        popUp.gameObject.SetActive(true);
        soundManager.Play("Goal");
        lPos.LockMove();
        lPos.LockThrow();
        rPos.LockMove();
        rPos.LockThrow();
        StartCoroutine(DelayToggleOff(1.5f));
    }
    
    
    IEnumerator DelayToggleOff(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        lPos.UnlockThrow();
        lPos.UnlockMove();

        rPos.UnlockThrow();
        rPos.UnlockMove();
        popUp.gameObject.SetActive(false);
    }


    public GameObject endGameCanvas;
    private bool _isFinished;

    public void OnMenuReturnButton() {
        endGameCanvas.SetActive(false);
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}
