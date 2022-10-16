using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCell : MonoBehaviour
{
    private bool _isUsed = false;

    public bool IsUsed { get => _isUsed; }

    public void SetUse(bool isUsed)
    {
        _isUsed = isUsed;
    }    
}
