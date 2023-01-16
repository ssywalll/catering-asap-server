using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class BankAccount : BaseAuditableEntity
    {
        public  string Number { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Bank_User { get; set; } = string.Empty;
        public int User_Id { get; set; }

        // public User User { get; set; }
    }
}