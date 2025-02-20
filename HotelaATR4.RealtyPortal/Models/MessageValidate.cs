using FluentValidation;

namespace HotelaATR4.RealtyPortal.Models
{

    //new MessageValidate()
    public class MessageValidate : AbstractValidator<Message>
    {
        public MessageValidate()
        {
            RuleFor(r => r.MessageBody)
                .NotEmpty()
                .WithMessage("Field MessageBody is requered");
        }
    }
}
