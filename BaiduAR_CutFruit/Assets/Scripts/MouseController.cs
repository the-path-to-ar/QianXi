using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseController : MonoBehaviour
{
    private GameObject button = null;
    private Image fillImage;

    private void Awake()
    {
        fillImage = transform.GetChild(0).GetComponent<Image>();
        fillImage.fillAmount = 0;
    }
    private void Update()
    {
        if (button != null && fillImage.fillAmount <= 1)
        {
            fillImage.fillAmount += 0.02f;
        }
        if (fillImage.fillAmount >= 1)
        {
            if (button != null)
            {
                button.GetComponent<Button>().onClick.Invoke();
                button = null;
            }
            fillImage.fillAmount = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        button = collision.gameObject;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        button = null;
        fillImage.fillAmount = 0;
    }
}
