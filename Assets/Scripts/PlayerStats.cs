using System.Collections.Generic;

namespace Sample
{
    public sealed class PlayerStats
    {
        private readonly Dictionary<string, float> stats = new();

        public void AddStat(string name, float value)
        {
            this.stats.Add(name, value);
        }
        
        public void SetStat(string name, float value)
        {
            this.stats[name] = value;
        }

        public float GetStat(string name)
        {
            return this.stats[name];
        }

        public IReadOnlyDictionary<string, float> GetStats()
        {
            return this.stats;
        }

        public void RemoveStat(string name)
        {
            this.stats.Remove(name);
        }
    }
}