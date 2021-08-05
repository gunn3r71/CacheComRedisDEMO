using System;
using Demo.Entities;
using ServiceStack.Redis;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            var redisHost = "localhost:6379";

            var cliente = new Client
            {
                Email = "lucas.p.oliveira@outlook.pt",
                Name = "Lucas"
            };

            var cliente2 = new Client
            {
                Email = "j@j.com",
                Name = "João"
            };
            


            using (var redisClient = new RedisClient(redisHost))
            {
                redisClient.Set<Client>(cliente.Id.ToString(), cliente);
                redisClient.Set<Client>(cliente2.Id.ToString(), cliente2);

                Console.WriteLine(redisClient.Get<Client>(cliente.Id.ToString()));
                var clients = redisClient.GetAll<Client>();

                foreach (var client in clients)
                {
                    Console.WriteLine(client);
                }
            }

            Console.ReadKey();
        }
    }
}
