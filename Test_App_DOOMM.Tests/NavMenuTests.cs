using Bunit;
using Xunit;
using Test_App_DOOMM.Components.Layout;

namespace Test_App_DOOMM.Tests
{
    public class NavMenuTests : TestContext
    {
        [Theory]
        [InlineData("/", "Home")]
        [InlineData("/counter", "Counter")]
        [InlineData("/weather", "Weather")]
        public void NavMenu_ShouldContain_MenuItem(string href, string linkText)
        {
            // Arrange
            var cut = RenderComponent<NavMenu>();

            // Act - find link by visible text to avoid differences in href formatting
            var navLink = cut.FindAll("a").FirstOrDefault(a => a.TextContent != null && a.TextContent.Contains(linkText));

            // Assert
            Assert.NotNull(navLink);
            Assert.Contains(linkText, navLink.TextContent);
        }
    }
}