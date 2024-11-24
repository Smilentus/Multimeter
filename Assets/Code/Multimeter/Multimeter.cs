using System;
using UnityEngine;

namespace Dimasyechka
{
    public class Multimeter : MonoBehaviour
    {
        public event Action DataCalculated = null;


        [Header("References")]
        [SerializeField]
        private MultimeterConnectedDevice _multimeterConnectedDevice;


        public float Resistance => _resistance;
        public float PowerWatt => _powerWatt;
        public float Amperage => _amperage;
        public float DirectCurrentVoltage => _directCurrentVoltage;
        public float AlternativeCurrentVoltage => _alternativeCurrentVoltage;


        private float _resistance; // R
        private float _powerWatt;  // P
        private float _amperage;   // I 
        private float _directCurrentVoltage;       // V=
        private float _alternativeCurrentVoltage;  // V~


        private void Update()
        {
            CalculateDataFromDevice();
        }

        private void CalculateDataFromDevice()
        {
            if (_multimeterConnectedDevice == null)
            {
                _resistance = 0;
                _powerWatt = 0;
                _amperage = 0;
                _directCurrentVoltage = 0;
                _alternativeCurrentVoltage = 0;
            }
            else
            {
                _resistance = _multimeterConnectedDevice.Resistance;
                _powerWatt = _multimeterConnectedDevice.PowerWatt;

                if (_powerWatt < 0)  { _powerWatt = 0;  }
                if (_resistance < 0) { _resistance = 0; }

                if (_resistance == 0)
                {
                    _amperage = 0;
                }
                else
                {
                    _amperage = Mathf.Sqrt(_powerWatt / _resistance);
                }

                _directCurrentVoltage = Mathf.Sqrt(_powerWatt * _resistance);
                _alternativeCurrentVoltage = 0.01f;
            }

            DataCalculated?.Invoke();
        }
    }
}
