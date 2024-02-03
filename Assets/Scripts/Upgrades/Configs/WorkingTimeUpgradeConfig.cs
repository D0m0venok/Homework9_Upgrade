using UnityEngine;

namespace Sample
{
    [CreateAssetMenu(fileName = nameof(WorkingTimeUpgradeConfig), menuName = "Configs/WorkingTimeUpgradeConfig")]
    public sealed class WorkingTimeUpgradeConfig : UpgradeConfig
    {
        [SerializeField]
        public UpgradeTable upgradeTable;
        
        public override Upgrade InstantiateUpgrade()
        {
            return new WorkingTimeUpgrade(this);
        }
        protected override void Validate()
        {
            base.Validate();
            upgradeTable.OnValidate(maxLevel);
        }
    }
}