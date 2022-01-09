using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBehaviour
{
    protected Animation _animation;
    protected int _startCounter;
    protected SpriteRenderer _renderer;
    public const int FRAMERATE = 60;

    protected void BaseInit(Transform origin, Animation animation)
    {
        _animation = animation;
        _renderer = origin.GetComponent<SpriteRenderer>();
    }
}
