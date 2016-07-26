using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skbTextEditor {
    public class EditorEngine {
        //TODO: Iimplement method Seek And Return Range
        public Dictionary<string,int> WordsRepository { get; set; }
        public List<string> PrefixCollection { get; set; }

        public EditorEngine()
        {
            this.WordsRepository = new Dictionary<string, int>();
            this.PrefixCollection = new List<string>();
        }

        public void InitializeWordsAndPrefixCollection(string path)
        {
            int countWords;
            int positionCountPrefix;
            int countPrefix;
            var lines = File.ReadLines(path).ToList();
            
            if (!int.TryParse(lines[0], out countWords))
            {
                throw new ArithmeticException("Исходный файл имел неваерный формат для определения количества слов текста.");
            }

            positionCountPrefix = countWords + 2;
            if (!int.TryParse(lines[positionCountPrefix - 1], out countPrefix))
            {
                throw new ArithmeticException("Исходный файл имел неваерный формат для определения количества слов текста.");
            }

            for (int i = 1; i < positionCountPrefix - 1; i++)
            {
                var line = lines[i].Trim();
                var array = line.Split(' ');

                WordsRepository.Add(array[0], int.Parse(array[1]));
            }

            PrefixCollection.AddRange(lines.GetRange(positionCountPrefix, countPrefix));
            Console.WriteLine("Words Repo load is successed");
        }
    }
}
