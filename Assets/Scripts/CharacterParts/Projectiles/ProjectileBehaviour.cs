
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private IDamager _shooter;
    private CharacterBehaviour _owner;

    private void OnTriggerEnter(Collider other)
    {
        if (_shooter == null)
        {
            return;
        }

        if (other.CompareTag("Character Part"))
        {
            if (other.transform.GetComponentInParent<CharacterBehaviour>() != _owner)
            {
                Destroy(other.gameObject);
            }

        }
        if (other.tag == "Character")
        {
            if (other.transform.GetComponentInParent<CharacterBehaviour>() != _owner)
            {
                _shooter.DoDamage(other.GetComponent<CharacterBehaviour>().character);
                Destroy(gameObject);
            }
        }
        if (other.tag == "Target")
        {
            _shooter.DoDamage(other.GetComponent<TargetBehaviour>().TargetConfig);
            Destroy(gameObject);
        }

        if (other.tag == "Enviornment")
        {
            Destroy(gameObject);
        }

    }

    public void SetShooter(IDamager d)
    {
        _shooter = d;
    }

    public void SetOwner(CharacterBehaviour cb)
    {
        _owner = cb;
    }
}
