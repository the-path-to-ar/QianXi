using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    public int initCount = 5;

    public GameObject pre_Apple;
    public GameObject pre_Lemon;
    public GameObject pre_Watermelon;
    public GameObject pre_Bomb;
    public GameObject broken_Apple, broken_Lemon, broken_Watermelon1, broken_Watermelon2;
    public GameObject splash;
    public GameObject effect_Bomb;

    private List<GameObject> applePreList = new List<GameObject>();
    private List<GameObject> lemonPreList = new List<GameObject>();
    private List<GameObject> watermelonPreList = new List<GameObject>();
    private List<GameObject> bombPreList = new List<GameObject>();
    private List<GameObject> appleBrokenList = new List<GameObject>();
    private List<GameObject> lemonBrokenList = new List<GameObject>();
    private List<GameObject> watermelonBrokenList_1 = new List<GameObject>();
    private List<GameObject> watermelonBrokenList_2 = new List<GameObject>();
    private List<GameObject> splashList = new List<GameObject>();
    private List<GameObject> bombEffectList = new List<GameObject>();

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < initCount; i++)
        {
            InstantiateObj(pre_Apple, ref applePreList);
        }
        for (int i = 0; i < initCount; i++)
        {
            InstantiateObj(pre_Lemon, ref lemonPreList);
        }
        for (int i = 0; i < initCount; i++)
        {
            InstantiateObj(pre_Watermelon, ref watermelonPreList);
        }
        for (int i = 0; i < initCount; i++)
        {
            InstantiateObj(pre_Bomb, ref bombPreList);
        }
        for (int i = 0; i < initCount; i++)
        {
            InstantiateObj(broken_Apple, ref appleBrokenList);
        }
        for (int i = 0; i < initCount; i++)
        {
            InstantiateObj(broken_Lemon, ref lemonBrokenList);
        }
        for (int i = 0; i < initCount; i++)
        {
            InstantiateObj(broken_Watermelon1, ref watermelonBrokenList_1);
        }
        for (int i = 0; i < initCount; i++)
        {
            InstantiateObj(broken_Watermelon2, ref watermelonBrokenList_2);
        }
        for (int i = 0; i < initCount; i++)
        {
            InstantiateObj(splash, ref splashList);
        }
        for (int i = 0; i < initCount; i++)
        {
            InstantiateObj(effect_Bomb, ref bombEffectList);
        }
    }
    /// <summary>
    /// 生成物体，加到相应的list里面
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="addList"></param>
    private GameObject InstantiateObj(GameObject prefab, ref List<GameObject> addList)
    {
        GameObject temp = Instantiate(prefab, transform);
        temp.SetActive(false);
        addList.Add(temp);
        return temp;
    }
    /// <summary>
    /// 随机获得水果物体
    /// </summary>
    /// <returns></returns>
    public GameObject GetRandomFruit()
    {
        int ran = Random.Range(0, 3);
        if (ran == 0)
        {
            return GetAppleObj();
        }
        else if (ran == 1)
        {
            return GetLemonObj();
        }
        else
        {
            return GetWatermelonObj();
        }
    }
    /// <summary>
    /// 获得苹果物体
    /// </summary>
    /// <returns></returns>
    private GameObject GetAppleObj()
    {
        for (int i = 0; i < applePreList.Count; i++)
        {
            if (applePreList[i].activeSelf == false)
            {
                return applePreList[i];
            }
        }
        //执行到这里，代表list里面没有可用的物体，那就再创建一个
        return InstantiateObj(pre_Apple, ref applePreList);
    }
    /// <summary>
    /// 获得Lemon物体
    /// </summary>
    /// <returns></returns>
    private GameObject GetLemonObj()
    {
        foreach (var item in lemonPreList)
        {
            if (item.activeSelf == false)
            {
                return item;
            }
        }
        return InstantiateObj(pre_Lemon, ref lemonPreList);
    }
    /// <summary>
    /// 获得Watermelon物体
    /// </summary>
    /// <returns></returns>
    private GameObject GetWatermelonObj()
    {
        foreach (var item in watermelonPreList)
        {
            if (item.activeSelf == false)
            {
                return item;
            }
        }
        return InstantiateObj(pre_Watermelon, ref watermelonPreList);
    }
    /// <summary>
    /// 获得Bomb物体
    /// </summary>
    /// <returns></returns>
    public GameObject GetBombObj()
    {
        foreach (var item in bombPreList)
        {
            if (item.activeSelf == false)
            {
                return item;
            }
        }
        return InstantiateObj(pre_Bomb, ref bombPreList);
    }
    public GameObject GetAppleBrokenObj()
    {
        foreach (var item in appleBrokenList)
        {
            if (item.activeSelf == false)
            {
                return item;
            }
        }
        return InstantiateObj(broken_Apple, ref appleBrokenList);
    }
    public GameObject GetLemonBrokenObj()
    {
        foreach (var item in lemonBrokenList)
        {
            if (item.activeSelf == false)
            {
                return item;
            }
        }
        return InstantiateObj(broken_Lemon, ref lemonBrokenList);
    }
    public GameObject GetWatermelonBrokenObj_1()
    {
        foreach (var item in watermelonBrokenList_1)
        {
            if (item.activeSelf == false)
            {
                return item;
            }
        }
        return InstantiateObj(broken_Watermelon1, ref watermelonBrokenList_1);
    }
    public GameObject GetWatermelonBrokenObj_2()
    {
        foreach (var item in watermelonBrokenList_2)
        {
            if (item.activeSelf == false)
            {
                return item;
            }
        }
        return InstantiateObj(broken_Watermelon2, ref watermelonBrokenList_2);
    }
    public GameObject GetSplash()
    {
        foreach (var item in splashList)
        {
            if (item.activeSelf == false)
                return item;
        }
        return InstantiateObj(splash, ref splashList);
    }
    public GameObject GetbombEffect()
    {
        foreach (var item in bombEffectList)
        {
            if (item.activeSelf == false)
                return item;
        }
        return InstantiateObj(effect_Bomb, ref bombEffectList);
    }
}
