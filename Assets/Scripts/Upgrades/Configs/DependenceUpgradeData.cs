using System;
using UnityEngine;

namespace Sample
{
    [Serializable]
    public sealed class DependenceUpgradeData
    {
        [SerializeField] private UpgradeConfig _config;
        [SerializeField] private int _levelDiff;

        public string Id => _config.id;
        public int LevelDiff => _levelDiff;
    }
}