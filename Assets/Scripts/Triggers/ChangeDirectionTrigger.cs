using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirectionTrigger : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Vector3 direction;


    private void OnTriggerEnter(Collider other)
    { 

        playerInput.Direction = direction;
        other.transform.position = new Vector3(transform.position.x, other.transform.position.y, transform.position.z);
    }
}
