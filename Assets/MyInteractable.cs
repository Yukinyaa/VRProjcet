using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Throwable))]
public class MyInteractable : MonoBehaviour
{
    Interactable a;
    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Interactable>();
        a.hideHandOnAttach = false;
        a.handFollowTransform = false;
        a.highlightOnHover = false;
    }

    // Update is called once per frame

    bool ragdolld = false;
    void Update()
    {
        if (a.attachedToHand != null)
        {
            Ragdollify();
        }
    }
    void Ragdollify()
    {
        if (!ragdolld)
        {
            ragdolld = true;
            Enemy e = GetComponent<Enemy>();
            if (e != null)
                e.enabled = false;
            View v = GetComponent<View>();
            if (v != null)
                v.enabled = false;
            NavMeshAgent n = GetComponent<NavMeshAgent>();
            if (n != null)
                n.enabled = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //todo: do collision effect
        var c = collision.gameObject.GetComponent<MyInteractable>();
        if (c != null) Ragdollify();
    }
}
