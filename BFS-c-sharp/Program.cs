using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;

namespace BFS_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomDataGenerator generator = new RandomDataGenerator();
            List<UserNode> users = generator.Generate();

            BreadthFirstSearch breadthFirstSearch = new BreadthFirstSearch(users);
            
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
            
            Console.WriteLine($"The number of users the algorithm traversed through: {breadthFirstSearch.TraverseGraph()}");

            Random random = new Random();
            
            UserNode userOne = users[random.Next(0, users.Count)];
            UserNode userTwo = users[random.Next(0, users.Count)];
            
            Console.WriteLine($"The distance between {userOne} and {userTwo} is {breadthFirstSearch.GetDistanceBetweenTwoUsers(userOne, userTwo)}");
            
            Console.WriteLine($"{userOne} closest friends are: ");
            foreach (UserNode friend in breadthFirstSearch.GetFriendsInDistance(userOne, 1))
            {
                Console.WriteLine(friend);
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
