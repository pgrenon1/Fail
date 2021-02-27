using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : GameMenuPanel
{
    public void GoToChapterSelect()
    {
        GameMenu.GoToChapterSelect();
    }

    public void GoToOptionsMenu()
    {
        GameMenu.GoToOptionsMenu();
    }

    public void QuitGame()
    {
        GameMenu.QuitGame();
    }
}
