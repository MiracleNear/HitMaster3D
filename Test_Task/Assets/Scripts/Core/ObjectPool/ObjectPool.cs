using System.Collections.Generic;
using Core.ObjectPool;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour, IObjectPool<T> where T : MonoBehaviour
{
    [SerializeField] private int _baseCapacity = 16;
    [SerializeField] private int _additionCapacity = 16;
    [SerializeField] private T _template;

    private Stack<T> _pool;

    public T GetFreeElement()
    {
        if (_pool == null)
        {
            CreatePool(_baseCapacity);
        }
        else if (_pool.Count == 0)
        {
            CreatePool(_additionCapacity);
        }

        return Release(_pool.Pop(), true);
    }

    public void ReturnToPool(T template)
    {
        _pool.Push(Release(template, false));
    }
    
    private void CreatePool(int capacity)
    {
        _pool = new Stack<T>(capacity);

        Fill(capacity);
    }

    private void Fill(int capacity)
    {
        for (int i = 0; i < capacity; i++)
        {
            _pool.Push(CreateElement());
        }
    }

    private T CreateElement()
    {
        T template = Instantiate(_template);

        return Release(template, false);
    }

    private T Release(T template, bool isActive)
    {
        template.gameObject.SetActive(isActive);
        template.transform.parent = isActive ? null : transform;

        return template;
    }
}
