
namespace Prj_Auth
{
     public interface IJwtAuthenticationMgr
    {
        string Authenticate(string username, string password);
    }
}
