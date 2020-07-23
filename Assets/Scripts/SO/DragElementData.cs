using GameParameters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "DragElementData", menuName = "DragElementData")]
public class DragElementData : ScriptableObject
{
    [SerializeField] private TypeService _typeService;
    [SerializeField] private int _cost;
    [SerializeField] private int _time;

    public void SetData(int cost, int time)
    {        
        _cost = cost;
        _time = time;
    }

    public TypeService GetTypeService()
    {
        return _typeService;
    }

    public float GetCost()
    {
        return _cost;
    }

    public float GetTime()
    {
        return _time;
    }
}
