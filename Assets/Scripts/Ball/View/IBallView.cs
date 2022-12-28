using System;
using UnityEngine;

namespace Ball.View
{
    public interface IBallView
    {
        event Action<GameObject> OnFirstBallSelect;
        event Action<GameObject> OnSecondBallSelect;
    }
}