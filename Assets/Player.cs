using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Healthbar hp = null;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Boom" :
                Destroy(other.gameObject);
                hp.TakeDamage(10);
            break;    
        }    
    }
}
