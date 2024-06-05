using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileView : AbstractView
{
    [SerializeField] private Joystick _joystick;

    public event Action jumpButtonClicked;
    public event Action<Vector2> joystickDraged;

    public void Jump()
    {
        jumpButtonClicked?.Invoke();
    }

    public void OnJoystickDrag()
    {
        joystickDraged?.Invoke(_joystick.Direction);
    }
}
