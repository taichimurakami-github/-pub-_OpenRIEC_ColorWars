using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCommand : UICommand
{
    public bool IsActive { get; }
    public TitleCommand(bool isActive)
    {
        IsActive = isActive;
    }
}
