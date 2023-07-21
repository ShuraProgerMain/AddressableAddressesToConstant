namespace GenerateAddressableAddressesConstants.GetAddressableAddresses
{
    public readonly struct AddressableGroupData
    {
        public readonly string GroupName;
        public readonly string[] Addresses;

        public AddressableGroupData(string groupName, string[] addresses)
        {
            GroupName = groupName;
            Addresses = addresses;
        }
    }
}