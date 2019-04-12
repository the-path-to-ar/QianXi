using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fruit : MonoBehaviour
{
    /// <summary>
    /// 产生破碎的水果抽象方法
    /// </summary>
    public abstract GameObject SpawnBroken();
    /// <summary>
    /// 产生果汁特效抽象方法
    /// </summary>
    public abstract GameObject SpawnSplash();

    private void Update()
    {
        transform.Rotate(Vector3.right, Random.Range(70, 150) * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Knife")
        {
            //增加成绩
            GameUI.Instance.UpdateScore();

            for (int i = 0; i < 2; i++)
            {
                //产生破碎的水果
                GameObject temp = SpawnBroken();
                temp.SetActive(true);
                temp.transform.position = transform.position;
                temp.transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
                //-3 -2  2 3

                float x, y;
                int ranX = Random.Range(0, 2);
                if (ranX == 0)
                {
                    x = Random.Range(-3.0f, -2.0f);
                }
                else
                {
                    x = Random.Range(2.0f, 3.0f);
                }

                int ranY = Random.Range(0, 2);
                if (ranY == 0)
                {
                    y = Random.Range(-3.0f, -2.0f);
                }
                else
                {
                    y = Random.Range(2.0f, 3.0f);
                }

                temp.GetComponent<Rigidbody>().velocity = new Vector2(x, y);

                if (i == 0)
                {
                    if (PlayerPrefs.HasKey("IsMute") && PlayerPrefs.GetInt("IsMute") == 0)
                    {
                        if (temp.GetComponent<AudioSource>() != null)
                            temp.GetComponent<AudioSource>().Play();
                    }
                }
            }

            //产生果汁特效
            GameObject splash = SpawnSplash();
            splash.SetActive(true);
            splash.transform.position = transform.position;
            splash.transform.rotation = Quaternion.identity;

            //隐藏水果物体
            gameObject.SetActive(false);
        }
        if (other.tag == "BottomCollider")
        {
            gameObject.SetActive(false);
        }
    }
}
