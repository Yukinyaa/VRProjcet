using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMeAfterSeconds : MonoBehaviour
{
    [SerializeField]
    float seconds;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
