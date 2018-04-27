 
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private IDamager _shooter;
 
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
    }
    
}
