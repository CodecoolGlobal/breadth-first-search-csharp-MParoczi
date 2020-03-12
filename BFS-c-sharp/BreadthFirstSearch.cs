using System;
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

        public int TraverseGraph()
        {
            throw new NotImplementedException();
        }

        public int GetDistanceBetweenTwoUsers(UserNode userOne, UserNode userTwo)
        {
            throw new NotImplementedException();
        }

        public List<UserNode> GetFriendsInDistance(UserNode user, int distance)
        {
            throw new NotImplementedException();
        }

        public List<List<UserNode>> GetShortestPathBetweenTwoUsers(UserNode userOne, UserNode userTwo)
        {
            throw new NotImplementedException();
        }
    }
}