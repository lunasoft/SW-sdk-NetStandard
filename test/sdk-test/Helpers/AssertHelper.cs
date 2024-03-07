using SW.Entities;
using Xunit;

namespace Test_SW.Helper
{
    internal static class CustomAssert
    {
        public static void SuccessResponse(Response response, object data)
        {
            AssertNotNullResponse(response);
            AssertStatusValue(response, "success");
            Assert.NotNull(data);
        }
        public static void ErrorResponse(Response response)
        {
            AssertNotNullResponse(response);
            AssertStatusValue(response, "error");
        }
        private static void AssertNotNullResponse(Response response)
        {
            Assert.NotNull(response);
            Assert.True(!string.IsNullOrEmpty(response.Status), GetNullPropertyMessage(nameof(response.Status)));
        }
        private static void AssertStatusValue(Response response, string expectedValue)
        {
            Assert.True(response.Status.Equals(expectedValue), GetExpectedValueMessage(response.Status, expectedValue, response));
        }
        private static string GetNullPropertyMessage(string paramName) => $"{paramName} es nulo o vacío.";
        private static string GetExpectedValueMessage(string actualValue, string expectedValue, Response response)
        {
            string message = $"Se esperaba {actualValue}, se obtuvo {expectedValue}.";
            return string.IsNullOrEmpty(response.Message) ? message : $"{message}\n{response.Message}";
        }
    }
}
