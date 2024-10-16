﻿using CustomEnergyBar.Utils;
using UnityEngine;

namespace CustomEnergyBar
{
	public class EnergyBar
	{
		public EnergyBarDescriptor descriptor;
		public GameObject energyBarPrefab { get; private set; }
		public string loadedFrom;

		private AssetBundle _bundle;
		private GameObject _prefabPool;

		public EnergyBar(string bundlePath, GameObject prefabPool) {
			_prefabPool = prefabPool;
			if (!string.IsNullOrEmpty(bundlePath)) {
				_bundle = AssetBundle.LoadFromFile(bundlePath);
				ExtractBundle(_bundle);
			}
		}

		public EnergyBar(byte[] bundleData, GameObject prefabPool) {
			_prefabPool = prefabPool;
			if (bundleData.Length > 0) {
				_bundle = AssetBundle.LoadFromMemory(bundleData);
				ExtractBundle(_bundle);
			}
		}

		private void ExtractBundle(AssetBundle assetBundle) {
			if (assetBundle != null) {
				energyBarPrefab = assetBundle.LoadAsset<GameObject>("_CustomEnergyBar");
				descriptor = energyBarPrefab.GetComponent<EnergyBarDescriptor>();
				if (descriptor.icon == null)
					descriptor.icon = ResourceUtilities.LoadSpriteFromResource($"CustomEnergyBar.Resources.icon.png");
				energyBarPrefab.transform.SetParent(_prefabPool.transform);
				energyBarPrefab.gameObject.name = descriptor.name;
				assetBundle.Unload(false);
			} else {
				return;
			}
		}

		public void Destroy() {
			if (_bundle != null) {
				_bundle.Unload(true);
			} else {
				UnityEngine.Object.Destroy(descriptor);
			}
		}
	}
}
