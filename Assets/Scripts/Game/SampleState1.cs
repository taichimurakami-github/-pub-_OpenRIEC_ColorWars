using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleState1 : GameState
{
    public SampleState1()
    {
        NextType = typeof(SampleState2);
    }
    public override void OnEnter(GameManager manager)
    {
        Debug.Log("State1に入りました．");
    }

    public override void OnExit(GameManager manager)
    {
        Debug.Log("State1を出ました．");
    }

    public override bool IsNext(GameManager manager)
    {
        return Input.GetKeyDown(KeyCode.A);
    }

    public override void Update(GameManager manager)
    {
        
    }
}
