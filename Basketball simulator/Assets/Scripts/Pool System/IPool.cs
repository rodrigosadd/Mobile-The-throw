using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPool
{
    void Reset();
    bool IsBeenUsed { get; set; }
}
