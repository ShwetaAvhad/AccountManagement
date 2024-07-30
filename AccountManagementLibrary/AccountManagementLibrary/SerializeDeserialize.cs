using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AccountManagementLibrary
{
    public class SerializeDeserialize
    {
        public static void SerializedData(List<Account> account)
        {
            File.WriteAllText("Account.json", JsonConvert.SerializeObject(account));
        }
        public static List<Account> DeserializedData()
        {
            List<Account> account = new List<Account>();
            string fileName = "Account.json";
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                account = JsonConvert.DeserializeObject<List<Account>>(json);
            }
            else
            {
                File.WriteAllText("Account.json", JsonConvert.SerializeObject(account));
            }
            return account;
        }
    }
}
