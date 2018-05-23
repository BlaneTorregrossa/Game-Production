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
    public IDamager damager;

    public abstract void Shoot(Transform ownerTransform, Transform positionTransform, IDamager damager, float projectileSpeed);

    public IEnumerator StartCountdown()
    {
        while (Cooldown >= 0)
        {
            Cooldown -= Time.deltaTime;
            yield return null;
        }
        Cooldown = _coolDownStart;
    }

    public void ResetCountdown()
    {
        Cooldown = _coolDownStart;
    }
}
