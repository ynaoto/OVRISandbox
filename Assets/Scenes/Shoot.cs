using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] OVRInput.Controller controller;
    [SerializeField] OVRInput.Button button;
    [SerializeField] GameObject prefab;
    [SerializeField] Transform parent;
    [SerializeField] float startScale = 0.025f;
    [SerializeField] float growRatio = 0.25f;
    [SerializeField] float spawnDistrance = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator shoot()
    {
        var scale = startScale;
        var pos = transform.position + spawnDistrance*transform.forward;
        var obj = Instantiate(prefab, pos, Quaternion.identity, parent);

        while (!OVRInput.GetUp(button, controller))
        {
            obj.transform.localScale = scale*Vector3.one;
            scale += Time.deltaTime*scale*growRatio;
            yield return null;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(button, controller))
        {
            StartCoroutine(shoot());
        }       
    }
}
