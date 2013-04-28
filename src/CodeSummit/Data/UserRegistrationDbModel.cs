using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CodeSummit.Models;

namespace CodeSummit.Data
{
    [Table("UserRegistrations")]
    public class UserRegistrationDbModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public virtual IList<Session> Sessions { get; set; }
    }
}