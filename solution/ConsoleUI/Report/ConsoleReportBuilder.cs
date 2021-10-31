﻿using PassingMazesAlgorithm.Core.GameMap.Model;
using System.Text;

namespace PassingMazesAlgorithm.Core.Report
{
    public class ConsoleReportBuilder
    {
        private readonly StringBuilder stringBuilder = new StringBuilder();

        public void AppendMessage(string title, string commands)
        {
            AppendSeparator();
            stringBuilder.Append($"{title} : {commands}").Append(' ').AppendLine();
        }

        public void AppendSymbols(Map map)
        {
            for (int r = 0; r < map.Height; r++)
            {
                for (int c = 0; c < map.Width; c++)
                {
                    stringBuilder.Append(map[r, c].Symbol).Append(' ');
                }
                stringBuilder.AppendLine();
            }
        }

        public void AppendMap(Map map)
        {
            var maxNameLenght = -1;

            map.ProcessFunctionOverData((r, c) =>
            {
                var name = map[r, c].Name;

                if (name.Length > maxNameLenght)
                    maxNameLenght = name.Length;
            });

            var nameMessageLenght = maxNameLenght + 1;

            for (int r = 0; r < map.Height; r++)
            {
                for (int c = 0; c < map.Width; c++)
                {
                    var name = $"{ map[r, c].Name }";

                    if (name.Length < nameMessageLenght)
                    {
                        var count = nameMessageLenght - name.Length;
                        AppendSpace(count);
                    }
                    stringBuilder.Append(name);
                }
                stringBuilder.AppendLine();
            }
        }

        private void AppendSpace(int count)
        {
            for (int x = 0; x < count; x++)
            {
                stringBuilder.Append(" ");
            }
        }

        public void AppendSeparator()
        {
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("===== ===== =====");
            stringBuilder.AppendLine();
        }

        public string Build() => stringBuilder.ToString();
    }
}
