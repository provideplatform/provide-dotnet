using System;
using System.Threading.Tasks;
using provide.Model.Ident;
using Xunit;

namespace provide.tests
{
    public class BaselineTest
    {
        private async Task<string> CreateIdentForTestUser()
        {
            var authResponse = await Ident.Authenticate(
                new Auth 
                { 
                    Email = "user@prvd.local",
                    Password = "testp455"
                });
            var ident = new Ident(authResponse.Token.Token);
            return authResponse.Token.Token;
        }

        [Fact]
        public void TestApiClientJwtInit()
        {
            var baseline = new Baseline("eyJhbGciOiJSUzI1NiIsImtpZCI6IjEwOjJlOmQ5OmUxOmI4OmEyOjM0OjM3Ojk5OjNhOjI0OmZjOmFhOmQxOmM4OjU5IiwidHlwIjoiSldUIn0.eyJhdWQiOiJodHRwczovL3Byb3ZpZGUuc2VydmljZXMiLCJleHAiOjE1ODgyMjA3NTMsImlhdCI6MTU4ODEzNDM1MywiaXNzIjoiaHR0cHM6Ly9pZGVudC5wcm92aWRlLnNlcnZpY2VzIiwianRpIjoiZmQ5NjRkYTgtYjk0MS00N2UyLWJhZGQtZTUwMmIwNDJlMmVhIiwibmF0cyI6eyJwZXJtaXNzaW9ucyI6eyJzdWJzY3JpYmUiOnsiYWxsb3ciOlsidXNlci5lODg5ZWRlYS01ODBmLTQwZDgtYWRkZi1kNTA5ZGNmNzc4M2EiLCJuZXR3b3JrLiouc3RhdHVzIiwicGxhdGZvcm0uXHUwMDNlIl19fX0sInBydmQiOnsicGVybWlzc2lvbnMiOjc1NTMsInVzZXJfaWQiOiJlODg5ZWRlYS01ODBmLTQwZDgtYWRkZi1kNTA5ZGNmNzc4M2EifSwic3ViIjoidXNlcjplODg5ZWRlYS01ODBmLTQwZDgtYWRkZi1kNTA5ZGNmNzc4M2EifQ.WCqvgl6NlmZD9mxcElT_x01HwKvlEposfFbt390t6Iqug1BmmtBSVbsWK1UNGSC9rhHDMY8pPfInjna7H7itmKxqQzI3K-FuER9uPtrmYLbguEkDfktp3sN1pJlMBlyV5PepO-1yc3T1NXSdUQ1FYJXYxRDgsn5av_2NyQPR9V42ulINKQq-UVOrtcG_3jUWh-aA5SbgyLvfsbu3LcojUFF65LIqzylFXUnEPJHIl2xDXJYAYP6bk8lW-ZjG26ThJVDs4hqLx_qSLsBVhnAQz5fUzK-Py9JRKsgU5dKfXP6AiEL9nKh5ngW3PTQwJtuVc-3KU26nIYJSHB9wJTsE0be7Pqge3DBRacrAEn3JjD-u6myvi9x20JSVMaFLUNVCPme2ok12qN8AZZJcTkPGn6ujYqUgOqGn8rRgK7rhrPG5E133K2zW40qqY_z6CUIxZPv91SQmAOBwm8CkUt4tDskoyRmGgh-0RBIio2cyZ6iXs3ft14r0-BZuYcX6LkiVrehMuQHyJwMUe7fcYRz9laj999vj79vFPtSeOjy5lf8wiqGtKhMhQbvS0IsZaf_kOMggqt3YiuDmsPezBKwy98T1weuKOrntSMCmetCifR6yEnK38FkmUbMruCtWFdzDuKN3xijz6n-WEDbF7zksQPdn2SPoGUsr95N1KiKUwJo");
            Console.WriteLine(baseline.ToString());
            // Assert.Equal(baseline.ToString(), "provide.ApiClient https://nchain.unibright.io/");
        }


        [Fact]
        public async void TestBaseline() 
        {
            var token = await CreateIdentForTestUser();
            // FIXME Kyle
            var baseline = new Baseline(token);
        }
    }
}
