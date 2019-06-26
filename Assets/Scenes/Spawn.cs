using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject dynamicObjectPrefab;
    public GameObject staticObjectPrefab;
    public Transform originPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Object prefab = null;

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            prefab = dynamicObjectPrefab;
        }
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            prefab = staticObjectPrefab;
        }
        if (prefab != null)
        {
            var pos = originPos.forward + new Vector3(0, 0, 0.5f);
            Instantiate(prefab, pos, Quaternion.identity, transform);
        }
    }
}
