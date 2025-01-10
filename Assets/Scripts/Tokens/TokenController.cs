using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BehaviourController), typeof(LifeController), typeof(InputHandler))]
public class TokenController : MonoBehaviour
{
    public BehaviourController PlayerBehaviourController;
    public LifeController LifeController;
    public InputHandler InputController;
    public List<TokenBase> PositiveTokens;
    public List<TokenBase> NegativeTokens;

    private void Awake()
    {
        PlayerBehaviourController = GetComponent<BehaviourController>();
        LifeController = GetComponent<LifeController>();
        InputController = GetComponent<InputHandler>();
    }


    public void DestroyOnePositiveToken(int index)
    {
        PositiveTokens.RemoveAt(index);
    }
    public void DestroyOneNegativeToken(int index)
    {
        NegativeTokens.RemoveAt(index);
    }

    public void DestroyAllPositiveToken()
    {
        PositiveTokens.Clear();
    }

    public void DestroyAllNegativeToken()
    {
        NegativeTokens.Clear();
    }
}