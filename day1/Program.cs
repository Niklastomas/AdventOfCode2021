using day1.extensions;

var measurements = File.ReadAllLines("data.txt").Select(m => Int32.Parse(m)).ToList();
GetIncreasedMeasurements(measurements);
GetIncreasedWindows(measurements);



void GetIncreasedMeasurements(List<int> measurements)
{
    var count = 0;
    var prevMeasurement = 0;
    foreach (var (measurement, index) in measurements.WithIndex())
    {
        if (index > 0)
        {
            if (measurement > prevMeasurement)
            {
                count++;
            }
            prevMeasurement = measurement;
        };
    };
    Console.WriteLine($"Increased measurements: {count}");
}

void GetIncreasedWindows(List<int> measurements)
{
    List<int> windows = new();
    foreach (var (item, index) in measurements.WithIndex())
    {
        if (index == measurements.Count - 2)
        {
            break;
        };
        windows.Add(item + measurements[index + 1] + measurements[index + 2]);
    }

    var count = 0;
    foreach (var (window, index) in windows.WithIndex())
    {
        if (index == windows.Count - 1)
        {
            break;
        };
        if (window < windows[index + 1])
        {
            count++;
        };
    }
    Console.WriteLine($"Increased windows: {count}");
}
