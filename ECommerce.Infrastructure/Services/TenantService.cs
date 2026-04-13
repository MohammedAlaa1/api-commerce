using ECommerce.Domain.Interfaces;

namespace ECommerce.Infrastructure.Services;

// Stub implementation — replace with JWT token extraction in Auth phase
public class TenantService : ITenantService
{
    public Guid GetTenantId()
    {
        // Hardcoded for now — will be read from JWT claims later
        return Guid.Parse("00000000-0000-0000-0000-000000000001");
    }
}
