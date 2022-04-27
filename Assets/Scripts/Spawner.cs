using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] GameObject _prefab;
    [SerializeField] float _secondsBetweenSpawn;
    [SerializeField] Player _player;

    private Vector2 _spawnPoint;
    private float randomY;
    private int _spawnIndex = 5;
    private float _elapsedTime = 0;

    private void OnEnable()
    {
        _player.Gameover += OnPlayerDestroy;
    }

    private void OnDisable()
    {
        _player.Gameover -= OnPlayerDestroy;
    }

    private void Start()
    {
        for (int i = 0; i < _spawnIndex; i++)
        {
            Initialize(_prefab);
        }
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if( _elapsedTime >= _secondsBetweenSpawn)
        {
            if(TryGetGameobject(out GameObject prefab) == true)
            {
                randomY = Random.Range(-1.25f, 1.25f);
                _spawnPoint = new Vector2(gameObject.transform.position.x, randomY);
                _elapsedTime = 0;
                SetPrefab(prefab, _spawnPoint);
            }
        }
    }

    private void SetPrefab(GameObject prefab, Vector2 spawnPoint)
    {
        randomY = Random.Range(-1.25f,1.25f);
        spawnPoint = new Vector2(gameObject.transform.position.x, randomY);
        prefab.SetActive(true);
        prefab.transform.position = spawnPoint;
    }

    private void OnPlayerDestroy()
    {
        ResetPool();
    }
}
