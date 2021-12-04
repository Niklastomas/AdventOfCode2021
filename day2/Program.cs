using day2;

Submarine submarine = new();

var commands = File.ReadAllLines("data.txt").ToList();
foreach (var command in commands)
{
    var instruction = command.Split(" ");
    string direction = instruction[0];
    int steps = Int32.Parse(instruction[1]);

    if (direction == "forward")
    {
        submarine.Forward(steps);
    }
    else if (direction == "down")
    {
        submarine.Down(steps);
    }
    else
    {
        submarine.Up(steps);
    }
}
submarine.CalculateResult();