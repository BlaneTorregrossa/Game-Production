 
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private IDamager _shooter;
    private float Damage;
 
    private void OnTriggerEnter(Collider other)
    {
        if (_shooter == null)
        {
            return;
        }
        if (other.tag == "Character")
        {
            _shooter.DoDamage(other.GetComponent<CharacterBehaviour>().character);
            Destroy(gameObject);
        }
        if(other.tag == "Target")
        {
            _shooter.DoDamage(other.GetComponent<TargetBehaviour>().TargetConfig);
            Destroy(gameObject);
        }
    }

    public void SetDamage(IDamageable d, float a)
    {

    }
}
