using Reparto;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public bool Refilled
    {
        get
        {
            return _refilled;
        }
        private set
        {
        }
    }

    [Header("UI Product")]
    [SerializeField] private Slider _sliderRetail;
    [SerializeField] private Image[] _uiSelectedProduct;
    [SerializeField] private int _carSelectedProduct;
    [SerializeField] private bool _refilled;
    

    private void Awake()
    {
        foreach (var item in _uiSelectedProduct)
        {
            item.enabled = false;
        }
    }
    internal void ActualProduct(int value)
    {
        _carSelectedProduct = value;
        Debug.Log("Product recibido" + _carSelectedProduct);
    }
    internal void Refill()
    {
        ActualProduct(_carSelectedProduct);
        _uiSelectedProduct[_carSelectedProduct].enabled = true;
        _sliderRetail.value += 1;

        if(_sliderRetail.value >= _sliderRetail.maxValue)
        {
            _refilled = true;
            FullyFilled(_refilled);

        }
    }
    internal void FullyFilled(bool _fullyfilled)
    {
        _refilled = _fullyfilled;
    }
}
