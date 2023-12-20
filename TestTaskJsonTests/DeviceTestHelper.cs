namespace TestTaskJsonTests;

internal class DeviceTestHelper
{
    public static IEnumerable<DeviceInfo> CreateDevicesInfoWithUniqueBrigadeCodes()
    {
        return new List<DeviceInfo>
        {
            new()
            {
                Device = new Device { IsOnline = true, SerialNumber = "0"},
                Brigade = new Brigade { Code = "10"}
            },
            new()
            {
                Device = new Device { IsOnline = true, SerialNumber = "4"},
                Brigade = new Brigade { Code = "20"}
            },
            new()
            {
                Device = new Device { IsOnline = false, SerialNumber = "1"},
                Brigade = new Brigade { Code = "30"}
            },
            new()
            {
                Device = new Device { IsOnline = true, SerialNumber = "2"},
                Brigade = new Brigade { Code = "40"}
            }
        };
    }

    //DevicesInfoContainsBrigadeDevicesGroupsAndAllDevicesOffline
    public static IEnumerable<DeviceInfo> CreateBrigadeDevicesGroupsAndAllDevicesInGroupsOffline()
    {
        return new List<DeviceInfo>
        {
            new()
            {
                Device = new Device { IsOnline = false, SerialNumber = "0"},
                Brigade = new Brigade { Code = "10"}
            },
            new()
            {
                Device = new Device { IsOnline = false, SerialNumber = "0"},
                Brigade = new Brigade { Code = "10"}
            },
            new()
            {
                Device = new Device { IsOnline = false, SerialNumber = "1"},
                Brigade = new Brigade { Code = "20"}
            },
            new()
            {
                Device = new Device { IsOnline = false, SerialNumber = "2"},
                Brigade = new Brigade { Code = "20"}
            },
            new()
            {
                Device = new Device { IsOnline = true, SerialNumber = "23"},
                Brigade = new Brigade { Code = "30"}
            }
        };
    }

    //DevicesInfoContainsBrigadeDevicesGroupsAndAllDevicesOffline
    public static IEnumerable<DeviceInfo> CreateBrigadeDevicesGroupsAndAnyDeviceInGroupsOnline()
    {
        return new List<DeviceInfo>
        {
            new()
            {
                Device = new Device { IsOnline = true, SerialNumber = "0"},
                Brigade = new Brigade { Code = "10"}
            },
            new()
            {
                Device = new Device { IsOnline = false, SerialNumber = "0"},
                Brigade = new Brigade { Code = "10"}
            },
            new()
            {
                Device = new Device { IsOnline = false, SerialNumber = "1"},
                Brigade = new Brigade { Code = "20"}
            },
            new()
            {
                Device = new Device { IsOnline = true, SerialNumber = "2"},
                Brigade = new Brigade { Code = "20"}
            },
            new()
            {
                Device = new Device { IsOnline = true, SerialNumber = "23"},
                Brigade = new Brigade { Code = "30"}
            }
        };
    }
}
