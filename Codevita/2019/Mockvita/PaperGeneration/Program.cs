using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaperGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


    }

    public class builder
    {
        public List<Question> OriginalList { get; set; }
        char currentChar = 'A';

        void fakeInput()
        {
            for (int i = 0; i < 3; i++)
            {
                insertQuestion(Complexity.simple);
            }
            Question.MaxComplexity[0] = 2;
            for (int i = 0; i < 4; i++)
            {
                insertQuestion(Complexity.medium);
            }
            Question.MaxComplexity[1] = 3;
            for (int i = 0; i < 3; i++)
            {
                insertQuestion(Complexity.complex);
            }
            Question.MaxComplexity[2] = 2;

            var allergic = "A D".Split(' ');
            OriginalList.First(x => x.Name.ToString() == allergic[1]).AllergyQues = Convert.ToChar(allergic[0]);
            OriginalList.First(x => x.Name.ToString() == allergic[0]).AllergyQues = Convert.ToChar(allergic[1]);
            var onlyOnce = "G";
            OriginalList.First(x => x.Name.ToString() == onlyOnce).CanBeUsedOnce = true;
        }

        void insertQuestion(Complexity complexity)
        {
            OriginalList.Add(new Question() { Name = currentChar, Complexity = complexity });
            currentChar = Convert.ToChar(Convert.ToInt32(currentChar) + 1);
        }

        bool AddQuesToNode(Question ques)
        {
            var node = new Node();
            if (Question.MaxComplexity[Convert.ToInt32(ques.Complexity)] > node.complexity[Convert.ToInt32(ques.Complexity)])
            {
                if ((ques.CanBeUsedOnce && ques.isUsed) == false)
                {
                    if (ques.AllergyQues != null)
                    {
                        var allergic = node.CurrentQuestion.FirstOrDefault(x => x.Name == ques.Name);
                        if (allergic == null)
                        {
                            node.addQues(ques);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        Node originalNode = new Node();
        void loop()
        {
            //simple
            var s = OriginalList.Where(x => x.Complexity == Complexity.simple);
            foreach (var item in s)
            {

            }
        }
    }

    class Node
    {
        public static List<string> allSol = new List<string>();
        public int[] complexity { get; set; }

        public List<Question> CurrentQuestion = new List<Question>();

        public void addQues(Question ques)
        {
            complexity[Convert.ToInt32(ques.Complexity)]++;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var q in CurrentQuestion)
            {
                sb.Append(q.Name);
            }
            return sb.ToString();
        }

        public bool isCompleted()
        {
            if (CurrentQuestion.Count == Question.MaxComplexity.Sum())
            {
                var ques = CurrentQuestion.FirstOrDefault(x => x.CanBeUsedOnce);
                if (ques != null) ques.isUsed = true;
                return true;
            }
            return false;
        }

        public static Node CreateDuplicateNode(Node oldNode)
        {
            var newNode = new Node();
            foreach (var q in oldNode.CurrentQuestion)
            {
                newNode.addQues(q);
            }
            return newNode;
        }
    }

    public enum Complexity { simple, medium, complex };
    public class Question
    {
        public Complexity Complexity { get; set; }
        public char Name { get; set; }
        public bool CanBeUsedOnce { get; set; }
        public bool isUsed { get; set; }
        public char? AllergyQues { get; set; }

        public static int[] MaxComplexity;
    }
}
