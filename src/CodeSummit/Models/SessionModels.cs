﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Text.RegularExpressions;
using CodeSummit.Data;

namespace CodeSummit.Models
{
    [Table("Session")]
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SessionId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Presenter ID")]
        public int? PresenterId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        private string _slug;

        [DataType(DataType.Text)]
        [Display(Name = "Slug")]
        public string Slug
        {
            get
            {
                if (string.IsNullOrEmpty(_slug) && !string.IsNullOrEmpty(Name))
                    _slug = Regex.Replace(Name.ToLower(), @"[\W]+", "-");

                return _slug;
            }
            set { _slug = value; }
        }

        [DataType(DataType.Text)]
        [Display(Name = "Status")]
        [EnumDataType(typeof(SessionStatus))]
        public string Status { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Scheduled For")]
        public DateTime? ScheduledTime { get; set; }

        public virtual IList<UserRegistrationDbModel> UserRegistrations { get; set; }
    }

    public enum SessionStatus
    {
        Submitted,
        Approved
    }

    public class AddSessionModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class SessionListModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public UserProfile Speaker { get; set; }

        public DateTime? ScheduledTime { get; set; }

        public string Slug { get; set; }

        public string Status { get; set; }
    }
}
