using System.Collections.Generic;
using System.Threading.Tasks;
using provide.Model.Ident;
using Xunit;

namespace provide.tests
{
    public class IdentTest
    {
        // [Fact]
        // public void TestIdentJwtInit()
        // {
        //     Ident.InitIdent("eyJhbGciOiJSUzI1NiIsImtpZCI6IjEwOjJlOmQ5OmUxOmI4OmEyOjM0OjM3Ojk5OjNhOjI0OmZjOmFhOmQxOmM4OjU5IiwidHlwIjoiSldUIn0.eyJhdWQiOiJodHRwczovL2dvbGRtaW5lLnVuaWJyaWdodC5pbyIsImV4cCI6MTU4ODE0MzczMiwiaWF0IjoxNTg4MDU3MzMyLCJpc3MiOiJodHRwczovL2lkZW50LnVuaWJyaWdodC5pbyIsImp0aSI6IjBmMjBmMDkxLTg5MWItNDczMy05NjdmLTZkNjVmZjJlZjhmMiIsIm5hdHMiOnsicGVybWlzc2lvbnMiOnsic3Vic2NyaWJlIjp7ImFsbG93IjpbInVzZXIuZTg4OWVkZWEtNTgwZi00MGQ4LWFkZGYtZDUwOWRjZjc3ODNhIiwibmV0d29yay4qLnN0YXR1cyIsInBsYXRmb3JtLlx1MDAzZSJdfX19LCJwcnZkIjp7InBlcm1pc3Npb25zIjo3NTUzLCJ1c2VyX2lkIjoiZTg4OWVkZWEtNTgwZi00MGQ4LWFkZGYtZDUwOWRjZjc3ODNhIn0sInN1YiI6InVzZXI6ZTg4OWVkZWEtNTgwZi00MGQ4LWFkZGYtZDUwOWRjZjc3ODNhIn0.hSaXhWPSfkw0eoYRitOI0PpKtzizFRbyqbW9rVAc7lspymlDj4BRgCN-iNIDd3hgwG4B29bzcAx4X3kHnZw3Cnm86rvdUFN0aTeP8HoICB2g0AV5b-XAjfZB7UITUB0R0UX_Nk3QI5m1fcZWVlMKEidjT-5231JjcHrfaAQLV7FcfOwx6VbSJyPvuJE8t7tc5rClkIqNaIdLU3CXjthQKSZX1zlMyHX25pu1OFUOSLPYsDF21-muRQhepbXOTs_IwTrWEtv7h69O07y6WHX37jRHMSe30KwKLO_pQZENcu7yttAbTh3YB9lOiguQCj4a2ijKUT4HVkSCfNMf3JUXNbpy69uyhDQJaqXmjfmAxX8koEEMJvZd3yW_Vo4v4sCr22DRyhGdFO0IXQPXyfDi59r8YbohiQcONj8roe0AVrSGJQUjei8QHBZDSZeTG7HkI-NPSivHpwNiDmY0tWbRAHJKxfDRhyisF_RKaTVlULhH0gZlIPdIJzDGdmf3EWA10WJJWIHz_D4UK2E7zC8UVEFxM9jPS6H8RVZ5Q7jpEUxlce6lSdNY9BmWWA9grN5hCMdIyNEjjomzNLl0Jb59DPH-pLhEKC6RENcoSt7EkHe3yu6qq8dioPKLjJAO5D9kC6IbTJsUTjcxOJiExoY0m906ccF65UyTqB2-XQlqHs4");
            
        //     // Assert.Equal("provide.ApiClient https://goldmine.unibright.io/", apiClient.ToString());
        // }

        private async Task<Ident> CreateIdentForTestUser()
        {
            var authResponse = await Ident.Authenticate(
                new Auth 
                { 
                    Email = "user@prvd.local",
                    Password = "testp455"
                }) as AuthResponse;
            return new Ident((authResponse as AuthResponse).Token.Token);
        }

        [Fact]
        public async void TestCreateUser() 
        {
            var ident = Ident.InitIdent("");
            var user = new User
            {
                Email = "user-test@prvd.local",
                Password = "testp455",
                FirstName = "Prvd",
                LastName = "User"
            };

            var res = await ident.CreateUser(user);
        }


        [Fact]
        public async void TestCreateOrganization()
        {
            var ident = await CreateIdentForTestUser();
            var organization = new Organization 
            {
                Name = "test organization"
            };
            // check error: unable to assert arbitrary org permissions
            var res = await ident.CreateOrganization(organization);
        }

        [Fact]
        public async void TestCreateApplication() 
        {
            var ident = await CreateIdentForTestUser();
            var application = new Application 
            {
                Name = "test application"
            };

            var res = await ident.CreateApplication(application);
        }

        [Fact]
        public async void TestListApplications()
        {
            var ident = await CreateIdentForTestUser();
            // TODO: checks args for list methods
            var res = await ident.ListApplications(new Dictionary<string, object>{});
        }
    }
}
