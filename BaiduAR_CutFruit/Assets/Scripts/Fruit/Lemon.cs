using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lemon : Fruit
{
    public override GameObject SpawnBroken()
    {
        return ObjectPool.Instance.GetLemonBrokenObj();
    }

    public override GameObject SpawnSplash()
    {
        GameObject temp = ObjectPool.Instance.GetSplash();
        temp.GetComponent<SpriteRenderer>().color = new Color32(255, 118, 0, 255);
        return temp;
    }
}
