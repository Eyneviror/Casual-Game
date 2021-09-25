using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WinTrigger : MonoBehaviour
{
    public event Action OnWin;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            OnWin?.Invoke();
        }
    }
}
