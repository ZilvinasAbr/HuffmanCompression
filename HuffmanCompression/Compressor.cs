using HuffmanCompression.Data_Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCompression
{
    static class Compressor
    {
        public static byte[] Compress(byte[] originalData)
        {
            Dictionary<byte, int> frequencies = GetFrequencies(originalData);
            List<Node> letterLeaves = GetLetterLeavesList(frequencies);
            PriorityQueue<Node> priorityQueue = CreatePriorityQueue(letterLeaves);
            Node root = CreateTree(priorityQueue);
            string nullTerminatedCode;
            Dictionary<byte, string> letterStringMap = CreateLetterStringMap(root, out nullTerminatedCode);

            MemoryStream m = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(m);
            byte[] treeBytes = ConvertTreeToBytes(root);
            writer.Write(treeBytes);

            byte[] compressedData = GetCompressedData(originalData, letterStringMap, nullTerminatedCode);
            writer.Write(compressedData);
            writer.Flush();
            return m.ToArray();
        }

        private static byte[] GetCompressedData(byte[] data, Dictionary<byte, string> letterStringMap, string nullTerminatedCode)
        {
            List<byte> result = new List<byte>();
            List<bool> buffer = new List<bool>();
            foreach (byte b in data)
            {
                string code = letterStringMap[b];
                foreach (char c in code)
                {
                    buffer.Add(c == '1' ? true : false);
                    if (buffer.Count == 8)
                    {
                        int intFromBools = Convert.ToByte(buffer[0]) * 1 + Convert.ToByte(buffer[1]) * 2 + Convert.ToByte(buffer[2]) * 4 + Convert.ToByte(buffer[3]) * 8
                            + Convert.ToByte(buffer[4]) * 16 + Convert.ToByte(buffer[5]) * 32 + Convert.ToByte(buffer[6]) * 64 + Convert.ToByte(buffer[7]) * 128;
                        result.Add((byte)intFromBools);
                        buffer.Clear();
                    }
                }

            }
            foreach (char c in nullTerminatedCode)
            {
                buffer.Add(c == '1' ? true : false);
                if (buffer.Count == 8)
                {
                    int intFromBools = Convert.ToByte(buffer[0]) * 1 + Convert.ToByte(buffer[1]) * 2 + Convert.ToByte(buffer[2]) * 4 + Convert.ToByte(buffer[3]) * 8
                        + Convert.ToByte(buffer[4]) * 16 + Convert.ToByte(buffer[5]) * 32 + Convert.ToByte(buffer[6]) * 64 + Convert.ToByte(buffer[7]) * 128;
                    result.Add((byte)intFromBools);
                    buffer.Clear();
                }
            }

            int lastByte = 0;
            int multiplier = 1;
            for (int i = 0; i < buffer.Count; i++)
            {
                if (buffer[i])
                    lastByte += multiplier;
                multiplier *= 2;
            }

            result.Add((byte)lastByte);

            return result.ToArray();
        }

        private static Dictionary<byte, int> GetFrequencies(byte[] originalData)
        {
            Dictionary<byte, int> frequencies = new Dictionary<byte, int>();
            foreach (byte a in originalData)
            {
                if (frequencies.ContainsKey(a))
                    frequencies[a] += 1;
                else
                    frequencies.Add(a, 1);
            }
            return frequencies;
        }
        private static List<Node> GetLetterLeavesList(Dictionary<byte, int> frequencies)
        {
            List<Node> letterLeaves = new List<Node>();
            foreach (KeyValuePair<byte, int> a in frequencies)
            {
                Node n = new Node(a.Key, a.Value, null, null, true);
                letterLeaves.Add(n);
            }
            return letterLeaves;
        }
        private static PriorityQueue<Node> CreatePriorityQueue(List<Node> nodes)
        {
            PriorityQueue<Node> priorityQueue = new PriorityQueue<Node>();
            foreach (Node n in nodes)
            {
                priorityQueue.push(n);
            }
            return priorityQueue;
        }
        private static Node CreateTree(PriorityQueue<Node> priorityQueue)
        {
            //Terminating node
            priorityQueue.push(new Node(System.Byte.MinValue, 0, null, null, true));
            while (priorityQueue.Count != 1)
            {
                Node first = priorityQueue.pop();
                Node second = priorityQueue.pop();
                Node newNode = new Node(System.Byte.MinValue, first.frequency + second.frequency, first, second, false);
                priorityQueue.push(newNode);
            }
            Node root = priorityQueue.pop();
            return root;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="nullTerminatedCode">This parameter gets the code that represents the end of compressed text</param>
        /// <returns></returns>
        private static Dictionary<byte, string> CreateLetterStringMap(Node root, out string nullTerminatedCode)
        {
            // TODO: Change this stupid workaround of List<string>
            List<string> listOfOneString = new List<string>();
            Dictionary<byte, string> map = new Dictionary<byte, string>();
            RecursiveCreateLetterStringMapHelper(map, root, "", listOfOneString);
            nullTerminatedCode = listOfOneString[0];
            return map;
        }
        private static void RecursiveCreateLetterStringMapHelper(Dictionary<byte, string> map, Node currentNode, string currentCode, List<string> listOfOneString)
        {
            if (currentNode == null)
                return;

            string newCodeLeft = currentCode + "0";
            string newCodeRight = currentCode + "1";
            RecursiveCreateLetterStringMapHelper(map, currentNode.left, newCodeLeft, listOfOneString);
            if (currentNode.isLetter)
            {
                if (currentNode.frequency != 0) // this is needed, so that the '\0' terminating node wouldn't be mapped
                    map.Add(currentNode.letter, currentCode);
                else
                    listOfOneString.Add(currentCode);
            }
            RecursiveCreateLetterStringMapHelper(map, currentNode.right, newCodeRight, listOfOneString);
        }
        private static byte[] ConvertTreeToBytes(Node root)
        {
            List<byte> bytesList = new List<byte>();
            MinimalNode[] minimalNodes = CompressTree(root);
            byte[] lengthBytes = BitConverter.GetBytes(minimalNodes.Length);
            bytesList.AddRange(lengthBytes);
            foreach (MinimalNode n in minimalNodes)
            {
                byte letterByte = n.letter;
                byte[] leftBytes = BitConverter.GetBytes(n.left);
                byte[] rightBytes = BitConverter.GetBytes(n.right);
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(leftBytes);
                    Array.Reverse(rightBytes);
                }
                bytesList.Add(letterByte); bytesList.AddRange(leftBytes); bytesList.AddRange(rightBytes);
            }

            return bytesList.ToArray();
        }
        private static MinimalNode[] CompressTree(Node root)
        {
            List<Node> nodes = new List<Node>();
            RecursiveCompressTree(root, nodes);
            for (int i = 0; i < nodes.Count; i++)
                nodes[i].id = i;
            MinimalNode[] result = new MinimalNode[nodes.Count];
            for (int i = 0; i < result.Length; i++)
            {
                if (nodes[i].frequency == 0)// if it is terminating symbol, make left and right ints equal -2
                {
                    int left = -2;
                    int right = -2;
                    result[i] = new MinimalNode(nodes[i].letter, left, right);
                }
                else
                {
                    int left = (nodes[i].left == null) ? -1 : nodes[i].left.id;
                    int right = (nodes[i].right == null) ? -1 : nodes[i].right.id;
                    result[i] = new MinimalNode(nodes[i].letter, left, right);
                }

            }

            return result;
        }
        private static void RecursiveCompressTree(Node currentNode, List<Node> nodes)
        {
            if (currentNode == null)
                return;
            nodes.Add(currentNode);
            RecursiveCompressTree(currentNode.left, nodes);
            RecursiveCompressTree(currentNode.right, nodes);
        }
    }
}
