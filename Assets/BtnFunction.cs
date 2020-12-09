using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnFunction : MonoBehaviour
{
    public enum BtnType
    {
        None,
        LoadScene,
        LoadGameScene,
        DisableThis,
        EnableThis,
        QuitGame
    }
    public BtnType function;

    public int arg_int = 0;
    public string arg_str = "";
    public Transform arg_transform;

    public void OnClick()
    {
        switch (function)
        {
            case BtnType.LoadScene:
                UnityEngine.SceneManagement.SceneManager.LoadScene(arg_str);
                break;
            case BtnType.None:
                break;
            case BtnType.DisableThis:
                arg_transform.gameObject.SetActive(false);
                break;
            case BtnType.EnableThis:
                arg_transform.gameObject.SetActive(true);
                break;

            case BtnType.LoadGameScene:
                DoLoadScene();
                break;

            case BtnType.QuitGame:
                Application.Quit();
                break;
        }
    }

    void DoLoadScene()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            Destroy(o);
        }
        SceneManager.LoadScene(arg_str);
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
