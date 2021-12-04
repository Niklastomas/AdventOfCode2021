namespace day2;

public class Submarine
{
    public int HorizontalPosition { get; set; }
    public int Depth { get; set; }
    public int Aim { get; set; }

    public void Forward(int steps)
    {
        HorizontalPosition += steps;
        Depth += Aim * steps;
    }

    public void Down(int steps)
    {
        Aim += steps;
    }

    public void Up(int steps)
    {
        Aim -= steps;
    }

    public void CalculateResult()
    {
       var result = HorizontalPosition * Depth;
       Console.WriteLine(result);
    }

}