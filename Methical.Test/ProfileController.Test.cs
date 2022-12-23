using Methical.Controllers;
using Methical.Services;
using Methical.Tests.Services.Mock;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methical.Tests
{
    public class ProfileControllerTest
    {
        private readonly ProfileController _controller;
        private readonly IProfileService _service;

        public ProfileControllerTest()
        {
            // Arrange
            _service = new ProfileServiceMock();
            _controller = new ProfileController(_service);
        }

        [Fact]
        public async void Get_Generate_Profile_ReturnsValidResult()
        {
            bool IsStableDiffusion = false;

            // Act
            var result = await _controller.GenerateProfile(IsStableDiffusion);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
