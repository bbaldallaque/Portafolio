using Portafolio.Web.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portafolio.Web.Servicios
{
    public interface IServicioEmial
    {
        Task Enviar(ContactoViewModel contacto);
    }

    public class ServicioEmailSedGrid : IServicioEmial
    {
        private readonly IConfiguration configuration;

        public ServicioEmailSedGrid(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Enviar(ContactoViewModel contacto)
        {
            var apiKey = configuration.GetValue<string>("SENDGRID_API_KEY");
            var email = configuration.GetValue<string>("SENDGRID_FROM");
            var nombre = configuration.GetValue<string>("SENDGRID_NOMBRE");

            var cliente = new SendGridClient(apiKey);
            var form = new EmailAddress(email, nombre);
            var subject = $"El Cliente{contacto.Email} quiere contactarte";
            var to = new EmailAddress(email, nombre);
            var mensajeTextoPlano = contacto.Mensaje;
            var contenidoHtml = $@"De: {contacto.Nombre} -
            Email: {contacto.Email}
            Mensaje: {contacto.Mensaje}";
            var singleEmail = MailHelper.CreateSingleEmail(form, to, subject, mensajeTextoPlano, contenidoHtml);
            var respuesta = await cliente.SendEmailAsync(singleEmail);

        }
    }
}
