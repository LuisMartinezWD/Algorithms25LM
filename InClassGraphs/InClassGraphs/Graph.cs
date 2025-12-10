using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InClassGraphs
{
    public class Graph
    {
        private readonly int _V;
        private readonly int[,] _adj;
        private int _E;            
        
         

  
        public Graph(int V)
        {
            _V = V;
            _E = 0;
            _adj = new int[V, V];
        }

        public int V() => _V;   
        public int E() => _E;   


        public void AddEdge(int v, int w)
        {
            if (_adj[v, w] == 0) 
            {
                _adj[v, w] = 1;
                _adj[w, v] = 1;
                _E++;
            }
        }


        public int[] Adj(int v)
        {
            var neighbors = new System.Collections.Generic.List<int>();
            for (int w = 0; w < _V; w++)
            {
                if (_adj[v, w] == 1)
                    neighbors.Add(w);
            }
            return neighbors.ToArray();
        }


      

        public int MaxDegree()
        {
            int max = 0;
            for (int v = 0; v < _V; v++)
            {
                int deg = Degree(v);
                if (deg > max) max = deg;
            }
            return max;
        }

    
        public float AverageDegree()
        {
            return (float)(2.0 * _E / _V);
        }

        public int Degree(int v)
        {
            int degree = 0;
            for (int w = 0; w < _V; w++)
            {
                degree += _adj[v, w];
            }
            return degree;
        }

      

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{_V} vertices, {_E} edges");
            for (int v = 0; v < _V; v++)
            {
                sb.Append($"{v}: ");
                for (int w = 0; w < _V; w++)
                {
                    if (_adj[v, w] == 1)
                        sb.Append($"{w} ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public int NumberOfSelfLoops()
        {
            int count = 0;
            for (int v = 0; v < _V; v++)
            {
                if (_adj[v, v] == 1)
                    count++;
            }
            return count;
        }

    }
}
