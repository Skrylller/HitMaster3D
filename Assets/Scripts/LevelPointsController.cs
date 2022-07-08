using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPointsController : MonoBehaviour
{
    public static LevelPointsController main;

    [SerializeField] List<LevelPoint> _levelPoints = new List<LevelPoint>();

    private void Awake()
    {
        main = this;
    }

    /// <summary>
    /// Если передать null, то вернет первую точку в массиве. Если передать последнюю точку массива, то вернет null.
    /// </summary>
    /// <param name="point"></param>
    /// <returns></returns>
    public LevelPoint GetNextPoint(LevelPoint point)
    {
        if(point == null)
            return _levelPoints[0];

        for(int i = 0; i < _levelPoints.Count - 1; i++)
        {
            if (_levelPoints[i] == point)
                return _levelPoints[i + 1];
        }

        return null;
    }

}
