using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace TanitakaTech.VisualStateSnap
{
    [CustomEditor(typeof(VisualStateSnapManager))]
    public class VisualStateSnapManagerEditor : Editor
    {
        private SerializedProperty _visualStateSnapsProperty;
        private SerializedProperty _snapTargetReferencesProperty;
        private VisualStateSnapManager _snapManager;

        private void OnEnable()
        {
            _visualStateSnapsProperty = serializedObject.FindProperty("_visualStateSnaps");
            _snapTargetReferencesProperty = serializedObject.FindProperty("_snapTargetReferences");
            _snapManager = (VisualStateSnapManager)target;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_snapTargetReferencesProperty);
            ShowVisualStateSnaps(_visualStateSnapsProperty);

            // 状態の名前のドロップダウンリスト
            string[] stateNames = _snapManager.VisualStateSnaps.Select(s => s.Name).ToArray();
            int selectedIndex = Array.IndexOf(stateNames, _snapManager.CurrentStateSnaps);
            int newStateIndex = EditorGUILayout.Popup("Current State", selectedIndex, stateNames);

            if (newStateIndex != selectedIndex)
            {
                _snapManager.ApplyState(stateNames[newStateIndex]);
            }
            
            if (GUILayout.Button("Update Reference"))
            {
                // 新しい状態を追加する際の初期設定もここで行う
                foreach (var snapManagerVisualStateSnap in _snapManager.VisualStateSnaps)
                {
                    snapManagerVisualStateSnap.UpdateProperties(_snapManager.SnapTargetReferences);
                }
            }
            
            
            serializedObject.ApplyModifiedProperties();
        }
        
        private void ShowVisualStateSnaps(SerializedProperty list)
        {
            EditorGUILayout.PropertyField(list);
        }

        private static string GetNextAvailableName(string name, List<string> existingNames)
        {
            // "New State"に続く数字を探すための正規表現パターン
            string pattern = $@"^{name}(\d*)$";
            var regex = new Regex(pattern);

            // 現在の名前から数字を抽出し、利用可能な最小の数字を見つける
            var numbers = existingNames.Select(name =>
            {
                var match = regex.Match(name);
                return match.Success && match.Groups[1].Value != "" ? int.Parse(match.Groups[1].Value) : -1;
            }).Where(n => n != -1).OrderBy(n => n).ToList();

            int nextNumber = 0;
            foreach (int num in numbers)
            {
                if (num != nextNumber) break;
                nextNumber++;
            }

            return $"{name}{nextNumber}";
        }
    }
}
