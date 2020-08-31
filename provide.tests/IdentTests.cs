
using System;
using System.Threading.Tasks;
using provide.Model.Ident;
using Xunit;

namespace provide.tests
{
    public class IdentFixture: IAsyncLifetime
    {
        public string email;
        public User user;
        public Ident ident;
        
        public async Task InitializeAsync()
        {
            await this.CreateTestInstance();
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        private async Task<User> CreateUser()
        {
            this.email = CreateUserEmail();
            this.user = await IdentFixture.CreateTestUser(this.email);
            return this.user;
        }

        private string CreateUserEmail()
        {
            return String.Format("user{0}@prvd.local", (Int32) (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
        }

        private static async Task<User> CreateTestUser(string email)
        {
            return await Ident.CreateUser(new User() {
                FirstName = "Test",
                LastName = "User",
                Email = email,
                Password = "testp4ss",
            });
        }

        private async Task CreateTestInstance()
        {
            await this.CreateUser();

            var authResponse = await Ident.Authenticate(
                new Auth {
                    Email = this.user.Email,
                    Password = this.user.Password,
                }
            );

            this.ident = new Ident(authResponse.Token.Token);
        }
    }

    public class IdentTest : IClassFixture<IdentFixture>
    {
        private IdentFixture fixture;

        public IdentTest(IdentFixture fixture)
        {
            this.fixture = fixture;
        }
        // [Fact]
        // public void TestIdentJwtInit()
        // {
        //     Ident.InitIdent("eyJhbGciOiJSUzI1NiIsImtpZCI6IjEwOjJlOmQ5OmUxOmI4OmEyOjM0OjM3Ojk5OjNhOjI0OmZjOmFhOmQxOmM4OjU5IiwidHlwIjoiSldUIn0.eyJhdWQiOiJodHRwczovL2dvbGRtaW5lLnVuaWJyaWdodC5pbyIsImV4cCI6MTU4ODE0MzczMiwiaWF0IjoxNTg4MDU3MzMyLCJpc3MiOiJodHRwczovL2lkZW50LnVuaWJyaWdodC5pbyIsImp0aSI6IjBmMjBmMDkxLTg5MWItNDczMy05NjdmLTZkNjVmZjJlZjhmMiIsIm5hdHMiOnsicGVybWlzc2lvbnMiOnsic3Vic2NyaWJlIjp7ImFsbG93IjpbInVzZXIuZTg4OWVkZWEtNTgwZi00MGQ4LWFkZGYtZDUwOWRjZjc3ODNhIiwibmV0d29yay4qLnN0YXR1cyIsInBsYXRmb3JtLlx1MDAzZSJdfX19LCJwcnZkIjp7InBlcm1pc3Npb25zIjo3NTUzLCJ1c2VyX2lkIjoiZTg4OWVkZWEtNTgwZi00MGQ4LWFkZGYtZDUwOWRjZjc3ODNhIn0sInN1YiI6InVzZXI6ZTg4OWVkZWEtNTgwZi00MGQ4LWFkZGYtZDUwOWRjZjc3ODNhIn0.hSaXhWPSfkw0eoYRitOI0PpKtzizFRbyqbW9rVAc7lspymlDj4BRgCN-iNIDd3hgwG4B29bzcAx4X3kHnZw3Cnm86rvdUFN0aTeP8HoICB2g0AV5b-XAjfZB7UITUB0R0UX_Nk3QI5m1fcZWVlMKEidjT-5231JjcHrfaAQLV7FcfOwx6VbSJyPvuJE8t7tc5rClkIqNaIdLU3CXjthQKSZX1zlMyHX25pu1OFUOSLPYsDF21-muRQhepbXOTs_IwTrWEtv7h69O07y6WHX37jRHMSe30KwKLO_pQZENcu7yttAbTh3YB9lOiguQCj4a2ijKUT4HVkSCfNMf3JUXNbpy69uyhDQJaqXmjfmAxX8koEEMJvZd3yW_Vo4v4sCr22DRyhGdFO0IXQPXyfDi59r8YbohiQcONj8roe0AVrSGJQUjei8QHBZDSZeTG7HkI-NPSivHpwNiDmY0tWbRAHJKxfDRhyisF_RKaTVlULhH0gZlIPdIJzDGdmf3EWA10WJJWIHz_D4UK2E7zC8UVEFxM9jPS6H8RVZ5Q7jpEUxlce6lSdNY9BmWWA9grN5hCMdIyNEjjomzNLl0Jb59DPH-pLhEKC6RENcoSt7EkHe3yu6qq8dioPKLjJAO5D9kC6IbTJsUTjcxOJiExoY0m906ccF65UyTqB2-XQlqHs4");
        //     // Assert.Equal("provide.ApiClient https://nchain.unibright.io/", apiClient.ToString());
        // }

        [Fact]
        public void TestCreateUser() 
        {
            Assert.NotNull(this.fixture.user);
            Assert.Equal(this.fixture.user.Email, this.fixture.email);
        }

        [Fact]
        public async void TestCreateOrganization()
        {
            var organization = new Organization 
            {
                Name = "test organization"
            };
            // check error: unable to assert arbitrary org permissions
            // don't send permission
            var res = await this.fixture.ident.CreateOrganization(organization);
        }

        [Fact]
        public async void TestCreateApplication() 
        {
            var application = new Application 
            {
                Name = "test application"
            };

            var res = await this.fixture.ident.CreateApplication(application);
            Assert.NotNull(res.Application.Id);
        }

        [Fact]
        public async void TestListApplications()
        {
            // TODO: checks args for list methods
            var res = await this.fixture.ident.ListApplications(new Application());
            var res2 = await this.fixture.ident.GetApplicationDetails(res[0].Id, new Application());
        }
    }
}
