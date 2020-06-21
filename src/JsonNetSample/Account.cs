using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonNetSample
{
    public class Account
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }

        public static Account GetInstanceFromJson(string json)
        {
            return JsonConvert.DeserializeObject<Account>(json);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    public static class SerializeDerializeObject
    {
        /// <summary>
        /// シリアライズ(Accountオブジェクトを json に変換)
        /// </summary>
        public static void Serialize()
        {
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

            string json = account.ToJson();
            Console.WriteLine(json);
        }

        /// <summary>
        /// デシリアライズ (json を Accountオブジェクトに変換)
        /// </summary>
        public static void Deserialize()
        {
            string json = @"{
  'Email': 'james@example.com',
  'Active': true,
  'CreatedDate': '2013-01-20T00:00:00Z',
  'Roles': [
    'User',
    'Admin'
  ]
}";
            var account = Account.GetInstanceFromJson(json);
            Console.WriteLine(account.Email);
            Console.WriteLine(account.Active);
            Console.WriteLine(account.CreatedDate);
        }
    }
}
