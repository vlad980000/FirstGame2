using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _conainer;
    [SerializeField] private int _capacity;

    private Vector2 _spawnRange;
    private float _randomY;
    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        GameObject spawned = Instantiate(prefab, _conainer.transform);

        spawned.SetActive(false);

        _pool.Add(spawned);
    }

    protected bool TryGetGameobject(out GameObject result)
    {
        result = _pool.First(p => p.activeSelf == false);

        return result != null;
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }
}
