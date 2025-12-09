using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_3tree
{
    public class TwoThreeNode
    {
        public List<int> Keys = new List<int>();
        public List<TwoThreeNode> Children = new List<TwoThreeNode>();
        public bool IsLeaf => Children.Count == 0;
    }

}
