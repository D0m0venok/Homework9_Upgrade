namespace Sample
{
    public sealed class WorkingTimeUpgrade : Upgrade, IConstruct
    {
        private const string Name = nameof(WorkingTimeUpgrade);
        
        private UpgradeTable _table;
        private PlayerStats _playerStats;

        public WorkingTimeUpgrade(WorkingTimeUpgradeConfig config) : base(config)
        {
            _table = config.upgradeTable;
        }

        public void Construct(PlayerStats playerStats)
        {
            _playerStats = playerStats;
            SetLevel(Level);
        }
        protected override void LevelUp(int level)
        {
            SetLevel(level);
        }
        private void SetLevel(int level)
        {
            var value = _table.GetValue(level);
            _playerStats.SetStat(Name, value);
        }
    }
}