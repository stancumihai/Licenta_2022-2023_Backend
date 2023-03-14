using Library.Enums;
using Microsoft.AspNetCore.Identity;

namespace BLL.Converters.Role
{
    public class RoleConverter
    {
        internal static Roles ToBLLModel(IdentityRole roleDALModel)
        {
            return (Roles)Enum.Parse(typeof(Roles), roleDALModel.Name);
        }

        internal static Roles ToBLLModel(string role)
        {
            return (Roles)Enum.Parse(typeof(Roles), role);
        }
    }
}