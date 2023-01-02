using IdleTycoon.Configs;
using IdleTycoon.Meta;
using TMPro;
using UnityEngine;
using Zenject;

namespace IdleTycoon.GasStation
{
    public class MoneyIncreaseText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        private readonly Vector3 targetPositionText = new Vector3(0, 4, 0);

        private GasStationConfig config;
        private IMetaValues metaValues;

        public bool Fuel { get; set; }

        [Inject]
        public void Init(GasStationConfig config, IMetaValues metaValues)
        {
            this.metaValues = metaValues;
            this.config = config;
        }

        private void Update()
        {
            if (Fuel)
            {
                ShowFuelText();
                text.text = "+" + FormatNums.FormatNum(config.Cost * metaValues.SoftMoneyCoefficient);
            }
            else
            {
                text.text = " ";
                text.transform.position = new Vector3(0, 3, 0);
            }
        }

        private void ShowFuelText()
        {
            if (text.transform.position == targetPositionText) Fuel = false;
            text.transform.position =
                Vector3.MoveTowards(text.transform.position, targetPositionText, 2 * Time.deltaTime);
        }
    }
}