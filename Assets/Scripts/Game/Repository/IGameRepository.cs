using System.Collections.Generic;
using UnityEngine;

namespace Game.Repository
{
    public interface IGameRepository
    {
        GameObject FirstBall { get; set; }
        GameObject SecondBall { get; set; }
        List<int> Scores { get; set; }
        int ActivePlayerIndex { get; set; }
    }
}