using UnityEngine;
using UnityEngine.UI;

namespace Reparto.Shop
{
    public class ShopUnfill : MonoBehaviour
    {
        public int GetShopSelectedProduct
        {
            get
            {
                return _shopSelectedProduct;
            }
            private set
            {
            }
        }
        #region Fields
        [Header("Product")]
        [SerializeField] private bool _unfilled = false;
        [SerializeField] private int _howManyProducts;
        [SerializeField] private int _shopSelectedProduct;
        [Header("Parking")]
        [SerializeField] Renderer _parkingZone;
        [Header("UI Product")]
        [SerializeField] private Slider _sliderRetail;
        [SerializeField] private Image _uiSelectedProduct;
        #endregion

        #region Methods
        private void Awake()
        {
            _parkingZone = GetComponent<Renderer>();
            //_uiSelectedProduct.enabled = false;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Car")
                GameController.Instance.ActiveShop(this);
        }
        #region Parking
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Car" && !_unfilled)
            {
                GameController.Instance.CheckShop();
                _parkingZone.material.color = Color.green;
            }
            else
                _parkingZone.material.color = Color.yellow;
            
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Car" && !_unfilled)
                _parkingZone.material.color = Color.red;

            else
                _parkingZone.material.color = Color.yellow;
        }

        #endregion Parking
        #endregion
    }
}
