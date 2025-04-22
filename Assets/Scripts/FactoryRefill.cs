using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

namespace Reparto.Fabrica
{


    public class FactoryRefill : MonoBehaviour
    {
        public int GetSelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            private set
            {
            }
        }
        
        #region Fields
        [Header("Product")]
        [SerializeField] private bool _refilled = false;
        [SerializeField] private int _selectedProduct;

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
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Car")
                GameController.Instance.ActiveFactory(this);
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Car" && !_refilled)
            {

                _parkingZone.material.color = Color.green;
                Refill(1);
            }
            if (_sliderRetail.value >= _sliderRetail.maxValue)
            {
                _refilled = true;
                _parkingZone.material.color = Color.yellow;
                _uiSelectedProduct.enabled = true;
                GameController.Instance.AsignProduct(_selectedProduct);

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
}
