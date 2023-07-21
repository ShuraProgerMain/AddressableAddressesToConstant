using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using GenerateAddressableAddressesConstants.GetAddressableAddresses;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace GenerateAddressableAddressesConstants.Editor.GenerateAddressableAddressesConstantsWindow
{
    public class AddressableAddressesToConstants : EditorWindow
    {
        [MenuItem("Tools/AddressableAddressesToConstants")]
        public static void ShowExample()
        {
            AddressableAddressesToConstants wnd = GetWindow<AddressableAddressesToConstants>();
            wnd.titleContent = new GUIContent("AddressableAddressesToConstants");
            wnd.minSize = new Vector2(350, 450);
            wnd.maxSize = new Vector2(350, 450);
        }

        private readonly FindGroups _findGroups = new();

        private IList<string> _groups;
        
        public void CreateGUI()
        {
            var root = rootVisualElement;
            _groups = _findGroups.GetAddressableGroups();

            var uxmlVisualElement = GetUxmlVisualElement();
            
            var contentContainer = uxmlVisualElement.Q<VisualElement>("unity-content-container");
            
            foreach (var group in _groups)
            {
                contentContainer.Add(CreateToggle($"{group}", HandleCallback));
            }
            

            var generateButton = uxmlVisualElement.Q<Button>("generate-scripts-button");
            
            generateButton.clicked += async () =>
            {
                await _findGroups.Generate(_groups);
            };
            
            root.Add(uxmlVisualElement);
        }

        private void HandleCallback(ChangeEvent<bool> evt, string args)
        {
            if (evt.newValue)
            {
                _groups.Add(args);
            }
            else
            {
                _groups.Remove(args);
            }
        }

        private VisualElement GetUxmlVisualElement()
        {
            var some = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Assets", "*.*", SearchOption.AllDirectories);

            var uxml = some.First(x => !x.Contains("meta") && x.Contains("AddressableAddressesToConstants.uxml")).Replace(Directory.GetCurrentDirectory() + "\\", "");
            var uss = some.First(x => !x.Contains("meta") && x.Contains("AddressableAddressesToConstants.uss")).Replace(Directory.GetCurrentDirectory() + "\\", "");

            var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(uxml);
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(uss);

            VisualElement labelFromUxml = visualTree.Instantiate();
            labelFromUxml.styleSheets.Add(styleSheet);

            return labelFromUxml;
        }

        private Toggle CreateToggle(string toggleLabel, EventCallback<ChangeEvent<bool>, string> handleCallback, bool toggleValue = true)
        {
            var toggle = new Toggle(toggleLabel)
            {
                value = toggleValue
            };

            toggle.RegisterCallback(handleCallback, toggleLabel);

            return toggle;
        }
    }
}