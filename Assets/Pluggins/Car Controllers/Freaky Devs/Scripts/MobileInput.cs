using UnityEngine;
using CarContollingScripts;
namespace MobileInputForCar
{


    public class MobileInput : MonoBehaviour
    {
        public CarController carController;

        public void OnBrakeButtonDown()
        {
            carController.BrakeInput(true);
        }

        public void OnBrakeButtonUp()
        {
            carController.BrakeInput(false);
        }

        // Add similar methods for MoveInput and SteerInput if needed
    }
}
