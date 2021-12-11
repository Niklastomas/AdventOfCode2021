using day3;

var binaries = File.ReadAllLines("data.txt").ToList();

// Step 1
var commonBits = new List<BitCount>();
foreach (var binary in binaries[0])
{
    commonBits.Add(new BitCount(0, 0));
}


for (int i = 0; i < binaries.Count; i++)
{
    for (int j = 0; j < binaries[i].Length; j++)
    {
        var bit = binaries[i][j];
        commonBits[j].AddCount(bit);
    }

}

var gammaRate = "";
var epsilonRate = "";
foreach (var item in commonBits)
{
    if (item.OneCount > item.ZeroCount)
    {
        gammaRate += "1";
        epsilonRate += "0";
    }
    else
    {
        gammaRate += "0";
        epsilonRate += "1";
    }
}
var gammaDecimal = Convert.ToInt32(gammaRate, 2);
var epsilonDecimal = Convert.ToInt32(epsilonRate, 2);

var powerConsumption = gammaDecimal * epsilonDecimal;
Console.WriteLine($"Power consumption: {powerConsumption}");

// Step 2
var oxygenBinaries = new List<string>(binaries);
for (int i = 0; i < commonBits.Count; i++)
{

    if (oxygenBinaries.Count == 1) break;

    var zeroBits = 0;
    var oneBits = 0;

    foreach (var item in oxygenBinaries)
    {
        if (item[i].Equals('1'))
        {
            oneBits++;
        }
        else
        {
            zeroBits++;
        }
    }

    if (zeroBits == oneBits)
    {
        oxygenBinaries = oxygenBinaries.Where(x => x[i].Equals('1')).ToList();
    }
    else if (oneBits > zeroBits)
    {
        oxygenBinaries = oxygenBinaries.Where(x => x[i].Equals('1')).ToList();
    }
    else
    {
        oxygenBinaries = oxygenBinaries.Where(x => x[i].Equals('0')).ToList();
    }
}

var co2ScrubberBinaries = new List<string>(binaries);
var copy = new List<string>();
for (int i = 0; i < commonBits.Count; i++)
{
    if (co2ScrubberBinaries.Count == 1) break;

    var zeroBits = 0;
    var oneBits = 0;

    foreach (var item in co2ScrubberBinaries)
    {
        if (item[i].Equals('1'))
        {
            oneBits++;
        }
        else
        {
            zeroBits++;
        }
    }

    if (oneBits == zeroBits)
    {
        co2ScrubberBinaries = co2ScrubberBinaries.Where(x => x[i].Equals('0')).ToList();
    }
    else if (oneBits < zeroBits)
    {
        co2ScrubberBinaries = co2ScrubberBinaries.Where(x => x[i].Equals('1')).ToList();
    }
    else
    {
        co2ScrubberBinaries = co2ScrubberBinaries.Where(x => x[i].Equals('0')).ToList();
    }
}

Console.WriteLine(oxygenBinaries.Count);
Console.WriteLine(co2ScrubberBinaries.Count);

var oxygenDecimal = Convert.ToInt32(oxygenBinaries[0], 2);
var co2ScrubberDecimal = Convert.ToInt32(co2ScrubberBinaries[0], 2);

Console.WriteLine(oxygenDecimal);
Console.WriteLine(co2ScrubberDecimal);

var lifeSupportRating = oxygenDecimal * co2ScrubberDecimal;

Console.WriteLine($"Life support rating: {lifeSupportRating}");