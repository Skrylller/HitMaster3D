using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPull : MonoBehaviour
{
    public static ObjectPull main;

    [System.Serializable]
    public class Pull
    {
        [SerializeField] private GameObject _objectPrefab;
        [SerializeField] private int _size;

        private Transform _parrent;

        private List<GameObject> _objects = new List<GameObject>();

        public void Inicializate(Transform parrent)
        {
            _objects.Clear();
            _parrent = parrent;

            for (int i = 0; i < _size; i++)
            {
                _objects.Add(Instantiate(_objectPrefab, _parrent));
                _objects[i].SetActive(false);
            }
        }

        /// <summary>
        /// если на найдет обьект в пуле, то создаст его
        /// </summary>
        /// <returns></returns>
        public GameObject FindFreeObject()
        {
            for (int i = 0; i < _size; i++)
            {
                if (_objects[i].activeSelf == false)
                    return _objects[i];
            }

            _objects.Add(Instantiate(_objectPrefab, _parrent));
            _size++;
            _objects[_size - 1].SetActive(false);

            return _objects[_size - 1];
        }

        /// <summary>
        /// находит свободный обьект в пуле и активирует его
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public GameObject ActivateObject(Vector3 position, Vector3 rotation)
        {
            GameObject obj = FindFreeObject();
            obj.transform.position = position;
            obj.transform.eulerAngles = rotation;
            obj.SetActive(true);
            return obj;
        }

        public void DeactivateAllObject()
        {
            for (int i = 0; i < _size; i++)
            {
                _objects[i].SetActive(false);
            }
        }
    }

    public Pull bullets;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        bullets.Inicializate(transform);
    }
}
