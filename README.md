An example demonstrating the use of Keyvault for storing and retrieving settings in an ASP.net Core API.

# Instructions
#### Packages
Install the following packages:

```powershell
Install-Package Microsoft.Extensions.Configuration.AzureKeyVault
Install-Package Microsoft.Extensions.Configuration.Binder
```

---

#### Appsettings

```
{
  "Keyvault": {
    "Uri": "[Your Keyvault URI]",
    "AppId": "[Service Principal AppId]",
    "Secret": "[Service Principal Secret]"
  } 
}
```

---
#### Things to note:

- In this method, we are using Microsoft.Extensions.Configuration.Binder to bind values in appsettings.json into a POCO object (Settings\KeyvaultSettings.cs)
- We perform the binding in the Program class, as the time when _CreateWebHostBuilder()_ is called
- We then pass the configuration object to the Startup class, through dependency injection

---

#### Useful References

- [Creating prefixed key vault secrets and loading configuration values (key-name-prefix-sample)][1]
- [In-memory provider and binding to a POCO class][2]


[1]: https://docs.microsoft.com/en-us/aspnet/core/security/key-vault-configuration?view=aspnetcore-2.1&tabs=aspnetcore2x
[2]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.1&tabs=basicconfiguration#in-memory-provider-and-binding-to-a-poco-class