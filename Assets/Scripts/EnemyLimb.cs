using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLimb : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _dammageFactor;

    public void LimbDammage(int dammage)
    {
        _enemy.Dammage((int)(_dammageFactor * dammage));
    }
}
