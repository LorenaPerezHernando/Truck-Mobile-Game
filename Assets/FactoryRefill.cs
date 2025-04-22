using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FactoryRefill : MonoBehaviour
{
    #region Fields
    [Header("Product")]
    [SerializeField] private bool _refilled = false; 
    [SerializeField] private string[] _prefabProducts;

    [Header("UI")]
    [SerializeField] private Slider _sliderRetail;

    [Header("Parking")]
    [SerializeField] Renderer _parkingZone;
    #endregion

    private void Awake()
    {
        _parkingZone = GetComponentInChildren<Renderer>();
    }
    #region Parking
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Car" && !_refilled)
        {

            _parkingZone.material.color = Color.green; 
            Refill(1);           
        }
        if(_sliderRetail.value >= _sliderRetail.maxValue)
        {
            _refilled = true;
            _parkingZone.material.color = Color.yellow;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Car" && !_refilled)       
            _parkingZone.material.color = Color.red;
        
        else
            _parkingZone.material.color = Color.yellow;
    }

    #endregion Parking
    private void Refill(int refillPerSec)
    {
        _sliderRetail.value += refillPerSec;
        print("Refill");        
    }
}
