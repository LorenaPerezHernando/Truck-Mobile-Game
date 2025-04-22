
using UnityEngine;
using System;
using Reparto.Fabrica;
using Reparto.Shop;
using Reparto.Car;
using TMPro.EditorUtilities;


namespace Reparto
{
    public class GameController : Singleton<GameController>
    {
        #region Properties
        [Header("Car")]
        public ProductSelected ProductSelected => _car;

        [Header("Products")]
        public FactoryRefill FactoryRefill => _factory;
        public ShopUnfill ShopUnfill => _shop;
        [Header("UI")]
        public UIController UIController => _ui;

        #endregion

        #region Fields
        [Header("Car")]
        [SerializeField] protected ProductSelected _car;
        
        [Header("Products")]
        [SerializeField] protected FactoryRefill _factory;
        [SerializeField] protected ShopUnfill _shop;
        [Header("UI")]
        [SerializeField] protected UIController _ui;
        #endregion

        public void ActiveFactory(FactoryRefill activeFactory)
        {
            _factory = activeFactory;
            Debug.Log("Factory Activo" + activeFactory.name);
        }
        public void ActiveShop(ShopUnfill activeShop)
        {
            _shop = activeShop;
            Debug.Log("Tienda Activo" + activeShop.name);
        }

        public void AsignProduct(int selectedProduct)
        {
            ProductSelected.ActualProduct(_factory.GetFactorySelectedProduct);
            UIController.ActualProduct(_factory.GetFactorySelectedProduct);
        }

        public void Refill()
        {
            UIController.Refill();
            //_ui.Refill();
            
        }

        public void Filled(bool fullyfilled)
        {
            UIController.FullyFilled(fullyfilled);
            FactoryRefill.FullyFilled();
        }

        public void CheckShop()
        {
            if(ProductSelected.GetCarSelectedProduct == ShopUnfill.GetShopSelectedProduct)
            {

            }
            
        }
    }

}
