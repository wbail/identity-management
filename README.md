# Identity Management

Poc to test built-in identity mangement api

### Usage

Add in services container:

```csharp
builder.Services.AddIdentityApiEndpoints<TUser>()
                .AddEntityFrameworkStores<TDbContext>();
```