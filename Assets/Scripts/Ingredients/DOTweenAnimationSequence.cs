using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOTweenAnimationSequence : MonoBehaviour
{
    public bool playOnAwake;
    public bool loops;

    private Sequence _sequence;

    private void Start()
    {
        var animations = GetComponentsInChildren<DOTweenAnimation>();
        if (animations.Length > 0)
        {
            _sequence = DOTween.Sequence();
            foreach (var animation in animations)
            {
                animation.CreateTween();
                animation.tween.SetAutoKill(false);
                _sequence.Append(animation.tween);
            }

            _sequence.SetAutoKill(false);
            _sequence.OnComplete(SequenceComplete);
            _sequence.OnRewind(SequenceComplete);

            if (playOnAwake)
            {
                PlaySequence();
            }
        }
        else
        {
            Debug.Log("This DOtween Sequence did not find any DOTweenAnimation components.", gameObject);
        }
    }

    private void SequenceComplete()
    {
        if (loops)
            PlaySequence();
    }

    private void PlaySequence()
    {
        if (_sequence.IsBackwards() || !_sequence.playedOnce)
            _sequence.Restart();
        else
            _sequence.PlayBackwards();
    }
}
