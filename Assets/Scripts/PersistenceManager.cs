﻿using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using Sirenix.OdinInspector;

public class PersistenceManager : OdinSerializedSingletonBehaviour<PersistenceManager>
{
    private const string SAVEDATAPATH = "save.json";

    private SaveData _saveData;

    private string PathName { get { return Path.Combine(Application.persistentDataPath, SAVEDATAPATH); } }

    protected override void Awake()
    {
        base.Awake();

        LoadSaveData();

        UnlockDefaultLevels();
    }

    public bool LevelIsCompleted(LevelData levelData)
    {
        var levelGUID = levelData.ID;

        return _saveData.completedLevelsGUIDs.Contains(levelGUID);
    }

    public bool LevelIsUnlocked(LevelData levelData)
    {
        var levelGUID = levelData.ID;

        return _saveData.unlockedLevelsGUIDs.Contains(levelGUID);
    }

    public string GetSceneNameFromPath(string path)
    {
        var fileName = Path.GetFileName(path);
        var sceneName = fileName.Replace(".scene", "");

        return sceneName;
    }

    public int GetChapterProgress(ChapterData chapterData)
    {
        var numberOfCompleted = 0;

        foreach (var chapterStepData in chapterData.chapterSteps)
        {
            foreach (var level in chapterStepData.levels)
            {
                if (LevelIsCompleted(level))
                    numberOfCompleted++;
            }
        }

        return numberOfCompleted;
    }

    private void UnlockDefaultLevels()
    {
        foreach (var chapter in GameManager.Instance.chapters)
        {
            foreach (var chapterStep in chapter.chapterSteps)
            {
                foreach (var levelData in chapterStep.levels)
                {
                    if (levelData.isUnlockedByDefault)
                        UnlockLevel(levelData);
                }
            }
        }
    }

    private void UnlockLevel(LevelData leveldata)
    {
        bool isDirty = false;
        if (!_saveData.unlockedLevelsGUIDs.Contains(leveldata.ID))
        {
            _saveData.unlockedLevelsGUIDs.Add(leveldata.ID);

            isDirty = true;
        }

        if (isDirty)
            WriteSaveData();
    }

    #region IO Stuff
    private void LoadSaveData()
    {
        if (File.Exists(PathName))
        {
            var jsonString = File.ReadAllText(PathName);

            _saveData = DeserializeJson(jsonString);
        }
        else
        {
            _saveData = new SaveData();
        }
    }

    private void WriteSaveData()
    {
        var jsonString = JsonUtility.ToJson(_saveData);

        if (!File.Exists(PathName))
        {
            File.WriteAllText(PathName, jsonString);
        }
        else
        {
            File.WriteAllText(PathName, jsonString);
        }
    }

    public SaveData DeserializeJson(string jsonString)
    {
        return JsonUtility.FromJson<SaveData>(jsonString);
    }

    public string SerializeJson()
    {
        return JsonUtility.ToJson(this);
    }
    #endregion
}

public class SaveData
{
    public List<string> unlockedLevelsGUIDs = new List<string>();
    public List<string> completedLevelsGUIDs = new List<string>();
}