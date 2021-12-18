namespace day4
{
    public class Board
    {
        public int Id { get; set; }
        public List<List<BoardCell>> Rows { get; set; }
        public int Result { get; set; }

        public Board(int id, List<List<BoardCell>> rows)
        {
            this.Id = id;
            this.Rows = rows;
        }

        public void DisplayBoard()
        {
            foreach (var row in this.Rows)
            {
                foreach (var item in row)
                {
                    var active = "";
                    if (item.Active)
                    {
                        active = "* ";
                    }
                    else
                    {
                        active = " ";
                    }
                    Console.Write(item.Value + active);
                }
                Console.WriteLine();
            }
        }

        public int GetSumOfUnmarkedNumbers()
        {
            var sum = 0;
            foreach (var row in Rows)
            {
                foreach (var cell in row)
                {
                    if (!cell.Active)
                    {
                        sum += cell.Value;
                    }
                }
            }
            return sum;
        }

        public int CheckIfBingo(int num)
        {
            var sum = 0;
            sum = CheckColumns(num);

            if (sum == 0)
            {
                sum = CheckRows(num);

            }
            return sum;
        }

        int CheckRows(int num)
        {
            foreach (var row in this.Rows)
            {
                var count = 0;
                foreach (var cell in row)
                {
                    if (cell.Value == num)
                    {
                        cell.Active = true;
                    }

                    if (cell.Active)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }

                    if (count == 5)
                    {
                        var sum = this.GetSumOfUnmarkedNumbers();
                        return sum * num;
                    }
                }
            }
            return 0;
        }

        int CheckColumns(int num)
        {
            for (int i = 0; i < this.Rows.Count; i++)
            {
                var count = 0;
                for (int j = 0; j < this.Rows[i].Count; j++)
                {
                    var cell = this.Rows[j][i];
                    if (cell.Value == num)
                    {
                        cell.Active = true;
                    }

                    if (cell.Active)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }

                    if (count == 5)
                    {
                        var sum = this.GetSumOfUnmarkedNumbers();
                        return sum * num;
                    }
                }
            }
            return 0;

        }
    }


    public class BoardCell
    {
        public int Value { get; set; }
        public bool Active { get; set; }

        public BoardCell(int value)
        {
            this.Value = value;
            this.Active = false;
        }
    }
}