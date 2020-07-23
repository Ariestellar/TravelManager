using GameParameters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerRequestPanel : MonoBehaviour
{
    [SerializeField] private Text _travelBudgetText;
    [SerializeField] private Text _tourTypeText;
    [SerializeField] private Text _lengthVacationText;    
    [SerializeField] private List<CustomerRequestData> _currentCustomerReques;
    [Header("Колличество сгенерированных клиентов на уровне")]
    [SerializeField] private int _countRequest;

    private int _numberCurrentRequest;

    //Разделить логику генерации и переключения элементов в игре
    private void Start()
    {
        for (int i = 0; i < _countRequest; i++)
        {             
            CustomerRequestData currentReqestData = CustomerRequestData.Create(i, GetTravelBudget(), GetTourType(), GetLengthVacation());
            _currentCustomerReques.Add(currentReqestData);
        }

        _numberCurrentRequest = 0;
        ChangeTextPanel();
    }

    public void InviteNextClient()
    {
        ChangeTextPanel();
    }

    private void ChangeTextPanel()
    {
        if (_numberCurrentRequest < _currentCustomerReques.Count)
        {
            _travelBudgetText.text = "Бюджет: " + _currentCustomerReques[_numberCurrentRequest].GetTravelBudget() + " $";
            _tourTypeText.text = "Вид отдыха: " + _currentCustomerReques[_numberCurrentRequest].GetTourType();

            int[] lenghtVacantion = _currentCustomerReques[_numberCurrentRequest].GetLengthVacation();
            _lengthVacationText.text = "Длительность отдыха: " + lenghtVacantion[0] + " - " + lenghtVacantion[1] + "дн.";
            _numberCurrentRequest += 1;
        }
        else
        {
            _travelBudgetText.text = "Клиенты закончились";
            _tourTypeText.text = "";
            _lengthVacationText.text = "";
        }
    }

    private int GetTravelBudget()
    { 
        return Random.Range(500, 5000);//вынести "магические" числа в поля
    }

    private TourType GetTourType()
    { 
        return (TourType)Random.Range(0, 3);//вынести "магические" числа в поля
    }

    private int[] GetLengthVacation()
    {
        int lengthVacantionMin = Random.Range(2, 5);//вынести "магические" числа в поля
        int lengthVacantionMax = Random.Range(lengthVacantionMin + 2, lengthVacantionMin + 10);//вынести "магические" числа в поля
        return new int[2] { lengthVacantionMin, lengthVacantionMax };
    }
}
