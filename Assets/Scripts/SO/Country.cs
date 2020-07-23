using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Country", menuName = "Country")]
public class Country : ScriptableObject
{
    [SerializeField] private String _name;
    [Header("Значение уровней типа тура")]
    [Range(0, 100)] [SerializeField] private int _levelBeaches;
    [Range(0, 100)] [SerializeField] private int _levelCulture;
    [Range(0, 100)] [SerializeField] private int _levelActivities;
    [Header("Стоимость трансфера в зависимости от вида транспорта")]
    [SerializeField] private int _costAir;
    [SerializeField] private int _costRailway;
    [SerializeField] private int _costAutomobile;
    [Header("Время в пути в зависимости от вида транспорта в часах")]
    [SerializeField] private int _timeAir;    
    [SerializeField] private int _timeRailway;    
    [SerializeField] private int _timeAutomobile;
    [Header("Стоимость одного дня в зависимости от уровня отеля")]
    [SerializeField] private int _coustOneDayHotelfiveStars;
    [SerializeField] private int _coustOneDayHotelfourStars;
    [SerializeField] private int _coustOneDayHotelthreeStars;
    [SerializeField] private int _coustOneDayHoteltwoStars;
    [SerializeField] private int _coustOneDayHoteloneStar;

    public String Name => _name;
    public int LevelBeaches => _levelBeaches;
    public int LevelCulture => _levelCulture;
    public int LevelActivities => _levelActivities;
    public int CostAir => _costAir;
    public int TimeAir => _timeAir;
    public int CostRailway => _costRailway;
    public int TimeRailway => _timeRailway;
    public int CostAutomobile => _costAutomobile;
    public int TimeAutomobile => _timeAutomobile;    
    public int CoustOneDayHotelfiveStars => _coustOneDayHotelfiveStars;
    public int CoustOneDayHotelfourStars => _coustOneDayHotelfourStars;
    public int CoustOneDayHotelthreeStars => _coustOneDayHotelthreeStars;
    public int CoustOneDayHoteltwoStars => _coustOneDayHoteltwoStars;
    public int CoustOneDayHoteloneStar => _coustOneDayHoteloneStar;
}
