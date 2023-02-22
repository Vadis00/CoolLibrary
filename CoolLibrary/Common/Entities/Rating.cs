using CoolLibrary.Common.DTO;
using CoolLibrary.Common.Entities.Abstract;
using FluentValidation;
using System.Net.Mail;
using System.Net;
using CoolLibrary.BLL.Exceptions;

namespace CoolLibrary.Common.Entities
{
    public class Rating : BaseEntity
    {
        public decimal Score { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
    }
}