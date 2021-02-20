using DAL.DataContext;
using DAL.Entities;

namespace DAL.DbInitializer
{
    class EmailsInitializer
    {
        private readonly ApplicationDbContext _context;

        public EmailsInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InitializeEmails()
        {
            AddEmailTemplate("ENGMessageForUser", @"<div>
    <table cellpadding='0' cellspacing='0' align='center' style='height: 826px;'>
        <tbody>
            <tr style='height: 559px;'>
                <td align='center' style='height: 559px; width: 600px;'>
                    <table bgcolor='#ffffff' align='center' cellpadding='0' cellspacing='0' width='600'>
                        <tbody>
                            <tr>
                                <td align='left'>
                                    <table cellpadding='0' cellspacing='0' width='100%' style='height: 105px; width: 100%;'>
                                        <tbody>
                                            <tr style='height: 105px;'>
                                                <td width='560' valign='top' align='center' esd-custom-block-id='14028' style='height: 105px;'>
                                                    <table style='border-right: 8px solid #e69138; border-collapse: separate; background-color: #373a44;' width='100%' cellspacing='0' cellpadding='0' bgcolor='#373a44'>
                                                        <tbody>
                                                            <tr>
                                                                <td align='left' bgcolor='#3d85c6'>
                                                                    <h2 style='color: #ffffff; line-height: 150%; font-size: 32px;'>Flexadel</h2>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td width='560' align='center' valign='top'>
                                    <table cellpadding='0' cellspacing='0' width='100%' style='height: 440px; width: 100%;'>
                                        <tbody>
                                            <tr style='height: 440px;'>
                                                <td align='center' style='height: 440px;'>
                                                    <p style='font-size: 40px; font-family: arvo, courier, georgia, serif; line-height: 150%; text-align: center;'><strong>##FirstName## ##LastName##, вы получили данное письмо в качестве талона на получение скидки - ##DiscountName##</strong></p>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr style='height: 201px;'>
                <td align='left' style='height: 201px; width: 600px;'>
                    <table width='100%' cellspacing='0' cellpadding='0'>
                        <tbody>
                            <tr>
                                <td width='560' valign='top' align='center'>
                                    <table width='100%' cellspacing='0' cellpadding='0'>
                                        <tbody>
                                            <tr>
                                                <td align='center'>
                                                    <p style='color: #333333; line-height: 150%; font-size: 32px;'>Сэкономьте ##DiscountValue## </p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align='center'>
                                                    <p style='color: #e69138; font-size: 24px;'>##Promocode##</p>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr style='height: 66px;'>
                <td align='left' style='height: 66px; width: 600px;'>
                    <p style='font-size: 20px;'>Скидка предоставлена ##Vendor## ##Date##</p>
                </td>
            </tr>
        </tbody>
    </table>
</div>", "Email template for user in english. Words like ##Word## are replaced with values from the database.");
            AddEmailTemplate("ENGMessageForVendor", @"<div>
    <table width='100%' cellspacing='0' cellpadding='0'>
        <tbody>
            <tr>
                <td valign='top'>
                    <table cellpadding='0' cellspacing='0' align='center'>
                        <tbody>
                            <tr>
                                <td align='center'>
                                    <table bgcolor='#ffffff' align='center' cellpadding='0' cellspacing='0' width='600'>
                                        <tbody>
                                            <tr>
                                                <td align='left'>
                                                    <table cellpadding='0' cellspacing='0' width='100%'>
                                                        <tbody>
                                                            <tr>
                                                                <td width='560' valign='top' align='center' esd-custom-block-id='14028'>
                                                                    <table style='border-right: 8px solid #e69138; border-collapse: separate; background-color: #373a44; height: 101px; width: 100%;' width='100%' cellspacing='0' cellpadding='0' bgcolor='#373a44'>
                                                                        <tbody>
                                                                            <tr style='height: 101px;'>
                                                                                <td align='left' bgcolor='#3d85c6' style='height: 101px;'>
                                                                                    <h2 style='color: #ffffff; line-height: 150%; font-size: 32px;'>Flexadel</h2>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width='560' align='center' valign='top'>
                                                    <table cellpadding='0' cellspacing='0' width='100%'>
                                                        <tbody>
                                                            <tr>
                                                                <td align='center'>
                                                                    <p style='font-size: 40px; font-family: arvo, courier, georgia, serif; line-height: 150%;'><strong>Hello ##Vendor##, you received this email as notification that a ##FirstName## LastName## has taken advantage of your discount offer ##DiscountName##. Best regards, Exadal company.</strong></p>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td width='560' align='center' valign='top'>
                                    <table cellpadding='0' cellspacing='0' width='100%'>
                                        <tbody>
                                            <tr>
                                                <td align='left'>
                                                    <p style='font-size: 20px;'>Предложением воспользовался&nbsp;##FirstName## ##LastNaDiscount used by&nbsp;##FirstName## ##LastName## on ##Date##&nbsp;me## ##Date##</p>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
</div>", "Email template for vendor in english. Words like ##Word## are replaced with values from the database.");
            AddEmailTemplate("RUSMessageForUser", @"<div>
    <table width='100%' cellspacing='0' cellpadding='0'>
        <tbody>
            <tr>
                <td valign='top'>
                    <table cellpadding='0' cellspacing='0' align='center'>
                        <tbody>
                            <tr>
                                <td align='center'>
                                    <table bgcolor='#ffffff' align='center' cellpadding='0' cellspacing='0' width='600'>
                                        <tbody>
                                            <tr>
                                                <td align='left'>
                                                    <table cellpadding='0' cellspacing='0' width='100%'>
                                                        <tbody>
                                                            <tr>
                                                                <td width='560' valign='top' align='center' esd-custom-block-id='14028'>
                                                                    <table style='border-right: 8px solid #e69138; border-collapse: separate; background-color: #373a44; height: 101px; width: 100%;' width='100%' cellspacing='0' cellpadding='0' bgcolor='#373a44'>
                                                                        <tbody>
                                                                            <tr style='height: 101px;'>
                                                                                <td align='left' bgcolor='#3d85c6' style='height: 101px;'>
                                                                                    <h2 style='color: #ffffff; line-height: 150%; font-size: 32px;'>Flexadel</h2>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width='560' align='center' valign='top'>
                                                    <table cellpadding='0' cellspacing='0' width='100%'>
                                                        <tbody>
                                                            <tr>
                                                                <td align='center'>
                                                                    <p style='font-size: 40px; font-family: arvo, courier, georgia, serif; line-height: 150%;'><strong>Hello ##Vendor##, you received this email as notification that a ##FirstName## LastName## has taken advantage of your discount offer ##DiscountName##. Best regards, Exadal company.</strong></p>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td width='560' align='center' valign='top'>
                                    <table cellpadding='0' cellspacing='0' width='100%'>
                                        <tbody>
                                            <tr>
                                                <td align='left'>
                                                    <p style='font-size: 20px;'>Предложением воспользовался&nbsp;##FirstName## ##LastNaDiscount used by&nbsp;##FirstName## ##LastName## on ##Date##&nbsp;me## ##Date##</p>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
</div>", "Email template for user in russian. Words like ##Word## are replaced with values from the database.");
            AddEmailTemplate("RUSMessageForVendor", @"<div>
    <table width='100%' cellspacing='0' cellpadding='0'>
        <tbody>
            <tr>
                <td align='center'>
                    <table bgcolor='#ffffff' align='center' cellpadding='0' cellspacing='0' width='600'>
                        <tbody>
                            <tr>
                                <td align='left'>
                                    <table cellpadding='0' cellspacing='0' width='100%'>
                                        <tbody>
                                            <tr>
                                                <td width='560' valign='top' align='center' esd-custom-block-id='14028'>
                                                    <table style='border-right: 8px solid #e69138; border-collapse: separate; background-color: #373a44;' width='100%' cellspacing='0' cellpadding='0' bgcolor='#373a44'>
                                                        <tbody>
                                                            <tr>
                                                                <td align='left' bgcolor='#3d85c6'>
                                                                    <h2 style='color: #ffffff; line-height: 150%; font-size: 32px;'>Flexadel</h2>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td width='560' align='center' valign='top'>
                                    <table cellpadding='0' cellspacing='0' width='100%'>
                                        <tbody>
                                            <tr>
                                                <td align='center'>
                                                    <p style='font-size: 40px; font-family: arvo, courier, georgia, serif; line-height: 150%;'><strong>Здравствуйте##Vendor##, вы получили это письмо в качестве уведомления, что ##FirstName## LastName## собирается воспользоваться вашим предложением&nbsp;##DiscountName##. С уважением, компания Exadel.</strong></p>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td align='left'>
                    <table cellpadding='0' cellspacing='0' width='100%'>
                        <tbody>
                            <tr>
                                <td align='left'>
                                    <p style='font-size: 20px;'>Предложением воспользовался&nbsp;##FirstName## ##LastName## ##Date##</p>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
</div>", "Email template for vendor in russian. Words like ##Word## are replaced with values from the database.");
        }

        public void AddEmailTemplate(string name, string value, string discription)
        {
            _context.ConfigVariables.Add(new ConfigVariable()
            {
                Name = name,
                Value = value,
                Description = discription,
            });

            _context.SaveChanges();
        }
    }
}