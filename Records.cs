using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace TypingStudy
{
    [Serializable]
    class Records
    {
        private static Records LB; //LeaderBoard
        private string pathToLb = "leaderboard.txt";
        Dictionary<string, double> leaderboard = new Dictionary<string, double>();

        private Records()
        { }

        public static Records GetObject()
        {
            if (LB == null)
            {
                LB = new Records();
            }

            return LB;
        }

        public void AddRecord(UserArguments args)
        {
            if (args.Score != null)
            {
                if (leaderboard.ContainsKey(args.Username))
                {
                    var temp = leaderboard[args.Username];
                    if (args.Score.Value < temp)
                        leaderboard[args.Username] = args.Score.Value;
                    else
                        leaderboard[args.Username] = temp;
                }
                else
                    leaderboard.Add(args.Username, args.Score.Value);
            }
            else throw new ArgumentException("Error adding the score");
        }

        public void SaveLeaderboard()
        {
            using (var sw = new StreamWriter(pathToLb, false, Encoding.Default))
            {
                foreach (var i in leaderboard)
                {
                    sw.WriteLine($"{i.Key}*{i.Value}");
                }
            }
        }

        public void LoadLeaderboard()
        {
            leaderboard.Clear();
            File.AppendAllText(pathToLb, "");
            using (var sr = new StreamReader(pathToLb, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var record = sr.ReadLine().Split('*');
                    leaderboard.Add(record[0], double.Parse(record[1]));
                }
            }
        }
    }
}
