using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPoint : MonoBehaviour
{
    [SerializeField] private bool isStopPlayerAnyway;
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();

    /// <summary>
    /// проверка - мертвы ли все враги привязанные к точке
    /// </summary>
    /// <returns></returns>
    public bool CheckAllEnemies()
    {
        if (isStopPlayerAnyway)
            return false;

        foreach(Enemy enemy in _enemies)
        {
            if (enemy.isDeath == false)
                return false;
        }
        return true;
    }
}
