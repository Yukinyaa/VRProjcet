using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool ui = false;
    [SerializeField]
    GameObject uwinPF, ulosePF;
    [SerializeField]
    GameObject uwinUI;
    public void Update()
    {
        int enemyCount = FindObjectsOfType<Enemy>().Length;
        enemyCount += FindObjectsOfType<Cannon>().Length;

        if ((enemyCount == 0) && (ui == false))
        {
            ui = true;
            StartCoroutine(UWin());
        }
        if ((FindObjectOfType<Healthbar>().health <= 0) && (ui == false))
        {
            ui = true;
            StartCoroutine(ULose());
        }
    }

    IEnumerator ULose()
    {
        ulosePF.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("StartScene");
    }
    IEnumerator UWin()
    {
        Instantiate(uwinPF, transform.position, Quaternion.identity);
        uwinUI.SetActive(true);
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            Destroy(o);
        }
        SceneManager.LoadScene("StartScene");
        
    }

}
