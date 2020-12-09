using UnityEngine;

internal class EffectManager : MonoBehaviour
{
    static public EffectManager instance;
    [SerializeField]
    GameObject nompf, xplosionpf, ouchepf;
    private void Start()
    {
        instance = this;
    }
    public void DoNom(Vector3 pos)
    {
        Instantiate(nompf, pos, Quaternion.identity);
    }
    public void DoOuche(Vector3 pos)
    {
        Instantiate(nompf, pos, Quaternion.identity);
    }
    public void DoXPlosion(Vector3 pos)
    {
        Instantiate(xplosionpf, pos, Quaternion.identity);
    }
}