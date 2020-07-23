using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResortPanelDownloader : MonoBehaviour
{
    [SerializeField] private Dropdown _listCountries;    
    [SerializeField] private ResortTypePanel _resortTypePanel;
    [SerializeField] private TransferPanel _transferPanel;
    [SerializeField] private HotelRatingPanel _hotelRatingPanel;
    [SerializeField] private List<Country> _countries;    

    private void Awake()
    {
        List<String> nameCountries = new List<String>();
        _countries = Resources.LoadAll<Country>("Countries").ToList();
        _countries.ForEach(countrie => nameCountries.Add(countrie.Name));        
        _listCountries.AddOptions(nameCountries);        
    }

    private void Start()
    {
        ChangeCountry();
    }
    
    public void ChangeCountry()
    {
        Country currentCountry = _countries[_listCountries.value];
        _hotelRatingPanel.SetCoustHotels(new List<int>() { currentCountry.CoustOneDayHotelfiveStars, currentCountry.CoustOneDayHotelfourStars, currentCountry.CoustOneDayHotelthreeStars, currentCountry.CoustOneDayHoteltwoStars, currentCountry.CoustOneDayHoteloneStar});
        _resortTypePanel.SetLevelType(currentCountry.LevelBeaches, currentCountry.LevelCulture, currentCountry.LevelActivities);
        _transferPanel.SetDataAirTransfer(currentCountry.TimeAir, currentCountry.CostAir);
        _transferPanel.SetDataRailwayTransfer(currentCountry.TimeRailway, currentCountry.CostRailway);
        _transferPanel.SetDataAutomobileTransfer(currentCountry.TimeAutomobile, currentCountry.CostAutomobile);
    }
}
