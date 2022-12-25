using Methical.Models;

namespace Methical.Services
{
    public interface IProfileService
    {
        public Task<Profile> GetProfileFromSpaceAsync(bool IsStableDiffusion);
    }
}
