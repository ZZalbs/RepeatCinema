using System.Collections.Generic;
using UnityEngine;

public class ThemeSwitchEnvironment : MonoBehaviour
{
    [SerializeField] private List<GameObject> grounds;
    [SerializeField] private List<GameObject> platforms;
    [SerializeField] private List<GameObject> backgrounds;

    private void Awake()
    {
        StageManager.Instance.ThemeSwitched += theme =>
        {
            for (int i = 0; i < grounds.Count; i++)
            {
                grounds[i].SetActive(i == (int)theme);
            }
            for (int i = 0; i < platforms.Count; i++)
            {
                platforms[i].SetActive(i == (int)theme);
            }
            for (int i = 0; i < backgrounds.Count; i++)
            {
                backgrounds[i].SetActive(i == (int)theme);
            }
        };
    }
}
