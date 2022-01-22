using System.Text;
using PassingMazesAlgorithm.Core.MazeMap.Model;

namespace PassingMazesAlgorithm.ConsoleApp.UI.ConsoleCommandFormaters.Report
{
    public class ConsoleReportBuilder
    {
        private readonly StringBuilder _sb = new StringBuilder();

        public void AppendMessage(string title, string commands)
        {
            AppendSeparator();
            _sb.Append($"{title} : {commands}").Append(' ').AppendLine();
        }

        public void AppendSymbols(Maze map)
        {
            for (int r = 0; r < map.Height; r++)
            {
                for (int c = 0; c < map.Width; c++)
                {
                    _sb.Append(map[r, c].Symbol).Append(' ');
                }
                _sb.AppendLine();
            }
        }

        public void AppendMap(Maze map)
        {
            int maxNameLenght = -1;

            map.ProcessFunctionOverAllData((r, c) =>
            {
                string name = map[r, c].Name;

                if (name.Length > maxNameLenght)
                    maxNameLenght = name.Length;
            });

            int nameMessageLenght = maxNameLenght + 1;

            map.ProcessFunctionOverAllData((r, c) =>
            {
                string name = $"{ map[r, c].Name }";

                if (name.Length < nameMessageLenght)
                {
                    int count = nameMessageLenght - name.Length;
                    AppendSpace(count);
                }
                _sb.Append(name);
            },
            (r) =>
            {
                _sb.AppendLine();
            });

        }

        private void AppendSpace(int count)
        {
            for (int x = 0; x < count; x++)
            {
                _sb.Append(" ");
            }
        }

        public void AppendSeparator()
        {
            _sb.AppendLine();
            _sb.AppendLine("===== ===== =====");
            _sb.AppendLine();
        }

        public string Build() => _sb.ToString();
    }
}
