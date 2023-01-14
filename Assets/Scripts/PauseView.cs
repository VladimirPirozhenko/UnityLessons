using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseView : BaseView
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button mainMenuButton;

    public override void Init()
    {
        resumeButton.onClick.AddListener(() =>
        {
            Show(false);
            GameSession.Instance.PauseSession(false);

        });

        settingsButton.onClick.AddListener(() =>
        {
            Show(false);
        });

        //mainMenuButton.onClick.AddListener(() =>
        //{

        //});

        restartButton.onClick.AddListener(() =>
        {
            GameSession.Instance.RestartSession();
        });
        base.Init();
    }
}
