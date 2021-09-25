using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
public class TileCollector : MonoBehaviour
{
    public static event Action<Transform> OnActivatePlatform;
    public event Action OnLose;

    [SerializeField] private GameObject totalPlatform;
    [SerializeField] private GameObject playerModel;
    [SerializeField] private float offset;
    [SerializeField] private float offsetHeight;
    [SerializeField] private float offsetPositionPlatform;
    [SerializeField] private int numberPlatforms;
    [SerializeField] private float ZscalePlayerPlatform;
    private void OnTriggerExit(Collider other)
    {



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpentPlatform"))
        {
            MeshRenderer meshRenderer = other.GetComponent<MeshRenderer>();
            if(meshRenderer.enabled == false && numberPlatforms == 0)
            {
                OnLose?.Invoke();
                
            }


            if (numberPlatforms >= 1)
            {
                numberPlatforms--;
                meshRenderer.enabled = true;
                totalPlatform.SetActive(true);
                playerModel.transform.Translate(Vector3.up * offsetHeight * -1);
                totalPlatform.transform.localScale = new Vector3(1, ZscalePlayerPlatform + offset * numberPlatforms, 1);
                totalPlatform.transform.Translate(Vector3.up * offsetPositionPlatform * -1);
                OnActivatePlatform.Invoke(other.transform);
            }
            else
            {
                totalPlatform.SetActive(false);
            }

        }
        if (other.CompareTag("Platform"))
        {

            Destroy(other.gameObject,0.05f);
            numberPlatforms++;

            if (numberPlatforms >= 1)
            {
                totalPlatform.SetActive(true);
                playerModel.transform.Translate(Vector3.up * offsetHeight);
                totalPlatform.transform.localScale = new Vector3(1, 0.2f + offset * numberPlatforms, 1);
                totalPlatform.transform.Translate(Vector3.up * offsetPositionPlatform);
            }

        }


    }
}
