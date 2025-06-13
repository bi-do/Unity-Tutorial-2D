using UnityEngine;

public class Study_Generic<T> : MonoBehaviour
{
    void Start()
    {
        Factory<Monster> factory = new Factory<Monster>();
    }

    public void CreateID()
    {
        
    }
}
