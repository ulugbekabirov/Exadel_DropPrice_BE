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
            AddEmailTemplate("ENGMessageForUser", @"<table cellpadding='0' cellspacing='0' align='center'>
    <tbody></tbody>
    <tbody></tbody>
    <tbody>
        <tr>
            <td width='560' align='center' valign='top'>
                <table cellpadding='0' cellspacing='0' width='100%'>
                    <tbody>
                        <tr>
                            <td align='center'>
                                <p style='font-size: 40px; font-family: arvo, courier, georgia, serif;'><strong>##FirstName## ##LastName##, you received this email as a ticket for ##DiscountName##</strong></p>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
    <tbody></tbody>
    <tbody>
        <tr>
            <td width='560' valign='top' align='center'>
                <table width='100%' cellspacing='0' cellpadding='0'>
                    <tbody>
                        <tr>
                            <td align='center' bgcolor='#e90b04'>
                                <p style='color: #f1f1f0; line-height: 150%; font-size: 32px;'>##DiscountValue##</p>
                            </td>
                        </tr>
                        <tr>
                            <td align='center'>
                                <p style='color: #ef1c15; font-size: 20px;'>##Promocode##</p>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
    <tbody></tbody>
    <tbody></tbody>
    <tbody>
        <tr>
            <td align='left'>
                <p style='font-size: 20px;'>Discount provided by ##Vendor##</p>
            </td>
        </tr>
    </tbody>
    <tbody></tbody>
    <tbody></tbody>
    <tbody>
        <tr>
            <td align='left'>
                <p style='font-size: 20px;'>Order date - ##Date##</p>
            </td>
        </tr>
    </tbody>
</table>", "Email template for user in english. Words like ##Word## are replaced with values from the database.");
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
                                                                <td width='560' align='center' valign='top'>
                                                                    <table cellpadding='0' cellspacing='0' width='100%'>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td align='center'>
                                                                                    <p style='font-size: 40px; font-family: arvo, courier, georgia, serif;'><strong>Hello ##Vendor##, you received this email as notification that a ##FirstName## LastName## has taken advantage of your discount offer ##DiscountName##. Best regards, Exadal company.</strong></p>
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
                                                                <td width='560' align='center' valign='top'>
                                                                    <table cellpadding='0' cellspacing='0' width='100%'>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td align='left'>
                                                                                    <p style='font-size: 20px;'>Discount used by ##FirstName## ##LastName## on ##Date##</p>
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
                                                                <td width='560' align='center' valign='top'>
                                                                    <table cellpadding='0' cellspacing='0' width='100%'>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td align='center'>
                                                                                    <p style='font-size: 40px; font-family: arvo, courier, georgia, serif;'><strong>##FirstName## ##LastName##, вы получили данное письмо в качестве талона на получение скидки - ##DiscountName##</strong></p>
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
                                                    <table width='100%' cellspacing='0' cellpadding='0'>
                                                        <tbody>
                                                            <tr>
                                                                <td width='560' valign='top' align='center'>
                                                                    <table width='100%' cellspacing='0' cellpadding='0'>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td align='center' bgcolor='#e90b04'>
                                                                                    <p style='color: #f1f1f0; line-height: 150%; font-size: 32px;'>##DiscountValue##</p>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align='center'>
                                                                                    <p style='color: #ef1c15; font-size: 20px;'>##Promocode##</p>
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
                                                                <td width='560' align='center' valign='top'>
                                                                    <table cellpadding='0' cellspacing='0' width='100%'>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td align='left'>
                                                                                    <p style='font-size: 20px;'>Скидка предоставлена ##Vendor## ##Date##</p>
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
                                                                <td width='560' align='center' valign='top'>
                                                                    <table cellpadding='0' cellspacing='0' width='100%'>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td align='center'>
                                                                                    <p style='font-size: 40px; font-family: arvo, courier, georgia, serif;'><strong>Здравствуйте##Vendor##, вы получили это письмо в качестве уведомления, что ##FirstName## LastName## собирается воспользоваться вашим предложением ##DiscountName##. С уважением, компания Exadel.</strong></p>
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
                                                                <td width='560' align='center' valign='top'>
                                                                    <table cellpadding='0' cellspacing='0' width='100%'>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td align='left'>
                                                                                    <p style='font-size: 20px;'>Предложением воспользовался ##FirstName## ##LastName## ##Date##</p>
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

