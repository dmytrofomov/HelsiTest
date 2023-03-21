using HelsiTest.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace HelsiTest.Core.Entities
{
    public class UserEntity : BaseEntity
    {

        public string Name { get; set; }

        public List<UserListEntity> UserLists { get; set; }

    }
}
