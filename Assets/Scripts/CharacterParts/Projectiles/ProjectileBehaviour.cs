 
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
        if (other.CompareTag("Character Part"))
        {
            Debug.Log("touch");
            Destroy(other.gameObject);

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
   
    public void SetOwner(IDamager d)
    {
        _shooter = d;
    }
}
