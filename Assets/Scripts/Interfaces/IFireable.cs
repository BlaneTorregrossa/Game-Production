using UnityEngine;
public interface IFireable
{    
    void Fire(Transform owner, Transform position, IDamager damager);
}
