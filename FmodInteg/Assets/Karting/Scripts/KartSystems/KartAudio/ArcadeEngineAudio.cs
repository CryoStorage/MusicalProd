using UnityEngine;
using UnityEngine.Serialization;

namespace KartGame.KartSystems
{
    /// <summary>
    /// This class produces audio for various states of the vehicle's movement.
    /// </summary>
    public class ArcadeEngineAudio : MonoBehaviour
    {
        public float minRPM = 0;
        public float maxRPM = 5000;
        ArcadeKart arcadeKart;
        [SerializeField]FMODUnity.StudioEventEmitter motorEmitter;
        [SerializeField] FMODUnity.StudioEventEmitter windEmitter;

        void Awake()
        {
            arcadeKart = GetComponentInParent<ArcadeKart>();
            if (motorEmitter != null) return;
            motorEmitter = GetComponent<FMODUnity.StudioEventEmitter>();
            if (arcadeKart != null) return;
            arcadeKart = GetComponentInParent<ArcadeKart>();
        }

        void Update()
        {
            float kartSpeed = arcadeKart.LocalSpeed();
            // set RPM value for the FMOD event
            //float effectiveRPM = Mathf.Lerp(minRPM, maxRPM, kartSpeed);
            motorEmitter.SetParameter("Acelerar", Mathf.Abs(kartSpeed)); 
            windEmitter.SetParameter("Speed", Mathf.Abs(kartSpeed) *.5f);
        }
    }
}