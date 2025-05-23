using XAlgiz.Data;

namespace XAlgiz.Services;

public abstract class BaseService(AppDbContext context)
{
    protected readonly AppDbContext Context = context;
}