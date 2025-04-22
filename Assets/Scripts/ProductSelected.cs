using UnityEngine;

namespace Reparto.Car
{


    public class ProductSelected : MonoBehaviour
    {
        public int GetCarSelectedProduct
        {
            get
            {
                return _productInCar;
            }
            private set
            {
            }
        }

        [SerializeField] private int _productInCar;


        internal void ActualProduct(int value)
        {
            _productInCar = value;
            Debug.Log("Product recibido" + _productInCar);
        }
    }
}
