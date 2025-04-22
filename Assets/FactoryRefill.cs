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

    [Header("UI Product")]
    [SerializeField] private Slider _sliderRetail;
    [SerializeField] private Image _uiSelectedProduct;

    [Header("Parking")]
    [SerializeField] Renderer _parkingZone;
    #endregion

    private void Awake()
    {
        _parkingZone = GetComponentInChildren<Renderer>();
        _uiSelectedProduct.enabled = false; 
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
            _uiSelectedProduct.enabled = true;

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
