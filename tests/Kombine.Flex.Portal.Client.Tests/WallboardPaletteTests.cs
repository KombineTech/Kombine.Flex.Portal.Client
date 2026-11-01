using System.Linq;
using System.Text.Json;
using Kombine.Flex.Portal.Client;

namespace Kombine.Flex.Portal.Client.Tests;

public sealed class WallboardPaletteTests
{
    [Fact]
    public void SeparatePalettesPreserveSignedColorBitsAcrossJsonRoundTrip()
    {
        const string json = "{\"c\":[[-2147483648,-1],[16777215,0]]}";
        var wallboard = JsonSerializer.Deserialize<Wallboard>(json)!;
        var palettes = wallboard.C!.Select(palette => palette.ToArray()).ToArray();
        Assert.Equal(new[] { int.MinValue, -1 }, palettes[0]);
        Assert.Equal(new[] { 16777215, 0 }, palettes[1]);
        var copy = JsonSerializer.Deserialize<Wallboard>(JsonSerializer.Serialize(wallboard))!;
        Assert.Equal(palettes[0], copy.C!.ElementAt(0));
        Assert.Equal(palettes[1], copy.C!.ElementAt(1));
    }
}
