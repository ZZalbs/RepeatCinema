using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private ResultUI result;

    public void Awake()
    {
        StageController sc = GetComponent<StageController>();
        TokenController tc = GetComponent<TokenController>();
        TokenProvider tp = GetComponent<TokenProvider>();

        result.Init(sc, tc, tp);
    }
}