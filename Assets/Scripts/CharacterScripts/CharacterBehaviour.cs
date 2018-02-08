using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{

    public SetUpArm setupInstance;
    public GameObject currentProjectileObject;
    public int Health;

    private List<BoxCollider> ListBC;


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
            BasicMelee();
        }

        // for testing
        if (Input.GetKeyUp(KeyCode.E))
        {

        }

        // for testing
        if (Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < ListBC.Count; i++)
            {
                Destroy(ListBC[i]);
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

    public void BasicMelee()
    {
        GameObject attackBox = new GameObject();
        BoxCollider bc = attackBox.AddComponent<BoxCollider>();
        attackBox.transform.parent = transform;
        bc.transform.position = attackBox.transform.position + (transform.forward * 3);
        bc.transform.localScale = new Vector3(4.5f, 3f, 1f);
        ListBC.Add(bc);
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
