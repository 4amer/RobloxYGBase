using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class AbstractView : MonoBehaviour
{
    public void Show()
    {
        gameObject.active = true;
    }

    public void Hide()
    {
        gameObject.active = false;
    }
}
