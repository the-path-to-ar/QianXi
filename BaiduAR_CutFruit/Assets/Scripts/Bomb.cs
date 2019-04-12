using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Knife")
        {
            //减少一颗心
            GameUI.Instance.ReduceLife();

            //产生爆炸特效
            GameObject temp = ObjectPool.Instance.GetbombEffect();
            temp.SetActive(true);
            temp.transform.position = transform.position;
            temp.transform.rotation = Quaternion.identity;

            if (PlayerPrefs.HasKey("IsMute") && PlayerPrefs.GetInt("IsMute") == 0)
            {
                temp.GetComponent<AudioSource>().Play();
            }
            //隐藏物体
            gameObject.SetActive(false);
        }
        if (other.tag == "BottomCollider")
        {
            gameObject.SetActive(false);
        }
    }
}
