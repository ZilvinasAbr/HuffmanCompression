using HuffmanCompression.Data_Structures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCompression
{
    static class Decompressor
    {
        /// <summary>
        /// Takes fullBytes, outputs decompressed bytes
        /// </summary>
        /// <param name="fullBytes"></param>
        /// <returns></returns>
        public static byte[] Decompress(byte[] fullBytes)
        {
            byte[] lenghtBytes = { fullBytes[0], fullBytes[1], fullBytes[2], fullBytes[3] };
            /*if (BitConverter.IsLittleEndian)
                Array.Reverse(lenghtBytes);*/
            int lenght = BitConverter.ToInt32(lenghtBytes, 0);
            List<MinimalNode> minimalNodes = new List<MinimalNode>();
            for (int i = 0; i < lenght; i++)
            {
                byte[] letterBytes = { fullBytes[4 + i * 9] };
                byte[] leftBytes = { fullBytes[4 + i * 9 + 1], fullBytes[4 + i * 9 + 2], fullBytes[4 + i * 9 + 3], fullBytes[4 + i * 9 + 4] };
                byte[] rightBytes = { fullBytes[4 + i * 9 + 5], fullBytes[4 + i * 9 + 6], fullBytes[4 + i * 9 + 7], fullBytes[4 + i * 9 + 8] };

                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(letterBytes);
                    Array.Reverse(leftBytes);
                    Array.Reverse(rightBytes);
                }
                byte letter = letterBytes[0];
                int left = BitConverter.ToInt32(leftBytes, 0);
                int right = BitConverter.ToInt32(rightBytes, 0);

                minimalNodes.Add(new MinimalNode(letter, left, right));
            }

            List<byte> decompressedDataList = new List<byte>();

            int currentNode = 0;
            byte[] compressedTextBytes = new byte[fullBytes.Length - 4 - lenght * 9];
            for (int i = 0; i < compressedTextBytes.Length; i++)
            {
                compressedTextBytes[i] = fullBytes[4 + lenght * 9 + i];
            }
            //fullBytes.CopyTo(compressedTextBytes, 4 + lenght * 10);

            BitArray bitArray = new BitArray(compressedTextBytes);
            for (int i = 0; i < bitArray.Length; i++)
            {
                if (bitArray[i])
                {
                    currentNode = minimalNodes[currentNode].right;
                    if (minimalNodes[currentNode].left == minimalNodes[currentNode].right && minimalNodes[currentNode].left == -1)
                    {
                        decompressedDataList.Add(minimalNodes[currentNode].letter);
                        currentNode = 0;
                    }
                    else if (minimalNodes[currentNode].left == minimalNodes[currentNode].right && minimalNodes[currentNode].left == -2) //if it is terminating symbol
                    {
                        i = bitArray.Length - 1;
                    }
                }
                else
                {
                    currentNode = minimalNodes[currentNode].left;
                    if (minimalNodes[currentNode].left == minimalNodes[currentNode].right && minimalNodes[currentNode].left == -1)
                    {
                        decompressedDataList.Add(minimalNodes[currentNode].letter);
                        currentNode = 0;
                    }
                    else if (minimalNodes[currentNode].left == minimalNodes[currentNode].right && minimalNodes[currentNode].left == -2) //if it is terminating symbol
                    {
                        i = bitArray.Length - 1;
                    }
                }
            }
            return decompressedDataList.ToArray();
        }
    }
}
