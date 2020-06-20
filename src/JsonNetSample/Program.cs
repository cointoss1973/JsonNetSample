using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace JsonNetSample
{
    public class Account
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // シリアライズ (Accountオブジェクトを json に変換)
            Account account = new Account
            {
                Email = "james@example.com",
                Active = true,
                CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
                Roles = new List<string>
                {
                    "User",
                    "Admin"
                }
            };

            string json = SerializeAccount(account);
            Console.WriteLine(json);


            // デシリアライズ (json を Accountオブジェクトに変換)
            json = @"{
  'Email': 'james@example.com',
  'Active': true,
  'CreatedDate': '2013-01-20T00:00:00Z',
  'Roles': [
    'User',
    'Admin'
  ]
}";
            account = DeserializeAccount(json);
            Console.WriteLine(account.Email);
        }

        static string SerializeAccount(Account account)
        {
            return JsonConvert.SerializeObject(account, Formatting.Indented);
        }

        static Account DeserializeAccount(string json)
        {
            return JsonConvert.DeserializeObject<Account>(json);
        }

    }




}
