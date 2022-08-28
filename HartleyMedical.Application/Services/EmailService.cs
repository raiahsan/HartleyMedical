using Application.ServiceInterfaces.IUserServices;
using HartleyMedical.Application.Common.Settings;
using HartleyMedical.Application.RepositoryInterfaces.IGeneralRepositories;
using HartleyMedical.Application.ServicesInterfaces;
using HartleyMedical.Domain.Constants;
using HartleyMedical.Domain.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailTemplateRepository _emailTemplateRepository;
        private readonly ISystemSettingsRepository _systemSettingsRepository;
        private readonly AppSettings _appSettings;
        public EmailService(IEmailTemplateRepository emailTemplateRepository, ISystemSettingsRepository systemSettingsRepository, IOptions<AppSettings> options)
        {
            _emailTemplateRepository = emailTemplateRepository;
            _systemSettingsRepository = systemSettingsRepository;
            _appSettings = options.Value;
        }

        public bool SendAccountCreatedEmail(User user)
        {
            bool result = false;
            var systemSettings = _systemSettingsRepository.GetSystemSettings();
            var emailTemplate = _emailTemplateRepository.GetEmailTemplateByName(EmailTemplateTypes.AccountCreated);

            if (emailTemplate != null)
            {
                string setpasswordURL = _appSettings.UIBaseURL + "/SetPassword?code=" + user.PasswordRequestHash+ "&pageCaption=" + "set";
                string emailTemplateBody = emailTemplate.Body.Replace("[Name]", user.FirstName + " " + user.LastName)
                                                    .Replace("[SetPasswordURL]", setpasswordURL)
                                                    .Replace("[LogoURL]", _appSettings.APIBaseURL + "/Images/logo.png");
                result = SendEmail(emailTemplateBody, user.Email, emailTemplate.Subject, systemSettings);
            }
            return result;
        }
        public bool SendForgotPasswordEmail(User user)
        {
            bool result = false;
            var systemSettings = _systemSettingsRepository.GetSystemSettings();
            var emailTemplate = _emailTemplateRepository.GetEmailTemplateByName(EmailTemplateTypes.ResetPassword);

            if (emailTemplate != null)
            {
                string setpasswordURL = _appSettings.UIBaseURL + "/ResetPassword?code=" + user.PasswordRequestHash + "&pageCaption=" + "reset";
                string emailTemplateBody = emailTemplate.Body.Replace("[Name]", user.FirstName + " " + user.LastName)
                                                    .Replace("[ResetPasswordURL]", setpasswordURL)
                                                    .Replace("[LogoURL]", _appSettings.APIBaseURL + "/Images/logo.png");
                result = SendEmail(emailTemplateBody, user.Email, emailTemplate.Subject, systemSettings);
            }
            return result;
        }
        private bool SendEmail(string message, string to, string subject, List<SystemSetting> systemSettings,
                                     List<string> ccs = null, Attachment file = null)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    var fromMail = systemSettings.Where(x => x.SettingName == SystemSettingsVariables.FromMail).FirstOrDefault();
                    var smtpClient = systemSettings.Where(x => x.SettingName == SystemSettingsVariables.SmtpClient).FirstOrDefault();
                    var smtpPort = systemSettings.Where(x => x.SettingName == SystemSettingsVariables.SmtpPort).FirstOrDefault();
                    var smtpUser = systemSettings.Where(x => x.SettingName == SystemSettingsVariables.SmtpUser).FirstOrDefault();
                    var smtpPassword = systemSettings.Where(x => x.SettingName == SystemSettingsVariables.SmtpPassword).FirstOrDefault();
                    mail.From = new MailAddress(fromMail.SettingValue, "Hartley Medical"); //From Mail
                    mail.To.Add(new MailAddress(to));
                    if (ccs != null)
                    {
                        foreach (string cc in ccs)
                        {
                            mail.CC.Add(cc);
                        }
                    }
                    mail.IsBodyHtml = true;
                    mail.Subject = subject;
                    mail.Body = message;
                    if (file != null)
                    {
                        mail.Attachments.Add(file);
                    }
                    using (SmtpClient smtp = new SmtpClient(smtpClient.SettingValue, Convert.ToInt32(smtpPort.SettingValue)))
                    {
                        smtp.Credentials = new NetworkCredential(smtpUser.SettingValue, smtpPassword.SettingValue);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);

                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
