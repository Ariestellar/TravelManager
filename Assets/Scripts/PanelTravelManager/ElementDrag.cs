using GameParameters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Временное решение в лоб, нужно использовать паттерн стратегию, сделать отдельные классы клона и оригинала элемента
public class ElementDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{    
    [SerializeField] private Transform _dragParentTransform;
    [SerializeField] private Transform _defaultParentTransform;
    [SerializeField] private Transform _readyTourParentTransform;
    [SerializeField] private DragElementData _dragElementData;    
    [SerializeField] private Text _time;
    [SerializeField] private Text _cost;

    private GameObject _cloneElement;
    private GameObject _placeholder;
    private bool _isClone;
    public bool IsClone => _isClone;
    public GameObject Placeholder => _placeholder;

    public void ChangeData(int cost, int time)
    {
        _dragElementData.SetData(cost, time);
        ChangeTextData(cost, time);
    }   

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Создаем клон элемента, привязываем к родителю - Canvas, указываем size и scale клону из оригинала, если это не клон
        //Можно реализовать через паттерн стратегию
        if (IsClone == true)
        {
            transform.SetParent(_dragParentTransform);
        }
        else
        {            
            _cloneElement = Instantiate(this.gameObject);
            _cloneElement.transform.SetParent(_dragParentTransform);
            _cloneElement.GetComponent<RectTransform>().sizeDelta = new Vector2(this.GetComponent<RectTransform>().rect.width, this.GetComponent<RectTransform>().rect.height);
            _cloneElement.transform.localScale = new Vector3(1, 1, 1);
            //помечаем клона, для дальнейщего использования
            _cloneElement.GetComponent<ElementDrag>().MarkClone();
        }        
    }

    public void OnDrag(PointerEventData eventData)
    {        
        if (_isClone == true)
        {            
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        }
        else
        {            
            _cloneElement.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        }        
    }

    public void OnEndDrag(PointerEventData eventData)
    {     
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.GetComponent<ReadyTour>())
        {
            Debug.Log("Установить предложение для клиента");
            //Назначение родителя 
            if (_isClone == true)
            {
                transform.SetParent(_readyTourParentTransform);
            }
            else
            {
                _cloneElement.transform.SetParent(_readyTourParentTransform);
            }                       
        }
        else
        {
            Debug.Log("Уничтожить элемент");

            if (_isClone == true)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(_cloneElement);
            }            
        }
    }

    public void MarkClone()
    {
        _isClone = true; 
    }

    private void ChangeTextData(int cost, int time)
    {
        string unitTime;
        //Меньше 3ех это все транспорт
        if ((int)_dragElementData.GetTypeService() < 3)
        {
            unitTime = " час.";
            //Только если время в дороге занимает больше суток делим и показываем количество суток
            if (time > 24)
            {
                time /= 24;
                unitTime = " cут.";
            }
                
        }
        else//в отелях все измеряется сутками
        {
            unitTime = " cут.";
        }

        _time.text = time + unitTime;
        _cost.text = cost + " $";
    }
}
