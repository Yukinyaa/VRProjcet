using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nohand : MonoBehaviour
{
    Vector3 vec3;
    float radian;
    public bool check =true;
    // Start is called before the first frame update
    void Update()
    {
       if(gameObject.tag == "Enemy")
       {
            radian+=0.05f;
       }
       else if(gameObject.tag == "Sword")
       {
            radian+=0.035f;
       }
       else if(gameObject.tag == "Spear")
       {
            radian+=0.02f;
       }

       vec3 = transform.position;
       float dir1 = vec3.y + Mathf.Abs(Mathf.Cos(radian));
       vec3.y = dir1;
       transform.position = vec3;
       StartCoroutine(WaitForIt());
       transform.Rotate(new Vector3(0,10,0) * Time.deltaTime);
    }

    // Update is called once per frame
     IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(1000.0f);
        check=true;
    }
}
