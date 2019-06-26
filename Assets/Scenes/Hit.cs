using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] OVRInput.Controller controller;
    [SerializeField] float vibDuration = 0.1f;
    [SerializeField] string colliderTag = "Movable";

    IEnumerator vib()
    {
        OVRInput.SetControllerVibration(1, 1, controller);
        yield return new WaitForSeconds(vibDuration);
        OVRInput.SetControllerVibration(0, 0, controller);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == colliderTag)
        {
            StartCoroutine(vib());
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
