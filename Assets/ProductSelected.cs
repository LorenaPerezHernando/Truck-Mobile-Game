using UnityEngine;

public class ProductSelected : MonoBehaviour
{
    [SerializeField] private int _productSelected;


    internal void ActualProduct(int value)
    {
        _productSelected = value;
        Debug.Log("Product recibido" + _productSelected);
    }
}
