using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] private float _repeatInterval;

    [SerializeField] private int _limitPrefab= System.Int32.MaxValue;

    private int _count=0;
    public void Start() {
        if (_repeatInterval > 0) {
            InvokeRepeating("SpawnObject", 0.0f, _repeatInterval);
        }
    }
    public GameObject SpawnObject() {
        if (_prefabToSpawn != null && _count < _limitPrefab) {
            //print(_count);
            _count=_count+1;
            return Instantiate(_prefabToSpawn, transform.position, Quaternion.identity);
        }
        return null;
    }
}
