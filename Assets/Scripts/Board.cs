using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    public Action PlayerVictory;
    private void Start()
    {
        
    }
    private void Update()
    {
        SendPlayerVictory();
    }
    private void SendPlayerVictory()
    {
        if(transform.childCount == 0)
        PlayerVictory?.Invoke();
    }
}
