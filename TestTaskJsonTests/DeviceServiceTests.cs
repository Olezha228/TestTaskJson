using NSubstitute;
using NSubstitute.ReturnsExtensions;
using TestTaskJson.ResultPattern;

namespace TestTaskJsonTests;

[TestFixture]
public class DeviceServiceTests
{
    [Test]
    public void GroupBrigadeCodeWithConflictDevices_WhenDevicesInfoIsNull_ExceptionThrownExpected()
    {
        // Arrange
        IEnumerable<DeviceInfo> devicesInfo = null!;

        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => DeviceService.GroupBrigadeCodeWithConflictDevices(devicesInfo));
    }

    [Test]
    public void GroupBrigadeCodeWithConflictDevices_WhenDevicesInfoIsEmpty_EmptyConflictsExpected()
    {
        // Arrange
        var devicesInfo = Enumerable.Empty<DeviceInfo>();

        // Act
        var conflicts = DeviceService.GroupBrigadeCodeWithConflictDevices(devicesInfo);

        // Assert
        Assert.That(conflicts, Is.Empty);
    }

    [Test]
    public void GroupBrigadeCodeWithConflictDevices_WhenAllBrigadeCodesAreUnique_EmptyConflictsExpected()
    {
        // Arrange
        var devicesInfo = DeviceTestHelper.CreateDevicesInfoWithUniqueBrigadeCodes();

        // Act
        var conflicts = DeviceService.GroupBrigadeCodeWithConflictDevices(devicesInfo);

        // Assert
        Assert.That(conflicts, Is.Empty);
    }

    [Test]
    public void GroupBrigadeCodeWithConflictDevices_WhenDevicesInfoContainsBrigadeDevicesGroupsAndAllDevicesAreOffline_EmptyConflictsExpected()
    {
        // Arrange
        var devicesInfo = DeviceTestHelper.CreateBrigadeDevicesGroupsAndAllDevicesInGroupsOffline();

        // Act
        var conflicts = DeviceService.GroupBrigadeCodeWithConflictDevices(devicesInfo);

        // Assert
        Assert.That(conflicts, Is.Empty);
    }

    [Test]
    public void GroupBrigadeCodeWithConflictDevices_WhenDevicesInfoContainsBrigadeDevicesGroupsAndAnyDeviceIsOnline_TwoConflictsExpected()
    {
        // Arrange
        var devicesInfo = DeviceTestHelper.CreateBrigadeDevicesGroupsAndAnyDeviceInGroupsOnline();

        // Act
        var conflicts = DeviceService.GroupBrigadeCodeWithConflictDevices(devicesInfo).ToList();

        // Assert
        Assert.That(conflicts.Count, Is.EqualTo(2));
        Assert.That(conflicts[0].BrigadeCode, Is.EqualTo("10"));
        Assert.That(conflicts[1].BrigadeCode, Is.EqualTo("20"));
    }

    [Test]
    public void StoreConflictBrigadeDevicesGroups_WhenRepositoryIsNull_ExceptionExpected()
    {
        // Arrange
        IRepository repository = null!;

        // Act and Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => DeviceService.StoreConflictBrigadeDevicesGroups(repository));
    }

    [Test]
    public void StoreConflictBrigadeDevicesGroups_WhenRepositoryReturnsNullDevicesInfo_NoDevicesErrorExpected()
    {
        // Arrange
        var repository = Substitute.For<IRepository>();
        repository.GetDevicesInfo().ReturnsNull();

        // Act
        var result = DeviceService.StoreConflictBrigadeDevicesGroups(repository).Result.Error;

        // Assert
        Assert.That(result, Is.EqualTo(DeviceErrors.NoDevicesInfo));
    }

    [Test]
    public void StoreConflictBrigadeDevicesGroups_WhenRepositoryReturnsEmptyDevicesInfo_NoDevicesErrorExpected()
    {
        // Arrange
        var repository = Substitute.For<IRepository>();
        repository.GetDevicesInfo().Returns(Enumerable.Empty<DeviceInfo>());

        // Act
        var result = DeviceService.StoreConflictBrigadeDevicesGroups(repository).Result.Error;

        // Assert
        Assert.That(result, Is.EqualTo(DeviceErrors.NoDevicesInfo));
    }

    [Test]
    public void StoreConflictBrigadeDevicesGroups_WhenRepositoryReturnsValidDevicesInfo_ResultSuccessExpected()
    {
        // Arrange
        var repository = Substitute.For<IRepository>();
        repository.GetDevicesInfo().Returns(DeviceTestHelper.CreateBrigadeDevicesGroupsAndAnyDeviceInGroupsOnline());

        // Act
        var result = DeviceService.StoreConflictBrigadeDevicesGroups(repository).Result;

        // Assert
        repository.Received(1).InsertConflicts(Arg.Any<IEnumerable<Conflict>>());
        Assert.That(result.IsSuccess, Is.True);

    }
}
