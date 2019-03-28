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
        Dictionary<string, double> leaderboard = new Dictionary<string, double>();
        private string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TypingStudy\\";

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
                    double temp = leaderboard[args.Username];
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

        public void LoadLeaderboard()
        {
            leaderboard.Clear();
            Directory.CreateDirectory(appData);
            appData += "\\leaderboard";
            File.AppendAllText(appData, "");
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(appData, FileMode.OpenOrCreate))
            {
                try
                {
                    var lb = formatter.Deserialize(fs) as Records;
                    this.leaderboard = lb.leaderboard;
                }
                catch (System.Runtime.Serialization.SerializationException)
                { }
            }
        }

        public void SaveLeaderboard()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(appData, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this);
            }
        }

        private void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        public string GetTop10()
        {
            string[] keys = new string[leaderboard.Keys.Count];
            leaderboard.Keys.CopyTo(keys, 0);
            double[] values = new double[leaderboard.Values.Count];
            leaderboard.Values.CopyTo(values, 0);
            try
            {
                for (int i = 0; i < values.Length; i++)
                {
                    for (int j = 0; j < values.Length - 1; j++)
                    {
                        if (values[j] > values[j + 1])
                        {
                            Swap(ref values[j], ref values[j + 1]);
                            Swap(ref keys[j], ref keys[j + 1]);
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                return "Ещё никто не играл!";
            }
            string leaders = string.Empty;
            int count = keys.Length;
            if (count > 10) count = 10;
            for (int i = 0; i < count; i++)
            {
                leaders += $"{i + 1}. {keys[i]} - {values[i]}\n";
            }
            return leaders;
        }
    }
}
