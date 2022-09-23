using Core;
using UnityEngine;


public abstract class WayPoint : MonoBehaviour, IWayPoint
{
    public Vector3 Position => transform.position;

    protected GameCycle GameCycle;
    
    private void Awake()
    {
        GameCycle = FindObjectOfType<GameCycle>();
    }
    
    public abstract void ExecuteEvent();

    protected virtual void Init()
    {
        
    }
}
