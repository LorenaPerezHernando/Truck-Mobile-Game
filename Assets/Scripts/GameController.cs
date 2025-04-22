
using UnityEngine;
using System;
using Reparto.Fabrica;
using Reparto.Tienda;


namespace Reparto
{
    public class GameController : Singleton<GameController>
    {
        #region Properties
        [Header("Car")]
        public ProductSelected ProductSelected => _productSelected;

        [Header("Products")]
        public FactoryRefill FactoryRefill => _factoryRefill;
        public ShopUnfill ShopUnfill => _shopUnfill;

        #endregion

        #region Fields
        [Header("Car")]
        [SerializeField] protected ProductSelected _productSelected;
        
        [Header("Products")]
        [SerializeField] protected FactoryRefill _factoryRefill;
        [SerializeField] protected ShopUnfill _shopUnfill;
        #endregion

        public void ActiveFactory(FactoryRefill activeFactory)
        {
            _factoryRefill = activeFactory;
            Debug.Log("Factory Activo" + activeFactory.name);
        }

        public void AsignProduct(int selectedProduct)
        {
            ProductSelected.ActualProduct(_factoryRefill.GetSelectedProduct); 
        }
    }

}
