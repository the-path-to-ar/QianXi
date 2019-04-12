using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHide : MonoBehaviour
{
    public float showTime = 1f;
    private float timer = 0.0f;

    private void OnEnable()
    {
        timer = showTime;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = showTime;
            gameObject.SetActive(false);
        }
    }
}
