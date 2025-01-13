using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    private PlayerSettingDataSO playerSetting;

    [SerializeField] private Toggle tutorialSkip;

    private void Awake()
    {
        playerSetting = Resources.Load<PlayerSettingDataSO>("PlayerSettingData");

        gameObject.SetActive(playerSetting.NeedTutorial);
    }

    public void ToggleTutorialSkip()
    {
        playerSetting.NeedTutorial = !tutorialSkip.isOn;
    }

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
