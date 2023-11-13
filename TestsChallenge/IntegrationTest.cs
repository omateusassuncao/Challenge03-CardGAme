using Azure.Core;
using Challenge03.Data;
using Challenge03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using System.Xml.Linq;

namespace Challenge03.Tests.Cards
{
    [TestFixture]
    public class IntegrationTest
    {

        [SetUp]
        public void SetUp()
        {
        }

        [TestCase("Test")]
        public void SendRequestToIntegration(string value)
        {
            HelperIntegration request = new HelperIntegration();
            int resultFromRequest = (int)request.SenderAsync(value).Result;

            var result = false;

            if (resultFromRequest == 200)
            {
                result = true;
            }

            Assert.IsTrue(result, "A conexão não foi bem sucedida.");
        }
    }
}