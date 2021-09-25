using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TileCollector))]
public class PlayerInput : MonoBehaviour
{

    public Vector3 Direction;
    public bool LockInput { get; private set; }

    [SerializeField] private Lean.Touch.LeanFingerSwipe swipeUp;
    [SerializeField] private Lean.Touch.LeanFingerSwipe swipeDown;
    [SerializeField] private Lean.Touch.LeanFingerSwipe swipeLeft;
    [SerializeField] private Lean.Touch.LeanFingerSwipe swipeRight;
    [SerializeField] private TileCollector tileCollector;
    [SerializeField] private WinTrigger winTrigger;
    public void ResetDirection()
    {
        Direction = Vector3.zero;
    }

    private void OnEnable()
    {
        swipeUp.OnFinger.AddListener(HandleSwipeUp);
        swipeDown.OnFinger.AddListener(HandleSwipeDown);
        swipeLeft.OnFinger.AddListener(HandleSwipeLeft);
        swipeRight.OnFinger.AddListener(HandleSwipeRight);
        tileCollector.OnLose += HandleOnLose;
        winTrigger.OnWin += HandleOnWin;
        
    }
    private void OnDisable()
    {
        swipeUp.OnFinger.RemoveListener(HandleSwipeUp);
        swipeDown.OnFinger.RemoveListener(HandleSwipeDown);
        swipeLeft.OnFinger.RemoveListener(HandleSwipeLeft);
        swipeRight.OnFinger.RemoveListener(HandleSwipeRight);
        tileCollector.OnLose -= HandleOnLose;
        winTrigger.OnWin -= HandleOnWin;
    }


    // x - лево право z - вперед назад 
    private void HandleSwipeUp(Lean.Touch.LeanFinger finger)
    {
        if (Direction == Vector3.zero && !LockInput)
            Direction = new Vector3(0, 0, -1);
    }
    private void HandleSwipeDown(Lean.Touch.LeanFinger finger)
    {
        if (Direction == Vector3.zero && !LockInput)
            Direction = new Vector3(0, 0, 1);
    }
    private void HandleSwipeLeft(Lean.Touch.LeanFinger finger)
    {
        if (Direction == Vector3.zero && !LockInput)
            Direction = new Vector3(1, 0, 0);
    }
    private void HandleSwipeRight(Lean.Touch.LeanFinger finger)
    {
        if (Direction == Vector3.zero && !LockInput)
            Direction = new Vector3(-1, 0, 0);
    }

    private void HandleOnLose()
    {
        LockInput = true;
        ResetDirection();
    }
    private void HandleOnWin()
    {
        LockInput = true;
        ResetDirection();
    }

}
