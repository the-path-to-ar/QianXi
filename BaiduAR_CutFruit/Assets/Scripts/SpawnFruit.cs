using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruit : MonoBehaviour
{
    private void Awake()
    {
        InvokeRepeating("BottomSpawn", 0f, 2f);
        InvokeRepeating("LeftSpawn", 0f, 1.5f);
        InvokeRepeating("RightSpawn", 1f, 2.5f);
    }
    /// <summary>
    /// 底部生成
    /// </summary>
    private void BottomSpawn()
    {
        GameObject temp = null;

        int ran = Random.Range(0, 15);
        if (ran != 10)
        {
            temp = ObjectPool.Instance.GetRandomFruit();
        }
        else
        {
            temp = ObjectPool.Instance.GetBombObj();
        }

        temp.SetActive(true);
        temp.transform.position = new Vector3(Random.Range(-1.4f, 1.4f), -4, 6);
        temp.transform.rotation = Quaternion.identity;
        temp.GetComponent<Rigidbody>().velocity = new Vector2(0, Random.Range(3.5f, 5f));

        if (temp.GetComponent<AudioSource>() != null)
        {
            if (PlayerPrefs.HasKey("IsMute") && PlayerPrefs.GetInt("IsMute") == 0)
            {
                temp.GetComponent<AudioSource>().Play();
            }
        }
    }
    /// <summary>
    /// 左边生成
    /// </summary>
    private void LeftSpawn()
    {
        GameObject temp = null;

        int ran = Random.Range(0, 15);
        if (ran != 10)
        {
            temp = ObjectPool.Instance.GetRandomFruit();
        }
        else
        {
            temp = ObjectPool.Instance.GetBombObj();
        }
        temp.SetActive(true);
        temp.transform.position = new Vector3(-2.5f, Random.Range(-2.3f, 0.6f), 6);
        temp.transform.rotation = Quaternion.identity;

        temp.GetComponent<Rigidbody>().velocity = new Vector2(Random.Range(1.0f, 1.5f), Random.Range(3f, 3.5f));
    }
    /// <summary>
    /// 右边生成
    /// </summary>
    private void RightSpawn()
    {
        GameObject temp = null;

        int ran = Random.Range(0, 15);
        if (ran != 10)
        {
            temp = ObjectPool.Instance.GetRandomFruit();
        }
        else
        {
            temp = ObjectPool.Instance.GetBombObj();
        }
        temp.SetActive(true);
        temp.transform.position = new Vector3(2.5f, Random.Range(-2.3f, 0.6f), 6);
        temp.transform.rotation = Quaternion.identity;
        temp.GetComponent<Rigidbody>().velocity = new Vector2(Random.Range(-1.0f, -1.5f), Random.Range(3f, 3.5f));
    }
}
