using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelsiTest.Core.Entities
{
    public class UserListEntity : BaseEntity
    {
        public int ListId { get; set; }
        public int UserId { get; set; }

        public UserEntity? User { get; set; }
        public ListEntity? List { get; set; }
    }
}
