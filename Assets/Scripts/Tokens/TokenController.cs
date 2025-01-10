using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BehaviourController), typeof(LifeController), typeof(InputHandler))]
public class TokenController : MonoBehaviour
{
    public BehaviourController PlayerBehaviourController;
    public LifeController LifeController;
    public InputHandler InputController;

    public List<TokenBase> tokens;

    private void Awake()
    {
        PlayerBehaviourController = GetComponent<BehaviourController>();
        LifeController = GetComponent<LifeController>();
        InputController = GetComponent<InputHandler>();
    }
}