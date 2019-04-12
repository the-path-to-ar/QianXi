using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance;

    public Text txt_Score;
    public Button btn_SwitchCamera;
    public GameObject lifes;
    public GameObject gamePanel;
    public GameObject gameOverPanel;
    public bool isGameOver = false;

    private int score = 0;
    private int lifeCount = 3;

    private void Awake()
    {
        Instance = this;
        txt_Score.text = score.ToString();
        btn_SwitchCamera.onClick.AddListener(() =>
        {
            FindObjectOfType<BaiduARWebCamera>().SwitchCamera();
        });
        gameOverPanel.transform.Find("btn_Again").GetComponent<Button>().onClick.AddListener(OnAgainButtonClick);
        gameOverPanel.transform.Find("btn_MainMenu").GetComponent<Button>().onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
        gameOverPanel.SetActive(false);

        if (PlayerPrefs.HasKey("IsMute"))
        {
            if (PlayerPrefs.GetInt("IsMute") == 0)//不静音
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }
    /// <summary>
    /// 再玩一局
    /// </summary>
    private void OnAgainButtonClick()
    {
        isGameOver = false;
        gameOverPanel.SetActive(false);
        gamePanel.SetActive(true);
        //复原成绩
        score = 0;
        txt_Score.text = score.ToString();
        lifeCount = 3;
        for (int i = 0; i < lifes.transform.childCount; i++)
        {
            lifes.transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
        }
    }
    /// <summary>
    /// 更新成绩显示
    /// </summary>
    public void UpdateScore()
    {
        score++;
        txt_Score.text = score.ToString();
    }
    /// <summary>
    /// 减少一颗心
    /// </summary>
    public void ReduceLife()
    {
        lifeCount--;
        for (int i = 0; i < lifes.transform.childCount; i++)
        {
            if (i < lifeCount)
            {
                lifes.transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                lifes.transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
            }
        }

        if (lifeCount <= 0)//游戏结束
        {
            isGameOver = true;
            gamePanel.SetActive(false);
            gameOverPanel.SetActive(true);
        }
    }
}
