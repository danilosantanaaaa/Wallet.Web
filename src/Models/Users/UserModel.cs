using Wallet.Web.Common.Models;

namespace Wallet.Web.Models.Users;

public class UserModel : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string Emaiil { get; set; } = string.Empty;
}