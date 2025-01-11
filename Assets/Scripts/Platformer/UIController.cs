using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]private TokenController tc;
    [SerializeField]private HUD Hud;

    private void Awake()
    {
        tc = GetComponent<TokenController>();
        StageStart();
        StageController stageController = GetComponent<StageController>();
        stageController.AddStageEventListener(StageEventType.Start, StageStart);
        
    }

    public void StageStart()
    {
        Hud.Init(tc);
    }
}
