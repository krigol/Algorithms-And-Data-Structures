// A C# program for Prim's Minimum 
// Spanning Tree (MST) algorithm. 
// The program is for adjacency 
// matrix representation of the graph 

using System;

namespace PrimsMinimumSpanningTree
{
    internal enum Letters
    {
        A,
        B,
        C,
        D,
        E
    }

    internal class Program
    {
        // Number of vertices in the graph 
        static int VerticiesInGraph;

        // Driver Code 
        public static void Main()
        {
            /* Graph visualization
            2    3 
         (A)--(B)--(C) 
         |   / \   | 
        6| 8/   \5 |7 
         | /     \ | 
         (D)-------(E) 
              9            */

            //Represents the weights of each vertices' edges 
                                       /*A  B  C  D  E*/
            var graph = new[,] { /*A*/ { 0, 2, 0, 6, 0 },
                                 /*B*/ { 2, 0, 3, 8, 5 },
                                 /*C*/ { 0, 3, 0, 0, 7 },
                                 /*D*/ { 6, 8, 0, 0, 9 },
                                 /*E*/ { 0, 5, 7, 9, 0 } };

            VerticiesInGraph = (int)Math.Sqrt(graph.Length);

            // Print the solution 
            primMST(graph);

            Console.WriteLine();
            Console.WriteLine("End of demo.");
            Console.ReadKey(true);
        }

        // Function to construct and 
        // print MST for a graph represented 
        // using adjacency matrix representation 
        static void primMST(int[,] graph)
        {

            // Array to store constructed MST 
            var parent = new int[VerticiesInGraph];

            // Key values used to pick 
            // minimum weight edge in cut 
            var keys = new int[VerticiesInGraph];

            // To represent set of vertices 
            // not yet included in MST 
            var mstSetVisited = new bool[VerticiesInGraph];

            // Initialize all keys 
            // as INFINITE 
            for (var i = 0; i < VerticiesInGraph; i++)
            {
                keys[i] = int.MaxValue;
                mstSetVisited[i] = false;
            }

            // Always include first 1st vertex in MST. 
            // Make key 0 so that this vertex is 
            // picked as first vertex 
            // First node is always root of MST 
            keys[0] = 0;
            parent[0] = -1;

            // The MST will have VerticiesInGraph vertices 
            for (var count = 0; count < VerticiesInGraph - 1; count++)
            {
                // Pick thd minimum key vertex 
                // from the set of vertices 
                // not yet included in MST 
                var currentVertices = minKey(keys, mstSetVisited);

                // Add the picked vertex 
                // to the MST Set 
                mstSetVisited[currentVertices] = true;

                // Update key value and parent 
                // index of the adjacent vertices 
                // of the picked vertex. Consider 
                // only those vertices which are 
                // not yet included in MST 
                for (var targetVertices = 0; targetVertices < VerticiesInGraph; targetVertices++)

                    // graph[u][v] is non zero only 
                    // for adjacent vertices of m 

                    // mstSet[v] is false for vertices 
                    // not yet included in MST

                    // Update the key only if graph[u][v] is 
                    // smaller than key[v] 
                    if (graph[currentVertices, targetVertices] != 0 && mstSetVisited[targetVertices] == false
                                         && graph[currentVertices, targetVertices] < keys[targetVertices])
                    {
                        parent[targetVertices] = currentVertices;
                        keys[targetVertices] = graph[currentVertices, targetVertices];
                    }
            }

            // print the constructed MST 
            printMST(parent, graph);
        }

        // A utility function to find 
        // the vertex with minimum key 
        // value, from the set of vertices 
        // not yet included in MST 
        static int minKey(int[] keys, bool[] mstSet)
        {

            // Initialize min value 
            var min = int.MaxValue;
            var min_index = -1;

            for (var v = 0; v < VerticiesInGraph; v++)
                if (mstSet[v] == false && keys[v] < min)
                {
                    min = keys[v];
                    min_index = v;
                }

            return min_index;
        }

        // A utility function to print 
        // the constructed MST stored in 
        // parent[] 
        static void printMST(int[] parent, int[,] graph)
        {
            Console.WriteLine("Edge \tWeight");
            for (var i = 1; i < VerticiesInGraph; i++)
                Console.WriteLine(GetLetter(parent[i]) + " - " + GetLetter(i) + "\t" + graph[i, parent[i]]);
        }

        static string GetLetter(int num)
        {
            return Enum.Parse(typeof(Letters), num.ToString()).ToString();
        }

    }
}