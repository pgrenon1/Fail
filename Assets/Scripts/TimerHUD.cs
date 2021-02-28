using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerHUD : MonoBehaviour
{
    private TextMeshProUGUI _timer;

    private void Awake()
    {
        _timer = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _timer.enabled = LevelManager.Instance.CurrentLevel != null && LevelManager.Instance.CurrentLevel.IsStarted;

        var timeSpan = TimeSpan.FromSeconds(LevelManager.Instance.Timer);
        _timer.SetText(timeSpan.ToString("m\\:ss\\.fff"));
    }
}
