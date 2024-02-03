using System.Linq;
using Game.Gameplay.Player;
using Sample;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace
{
    public class Helper : MonoBehaviour
    {
        [SerializeField] private UpgradeCatalog _upgradeCatalog;
        [SerializeField] private MoneyStorage _moneyStorage;
        private UpgradesManager _upgradesManager;
        private PlayerStats _playerStats;

        private void Awake()
        {
            _upgradesManager = new UpgradesManager();
            _playerStats = new PlayerStats();
            
            _upgradesManager.Construct(_moneyStorage);
            _upgradesManager.Setup(_upgradeCatalog.GetAllUpgrades().Select(c => c.InstantiateUpgrade()).ToArray());
            
            foreach (var upgrade in _upgradesManager.GetAllUpgrades())
            {
                if(upgrade is IConstruct construct)
                    construct.Construct(_playerStats);
            }
        }

        [Button]
        public void UpTime()
        {
            var id = "WorkingTimeUpgrade";
            var upgrade = _upgradesManager.GetUpgrade(id);
            if (!_upgradesManager.CanLevelUp(upgrade))
            {
                Debug.Log($"Can not level up {upgrade.Id}");
                return;
            }

            _upgradesManager.LevelUp(upgrade);
            Debug.Log($"{id} Level = {upgrade.Level} value = {_playerStats.GetStat(id)}");
        }
        [Button]
        public void UpLoading()
        {
            var id = "VolumeLoadingAreaUpgrade";
            var upgrade = _upgradesManager.GetUpgrade(id);
            if (!_upgradesManager.CanLevelUp(upgrade))
            {
                Debug.Log($"Can not level up {upgrade.Id}");
                return;
            }

            _upgradesManager.LevelUp(upgrade);
            Debug.Log($"{id} Level = {upgrade.Level} value = {_playerStats.GetStat(id)}");
        }
        [Button]
        public void UpUnloading()
        {
            var id = "VolumeUnloadingAreaUpgrade";
            var upgrade = _upgradesManager.GetUpgrade(id);
            if (!_upgradesManager.CanLevelUp(upgrade))
            {
                Debug.Log($"Can not level up {upgrade.Id}");
                return;
            }

            _upgradesManager.LevelUp(upgrade);
            Debug.Log($"{id} Level = {upgrade.Level} value = {_playerStats.GetStat(id)}");
        }
    }
}