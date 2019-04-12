using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaiduARInternal;

public class HumanPose : MonoBehaviour
{
    public GameObject LWrist;
    public GameObject RWrist;
    public GameObject LAnkle;
    public GameObject RAnkle;
    public GameObject mouse;

    private BaiduARHumanPose humanPose;

    private void Awake()
    {
        LWrist.SetActive(false);
        RWrist.SetActive(false);
        LAnkle.SetActive(false);
        RAnkle.SetActive(false);

        //切换摄像头，默认前置
        FindObjectOfType<BaiduARWebCamera>().SwitchCamera();

        humanPose = GetComponent<BaiduARHumanPose>();
        humanPose.InvokePosMessage(InvokePosMessage);
    }
    private void InvokePosMessage(List<OutPutData> datas)
    {
        if (GameUI.Instance.isGameOver)
        {
            if (datas[7].score < 0.2f)
            {
                mouse.SetActive(false);
            }
            else
            {
                if (mouse.activeSelf == false)
                    mouse.SetActive(true);
                mouse.transform.position = new Vector3(datas[7].VectorScreenPos.x, datas[7].VectorScreenPos.y, 0);
            }
            return;
        }

        //4 7 10 13
        if (datas[4].score < 0.2f)
        {
            RWrist.SetActive(false);
        }
        else
        {
            RWrist.SetActive(true);
            RWrist.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(datas[4].VectorScreenPos.x, datas[4].VectorScreenPos.y, 6));
        }

        if (datas[7].score < 0.2f)
        {
            LWrist.SetActive(false);
        }
        else
        {
            LWrist.SetActive(true);
            LWrist.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(datas[7].VectorScreenPos.x, datas[7].VectorScreenPos.y, 6));
        }

        if (datas[10].score < 0.2f)
        {
            RAnkle.SetActive(false);
        }
        else
        {
            RAnkle.SetActive(true);
            RAnkle.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(datas[10].VectorScreenPos.x, datas[10].VectorScreenPos.y, 6));
        }
        if (datas[13].score < 0.2f)
        {
            LAnkle.SetActive(false);
        }
        else
        {
            LAnkle.SetActive(true);
            LAnkle.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(datas[13].VectorScreenPos.x, datas[13].VectorScreenPos.y, 6));
        }
    }
}
