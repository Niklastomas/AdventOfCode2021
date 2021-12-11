namespace day3;

public class BitCount
{
    public int OneCount { get; set; }
    public int ZeroCount { get; set; }

    public BitCount(int oneCount, int zeroCount)
    {
        this.OneCount = oneCount;
        this.ZeroCount = zeroCount;
    }

    public void AddCount(char bit)
    {
        if (bit.Equals('0'))
        {
            ZeroCount++;
        }
        else
        {
            OneCount++;
        }
    }
}