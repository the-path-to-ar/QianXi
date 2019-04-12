using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaiduARInternal;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public GameObject mouse;
    public Button btn_Play;
    public Button btn_Audio;
    public Button btn_SwitchCamera;
    public Sprite audio_Normal;
    public Sprite audio_Mute;

    private BaiduARHumanPose humanPose;
    /// <summary>
    /// 是否静音
    /// </summary>
    private bool isMute = false;
    private BaiduARWebCamera webCamera;

    private void Awake()
    {
        //切换摄像头，默认前置
        webCamera = FindObjectOfType<BaiduARWebCamera>();
        webCamera.SwitchCamera();

        humanPose = FindObjectOfType<BaiduARHumanPose>();
        humanPose.InvokePosMessage(InvokePosMessage);

        btn_Play.onClick.AddListener(OnPlayButtonClick);
        btn_Audio.onClick.AddListener(OnAudioButtonClick);
        btn_SwitchCamera.onClick.AddListener(OnSwitchCameraButtonClick);

        if (PlayerPrefs.HasKey("IsMute"))
        {
            if (PlayerPrefs.GetInt("IsMute") == 1)//静音
            {
                isMute = true;
                btn_Audio.GetComponent<Image>().sprite = audio_Mute;
            }
            else
            {
                isMute = false;
                btn_Audio.GetComponent<Image>().sprite = audio_Normal;
            }
        }
        else
        {
            PlayerPrefs.SetInt("IsMute", 0);
        }
    }
    private void OnSwitchCameraButtonClick()
    {
        webCamera.SwitchCamera();
    }
    /// <summary>
    /// 开始游戏按钮点击
    /// </summary>
    private void OnPlayButtonClick()
    {
        SceneManager.LoadScene(1);
    }
    /// <summary>
    /// 音效按钮点击
    /// </summary>
    private void OnAudioButtonClick()
    {
        isMute = !isMute;
        if (isMute)
        {
            PlayerPrefs.SetInt("IsMute", 1);
            btn_Audio.GetComponent<Image>().sprite = audio_Mute;
        }
        else
        {
            PlayerPrefs.SetInt("IsMute", 0);
            btn_Audio.GetComponent<Image>().sprite = audio_Normal;
        }
    }
    /// <summary>
    /// 肢体识别所有骨骼点的信息
    /// </summary>
    /// <param name="datas"></param>
    private void InvokePosMessage(List<OutPutData> datas)
    {
        if (datas[7].score < 0.2f)
        {
            mouse.SetActive(false);
        }
        else
        {
            if (mouse.activeSelf == false)
                mouse.SetActive(true);

            mouse.transform.position = new Vector3(datas[7].VectorScreenPos.x, datas[7].VectorScreenPos.y + 10, 0);
        }
    }
}
