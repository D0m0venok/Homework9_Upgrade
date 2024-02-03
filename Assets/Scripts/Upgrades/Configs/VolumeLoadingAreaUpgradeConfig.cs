using UnityEngine;

namespace Sample
{
    [CreateAssetMenu(fileName = nameof(VolumeLoadingAreaUpgradeConfig), menuName = "Configs/VolumeLoadingAreaUpgradeConfig")]
    public sealed class VolumeLoadingAreaUpgradeConfig  : UpgradeConfig
    {
        [SerializeField]
        public UpgradeTable upgradeTable;
        
        public override Upgrade InstantiateUpgrade()
        {
            return new VolumeLoadingAreaUpgrade(this);
        }
        protected override void Validate()
        {
            base.Validate();
            upgradeTable.OnValidate(maxLevel);
        }
    }
}