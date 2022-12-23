using Methical.Models;
using Methical.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methical.Tests.Services.Mock
{
    internal class ProfileServiceMock : IProfileService
    {
        public async Task<Profile> GetProfileAsync(bool IsStableDiffusion)
        {
            Profile profile = new Profile
            {
                Name="Name",
                Location="Location",
                Bio="Bio",
                PhotoBase64= "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAgAAAAIAQMAAAD+wSzIAAAABlBMVEX///+/v7+jQ3Y5AAAADklEQVQI12P4AIX8EAgALgAD/aNpbtEAAAAASUVORK5CYII"
            };

            return profile;
        }
    }
}
