using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Por favor digite o nome do cliente.")]
        [StringLength(255)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Tipo de assinatura")]
        public byte MembershipTypeId { get; set; }
        
        //? na frente do tipo da variavel significa que ela pode ser nula.
        [Display(Name = "Date of Birth")]
        [Min18yearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}