﻿using UnityEngine;
using TMPro;

namespace CustomEnergyBar
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	[AddComponentMenu("Custom Energy Bars/Energy Text")]
	public class EnergyText : MonoBehaviour
	{
		public enum DisplayTypes { 
			Decimal,
			Percent,
			PercentNoSymbol,
			Battery
		}

		public DisplayTypes displayType;
		public string formattedString = "Energy: {0}";
		public int batteryLives = 4;

		private TextMeshProUGUI _tmpro;

		public void UpdateEnergyText(float energy) {
			if (_tmpro == null)
				if (!TryGetComponent<TextMeshProUGUI>(out _tmpro)) return;

			string energyString = energy.ToString();
			switch (displayType) {
				case DisplayTypes.Decimal:
					energyString = ((Mathf.Round(energy * 100)) / 100.0f).ToString();
					break;
				case DisplayTypes.Percent:
					energyString = Mathf.Round(energy * 100).ToString() + "%";
					break;
				case DisplayTypes.PercentNoSymbol:
					energyString = Mathf.Round(energy * 100).ToString();
					break;
				case DisplayTypes.Battery:
					energyString = Mathf.Round(energy * batteryLives).ToString();
					break;
			}
			_tmpro.text = string.Format(formattedString, energyString);
		}
	}
}
