using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    private PlayerSettingDataSO playerSetting;

    [SerializeField] private Toggle tutorialSkip;

    private void Start()
    {
        playerSetting = Resources.Load<PlayerSettingDataSO>("PlayerSettingData");

        gameObject.SetActive(playerSetting.NeedTutorial);
    }

    public void ToggleTutorialSkip()
    {
        playerSetting.NeedTutorial = !tutorialSkip.isOn;
    }
}
