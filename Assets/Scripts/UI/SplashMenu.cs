using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashMenu : MonoBehaviour
{
    [SerializeField] private WinTrigger winTrigger;
    [SerializeField] private GameObject menu;

    private void OnEnable()
    {
        winTrigger.OnWin += HandleOnWin;
    }

    private void OnDisable()
    {
        winTrigger.OnWin -= HandleOnWin;
    }
    private void HandleOnWin() 
    {
        menu.SetActive(true);
    }
}
