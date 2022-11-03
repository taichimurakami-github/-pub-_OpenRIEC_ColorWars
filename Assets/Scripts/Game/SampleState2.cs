using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleState2 : GameState
{
    private float _totalTime;
    private float _limitTime;
    
    public SampleState2()
    {
        NextType = typeof(SampleState1);
        _totalTime = 0;
        _limitTime = 3.0f;
    }
    public override void OnEnter(GameManager manager)
    {
        Debug.Log("State2に入りました．");
        PaintTarget.TallyScore();
        Debug.Log($"score {PaintTarget.scores[0]}:{PaintTarget.scores[1]}");
    }

    public override void OnExit(GameManager manager)
    {
        Debug.Log("State2を出ました．");
    }

    public override bool IsNext(GameManager manager)
    {
        return _totalTime > _limitTime;
    }

    public override void Update(GameManager manager)
    {
        _totalTime += Time.deltaTime;

    }
}
