using Base_code.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Domain.Entities
{
    public class User : BaseEntity
    {
        public long UserId { get; set; }
        public string FullName {  get; set; }
        public bool Gender {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public string Role {  get; set; }
    }
}
