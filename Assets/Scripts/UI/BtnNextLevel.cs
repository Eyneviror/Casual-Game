using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BtnNextLevel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string SceneName;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(SceneName);
    }
}
