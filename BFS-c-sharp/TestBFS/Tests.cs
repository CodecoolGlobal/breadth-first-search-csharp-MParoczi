using System;
using System.Collections.Generic;
using System.Linq;
using BFS_c_sharp;
using BFS_c_sharp.Model;
using NUnit.Framework;

namespace TestBFS
{
    [TestFixture]
    public class Tests
    {
        private static readonly List<UserNode> Users = GenerateTestGraph();
        private static readonly  BreadthFirstSearch BreadthFirstSearch = new BreadthFirstSearch(Users);
        
        private static List<UserNode> GenerateTestGraph()
        {
            List<UserNode> users = new List<UserNode>();
            
            UserNode a = new UserNode("Node", "A", Guid.NewGuid().ToString());
            UserNode b = new UserNode("Node", "B", Guid.NewGuid().ToString());
            UserNode c = new UserNode("Node", "C", Guid.NewGuid().ToString());
            UserNode d = new UserNode("Node", "D", Guid.NewGuid().ToString());
            UserNode e = new UserNode("Node", "E", Guid.NewGuid().ToString());
            UserNode f = new UserNode("Node", "F", Guid.NewGuid().ToString());
            UserNode g = new UserNode("Node", "G", Guid.NewGuid().ToString());
            
            foreach (UserNode user in new List<UserNode> {b, c, e}) a.Friends.Add(user);
            
            foreach (UserNode user in new List<UserNode> {a, e}) b.Friends.Add(user);
            
            foreach (UserNode user in new List<UserNode> {a, d, f}) c.Friends.Add(user);
            
            foreach (UserNode user in new List<UserNode> {c,e, g}) d.Friends.Add(user);
            
            foreach (UserNode user in new List<UserNode> {a, b, d, g}) e.Friends.Add(user);
            
            foreach (UserNode user in new List<UserNode> {c}) f.Friends.Add(user);
            
            foreach (UserNode user in new List<UserNode> {d, e}) g.Friends.Add(user);
            
            users.AddRange(new []{a, b, c, d, e, f, g});

            return users;
        }

        [Test]
        public void GetDistanceBetweenTwoUsers_TwoUserTheSame_Zero()
        {
            UserNode userOne = Users.Find(u => u.LastName.Equals("A"));

            int result = BreadthFirstSearch.GetDistanceBetweenTwoUsers(userOne, userOne);
            
            Assert.AreEqual(0, result);
        }
        
        [Test]
        public void GetDistanceBetweenTwoUsers_TwoAdjacentUser_One()
        {
            ArrangeTwoUsers(out var userOne, out var userTwo, "A", "B");

            int result = BreadthFirstSearch.GetDistanceBetweenTwoUsers(userOne, userTwo);
            
            Assert.AreEqual(1, result);
        }
        
        [Test]
        public void GetDistanceBetweenTwoUsers_TwoDistantUser_Two()
        {
            ArrangeTwoUsers(out var userOne, out var userTwo, "A", "D");

            int result = BreadthFirstSearch.GetDistanceBetweenTwoUsers(userOne, userTwo);
            
            Assert.AreEqual(2, result);
        }
        
        [Test]
        public void GetDistanceBetweenTwoUsers_TwoFarDistantUser_Three()
        {
            ArrangeTwoUsers(out var userOne, out var userTwo, "E", "F");

            int result = BreadthFirstSearch.GetDistanceBetweenTwoUsers(userOne, userTwo);
            
            Assert.AreEqual(3, result);
        }
        
        [Test]
        public void GetFriendsInDistance_DistanceOneFromD_CEG()
        {
            UserNode user = Users.Find(u => u.LastName.Equals("D"));

            List<string> result = BreadthFirstSearch.GetFriendsInDistance(user, 1).Select(u => u.LastName).ToList();
            
            Assert.AreEqual(new List<string> {"C", "E", "G"}, result);
        }
        
        [Test]
        public void GetFriendsInDistance_DistanceTwoFromF_CAD()
        {
            UserNode user = Users.Find(u => u.LastName.Equals("F"));

            List<string> result = BreadthFirstSearch.GetFriendsInDistance(user, 2).Select(u => u.LastName).ToList();
            
            Assert.AreEqual(new List<string> {"C", "A", "D"}, result);
        }

        private void ArrangeTwoUsers(out UserNode userOne, out UserNode userTwo, string symbolOne, string symbolTwo)
        {
            userOne = Users.Find(u => u.LastName.Equals(symbolOne));
            userTwo = Users.Find(u => u.LastName.Equals(symbolTwo));
        }
    }
}