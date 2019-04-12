using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeManager : MonoBehaviour
{
    private TrailRenderer trailRenderer;

    private void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
    }
    private void Update()
    {
        if (GameUI.Instance.isGameOver)
        {
            gameObject.SetActive(false);
            return;
        }
        else
        {
            if (gameObject.activeSelf == false)
                gameObject.SetActive(true);
        }
        if (trailRenderer.positionCount >= 2)
        {
            Vector3 fristPos = trailRenderer.GetPosition(0);
            Vector3 lastPos = trailRenderer.GetPosition(trailRenderer.positionCount - 1);
            if (Vector3.Distance(fristPos, lastPos) > 0.6f)
            {
                //运动幅度过大
                GetComponent<SphereCollider>().enabled = true;
            }
            else
            {
                //静止
                GetComponent<SphereCollider>().enabled = false;
            }
        }
        else
        {
            GetComponent<SphereCollider>().enabled = false;
        }
    }
}
