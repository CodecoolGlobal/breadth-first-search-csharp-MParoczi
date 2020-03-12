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
            List<UserNode> visitedUsers = new List<UserNode>();
            Queue<UserNode> usersToVisit = new Queue<UserNode>();
            int iteration = 0;
            
            usersToVisit.Enqueue(_graph[0]);

            while (usersToVisit.Count != 0)
            {
                iteration += 1;
                
                UserNode currentUser = usersToVisit.Dequeue();
                
                visitedUsers.Add(currentUser);

                foreach (UserNode friend in currentUser.Friends)
                {
                    if (!visitedUsers.Contains(friend) && !usersToVisit.Contains(friend))
                    {
                        usersToVisit.Enqueue(friend);
                    }
                }
            }

            return iteration;
        }

        public int GetDistanceBetweenTwoUsers(UserNode userOne, UserNode userTwo)
        {
            if (userOne.Equals(userTwo))
            {
                return 0;
            }
            
            List<UserNode> visitedUsers = new List<UserNode>();
            Queue<UserNode> usersToVisit = new Queue<UserNode>();
            int iteration = 0;
            
            usersToVisit.Enqueue(userOne);

            while (usersToVisit.Count != 0)
            {
                iteration += 1;
                
                UserNode currentUser = usersToVisit.Dequeue();
                
                visitedUsers.Add(currentUser);

                foreach (UserNode friend in currentUser.Friends)
                {
                    if (visitedUsers.Contains(friend) || usersToVisit.Contains(friend)) continue;
                    if (friend.Id.Equals(userTwo.Id)) return iteration;
                    usersToVisit.Enqueue(friend);
                }
            }

            return iteration;
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