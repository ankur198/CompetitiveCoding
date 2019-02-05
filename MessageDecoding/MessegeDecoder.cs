using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageDecoding
{
    internal class MessegeDecoder
    {
        private List<string[]> paths = new List<string[]>();

        internal int GetPossibleCombinations(int message)
        {
            MakeNewNode(null, message.ToString());
            return paths.Count();
        }

        private void MakeNewNode(List<string> path, string remMessage)
        {
            if (path == null)
            {
                path = new List<string>();
            }
            MakePath(remMessage, path);
        }

        private void MakePath(string RemMessage, List<string> Path)
        {
            if (RemMessage == "")
            {
                paths.Add(Path.ToArray());
                return;
            }
            Combine(Path.ToList(), RemMessage);

            Seperate(Path.ToList(), RemMessage);
        }

        private void Seperate(List<string> path, string remMessage)
        {
            var value = remMessage[0];
            if (value != '0')
            {
                path.Add(value.ToString());
                remMessage = remMessage.Substring(1);

                MakeNewNode(path, remMessage);
            }
        }

        private void Combine(List<string> Path, string RemMessage)
        {
            if (Path.Count == 0)
            {
                //first time only
                return;
            }
            if (Path.Last().Length == 2)
            {
                return;
            }

            var value = Path.Last() + RemMessage[0];

            if (int.Parse(value) < 27)
            {
                if (value.Length == 2 && value[0] != 0)
                {
                    Path[Path.Count - 1] = value;
                    RemMessage = RemMessage.Substring(1);

                    MakeNewNode(Path, RemMessage);
                }
            }
        }

    }
}
