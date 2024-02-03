using UnityEngine;

namespace Sample
{
    [CreateAssetMenu(fileName = nameof(VolumeUnloadingAreaUpgradeConfig), menuName = "Configs/VolumeUnloadingAreaUpgradeConfig")]
    public sealed class VolumeUnloadingAreaUpgradeConfig : UpgradeConfig 
    {
        [SerializeField]
        public  UpgradeTable upgradeTable;
        
        public override Upgrade InstantiateUpgrade()
        {
            return new VolumeUnloadingAreaUpgrade(this);
        }
        protected override void Validate()
        {
            base.Validate();
            upgradeTable.OnValidate(maxLevel);
        }
    }
}