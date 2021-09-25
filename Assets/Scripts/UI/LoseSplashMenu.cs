using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseSplashMenu : MonoBehaviour
{
    [SerializeField] private TileCollector tileCollector;
    [SerializeField] private GameObject menu;

    private void OnEnable()
    {
      tileCollector.OnLose+= HandleOnLose;
    }

    private void OnDisable()
    {
        tileCollector.OnLose -= HandleOnLose;
    }
    private void HandleOnLose()
    {
        menu.SetActive(true);
    }
}
