using System.Collections.Generic;
using UnityEngine;

public class WishQueue : MonoBehaviour
{
    [SerializeField] private List<Desire> _wishList = new();

    private Queue<Desire> _wishQueue;

    private void Awake()
    {
        _wishQueue = new Queue<Desire>(_wishList);
    }

    public Desire GetNewWish()
    {
        if (_wishQueue.Count > 0)
        {
            return _wishQueue.Dequeue();
        }
        else
        {
            Debug.LogError("Программа не смогла получить новое желание для ГГ, так как очередь желаний пуста");
            return null;
        }
    }
}
