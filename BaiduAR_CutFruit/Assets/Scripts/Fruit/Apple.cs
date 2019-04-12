using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Fruit
{
    public override GameObject SpawnBroken()
    {
        return ObjectPool.Instance.GetAppleBrokenObj();
    }

    public override GameObject SpawnSplash()
    {
        GameObject temp = ObjectPool.Instance.GetSplash();
        //temp.GetComponent<SpriteRenderer>().color
        return temp;
    }
}
