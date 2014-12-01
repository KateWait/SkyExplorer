using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkyExplorer1.Models
{
    public class User
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Login { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Street { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int HomeNumber { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.PostalCode)]
        public string CityName { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime BirthdayDate { get; set; }
        public DateTime CreatedAccount { get; set; }

        //Ref

        public AccountType AccountType { get; set; }
        public IList<Attachment> Attachment { get; set; }
        public IList<ConnectionString> ConnectionString { get; set; }

    }
}