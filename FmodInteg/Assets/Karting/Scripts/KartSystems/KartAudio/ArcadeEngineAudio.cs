using UnityEngine;

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
        FMODUnity.StudioEventEmitter emitter;

        void Awake()
        {
            arcadeKart = GetComponentInParent<ArcadeKart>();
            if (emitter != null) return;
            emitter = GetComponent<FMODUnity.StudioEventEmitter>();
            if (arcadeKart != null) return;
            arcadeKart = GetComponentInParent<ArcadeKart>();
        }

        void Update()
        {
            float kartSpeed = arcadeKart.LocalSpeed();
            // set RPM value for the FMOD event
            //float effectiveRPM = Mathf.Lerp(minRPM, maxRPM, kartSpeed);
            this.emitter.SetParameter("Acelerar", Mathf.Abs(kartSpeed)); 
        }
    }
}