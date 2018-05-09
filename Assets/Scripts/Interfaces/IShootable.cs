using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootable
{
    GameObject Prefab { get;}
    void Shoot(Transform ownerTransform, float projectileSpeed);
}
