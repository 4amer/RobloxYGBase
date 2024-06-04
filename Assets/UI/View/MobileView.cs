using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileView : AbstractView
{
    [SerializeField] private Joystick _joystick;

    public event Action jumpButtonClicked;

    public void Jump()
    {
        jumpButtonClicked?.Invoke();
    }
}
