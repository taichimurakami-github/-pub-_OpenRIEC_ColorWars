using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameState
{
    public GameState()
    {
        NextType = typeof(GameState);
    }
    public virtual void OnEnter(GameManager manager){}

    public virtual void OnExit(GameManager manager){}

    public virtual bool IsNext(GameManager manager)
    {
        return false;
    }

    public virtual void Update(GameManager manager)
    {
        
    }

    public Type NextType { get; protected set; }

}
