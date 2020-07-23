using GameParameters;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomerRequestData", menuName = "CustomerRequestData")]
public class CustomerRequestData : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private int _travelBudget;
    [SerializeField] private TourType _tourType;
    [SerializeField] private int[] _lengthVacation;    

    public void SetData(int id, int budget, TourType tourType, int[] lengthVacation)
    {
        _id = id;
        _travelBudget = budget;
        _tourType = tourType;
        _lengthVacation = lengthVacation;        
    }

    public static CustomerRequestData Create(int id, int budget, TourType tourType, int[] lengthVacation)
    {
        CustomerRequestData data = ScriptableObject.CreateInstance<CustomerRequestData>();
        AssetDatabase.CreateAsset(data, "Assets/Scripts/Resources/CustomerRequestData/" + id + ".asset");
        data.SetData(id, budget, tourType, lengthVacation);
        AssetDatabase.Refresh();
        return data;
    }

    public int GetTravelBudget()
    {
        return _travelBudget;
    }

    public TourType GetTourType()
    {
        return _tourType;
    }

    public int[] GetLengthVacation()
    {
        return _lengthVacation;
    }
}
