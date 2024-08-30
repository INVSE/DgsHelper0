using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgsHelper0
{
    internal class DiagnosisNode
    {
        public string Text { get; }
        public List<DiagnosisNode> Children { get; }

        public DiagnosisNode(string text)
        {
            Text = text;
            Children = new List<DiagnosisNode>();
        }
    }
}
