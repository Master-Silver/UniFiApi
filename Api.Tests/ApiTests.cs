using KoenZomers.UniFi.Api.Tests.Fakes;
using System;
using System.Threading.Tasks;
using Xunit;


namespace KoenZomers.UniFi.Api.Tests
{
    public class ApiTests
    {
        private readonly Uri _baseUri = new Uri("https://localhost/test");

        [Fact]
        public void Should_BuildApi_When_DependenciesAreGiven()
        {
            new Api(new FakeHttpUtility(), _baseUri);
        }

        [Fact]
        public async Task Should_ReturnTrue_When_AuthenticateIsSuccessful()
        {
            var api = new Api(
                new FakeHttpUtility(),
                _baseUri);

            Assert.False(api.IsAuthenticated);
            Assert.True(await api.Authenticate("test", "test"));
            Assert.True(api.IsAuthenticated);
        }

        [Fact]
        public async Task Should_ReturnFalse_When_AuthenticateFails()
        {
            var api = new Api(
                new FakeHttpUtility()
                {
                    FailAuthenticate = true
                },
                _baseUri);

            Assert.False(api.IsAuthenticated);
            Assert.False(await api.Authenticate("test", "test"));
            Assert.False(api.IsAuthenticated);
        }

        [Fact]
        public async Task Should_ThrowArgumentNullException_When_ResultStringIsNull()
        {
            var api = new Api(
                new FakeHttpUtility()
                {
                    BadAuthenticate = true
                },
                _baseUri);

            Assert.False(api.IsAuthenticated);
            await Assert.ThrowsAsync<ArgumentNullException>("value", async () =>
            {
                await api.Authenticate("test", "test");
            });
            Assert.False(api.IsAuthenticated);
        }
    }
}
