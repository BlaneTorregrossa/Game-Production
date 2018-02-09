using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{

    public SetUpArm setupInstance;
    public GameObject currentProjectileObject;
    public GameObject emptyAttackBox;
    public int Health;

    // Very Temporary
    private List<GameObject> attackObjectList = new List<GameObject>();

    void Start()
    {
        setupInstance.currentCharacter.Heath = 100;
    }

    void Update()
    {
        Health = setupInstance.currentCharacter.Heath;

        #region For Testing Attack Behaviors
        // for testing
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShootBasicProjectile(setupInstance.currentCharacter.Right);
        }

        // for testing
        if (Input.GetKeyDown(KeyCode.Q))
        {
            BasicMelee(setupInstance.currentCharacter.Left);
        }

        // for testing
        if (Input.GetKeyUp(KeyCode.E))
        {

        }

        // for testing 
        if (Input.GetKeyDown(KeyCode.Q))
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

    public void ShootBasicProjectile(Arm currentArm)
    {
        List<GameObject> ActiveProjectiles = new List<GameObject>();
        GameObject newProjectile = Instantiate(currentProjectileObject, currentArm.armPos + transform.forward, currentProjectileObject.transform.rotation);
        ProjectileBehavior pb = newProjectile.AddComponent<ProjectileBehavior>();
        pb.character = setupInstance;
        newProjectile.tag = "Bullet";
        ActiveProjectiles.Add(newProjectile);
    }
    
    public void BasicMelee(Arm currentArm)
    {
        GameObject newAttackBox = Instantiate(emptyAttackBox, currentArm.armPos + transform.forward * 2, transform.rotation);
        BoxCollider newBoxCollider = newAttackBox.AddComponent<BoxCollider>();
        newBoxCollider.size = new Vector3(3.5f, 4f, 2f);
        newAttackBox.transform.parent = transform;
        newAttackBox.tag = "Melee";
        attackObjectList.Add(newAttackBox);
    }

    public void TakeDamage()
    {
        setupInstance.currentCharacter.Heath -= 10;
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
