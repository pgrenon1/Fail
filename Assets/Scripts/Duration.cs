using UnityEngine;

public class Duration
{
    public float timeDuration;

    public bool IsStarted { get; private set; } = false;
    public bool IsElapsed { get; private set; } = false;

    public float CurrentDuration { get; private set; }

    public delegate void OnDurationElapsed();
    public event OnDurationElapsed DurationElapsed;

    public Duration(float timeDuration)
    {
        this.timeDuration = timeDuration;
    }

    public void Start()
    {
        IsElapsed = false;
        IsStarted = true;
        CurrentDuration = timeDuration;
    }

    public void Update()
    {
        if (!IsStarted || IsElapsed)
            return;

        CurrentDuration -= Time.deltaTime;

        if (CurrentDuration <= 0f)
        {
            IsElapsed = true;
        }
    }
}