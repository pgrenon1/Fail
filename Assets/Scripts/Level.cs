using Cinemachine;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

public enum LevelType
{
    Collect,
    Reach,
    Sport
}

public class Level : OdinSerializedBehaviour
{
    public CinemachineVirtualCamera dollyVCam;
    public PlayerTracker playerTracker;

    public List<LevelEndConditionData> levelEndConditionDatas = new List<LevelEndConditionData>();

    public List<LevelEndConditionRuntime> LevelEndConditions { get; private set; } = new List<LevelEndConditionRuntime>();

    public bool HasEnded { get; private set; }
    public bool IsStarted { get; private set; }
    public LevelData LevelData { get; set; }
    public float Record { get; set; }

    private bool HasRecord = false;

    private void Start()
    {
        LevelManager.Instance.CurrentLevel = this;
        Init();
        LevelManager.Instance.StartLevel();
    }

    public void Init()
    {
        LevelData = LevelManager.Instance.GetLevelDataForScene(gameObject.scene);

        float record = 0f;
        if (PersistenceManager.Instance.GetLevelRecord(LevelData, ref record))
        {
            Record = record;
            HasRecord = true;
        }

        InitLevelEndTriggers();

        foreach (var levelEndConditionData in levelEndConditionDatas)
        {
            LevelEndConditions.Add(levelEndConditionData.CreateLevelEndCondition());
        }
    }

    private void InitLevelEndTriggers()
    {
        // Zones
        var levelEndTriggerSources = FindObjectsOfType<LevelEndTriggerZone>();
        foreach (var levelEndTriggerSource in levelEndTriggerSources)
        {
            var levelEndConditionDataTrigger = new LevelEndConditionData_Trigger(levelEndTriggerSource);
            levelEndConditionDatas.Add(levelEndConditionDataTrigger);
        }

        // Pickups
        var levelEndPickups = FindObjectsOfType<LevelEndPickup>();
        if (levelEndPickups.Length > 0)
        {
            var levelEndConditionDataPickupCount = new LevelEndConditionData_Pickup(levelEndPickups);
            levelEndConditionDatas.Add(levelEndConditionDataPickupCount);
        }
    }

    public void StartLevel()
    {
        IsStarted = true;

        foreach (var levelEndCondition in LevelEndConditions)
        {
            levelEndCondition.Start();
        }
    }

    private void Update()
    {
        UpdateLevelEndConditions();
    }

    private void UpdateLevelEndConditions()
    {
        if (HasEnded)
            return;

        foreach (var levelEndCondition in LevelEndConditions)
        {
            levelEndCondition.UpdateCondition();

            if (levelEndCondition.IsFulfilled)
            {
                EndLevel(levelEndCondition);
                break;
            }
        }
    }

    public void EndLevel(LevelEndConditionRuntime levelEndCondition)
    {
        IsStarted = false;
        HasEnded = true;
        LevelManager.Instance.EndLevel(levelEndCondition);
    }

    private void OnGUI()
    {
        var y = 10f;
        foreach (var levelEndCondition in LevelEndConditions)
        {
            levelEndCondition.OnGUI(y);
            y += 10f;
        }
    }
}

public abstract class LevelEndConditionData
{
    public abstract LevelEndConditionRuntime CreateLevelEndCondition();
}

public class LevelEndConditionData_Time : LevelEndConditionData
{
    [SuffixLabel("sec")]
    public float timeDuration = 60f;

    [ShowInInspector, ReadOnly]
    public float DurationInMins { get { return timeDuration / 60f; } }

    public override LevelEndConditionRuntime CreateLevelEndCondition()
    {
        return new LevelEndConditionRuntime_Time(this);
    }
}

public class LevelEndConditionData_Trigger : LevelEndConditionData
{
    public LevelEndTriggerZone LevelEndTriggerSource { get; private set; }

    public LevelEndConditionData_Trigger(LevelEndTriggerZone levelEndTriggerSource)
    {
        LevelEndTriggerSource = levelEndTriggerSource;
    }

    public override LevelEndConditionRuntime CreateLevelEndCondition()
    {
        return new LevelEndCondition_Trigger(this);
    }
}

public class LevelEndConditionData_Pickup : LevelEndConditionData
{
    public List<LevelEndPickup> LevelEndPickups { get; private set; }

    public LevelEndConditionData_Pickup(LevelEndPickup[] levelEndPickups)
    {
        LevelEndPickups = new List<LevelEndPickup>(levelEndPickups);
    }

    public override LevelEndConditionRuntime CreateLevelEndCondition()
    {
        return new LevelEndConditionRuntime_Pickup(this);
    }
}

[Serializable]
public abstract class LevelEndConditionRuntime
{
    public LevelEndConditionData LevelEndConditionData { get; private set; }

    public bool IsFulfilled { get; private set; } = false;

    public delegate void OnLevelEndConditionFulfilled(Collider other);
    public event OnLevelEndConditionFulfilled OnConditionFulfilled;

    protected LevelEndConditionRuntime(LevelEndConditionData levelEndConditionData)
    {
        LevelEndConditionData = levelEndConditionData;
    }

    public virtual void UpdateCondition() { }

    public virtual void Fulfill()
    {
        IsFulfilled = true;
    }

    public virtual void Start() { }

    public virtual void OnGUI(float y) { }
}

public class LevelEndConditionRuntime_Time : LevelEndConditionRuntime
{
    private Duration _duration;

    public LevelEndConditionRuntime_Time(LevelEndConditionData_Time levelEndConditionDataTime)
        : base(levelEndConditionDataTime)
    {
        _duration = new Duration(levelEndConditionDataTime.timeDuration);
    }

    public override void Start()
    {
        base.Start();

        _duration.Start();
    }

    public override void UpdateCondition()
    {
        if (IsFulfilled)
            return;

        _duration.Update();

        if (_duration.IsElapsed)
        {
            Fulfill();
        }
    }

    public override void OnGUI(float y)
    {
        base.OnGUI(y);

        TimeSpan time = TimeSpan.FromSeconds(_duration.CurrentDuration);
        GUI.Label(new Rect(10, y, 100f, 50f), time.ToString(@"hh\:mm\:ss\:fff"));
    }
}

public class LevelEndConditionRuntime_Pickup : LevelEndConditionRuntime
{
    public int TargetCount { get; private set; }
    public int CurrentCount { get; private set; }

    public LevelEndConditionRuntime_Pickup(LevelEndConditionData_Pickup levelEndConditionData_Pickup)
        : base(levelEndConditionData_Pickup)
    {
        TargetCount = levelEndConditionData_Pickup.LevelEndPickups.Count;
        //Debug.Log("TargetCount = " + TargetCount);
    }

    public void IncrementCount()
    {
        CurrentCount++;

        //Debug.Log("CurrentCount = " + CurrentCount + " / " + TargetCount);

        var levelEndConditionData_Count = LevelEndConditionData as LevelEndConditionData_Pickup;
        if (CurrentCount >= TargetCount)
        {
            Fulfill();
        }
    }
}

public class LevelEndCondition_Trigger : LevelEndConditionRuntime
{
    //public LevelEndConditionData_Trigger LevelEndConditionDataTrigger { get { return LevelEndConditionData as LevelEndConditionData_Trigger; } }

    public LevelEndCondition_Trigger(LevelEndConditionData_Trigger levelEndConditionDataTrigger)
        : base(levelEndConditionDataTrigger)
    {
        levelEndConditionDataTrigger.LevelEndTriggerSource.LevelEndCondition_Trigger = this;
    }
}
