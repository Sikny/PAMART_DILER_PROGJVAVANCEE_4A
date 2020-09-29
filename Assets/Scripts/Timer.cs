using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour {
    public int startTime = 60;
    public TextMeshProUGUI timerText;
    private float _time;

    private void Awake() {
        if(GameManager.Instance)
            GameManager.Instance.timer = this;
        _time = startTime;
    }

    public void UpdateTimer() {
        _time -= Time.deltaTime;
        timerText.text = "Time\n"+(int) _time;
        if(_time <= 0.01f) GameManager.Instance.EndGame();
    }
}
