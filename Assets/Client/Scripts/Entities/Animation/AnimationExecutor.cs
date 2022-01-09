using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class AnimationExecutor : MonoBehaviour
{
    private static List<IAnimation> _animations = new List<IAnimation>();
    private static UnityEvent<int> _animationUpdateEvent = new UnityEvent<int>();
    private static int _animationsCount = 0;
    private static int _globalCounter = 0;
    private static float _timer = 0f;
    private static bool _pause = true;

    private static event UnityAction<int> AnimationUpdate
    {
        add => _animationUpdateEvent.AddListener(value);
        remove => _animationUpdateEvent.RemoveListener(value);
    }
    private void OnEnable()
    {
        _pause = false;
    }
    private void OnDisable()
    {
        _pause = true;
    }

    public static void Add(IAnimation animation)
    {
        _animationsCount++;
        _animations.Add(animation);
        animation.InitAnimation(_globalCounter);
        AnimationUpdate += animation.UpdateAnimation;
    }
    public static void Remove(IAnimation animation)
    {
        AnimationUpdate -= animation.UpdateAnimation;
        _animations.Remove(animation);
        _animationsCount--;
    }
    public static void RemoveAll()
    {
        for (int i = 0; i < _animationsCount; i++)
        {
            AnimationUpdate -= _animations[i].UpdateAnimation;
        }
        _animations.RemoveRange(0, _animationsCount);
        _animationsCount = 0;
    }

    private void Update()
    {
        if (_pause)
            return;
        _timer += Time.deltaTime;
        int localCounter = (int)(_timer * AnimationBehaviour.FRAMERATE);
        if (localCounter > _globalCounter)
        {
            _globalCounter = localCounter;
            _animationUpdateEvent.Invoke(_globalCounter);
        }
    }
}
