using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeSummit.Models
{
    public class UserRegistrationModel
    {
        public IList<SessionModel> Sessions { get; set; }
    }

    public class SessionModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Selected { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Session Time")]
        public DateTime? ScheduledTime { get; set; }
    }
}