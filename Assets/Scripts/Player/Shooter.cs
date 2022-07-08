using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _bulletStartPoint;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        CheckTouch();
    }

    private void CheckTouch()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hit);
            Shoot(hit.point);
        }
    }

    private void Shoot(Vector3 target)
    {
        _bulletStartPoint.LookAt(target);
        ObjectPull.main.bullets.ActivateObject(_bulletStartPoint.position, _bulletStartPoint.eulerAngles);
    }
}
