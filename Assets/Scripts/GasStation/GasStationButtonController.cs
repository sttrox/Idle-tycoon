using IdleTycoon.Configs;
using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IdleTycoon.GasStation
{
    public class GasStationButtonController : MonoBehaviour
    {
        //TODO все переменные через сохранения а не через конфиги, в конфигах только начальные значения.
        [SerializeField] private TextMeshProUGUI levelText = null;
        [SerializeField] private TextMeshProUGUI fuelingTimeText = null;
        [SerializeField] private TextMeshProUGUI carsSpawnDelay = null;
        [SerializeField] private TextMeshProUGUI profitText = null;
        [SerializeField] private TextMeshProUGUI upgradeCost = null;
        [SerializeField] private TextMeshProUGUI costFueling = null;
        [SerializeField] private TextMeshProUGUI costSpawnDelay = null;
        [SerializeField] private GasStationConfig config;
        [SerializeField] public Image fuelingProgressBar;
        [SerializeField] public Image spawnProgressBar;

        private UpgradableGasStation upgradableGasStation;

        private void Awake()
        {
            upgradableGasStation = FindObjectOfType<UpgradableGasStation>();
        }

        private void Start()
        {
            RefreshGasStationInfo();
        }

        public void RefreshGasStationInfo()
        {
            levelText.text = "Уровень: " + config.Level;
            fuelingTimeText.text = "Время заправки: " + Math.Round(config.FuelingTime, 2).ToString(CultureInfo.InvariantCulture) + "c";
            carsSpawnDelay.text = "Машин в минуту: " + Math.Round(60f / config.SpawnDelay, 1).ToString(CultureInfo.InvariantCulture);
            profitText.text = FormatNums.FormatNum(config.Cost);
            upgradeCost.text = FormatNums.FormatNum(upgradableGasStation.CurrentCost);
            costFueling.text = FormatNums.FormatNum(config.CostFueling);
            costSpawnDelay.text = FormatNums.FormatNum(config.CostSpawnDelay);
        }
    }
}