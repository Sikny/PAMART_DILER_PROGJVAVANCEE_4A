using UnityEngine;

public class SimulateScoreTime
{
    private int _lScore;

    public int LScore {
        get => _lScore;
        set => _lScore = value;
    }

    public int RScore {
        get => _rScore;
        set => _rScore = value;
    }

    private int _rScore;
    private float _timer;

    private int _goalPosX = 8;
    private Vector2 _lGoal = new Vector2(8, 2);
    private Vector2 _rGoal = new Vector2(-8, -2);

    public void Init(float time) {
        _timer = time;
    }
    
    public bool CheckInGoal(Vector2 posFrisbee)
    {
        if (posFrisbee.x <= -_goalPosX)            //in left goal
        {
            if (posFrisbee.y < 2 || posFrisbee.y > -2)
                _lScore += 5;
            else
                _lScore += 3;
            return true;
        }
        if (posFrisbee.x >= _goalPosX)            //in right goal
        {    
            
            if (posFrisbee.y < 2 || posFrisbee.y > -2)
                _rScore += 5;
            else
                _rScore += 3;
            return true;
        }
        return false;
    }
    
    public float UpdateTimer()
    {
        _timer -= 1f / 60f;
        return _timer;
    }

    public float GetTime() {
        return _timer;
    }
}
