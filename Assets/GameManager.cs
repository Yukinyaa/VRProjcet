using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
    
    public Text timeText;
    private float time;
 
    private void Update () {
        time += Time.deltaTime;
        timeText.text = time.ToString ();
    }
}