using day4;

var numbersData = File.ReadAllText("data.txt").Split(",");
var numbers = numbersData.Select(n => Int32.Parse(n));


var boardsData = File.ReadAllLines("boards.txt");



// First solution
List<Board> boards = new();

var count = 0;
List<List<BoardCell>> rows = new();
for (int i = 0; i < boardsData.Length; i++)
{
    if (boardsData[i] == "")
    {
        count = 0;
        rows = new();
        continue;
    }

    var row = boardsData[i].Split(" ").ToList();
    List<BoardCell> cells = new();
    foreach (var cell in row)
    {
        if (cell == "") continue;

        var num = Int32.Parse(cell);
        cells.Add(new BoardCell(num));
    }
    rows.Add(cells);
    count++;

    if (count == 5)
    {
        boards.Add(new Board(i + 1, rows));
    }

}

List<Board> winningBoards = new();
foreach (var num in numbers)
{
    var result = 0;
    foreach (var board in boards)
    {
        if (board.Result > 0)
        {
            continue;
        }
        
        result = board.CheckIfBingo(num);
        board.Result = result;
        if (board.Result > 0)
        {
            winningBoards.Add(board);
        }
    }
}

var firstBoard = winningBoards.First();
var lastBoard = winningBoards.Last();

System.Console.WriteLine($"First: {firstBoard.Result}");
System.Console.WriteLine($"Last: {lastBoard.Result}");

