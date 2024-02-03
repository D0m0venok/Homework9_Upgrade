using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Sample
{
    [Serializable]
    public sealed class UpgradeTable
    {
        public float Step => _step;

        [Space]
        [InfoBox("Speed: Linear Function")]
        [SerializeField]
        private float _startValue;

        [SerializeField]
        private float _endValue;

        [ReadOnly]
        [SerializeField]
        private float _step;

        [Space]
        [ListDrawerSettings(
            IsReadOnly = true,
            OnBeginListElementGUI = "DrawLabelForListElement"
        )]
        [SerializeField]
        private float[] _table;

        public float GetValue(int level)
        {
            var index = level - 1;
            return _table[index];
        }

        public void OnValidate(int maxLevel)
        {
            EvaluateTable(maxLevel);
        }

        private void EvaluateTable(int maxLevel)
        {
            _table = new float[maxLevel];
            _table[0] = _startValue;
            _table[maxLevel - 1] = _endValue;

            var step = (_endValue - _startValue) / (maxLevel - 1);
            _step = (float) Math.Round(step, 2);

            for (var i = 1; i < maxLevel - 1; i++)
            {
                var value = _startValue + _step * i;
                _table[i] = (float) Math.Round(value, 2);
            }
        }

#if UNITY_EDITOR
        private void DrawLabelForListElement(int index)
        {
            GUILayout.Space(8);
            GUILayout.Label($"Level {index + 1}");
        }
#endif
    }
}