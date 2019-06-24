using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaperGeneration
{
    class Program
    {
        static void MainMy(string[] args)
        {
            Builder b = new Builder(new int[] { 3, 4, 3 }, new int[] { 2, 3, 2 }, new char[] { 'A', 'D' }, 'G');
            b.GetPossibleCombinations();
            PrintPossibleCombinations(b);

            Console.WriteLine();

            Builder b1 = new Builder(new int[] { 3, 3, 3 }, new int[] { 2, 2, 2 }, new char[] { 'A', 'C' }, 'D');
            b1.GetPossibleCombinations();
            PrintPossibleCombinations(b1);
        }

        static void Main(string[] args)
        {
            int[] Total = new int[3];
            int[] Count = new int[3];
            Total[0] = int.Parse(Console.ReadLine());
            Count[0] = int.Parse(Console.ReadLine());
            Total[1] = int.Parse(Console.ReadLine());
            Count[1] = int.Parse(Console.ReadLine());
            Total[2] = int.Parse(Console.ReadLine());
            Count[2] = int.Parse(Console.ReadLine());
            string[] AllergicS = Console.ReadLine().Split(' ');
            char Once = Convert.ToChar(Console.ReadLine());
            char[] Allergic = new char[2];
            for (int i = 0; i < AllergicS.Length; i++)
            {
                Allergic[i] = Convert.ToChar(AllergicS[i]);
            }
            Builder builder = new Builder(Total, Count, Allergic, Once);
            builder.GetPossibleCombinations();
            int t = 1;
            foreach (var item in Total)
            {
                t *= item;
            }
            Console.WriteLine(t);
            Console.WriteLine(builder.SelectedNodes.Count());
        }

        private static void PrintPossibleCombinations(Builder b)
        {
            foreach (var item in b.SelectedNodes)
            {
                foreach (var n in item.Questions)
                {
                    Console.Write(n.Name.ToString() + ' ');
                }
                Console.WriteLine();
            }
        }
    }

    public enum Category
    {
        Easy, Meduim, Complex
    };
    public class Question
    {
        public char Name { get; set; }
        public bool isOnce { get; set; }
        public bool isCanAdd { get; set; }
        public char? allergicTo { get; set; }
        public Category Category { get; set; }

        public static Question CreateQuestion(Category category, char currentChar) => new Question { Category = category, Name = currentChar, isCanAdd = true };
    }

    public class Builder
    {
        private char currentChar = 'A';
        public readonly int EasyCount;
        public readonly int MediumCount;
        public readonly int ComplexCount;
        public readonly List<Question> Questions = new List<Question>();
        public readonly int[] Total;

        public Builder(int[] total, int[] Count, char[] allergic, char onlyOnce)
        {
            Total = total;
            EasyCount = Count[0];
            MediumCount = Count[1];
            ComplexCount = Count[2];

            for (int i = 0; i < Total[0]; i++)
            {
                Questions.Add(Question.CreateQuestion(Category.Easy, currentChar++));
            }
            for (int i = 0; i < Total[1]; i++)
            {
                Questions.Add(Question.CreateQuestion(Category.Meduim, currentChar++));
            }
            for (int i = 0; i < Total[2]; i++)
            {
                Questions.Add(Question.CreateQuestion(Category.Complex, currentChar++));
            }

            Questions[allergic[0] - 'A'].allergicTo = allergic[1];
            Questions[allergic[1] - 'A'].allergicTo = allergic[0];

            Questions[onlyOnce - 'A'].isOnce = true;
        }

        public List<Node> SelectedNodes = new List<Node>();

        public List<Node> GetPossibleCombinations()
        {
            traverse(new Node());
            return SelectedNodes;
        }

        bool uniqueElementAdded = false;

        void traverse(Node parent)
        {
            // feasability
            if (isFeasable())
            {
                if (isComplete())
                {
                    SelectedNodes.Add(parent);
                    if (parent.containsUniqueElement)
                    {
                        foreach (var item in from item in parent.Questions
                                             where item.isOnce
                                             select item)
                        {
                            item.isCanAdd = false;
                            uniqueElementAdded = true;
                        }
                    }
                }
                else
                {
                    if (parent.currentCategory == Category.Easy)
                    {
                        if (parent.Index < Total[0])
                        {
                            var child1 = parent.makeCopyNode();
                            if (child1.isCanBeAdded(Questions[child1.Index]))
                            {
                                child1.Add(Questions[child1.Index++]);

                                if (child1.currentEasy == EasyCount)
                                {
                                    child1.currentCategory = Category.Meduim;
                                    child1.Index = Total[0];
                                }
                                traverse(child1);
                            }

                            var child2 = parent.makeCopyNode();
                            child2.Index++;
                            traverse(child2);
                        }
                    }


                    if (parent.currentCategory == Category.Meduim)
                    {
                        if (parent.Index < Total[0] + Total[1])
                        {
                            var child1 = parent.makeCopyNode();
                            if (child1.isCanBeAdded(Questions[child1.Index]))
                            {
                                child1.Add(Questions[child1.Index++]);

                                if (child1.currentMedium == MediumCount)
                                {
                                    child1.currentCategory = Category.Complex;
                                    child1.Index = Total[0] + Total[1];
                                }
                                traverse(child1);
                            }

                            var child2 = parent.makeCopyNode();
                            child2.Index++;
                            traverse(child2);
                        }
                    }
                    if (parent.currentCategory == Category.Complex)
                    {
                        if (parent.Index < Total[0] + Total[1] + Total[2])
                        {
                            var child1 = parent.makeCopyNode();
                            if (child1.isCanBeAdded(Questions[child1.Index]))
                            {
                                child1.Add(Questions[child1.Index++]);

                                traverse(child1);
                            }

                            var child2 = parent.makeCopyNode();
                            child2.Index++;
                            traverse(child2);
                        }
                    }
                }
            }
        }
        bool isFeasable(Node parent)
        {
            if (parent.currentEasy <= EasyCount && parent.currentMedium <= MediumCount && parent.currentComplex <= ComplexCount)
            {
                if (uniqueElementAdded && parent.containsUniqueElement)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        bool isComplete(Node parent) => parent.currentEasy == EasyCount && parent.currentMedium == MediumCount && parent.currentComplex == ComplexCount;

    }

    public class Node
    {
        public List<Question> Questions = new List<Question>();
        public int currentEasy = 0;
        public int currentMedium = 0;
        public int currentComplex = 0;
        public int Index = 0;

        public bool containsUniqueElement = false;
        char? allergic;

        public Category currentCategory = Category.Easy;

        public bool isCanBeAdded(Question question)
        {
            if (question.isCanAdd)
            {
                if (allergic == null) { return true; }
                if (allergic != null && question.allergicTo == null) { return true; }
            }
            return false;
        }

        public void Add(Question question)
        {
            //Index++;
            if (question.Category == Category.Easy)
            {
                currentEasy++;
            }
            else if (question.Category == Category.Meduim)
            {
                currentMedium++;
            }
            else
            {
                currentComplex++;
            }
            Questions.Add(question);
            if (question.allergicTo != null)
            {
                allergic = question.allergicTo;
            }
            if (question.isOnce)
            {
                containsUniqueElement = true;
            }
        }

        public Node makeCopyNode()
        {
            var newNode = new Node() { Index = Index, currentCategory = currentCategory, currentEasy = currentEasy, currentComplex = currentComplex, currentMedium = currentMedium, allergic = allergic, containsUniqueElement = containsUniqueElement };
            newNode.Questions = Questions.ToArray().ToList();
            return newNode;
        }
    }
}
