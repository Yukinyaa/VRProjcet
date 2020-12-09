using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Healthbar hp = null;
    [SerializeField] bool isHead = false;
    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Boom" :
                Destroy(other.gameObject);
                hp.TakeDamage(10);
                EffectManager.instance.DoOuche(this.transform.position);
            break;    
        }
        if(isHead == true)
        if (other.gameObject.GetComponent<Eatable>() == true)
        {
            GameObject.Destroy(other.gameObject);
            EffectManager.instance.DoNom(other.transform.position);
            hp.health += 20;
        }
    }
}
