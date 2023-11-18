using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TanitakaTech.VisualStateSnap.SnapProperty;

namespace TanitakaTech.VisualStateSnap
{
    public class VisualStateSnapManager : MonoBehaviour
    {
        [SerializeReference, SubclassSelector] private ISnapTargetReference[] _snapTargetReferences;
        [SerializeField] private List<VisualStateSnap> _visualStateSnaps;
        private string _currentStateName;

        public IReadOnlyList<ISnapTargetReference> SnapTargetReferences => _snapTargetReferences;
        public IReadOnlyList<VisualStateSnap> VisualStateSnaps => _visualStateSnaps;
        public string CurrentStateSnaps => _currentStateName;

        public void ApplyState(string stateName)
        {
            var state = _visualStateSnaps.FirstOrDefault(s => s.Name == stateName);
            if (state != null)
            {
                _currentStateName = stateName;
            }
        }
    }
}