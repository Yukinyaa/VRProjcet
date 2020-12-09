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
        a.highlightOnHover = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame

    public bool ragdolld = false;
    void Update()
    {
        if (a.attachedToHand != null)
        {
            Ragdollify();
        }
        if (transform.position.y < 0)
        {
            EffectManager.instance.XPlosion(transform.position);
            Destroy(this.gameObject);
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
            nohand nj = GetComponent<nohand>();
            if (nj != null)
                nj.enabled = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //todo: do collision effect
        var c = collision.gameObject.GetComponent<MyInteractable>();
        if (c != null && c.ragdolld == true) Ragdollify();
        if (collision.gameObject.layer == LayerMask.NameToLayer("Sea"))
        {
            EffectManager.instance.XPlosion(transform.position);
            Destroy(this.gameObject);
        }
    }
}
