using UnityEngine;

internal class EffectManager : MonoBehaviour
{
    static public EffectManager instance;
    [SerializeField]
    GameObject nompf, xplosionpf;
    private void Start()
    {
        instance = this;
    }
    public void DoNom(Vector3 pos)
    {
        Instantiate(nompf, pos, Quaternion.identity);
    }
    public void XPlosion(Vector3 pos)
    {
        Instantiate(xplosionpf, pos, Quaternion.identity);
    }
}