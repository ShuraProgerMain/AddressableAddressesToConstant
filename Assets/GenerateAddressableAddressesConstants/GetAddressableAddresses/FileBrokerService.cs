using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace GenerateAddressableAddressesConstants.GetAddressableAddresses
{
    public class FileBrokerService
    {
        public FileBrokerService(string mainDirectoryPath)
        {
            if (Directory.Exists(mainDirectoryPath))
            {
                Debug.Log("Good");
            }
            else
            {
                Directory.CreateDirectory(mainDirectoryPath);
            }
        }

        public bool Exists(string path, string fileName)
        {
            return File.Exists($"{path}\\{fileName}");
        }

        public async Task CreateFile(string path, string fileName, ReadOnlyMemory<byte> defaultData)
        {
            await using var fileStream = File.Create($"{path}\\{fileName}");
            await fileStream.WriteAsync(defaultData);
            await fileStream.DisposeAsync();
        }
    }
}