# Everything

> .NET Core library for searching through [Voidtool's Everything](https://www.voidtools.com)

:warning: This is a very early preview. Consider using [EverythingNET](https://github.com/ju2pom/EverythingNet) for your production needs

## Async high level client

Intutive, thread safe, search

```cs
var client = new EverythingClient();
var result = await client.SearchAsync("tickets.pdf");
var files = result.Items.OfType<FileResultItem>();

foreach (var file in files)
{
    var fileName = file.Name;
    var size = file.Size;
    var created = file.Created;
}
```

Get more control by providing `SearchOptions` and `CancellationToken` to the search:

```cs
var options = new SearchOptions
{
    MatchCase = true,
    RequestFlags = RequestFlags.FileName,
    Sort = Sort.DateModifiedDescending
};
```

Out of the box query builder for Everything's search syntax

```cs
var executables = await client.SearchAsync(q => q
    .Executables("everything")
    .OfLargeSize()
    .Modified("2018"));

var pictures = await client.SearchAsync(q => q
    .Pictures("xmas")
    .OfAnySize()
    .CreatedAt(new DateTime(2017, 12, 24)));
```

## Low level SDK

Not a fan of the high levevl client? Build one yourself by using `LowLevelSdk` (the unaltered methods provided by everythings SDK) or `EverythingSdk` which is the same, but with .NET-like method names

```cs
EverythingSdk.Search = query;
EverythingSdk.MatchCase = true;
EverythingSdk.Query(wait: true);
EverythingSdk.TryGetSize(1, out var size);
```

:warning: The SDK is not threadsafe and only support one active search at the time.
