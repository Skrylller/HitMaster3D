using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _health;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private List<Rigidbody> _bones = new List<Rigidbody>();
    [SerializeField] private Animator _animator;
    public bool isDeath { get; private set; }

    private void Start()
    {
        ResetEnemy();
    }

    public void Dammage(int dammage)
    {
        _health -= dammage;

        if(_health <= 0)
        {
            _healthBar.gameObject.SetActive(false);
            _health = 0;
            Death();
            return;
        }

        _healthBar.gameObject.SetActive(true);
        _healthBar.value = _health;
    }

    private void Death()
    {
        _animator.enabled = false;

        for (int i = 0; i < _bones.Count; i++)
        {
            _bones[i].isKinematic = false;
        }

        isDeath = true;
    }

    private void ResetEnemy()
    {
        _health = _maxHealth;
        _healthBar.gameObject.SetActive(false);

        _animator.enabled = true;

        for (int i = 0; i < _bones.Count; i++)
        {
            _bones[i].isKinematic = true;
        }

        isDeath = false;
    }
}
