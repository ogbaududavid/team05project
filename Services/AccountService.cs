using team_project.Models;
namespace team_project.Services
{
    public class AccountService
    {
        private static List<Account> _accounts = new List<Account>
        {
            new Account { Id = 1, Username = "admin", Password = "password123" }
        };

        public string ValidateAccount(string username, string password)
        {
            bool accountMatch = _accounts.Any(account => account.Username == username && account.Password == password);
            if (accountMatch)
            {
                return "Success"; // Return "Success" if the account credentials are valid
            }
            else
            {
                return "Login failed: Wrong credentials"; // Return an error message if the account credentials do not match or they do not exist
            }
        }

        // Creates a user account
        public string CreateAccount(string username, string password)
        {
            bool accountMatch = _accounts.Any(account => account.Username == username && account.Password == password);
            if (accountMatch)
            {
                return "This account already exists. Login.";
            }
            else
            {
                Account accountData = new Account { Id = _accounts.Count() + 1, Username = username, Password = password };
                _accounts.Add(accountData);

                return "Your account has been successfully created.";
            }
        }

        // Deletes an existing user account
        public string DeleteAccount(string username, string password)
        {
            Account? accountMatch = _accounts.Find(account => account.Username == username && account.Password == password);
            if (accountMatch != null)
            {
                _accounts.Remove(accountMatch);
                return "Account successfully deleted";
            }
            else
            {
                return "You cannot delete this account either because it does not belong to you or the account credentials are wrong/invalid.";
            }
        }

        // Retrieves an existing user account
        public Account? GetAccount(string username, string password)
        {
            Account? accountData = _accounts.Find(account => account.Username == username && account.Password == password);

            if (accountData != null)
            {
                Console.WriteLine("Login Successful");
                return accountData;
            }
            else
            {
                Console.WriteLine("No matching account found");
                return null;
            }
        }
    }
}