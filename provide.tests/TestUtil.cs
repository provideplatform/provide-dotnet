// Copyright 2017-2022 Provide Technologies Inc.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using provide;
using provide.Model.Ident;

public static class TestUtil 
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

    public static string GetTempNatsToken()
    {
        // hardcoded pvt key used for testing in baseline repo
        var natsPrivateKey = "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";

        // create jwt header
        var rsa = RSA.Create();
        rsa.ImportRSAPrivateKey(Convert.FromBase64String(natsPrivateKey), out _);
        var signingCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
        {
            CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
        };

        var header = new JwtHeader(signingCredentials);

        // create jwt payload
        var permissions = new Dictionary<string, object>
        {
            { "publish", new Dictionary<string, object> { { "allow", new[]{ "my.pub.subject" } } } },
            { "subscribe", new Dictionary<string, object> { { "allow", new[]{ "my.pub.subject" } } } }
        };

        var natsClaim = new Dictionary<string, object>
        {
            { "permissions", permissions }
        };
        var payload = new JwtPayload
        {
            { "nats", natsClaim },
            { "exp", EpochTime.GetIntDate(DateTime.UtcNow.AddMinutes(5)) }
        };

        var jwtSecurityToken = new JwtSecurityToken(header, payload);
        var handler = new JwtSecurityTokenHandler();

        return handler.WriteToken(jwtSecurityToken);
    }
    
    public static async Task<Vault> InitVaultWithOrgToken()
    {
        var token = await TestUtil.CreateIdentForTestUser();
        var ident = Ident.InitIdent(token);
        var org = await ident.CreateOrganization(new Organization
        {
            Name = "test org"
        });
        var orgToken = await ident.CreateToken(new JWTToken { OrganizationId = org.Id });

        return Vault.InitVault(orgToken.Token);
    }
}
