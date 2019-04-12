using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watermelon : Fruit
{
    int index = 0;
    public override GameObject SpawnBroken()
    {
        if (index > 1)
        {
            index = 0;
        }
        if (index == 0)
        {
            return ObjectPool.Instance.GetWatermelonBrokenObj_1();
        }
        else
        {
            return ObjectPool.Instance.GetWatermelonBrokenObj_2();
        }
    }

    public override GameObject SpawnSplash()
    {
        GameObject temp = ObjectPool.Instance.GetSplash();
        temp.GetComponent<SpriteRenderer>().color = Color.red;
        return temp;
    }
}
