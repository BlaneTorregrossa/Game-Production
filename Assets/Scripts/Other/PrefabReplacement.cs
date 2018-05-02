using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PrefabReplacement : MonoBehaviour
{
    public GameObject BlueCrate;
    public GameObject RedCrate;
    public GameObject YellowCrate;
    public GameObject WoodenBox;
    public GameObject Bridge;
    public GameObject OilDrum;
    public List<GameObject> MapList;

    void Start()
    {
        ReplaceObjects();
    }

    public void ReplaceObjects()
    {
        for (int i = 0; i < MapList.Count; i++)
        {
            Quaternion prevRotation;
            Vector3 prevPosition;
            MeshRenderer prevMesh;
            string prevName;

            prevName = MapList[i].name;
            prevRotation = MapList[i].transform.rotation;
            prevPosition = MapList[i].transform.position;
            prevMesh = MapList[i].GetComponent<MeshRenderer>();
            if (prevMesh == null)
                prevMesh = MapList[i].GetComponentInChildren<MeshRenderer>();

            if (MapList[i].name[0] == 'C')  //  Crate
            {
                var CrateNum = Random.Range(0, 3);
                if (CrateNum == 0)
                    MapList[i] = BlueCrate;
                else if (CrateNum == 1)
                    MapList[i] = RedCrate;
                else if (CrateNum == 2)
                    MapList[i] = YellowCrate;

                MapList[i].transform.rotation = prevRotation;
                MapList[i].transform.position = prevPosition;
                MapList[i].transform.localScale = new Vector3(200f, 200f, 200f);
                //MapList[i].GetComponent<MeshRenderer>().sharedMaterials[0] = prevMesh.sharedMaterials[0];
            }
            else if (MapList[i].name[0] == 'B') //  Bridge
            {
                MapList[i] = Bridge;

                MapList[i].transform.rotation = prevRotation;
                MapList[i].transform.position = prevPosition;
                MapList[i].transform.localScale = new Vector3(0.75f, 0.75f, 0.80f);
            }
            else if (MapList[i].name[0] == 'O') //  Oil Drum
            {
                MapList[i] = OilDrum;

                MapList[i].transform.rotation = prevRotation;
                MapList[i].transform.position = prevPosition + new Vector3 (0, .55f, 0);
                MapList[i].transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (MapList[i].name[0] == 'W') //  Wooden Box
            {
                MapList[i] = WoodenBox;

                MapList[i].transform.rotation = prevRotation;
                MapList[i].transform.position = prevPosition;
                MapList[i].transform.localScale = new Vector3(1f, 1f, 1f);
            }

            Instantiate(MapList[i]);
        }
    }

}
