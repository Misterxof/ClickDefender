using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerPublisher : MonoBehaviour, IPublisher
{
    private static PlayerPublisher _instance = null;

    private List<IPlayerObserver> _observers = new List<IPlayerObserver>();

    private PlayerPublisher() { }

    public static PlayerPublisher GetInstance()
    {
        return _instance;
    }

    public void AttachObserver(IPlayerObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IPlayerObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
    }

    public void OnHealthDamage(float health)
    {
        foreach (var observer in _observers)
        {
            observer.OnHealthDamage(health);
        }
    }

    public void OnXPChange(float experience, float maxExpierence)
    {
        foreach (var observer in _observers)
        {
            observer.OnXPChange(experience, maxExpierence);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
