using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;

namespace GenerateAddressableAddressesConstants.GetAddressableAddresses
{
    public class FindGroups
    {
        public IList<string> GetAddressableGroups()
        {
            return AddressableAssetSettingsDefaultObject.Settings.groups.Select(x => x.name).ToList();
        }

        public async Task Generate(IList<string> usedGroups)
        { 
            var groups = AddressableAssetSettingsDefaultObject.Settings.groups
                .Where(group => usedGroups.Contains(group.name))
                .ToDictionary(key => key.name, value => value.entries.ToArray());
            
            var creator = new FileConstructorService();

            foreach (var addressableAssetGroup in groups)
            {
                for (var i  = 0; i < addressableAssetGroup.Value.Length; i++)
                {
                    var address = addressableAssetGroup.Value[i].address;

                    Debug.Log(address);
                    if (address.Contains('/') || address.Contains('.'))
                    {
                        SimplifyAddressableName(addressableAssetGroup.Value, i, FormatAddress(address));
                    }
                }
                
                await creator.InstanceFile(new AddressableGroupData(addressableAssetGroup.Key,
                    addressableAssetGroup.Value.Select(x => x.address).ToArray()));
            }

            AssetDatabase.Refresh();
        }

        private string FormatAddress(string address)
        {
            var currentAddress = address.Split("/")[^1]; 
            return currentAddress.AsSpan(0, currentAddress.IndexOf('.')).ToString();
        }

        private void SimplifyAddressableName(AddressableAssetEntry[] actualEntries, int index, string newAddress)
        {
            Debug.Log(newAddress);
            actualEntries[index].address = newAddress;
        }
    }
}