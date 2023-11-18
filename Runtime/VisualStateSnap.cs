using System;
using System.Collections.Generic;
using System.Linq;
using TanitakaTech.VisualStateSnap.SnapProperty;
using UnityEngine;

namespace TanitakaTech.VisualStateSnap
{
    [Serializable]
    public class VisualStateSnap
    {
        [SerializeField] private string _name;
        [SerializeReference] private ISnapProperty[] _properties;
        private SnapPropertyDictionary _snapPropertyDictionary;

        public string Name => _name;

        public VisualStateSnap(string name, IReadOnlyList<ISnapTargetReference> snapTargetReferences)
        {
            _name = name;
            _snapPropertyDictionary = new SnapPropertyDictionary();
            UpdateProperties(snapTargetReferences);
        }

        public void UpdateProperties(IReadOnlyList<ISnapTargetReference> snapTargetReferences)
        {
            _properties = snapTargetReferences
                .Select(snapTargetReference =>
                {
                    if (snapTargetReference == null)
                    {
                        return null;
                    }
                    var snapProperty = snapTargetReference.GetSnapProperty(_snapPropertyDictionary);
                    var alreadyExistProperty = _properties?.FirstOrDefault(property => property == snapProperty);
                    return alreadyExistProperty ?? snapProperty;
                })
                .ToArray();
        }
    }
}