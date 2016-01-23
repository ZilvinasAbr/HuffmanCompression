using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCompression.Data_Structures
{
    class MinimalNode
    {
        public byte letter;
        public int left, right;
        public MinimalNode() { }
        public MinimalNode(byte letter, int left, int right)
        {
            this.letter = letter; this.left = left; this.right = right;
        }
    }
}
