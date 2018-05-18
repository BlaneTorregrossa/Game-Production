using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBehaviour : MonoBehaviour, IBreakable
{
    public Crate CrateConfig;
    public GameObject BrokenObject;

    public void Break(GameObject Object)
    {
        var go = Instantiate(Object, gameObject.transform.position, gameObject.transform.rotation);
        go.tag = "Enviornment";
        var cd = go.GetComponent<Collider>();
        if(cd == false)
        {
            cd = go.AddComponent<Collider>();
        }
        Destroy(gameObject);
    }

    public void ResetDurability()
    {
        CrateConfig.Durability = CrateConfig.MaxDurability;
    }

    void Start()
    {
        ResetDurability();
    }

    // Update is called once per frame
    void Update ()
    {
		if(CrateConfig.Durability <= 0)
        {
            Break(BrokenObject);
        }
	}
}
