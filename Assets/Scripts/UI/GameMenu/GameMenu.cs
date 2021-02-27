using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameMenu : MonoBehaviour
{
    public bool debugStateMachine;
    public bool debugStateTransitions;

    public PushdownStateMachine StateMachine { get; private set; } = new PushdownStateMachine();

    public SplashScreenState SplashScreenState { get; private set; }
    public MainMenuState MainMenuState { get; private set; }
    public ChapterSelectState ChapterSelectState { get; private set; }
    public LevelSelectState LevelSelectState { get; private set; }
    public OptionsState OptionsState { get; private set; }

    public SplashScreen SplashScreen { get; private set; }
    public MainMenu MainMenu { get; private set; }
    public ChapterSelect ChapterSelect { get; private set; }
    public LevelSelect LevelSelect { get; private set; }
    public OptionsMenu OptionsMenu { get; private set; }

    public ChapterData SelectedChapter { get; set; }

    private void Awake()
    {
        SplashScreen = GetComponentInChildren<SplashScreen>(true);
        SplashScreen.GameMenu = this;
        SplashScreen.gameObject.SetActive(false);

        MainMenu = GetComponentInChildren<MainMenu>(true);
        MainMenu.GameMenu = this;
        MainMenu.gameObject.SetActive(false);

        ChapterSelect = GetComponentInChildren<ChapterSelect>(true);
        ChapterSelect.GameMenu = this;
        ChapterSelect.gameObject.SetActive(false);

        LevelSelect = GetComponentInChildren<LevelSelect>(true);
        LevelSelect.GameMenu = this;
        LevelSelect.gameObject.SetActive(false);

        OptionsMenu = GetComponentInChildren<OptionsMenu>(true);
        OptionsMenu.GameMenu = this;
        OptionsMenu.gameObject.SetActive(false);

        SplashScreenState = new SplashScreenState(SplashScreen, this, StateMachine);
        MainMenuState = new MainMenuState(MainMenu, this, StateMachine);
        ChapterSelectState = new ChapterSelectState(ChapterSelect, this, StateMachine);
        LevelSelectState = new LevelSelectState(LevelSelect, this, StateMachine);
        OptionsState = new OptionsState(OptionsMenu, this, StateMachine);

        InputManager.Instance.GameInputs.MenuActions.Back.performed += crx => GoBack();
    }

    private void OnEnable()
    {
        InputManager.Instance.GameInputs.MenuActions.Enable();
    }

    private void OnDisable()
    {
        InputManager.Instance.GameInputs.MenuActions.Disable();
    }

    private void Start()
    {
        StateMachine.ChangeState(SplashScreenState);
    }

    private void Update()
    {
        StateMachine.DebugTransition = debugStateTransitions;

        StateMachine.Update();
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }

    public void GoToChapterSelect()
    {
        StateMachine.ChangeState(ChapterSelectState);
    }

    public void GoToOptionsMenu()
    {
        StateMachine.ChangeState(OptionsState);
    }

    public void GoToMainMenu()
    {
        StateMachine.ChangeState(MainMenuState);
    }

    public void GoToLevelSelect(ChapterData chapterData)
    {
        SelectedChapter = chapterData;
        StateMachine.ChangeState(LevelSelectState);
    }

    public void GoBack()
    {
        StateMachine.ChangeStateBack();
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle(GUI.skin.box);
        style.alignment = TextAnchor.UpperLeft;

        var currentSelected = EventSystem.current.currentSelectedGameObject;
        if (currentSelected)
            GUI.Label(new Rect(0,0,200,25), currentSelected.name);

        GUIContent content = new GUIContent();
        //content.text = "GameMenu Debug\n";
        //content.text += "CurrentEventSystemSelected: \n\t" + EventSystem.current.currentSelectedGameObject;
        //GUI.Box(new Rect(0, 0, 250, 50), content, style);

        if (debugStateMachine)
        {
            content.text = "StateStack: \n";

            foreach (var state in StateMachine.StateStack)
            {
                content.text += "\t" + state + "\n";
            }
            GUI.Box(new Rect(0, 50, 250, 100), content, style);
        }
    }
}
