using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSystem : MonoBehaviour
{
    public static ViewSystem instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
}