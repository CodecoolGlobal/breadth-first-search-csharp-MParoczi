using System;
using System.Collections.Generic;
using BFS_c_sharp.Model;
using NUnit.Framework;

namespace TestBFS
{
    [TestFixture]
    public class Tests
    {
        private List<UserNode> GenerateTestGraph()
        {
            List<UserNode> users = new List<UserNode>();
            
            UserNode a = new UserNode("Node", "A", Guid.NewGuid().ToString());
            UserNode b = new UserNode("Node", "B", Guid.NewGuid().ToString());
            UserNode c = new UserNode("Node", "C", Guid.NewGuid().ToString());
            UserNode d = new UserNode("Node", "D", Guid.NewGuid().ToString());
            UserNode e = new UserNode("Node", "E", Guid.NewGuid().ToString());

            a.Friends.Add(b);
            a.Friends.Add(c);
            a.Friends.Add(e);

            b.Friends.Add(a);
            b.Friends.Add(e);

            c.Friends.Add(a);
            c.Friends.Add(d);

            d.Friends.Add(c);
            d.Friends.Add(e);

            e.Friends.Add(a);
            e.Friends.Add(b);
            e.Friends.Add(d);
            
            users.AddRange(new []{a, b, c, d, e});

            return users;
        }

        [Test]
        public void Test1()
        {
            Assert.True(true);
        }
    }
}