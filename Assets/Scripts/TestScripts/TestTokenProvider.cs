using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTokenProvider : MonoBehaviour
{
    [SerializeField] private TokenController tokenController;
    [SerializeField] private StageController stageController;
    
    private void Start()
    {
        tokenController.SelectToken(new SpeedToken(tokenController, "", "", Rarity.Common, false, 1));
        stageController.StartStage();
    }
}
