using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCompression.Data_Structures
{
    class Node : IComparable<Node>
    {
        public int id;
        public bool isLetter;
        public byte letter;
        public int frequency;
        public Node left, right;
        public Node() { }
        public Node(byte letter, int frequency, Node left, Node right, bool isLetter)
        {
            this.letter = letter; this.frequency = frequency; this.left = left; this.right = right; this.isLetter = isLetter;
        }

        public int CompareTo(Node other)
        {
            return (this.frequency > other.frequency) ? -1 : ((this.frequency == other.frequency) ? 0 : 1);
        }
    }
}
