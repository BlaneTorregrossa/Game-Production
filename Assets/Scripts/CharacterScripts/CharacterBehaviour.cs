using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// =*=
public class CharacterBehaviour : MonoBehaviour
{
    public SetUpCharacterBehaviour setupInstance;
    public GameObject currentProjectileObject;
    public GameObject emptyAttackBox;
    public int Health;

    // Very Temporary
    private List<GameObject> attackObjectList = new List<GameObject>();

    void Start()
    {
        setupInstance.CurrentCharacter.Heatlh = 100;
    }

    void Update()
    {
        Health = setupInstance.CurrentCharacter.Heatlh;

        #region For Testing Attack Behaviors
        // for testing
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShootBasicProjectile(setupInstance.CurrentCharacter.Right);
        }

        // for testing
        if (Input.GetKeyDown(KeyCode.Q))
        {
            BasicMelee(setupInstance.CurrentCharacter.Left);
        }

        // for testing
        if (Input.GetKeyUp(KeyCode.E))
        {

        }

        // for testing 
        if (Input.GetKeyUp(KeyCode.Q))
        {
            if(attackObjectList.Count > 0)
            {
                for (int i = 0; i < attackObjectList.Count; i++)
                {
                    Destroy(attackObjectList[i]);
                }
            }
        }
        #endregion
    }

    public void ShootBasicProjectile(Part currentArm)
    {
        List<GameObject> ActiveProjectiles = new List<GameObject>();
        GameObject newProjectile = Instantiate(currentProjectileObject, currentArm.partPos + transform.forward, currentProjectileObject.transform.rotation);
        ProjectileBehavior pb = newProjectile.AddComponent<ProjectileBehavior>();
        pb.character = setupInstance;
        newProjectile.tag = "Bullet";
        ActiveProjectiles.Add(newProjectile);
    }
    
    //  Changes once animations are given
    //  Attack would stick with the animation
    public void BasicMelee(Part currentArm)
    {
        GameObject newAttackBox = Instantiate(emptyAttackBox, transform.position + transform.forward * 5, transform.rotation);
        BoxCollider newBoxCollider = newAttackBox.AddComponent<BoxCollider>();
        newBoxCollider.size = new Vector3(7.5f, 4f, 2f);
        newBoxCollider.isTrigger = true;
        newAttackBox.transform.parent = transform;
        newAttackBox.tag = "Melee";
        attackObjectList.Add(newAttackBox);
    }

    public void TakeDamage()
    {
        setupInstance.CurrentCharacter.Heatlh -= 10;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Debug.Log("A projectile hit!");
            TakeDamage();
        }

        if (other.tag == "Melee")
        {
            Debug.Log("A Melee Attack");
            TakeDamage();
        }
    }
}
