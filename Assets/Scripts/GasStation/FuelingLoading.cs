using IdleTycoon.Configs;
using UnityEngine;
using UnityEngine.UI;

namespace IdleTycoon.GasStation
{
    public class FuelingLoading : BaseLoadingCircle
    {
        [SerializeField] private Image loadingImage;
        [SerializeField] GasStationConfig config;
        [SerializeField] private Canvas canvas;

        private bool deactivateTimer;

        public bool IsActive { get; set; }

        private void Awake()
        {
            loadingImage.fillAmount = 0;
        }

        private void Update()
        {
            GetCircle(canvas, loadingImage, IsActive, config.FuelingTime);
        }
    }
}