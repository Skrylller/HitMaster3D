using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _dammage;
    [SerializeField] private float _speed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyLimb>().LimbDammage(_dammage);
        }

        DeactiveBullet();
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0, 0, _speed * Time.fixedDeltaTime), Space.Self);
    }

    private void DeactiveBullet()
    {
        gameObject.SetActive(false);
    }
}
