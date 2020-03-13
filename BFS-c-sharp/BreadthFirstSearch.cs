﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            Queue<KeyValuePair<UserNode, int>> usersToVisit = new Queue<KeyValuePair<UserNode, int>>();

            usersToVisit.Enqueue(new KeyValuePair<UserNode, int>(userOne, 0));

            while (usersToVisit.Count != 0)
            {
                KeyValuePair<UserNode, int> currentUser = usersToVisit.Dequeue();

                visitedUsers.Add(currentUser.Key);

                foreach (UserNode friend in currentUser.Key.Friends)
                {
                    if (visitedUsers.Contains(friend) || usersToVisit.Select(u => u.Key).Contains(friend)) continue;
                    if (friend.Id.Equals(userTwo.Id)) return currentUser.Value + 1;
                    usersToVisit.Enqueue(new KeyValuePair<UserNode, int>(friend, currentUser.Value + 1));
                }
            }
            return 0;
        }

        public List<UserNode> GetFriendsInDistance(UserNode user, int distance)
        {
            if (distance.Equals(0))
            {
                return new List<UserNode> {user};
            }
            
            List<UserNode> visitedUsers = new List<UserNode>();
            Queue<KeyValuePair<UserNode, int>> usersToVisit = new Queue<KeyValuePair<UserNode, int>>();
            
            usersToVisit.Enqueue(new KeyValuePair<UserNode, int>(user, 0));
            
            while (usersToVisit.Count != 0)
            {
                KeyValuePair<UserNode, int> currentUser = usersToVisit.Dequeue();

                if (currentUser.Value > distance)
                {
                    return visitedUsers.Where(u => !u.Equals(user)).ToList();
                }
                
                visitedUsers.Add(currentUser.Key);
                
                foreach (UserNode friend in currentUser.Key.Friends)
                {
                    if (visitedUsers.Contains(friend) || usersToVisit.Select(u => u.Key).Contains(friend)) continue;
                    usersToVisit.Enqueue(new KeyValuePair<UserNode, int>(friend, currentUser.Value + 1));
                }
            }
            return null;
        }

        public List<List<UserNode>> GetShortestPathBetweenTwoUsers(UserNode userOne, UserNode userTwo)
        {
            throw new NotImplementedException();
        }
    }
}