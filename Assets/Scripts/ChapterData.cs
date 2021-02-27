using Sirenix.Serialization;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ChapterData : OdinSerializedScriptableObject
{
    public string title;
    public Sprite image;
    [NonSerialized, OdinSerialize]
    public List<ChapterStepData> chapterSteps = new List<ChapterStepData>();
}

[Serializable]
public class ChapterStepData
{
    public List<LevelData> levels = new List<LevelData>();
}
