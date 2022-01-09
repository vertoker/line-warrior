using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimation
{
    /// <summary>
    /// Initializing animation
    /// </summary>
    /// <param name="counter"></param>
    public void InitAnimation(int counter);

    /// <summary>
    /// Update animation (framerate = 60)
    /// </summary>
    /// <param name="counter"></param>
    public void UpdateAnimation(int counter);
}
