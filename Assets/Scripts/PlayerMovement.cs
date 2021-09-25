using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float returnEffect;


    private PlayerInput playerInput;
    private bool canRun = true;
    private Vector3 previousPosition;


    private void OnEnable()
    {
        TileCollector.OnActivatePlatform += HandleActivatePlatform;
    }
    private void OnDisable()
    {
        TileCollector.OnActivatePlatform -= HandleActivatePlatform;
    }

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (canRun)
        {
            transform.Translate(playerInput.Direction * speed * Time.deltaTime, Space.World);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            transform.position = new Vector3(previousPosition.x, transform.position.y, previousPosition.z);
            playerInput.ResetDirection();
        }
        if (other.CompareTag("ReturnPoint"))
        {
            previousPosition = other.transform.position;
        }
    }
    private void HandleActivatePlatform(Transform other)
    {
        previousPosition = other.position;
    }

    public void ReturnToResetPosition()
    {
        transform.position = new Vector3(previousPosition.x, transform.position.y, previousPosition.z);
        playerInput.ResetDirection();
    }

}
