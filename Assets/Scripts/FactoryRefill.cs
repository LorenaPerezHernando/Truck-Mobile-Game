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
        public int GetFactorySelectedProduct
        {
            get
            {
                return _factorySelectedProduct;
            }
            private set
            {
            }
        }
        
        #region Fields
        [Header("Product")]
        [SerializeField] private bool _refilled = false;
        [SerializeField] private int _factorySelectedProduct;

        

        [Header("Parking")]
        [SerializeField] Renderer _parkingZone;
        #endregion
        #region Methods
        private void Awake()
        {
            _parkingZone = GetComponentInChildren<Renderer>();

        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Car")
                GameController.Instance.ActiveFactory(this);
        }
        #region Parking
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Car" && !_refilled)
            {

                _parkingZone.material.color = Color.green;
                GameController.Instance.Refill();
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
        
        internal void FullyFilled()
        {
            _parkingZone.material.color = Color.yellow;
            GameController.Instance.AsignProduct(_factorySelectedProduct);
        }

        #endregion

    }
}
