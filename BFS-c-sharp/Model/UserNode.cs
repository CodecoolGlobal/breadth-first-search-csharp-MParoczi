﻿using System.Collections.Generic;

namespace BFS_c_sharp.Model
{
    public class UserNode
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private readonly HashSet<UserNode> _friends = new HashSet<UserNode>();

        public HashSet<UserNode> Friends
        {
            get { return _friends; }
        }


        public UserNode() { }

        public UserNode(string firstName, string lastName, string id)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }

        public void AddFriend(UserNode friend)
        {
            Friends.Add(friend);
            friend.Friends.Add(this);
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + "(" + Friends.Count + ")";
        }
    }
}
