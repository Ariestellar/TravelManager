using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransferPanel : MonoBehaviour
{
    [SerializeField] private ElementDrag _airTransport;
    [SerializeField] private ElementDrag _railwayTransport;
    [SerializeField] private ElementDrag _automobileTransport;
       
    public void SetDataAirTransfer(int time, int cost)
    {
        _airTransport.ChangeData(cost, time);        
    }

    public void SetDataRailwayTransfer(int time, int cost)
    {
        _railwayTransport.ChangeData(cost, time);        
    }

    public void SetDataAutomobileTransfer(int time, int cost)
    {
        _automobileTransport.ChangeData(cost, time);        
    }
}
