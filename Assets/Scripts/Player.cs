using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(NavMeshAgent), typeof(Shooter))]
public class Player : MonoBehaviour
{
    private enum State
    {
        start,
        idle,
        walk
    }

    [SerializeField] private float _stopDistance;
    [SerializeField] private Animator _animator;

    private Shooter _shooter;
    private NavMeshAgent _navMeshAgent;
    private LevelPoint _levelPoint;

    private State _state;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _shooter = GetComponent<Shooter>();
    }

    public void Start()
    {
        _state = State.start;
        _animator.SetBool("isIdle", true);
        _shooter.enabled = false;
        _navMeshAgent.enabled = false;
    }

    private void Update()
    {
        CheckState();
    }
    public void StartNextPoint()
    {
        _state = State.walk;
        _animator.SetBool("isIdle", false);
        _shooter.enabled = false;

        _levelPoint = LevelPointsController.main.GetNextPoint(_levelPoint);

        if (_levelPoint == null)
        {
            SceneManager.LoadScene(0);
            return;
        }

        _navMeshAgent.enabled = true;
        _navMeshAgent.SetDestination(_levelPoint.transform.position);

    }

    private void CheckState()
    {
        switch (_state)
        {
            case State.idle:
                Idle();
                break;

            case State.walk:
                Walk();
                break;
        }
    }

    private void Walk()
    {
        if(Vector3.Distance(_levelPoint.transform.position, transform.position) <= _stopDistance)
        {
            StopPlayer();
        }
    }

    private void Idle()
    {
        if (_levelPoint.CheckAllEnemies())
        {
            StartNextPoint();
        }
    }

    private void StopPlayer()
    {
        _state = State.idle;
        _animator.SetBool("isIdle", true);
        _navMeshAgent.enabled = false;
        _shooter.enabled = true;
    }
}
