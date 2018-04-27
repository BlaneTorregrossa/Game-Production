using System.Collections;
using UnityEngine;

public abstract class Projectile : ScriptableObject, IShootable
{
    protected float _coolDownStart = 3;
    public float Cooldown = 3;

    public GameObject prefab;
    public GameObject Prefab
    {
        get { return prefab; }
        set { prefab = value; }
    }

    public abstract void Shoot(Transform ownerTransform, float projectileSpeed);

    public IEnumerator StartCountdown()
    {
        while (Cooldown >= 0)
        {
            Cooldown -= Time.deltaTime;
            yield return null;
        }

        Cooldown = _coolDownStart;
    }
}
