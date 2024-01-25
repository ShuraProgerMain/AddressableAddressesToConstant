using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GenerateAddressableAddressesConstants.GetAddressableAddresses
{
    public class FileConstructorService
    {
        private readonly string _directoryPath;

        public FileConstructorService()
        {
            _directoryPath = $"{Application.dataPath}\\Scripts\\AddressableExtensions";
        }
        
        public FileConstructorService(string directoryPath)
        {
            _directoryPath = directoryPath;
        }
        
        public async Task InstanceFile(AddressableGroupData data)
        {
            var groupName = data.GroupName.Replace(" ", string.Empty);

            Debug.Log($"Group name {groupName}");
            IList<string> allLines = new List<string>
            {
                "namespace AddressableExtensions" ,
                "\n{" ,
                $"\n   internal class {groupName}" ,
                "\n   {" ,
                "\n   }",
                "\n}",
            };
            
            foreach (var address in data.Addresses)
            {
                allLines.Insert(allLines.Count - 2, FormatAddress(address));
            }
            
            var fileBrokerService = new FileBrokerService(_directoryPath);
            
            var formatData = new UTF8Encoding(true).GetBytes(string.Join("", allLines));
            await fileBrokerService.CreateFile(_directoryPath, $"{groupName}.cs", formatData);
        }
        
        private string FormatAddress(string text)
        {
            return $"\n        public const string {text.Replace(" ", string.Empty)} = \"{text}\";";
        }
    }
}