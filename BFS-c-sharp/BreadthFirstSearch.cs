using System.Collections.Generic;
using BFS_c_sharp.Model;

namespace BFS_c_sharp
{
    public class BreadthFirstSearch
    {
        private readonly List<UserNode> _graph;

        public BreadthFirstSearch(List<UserNode> graph)
        {
            _graph = graph;
        }
    }
}