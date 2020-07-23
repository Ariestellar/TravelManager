using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResortTypePanel : MonoBehaviour
{
    [SerializeField] private Image _levelBeaches;
    [SerializeField] private Image _levelCulture;
    [SerializeField] private Image _levelActivities;

    public void SetLevelType(int levelBeaches, int levelCulture, int levelActivities)
    {
        _levelBeaches.fillAmount = levelBeaches * 0.01f;
        _levelCulture.fillAmount = levelCulture * 0.01f;
        _levelActivities.fillAmount = levelActivities * 0.01f;
    }
}
