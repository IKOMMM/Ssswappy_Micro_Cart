using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text energyText;

    [SerializeField] private AndroidNotificationHandler androidNotificationHandler;

    [SerializeField] private int maxEnergy;
    [SerializeField] private int energyRechargeDuration;

    private int energy;
    private const string energyKey = "Energy";
    private const string energyReadyKey = "EnergyReady";

    private void Start()
    {
        int highScore = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);

        highScoreText.text = $"Your Record:\r\n{highScore}";

        energy = PlayerPrefs.GetInt(energyKey, maxEnergy);

        if (energy == 0)
        {
            string energyReadyString = PlayerPrefs.GetString(energyReadyKey, string.Empty);

            if(energyReadyKey == string.Empty){
                return;
            }

            DateTime energyReady = DateTime.Parse(energyReadyString);

            if (DateTime.Now > energyReady)
            {
                energy = maxEnergy;
                PlayerPrefs.SetInt(energyKey, energy);
            }
        }

        energyText.text = $"Play ({energy})";
    }           

    public void Play()
    {
        if (energy < 1)
        {
            return;
        }

        energy--;

        PlayerPrefs.SetInt(energyKey, energy);

        if (energy == 0)
        {
            DateTime energyReady = DateTime.Now.AddMinutes(energyRechargeDuration);
            PlayerPrefs.SetString(energyReadyKey, energyReady.ToString());
#if UNITY_ANDROID
            androidNotificationHandler.ScheduleNotification(energyReady);
#endif
        }        

        SceneManager.LoadScene(1);
    }
}
