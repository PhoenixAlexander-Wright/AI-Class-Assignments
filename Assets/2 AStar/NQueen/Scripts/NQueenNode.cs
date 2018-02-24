using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AStarSearch {
    public class NQueenNode : Node {

        //queens index = row, value = column
        int[] queens;


        public int[] Queens {
            get {
                int[] copy = new int[Size];
                Array.Copy(queens, copy, Size);
                return copy;
            }
        }

        public int Size {
            get { return queens.Length; }
        }

        public NQueenNode(int size) {
            queens = new int[size];
            //random configuration
            for(int i = 0; i < size; i++) {
                queens[i] = UnityEngine.Random.Range(0, size);
            }
        }

        public NQueenNode(int[] q) {
            queens = q;
        }

        public bool IsAttacked(int row) {
            int col = queens[row];
            for(int i = 0; i < Size; i++) {
                if (i != row) {
                    //same column
                    if (queens[i] == col)
                        return true;
                    //same major diagonal
                    if (queens[i] - col == row - i)
                        return true;
                    //same minor diagonal
                    if (col - queens[i] == row - i)
                        return true;
                }
            }

            return false;
        }

        public int AttackedQueens() {
            int attacked = 0;
            for(int i = 0; i < Size; i++) {
                if (IsAttacked(i))
                    attacked++;
            }
            return attacked;
        }


        public override bool EndReached(Node other) {
            if (AttackedQueens() == 0)
                return true;   
            
            return false;
        }

    }
}