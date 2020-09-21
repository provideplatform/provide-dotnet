using System;
using System.Linq;
using System.Threading.Tasks;
using provide;
using provide.Model.Ident;

public static class IdentTestUtil 
{
    public async static Task<string> CreateIdentForTestUser()
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string username = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        string email = String.Format("user{0}@prvd.local", username);

        await Ident.CreateUser(new User() {
            FirstName = "Test",
            LastName = "User",
            Email = email,
            Password = "prvdp4ss",
        });

        return (await Ident.Authenticate(
            new Auth 
            {
                Email = email,
                Password = "prvdp4ss",
            }
        )).Token.Token;
    }
}
