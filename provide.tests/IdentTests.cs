
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using provide.Model.Ident;
using Xunit;

namespace provide.tests
{
    public class IdentFixture: IAsyncLifetime
    {
        public string Email { get; private set; }
        public User User { get; private set; }
        public Ident Ident { get; private set; }

        private const string TestUserPwd = "testp4ss";
    
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
            this.Email = CreateUserEmail();
            this.User = await IdentFixture.CreateTestUser(this.Email);
            return this.User;
        }

        private string CreateUserEmail()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string username = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
            return String.Format("user{0}@prvd.local", username);
        }

        private static async Task<User> CreateTestUser(string email)
        {
            return await Ident.CreateUser(new User() {
                FirstName = "Test",
                LastName = "User",
                Email = email,
                Password = TestUserPwd,
            });
        }

        public async Task CreateTestInstance()
        {
            await this.CreateUser();

            var authResponse = await Ident.Authenticate(
                new Auth {
                    Email = this.User.Email,
                    Password = TestUserPwd,
                }
            );

            this.Ident = Ident.InitIdent(authResponse.Token.Token);
        }
    }

    public class IdentTest : IClassFixture<IdentFixture>
    {
        private IdentFixture fixture;

        public IdentTest(IdentFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void TestCreateUser() 
        {
            Assert.NotNull(this.fixture.User);
            Assert.Equal(this.fixture.User.Email, this.fixture.Email.ToLower());
        }

        [Fact]
        public async void TestCreateOrganization()
        {
            var organization = new Organization 
            {
                Name = "test organization"
            };
            var res = await this.fixture.Ident.CreateOrganization(organization);
            Assert.NotNull(res.Id);
        }

        [Fact]
        public async void TestCreateAndGetApplications() 
        {
            var application = new Application 
            {
                Name = "test application"
            };

            var res = await this.fixture.Ident.CreateApplication(application);
            Assert.NotNull(res.Id);

            var appToken = await this.fixture.Ident.CreateToken(new JWTToken
            {
                ApplicationId = res.Id
            });

            var appList = await this.fixture.Ident.ListApplications(new Dictionary<string, object>());
            Assert.Single(appList);
            Assert.Equal(application.Name, appList[0].Name);

            var appDetails = await this.fixture.Ident.GetApplicationDetails(appList[0].Id, new Dictionary<string, object>());
            Assert.NotNull(appDetails.Id);
            Assert.Equal(application.Name, appDetails.Name);
        }

        [Fact]
        public async void TestRefreshAndAccessTokens()
        {
            var org = await this.fixture.Ident.CreateOrganization(new Organization
            {
                Name = "test organization"
            });

            var accessRefreshToken = await this.fixture.Ident.CreateToken(new JWTToken
            {
                Scope = "offline_access",
                OrganizationId = org.Id
            });

            Assert.NotNull(accessRefreshToken.AccessToken);
            Assert.NotNull(accessRefreshToken.RefreshToken);
            Assert.NotNull(accessRefreshToken.ExpiresIn);
            Assert.Equal("offline_access", accessRefreshToken.Scope);

            var accessTokenIdent = new Ident(accessRefreshToken.RefreshToken);
            var accessToken = await accessTokenIdent.CreateToken(new JWTToken
            {
                GrantType = "refresh_token"
            });

            Assert.NotNull(accessToken.RefreshToken);
            Assert.NotNull(accessRefreshToken.ExpiresIn);
        }
    }
}
