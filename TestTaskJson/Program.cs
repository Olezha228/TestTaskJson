using TestTaskJson.Services;

var result = await DeviceService.StoreConflictBrigadeDevicesGroups(new FileRepository());

Console.WriteLine("Result: " + result.IsSuccess);