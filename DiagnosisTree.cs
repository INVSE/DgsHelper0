using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgsHelper0
{
    internal class DiagnosisTree
    {
        public DiagnosisNode Root { get; private set; }

        public DiagnosisTree(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            Root = ParseLinesToTree(lines);
        }

        private DiagnosisNode ParseLinesToTree(string[] lines)
        {
            Stack<DiagnosisNode> nodeStack = new Stack<DiagnosisNode>();
            DiagnosisNode root = null;

            foreach (var line in lines)
            {
                var trimmedLine = line.Trim();
                if (string.IsNullOrEmpty(trimmedLine)) continue;

                int level = GetIndentationLevel(line);
                var node = new DiagnosisNode(trimmedLine);

                if (level == 0)
                {
                    root = node;
                }
                else
                {
                    while (nodeStack.Count > level)
                    {
                        nodeStack.Pop();
                    }

                    var parentNode = nodeStack.Peek();
                    parentNode.Children.Add(node);
                }

                nodeStack.Push(node);
            }

            return root;
        }

        private int GetIndentationLevel(string line)
        {
            int level = 0;
            foreach (char ch in line)
            {
                if (ch == '\t')
                {
                    level++;
                }
                else
                {
                    break;
                }
            }
            return level;
        }
    }
}
