using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotelRatingPanel : MonoBehaviour
{
    [SerializeField] private Dropdown _selectedPayDays;
    [SerializeField] private ElementDrag _fiveStars;
    [SerializeField] private ElementDrag _fourStars;
    [SerializeField] private ElementDrag _threeStars;
    [SerializeField] private ElementDrag _twoStars;
    [SerializeField] private ElementDrag _oneStar;

    private List<ElementDrag> _dragElementDataHotels;
    private List<int> _coustOneDayHotels;
    private List<int> _countDay = new List<int>() {1, 3, 7, 14, 30};    

    private void Awake()
    {
        _dragElementDataHotels = new List<ElementDrag>() { _fiveStars, _fourStars, _threeStars, _twoStars, _oneStar };        
    }

    public void SetCoustHotels(List<int> coustOneDayHotels)
    {
        _coustOneDayHotels = coustOneDayHotels;
        ChangePayDays();
    }

    public void ChangePayDays()
    {
        for (int i = 0; i < _dragElementDataHotels.Count; i++)
        {
            _dragElementDataHotels[i].ChangeData(_coustOneDayHotels[i] * _countDay[_selectedPayDays.value], _countDay[_selectedPayDays.value]);            
        }       
    }
}
