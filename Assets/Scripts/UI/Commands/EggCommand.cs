using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCommand : UICommand
{
    public int ControllerId { get; }

    public EggCommand(int controllerId)
    {
        ControllerId = controllerId;
    }
}
