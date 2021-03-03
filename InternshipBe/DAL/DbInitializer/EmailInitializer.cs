using DAL.DataContext;
using DAL.Entities;
using Shared.Infrastructure;
using System.Linq;

namespace DAL.DbInitializer
{
    class EmailsInitializer
    {
        private readonly ApplicationDbContext _context;

        public EmailsInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddEmailTemplate(string name, string value, string discription)
        {
            if (!_context.ConfigVariables.Any(p => p.Name == name))
            {
                _context.ConfigVariables.Add(new ConfigVariable()
                {
                    Name = name,
                    Value = value,
                    Description = discription,
                    DataType = DataTypes.String,
                });

                _context.SaveChanges();
            }
        }

        public void InitializeEmails()
        {
            AddEmailTemplate("Email body for User in English", @"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>
<html xmlns='http://www.w3.org/1999/xhtml' xmlns:o='urn:schemas-microsoft-com:office:office' style='width:100%;font-family:arvo, courier, georgia, serif;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0'>
<head>
    <meta content='width=device-width, initial-scale=1' name='viewport' />
    <meta charset='UTF-8' />
    <meta name='x-apple-disable-message-reformatting' />
    <meta http-equiv='X-UA-Compatible' content='IE=edge' />
    <meta content='telephone=no' name='format-detection' />
    <title>Message to user Eng</title>
    <link href='https://fonts.googleapis.com/css?family=Arvo:400,400i,700,700i' rel='stylesheet' />
    <style type='text/css'>
        .ticket {
            font-size: 1.2em;
            top: 0;
        }

        .ticket-title {
            text-align: center;
        }

        .ticket-content {
            color: #3a3939;
            justify-content: center;
            align-items: center;
            box-sizing: border-box;
            height: 100%;
            width: 25%;
            margin: 0 auto;
        }

        .ticket-content__dotted-line {
            background: url(https://i.ibb.co/g4WybG2/stars.png);
            height: 6px;
            width: 100%;
            margin: .6em 0 1em 0;
        }

        .logo-img {
            width: 40%;
        }

        .ticket-info {
            margin-top: 5px;
        }

        .ticket-info__label {
            margin-right: 2em;
        }

        .ticket-info__field {
            margin-left: auto;
            font-size: 1em;
            font-weight: 400;
        }

        .ticket-discount {
            text-align: center;
            font-size: 1em;
            font-weight: bold;
        }

        .discount-amount {
            margin-left: .3em;
        }

        .ticket-date {
            margin-left: 5px;
        }

        .ticket-date__confirmation {
            font-size: 1em;
        }

        .ticket-content__field {
            list-style: none;
            display: flex;
        }

        .content {
            padding: 0;
        }
    </style>
</head>
<body>
    <div class='ticket' ;=; style='background-color:#F6F6F6'>
        <div class='ticket-content'>
            <div align='left' style='padding:0;Margin:0;font-size:0px'><img src='https://naqgik.stripocdn.email/content/guids/CABINET_034eaea83c8d1d71346c232bbb2726eb/images/35461613885865928.png' alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt style='display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic' width='180' /></div>
            <h2 class='ticket-title'>Ticket for user</h2>
            <div class='ticket-content__dotted-line'></div>
            <div class='ticket-detail__content'>
                <ul class='content'>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            FirstName:
                        </p>
                        <p class='ticket-info__field'>
                            ##FirstName##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            LastName:
                        </p>
                        <p class='ticket-info__field'>
                            ##LastName##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'
                        *ngIf='ticket?.patronymic'>
                        <p class='ticket-info__label'>
                            Patronymic:
                        </p>
                        <p class='ticket-info__field'>
                            ##Patronymic##
                        </p>
                    </li>
                    <li class='ticket-content__field' ;=; style='background: url(https://i.ibb.co/g4WybG2/stars.png); height: 6px; width: 100%; margin: .6em 0 1em 0;'></li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Product/Service:
                        </p>
                        <p class='ticket-info__field'>
                            ##DiscountName##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Vendor:
                        </p>
                        <p class='ticket-info__field'>
                            ##VendorName##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Email:
                        </p>
                        <p class='ticket-info__field'>
                            ##VendorEmail##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Phone:
                        </p>
                        <p class='ticket-info__field'>
                            ##VendorPhone##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Confirmation Date:
                        </p>
                        <p class='ticket-info__field'>
                            ##Date##
                        </p>
                    </li>
                    <li *ngIf='ticket?.promoCode'
                        class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Promocode:
                        </p>
                        <p class='ticket-info__field'>
                            ##Promocode##
                        </p>
                    </li>
                </ul>
            </div>
            <div class='ticket-discount'>
                <p class='ticket-info__label'>Discount: ##DiscountValue##%</p>
            </div>
            <div class='ticket-content__dotted-line'></div>
        </div>

    </div>
    </div>
</body>
</html>
", "Email template for user in english. Words like ##Word## are replaced with values from the database.");
            AddEmailTemplate("Email body for Vendor in English", @"
<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>
<html xmlns='http://www.w3.org/1999/xhtml' xmlns:o='urn:schemas-microsoft-com:office:office' style='width:100%;font-family:arvo, courier, georgia, serif;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0'>
<head>
    <meta content='width=device-width, initial-scale=1' name='viewport' />
    <meta charset='UTF-8' />
    <meta name='x-apple-disable-message-reformatting' />
    <meta http-equiv='X-UA-Compatible' content='IE=edge' />
    <meta content='telephone=no' name='format-detection' />
    <title>Message to user Eng</title>
    <link href='https://fonts.googleapis.com/css?family=Arvo:400,400i,700,700i' rel='stylesheet' />
    <style type='text/css'>
        .ticket {
            font-size: 1.2em;
            top: 0;
        }

        .ticket-title {
            text-align: center;
        }

        .ticket-content {
            color: #3a3939;
            justify-content: center;
            align-items: center;
            box-sizing: border-box;
            height: 100%;
            width: 25%;
            margin: 0 auto;
        }

        .ticket-content__dotted-line {
            background: url(https://i.ibb.co/g4WybG2/stars.png);
            height: 6px;
            width: 100%;
            margin: .6em 0 1em 0;
        }

        .logo-img {
            width: 40%;
        }

        .ticket-info {
            margin-top: 5px;
        }

        .ticket-info__label {
            margin-right: 2em;
        }

        .ticket-info__field {
            margin-left: auto;
            font-size: 1em;
            font-weight: 400;
        }

        .ticket-discount {
            text-align: center;
            font-size: 1em;
            font-weight: bold;
        }

        .discount-amount {
            margin-left: .3em;
        }

        .ticket-date {
            margin-left: 5px;
        }

        .ticket-date__confirmation {
            font-size: 1em;
        }

        .ticket-content__field {
            list-style: none;
            display: flex;
        }

        .content {
            padding: 0;
        }
    </style>
</head>
<body>
    <div class='ticket' ;=; style='background-color:#F6F6F6'>
        <div class='ticket-content'>
            <div align='left' style='padding:0;Margin:0;font-size:0px'><img src='https://naqgik.stripocdn.email/content/guids/CABINET_034eaea83c8d1d71346c232bbb2726eb/images/35461613885865928.png' alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt style='display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic' width='180' /></div>
            <h2 class='ticket-title'>Order Notification</h2>
            <div class='ticket-content__dotted-line'></div>
            <div class='ticket-detail__content'>
                <ul class='content'>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            FirstName:
                        </p>
                        <p class='ticket-info__field'>
                            ##FirstName##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            LastName:
                        </p>
                        <p class='ticket-info__field'>
                            ##LastName##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'
                        *ngIf='ticket?.patronymic'>
                        <p class='ticket-info__label'>
                            Patronymic:
                        </p>
                        <p class='ticket-info__field'>
                            ##Patronymic##
                        </p>
                    </li>
                    <li class='ticket-content__field' ;=; style='background: url(https://i.ibb.co/g4WybG2/stars.png); height: 6px; width: 100%; margin: .6em 0 1em 0;'></li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Product/Service:
                        </p>
                        <p class='ticket-info__field'>
                            ##DiscountName##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Vendor:
                        </p>
                        <p class='ticket-info__field'>
                            ##VendorName##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Email:
                        </p>
                        <p class='ticket-info__field'>
                            ##VendorEmail##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Phone:
                        </p>
                        <p class='ticket-info__field'>
                            ##VendorPhone##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Confirmation Date:
                        </p>
                        <p class='ticket-info__field'>
                            ##Date##
                        </p>
                    </li>
                    <li *ngIf='ticket?.promoCode'
                        class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Promocode:
                        </p>
                        <p class='ticket-info__field'>
                            ##Promocode##
                        </p>
                    </li>
                </ul>
            </div>
            <div class='ticket-discount'>
                <p class='ticket-info__label'>Discount: ##DiscountValue##%</p>
            </div>
            <div class='ticket-content__dotted-line'></div>
        </div>

    </div>
    </div>
</body>
</html>
", "Email template for vendor in english. Words like ##Word## are replaced with values from the database.");
            AddEmailTemplate("Email body for User in Russian", @"
<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>
<html xmlns='http://www.w3.org/1999/xhtml' xmlns:o='urn:schemas-microsoft-com:office:office' style='width:100%;font-family:arvo, courier, georgia, serif;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0'>
<head>
    <meta content='width=device-width, initial-scale=1' name='viewport' />
    <meta charset='UTF-8' />
    <meta name='x-apple-disable-message-reformatting' />
    <meta http-equiv='X-UA-Compatible' content='IE=edge' />
    <meta content='telephone=no' name='format-detection' />
    <title>Message to vendor Rus</title>
    <link href='https://fonts.googleapis.com/css?family=Arvo:400,400i,700,700i' rel='stylesheet' />
    <style type='text/css'>
        .ticket {
            font-size: 1.2em;
            top: 0;
        }

        .ticket-title {
            text-align: center;
        }

        .ticket-content {
            color: #3a3939;
            justify-content: center;
            align-items: center;
            box-sizing: border-box;
            height: 100%;
            width: 25%;
            margin: 0 auto;
        }

        .ticket-content__dotted-line {
            background: url(https://i.ibb.co/g4WybG2/stars.png);
            height: 6px;
            width: 100%;
            margin: .6em 0 1em 0;
        }

        .logo-img {
            width: 40%;
        }

        .ticket-info {
            margin-top: 5px;
        }

        .ticket-info__label {
            margin-right: 2em;
        }

        .ticket-info__field {
            margin-left: auto;
            font-size: 1em;
            font-weight: 400;
        }

        .ticket-discount {
            text-align: center;
            font-size: 1em;
            font-weight: bold;
        }

        .discount-amount {
            margin-left: .3em;
        }

        .ticket-date {
            margin-left: 5px;
        }

        .ticket-date__confirmation {
            font-size: 1em;
        }

        .ticket-content__field {
            list-style: none;
            display: flex;
        }

        .content {
            padding: 0;
        }
    </style>
</head>
<body>
    <div class='ticket' ;=; style='background-color:#F6F6F6'>
        <div class='ticket-content'>
            <div align='left' style='padding:0;Margin:0;font-size:0px'><img src='https://naqgik.stripocdn.email/content/guids/CABINET_034eaea83c8d1d71346c232bbb2726eb/images/35461613885865928.png' alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt style='display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic' width='180' /></div>
            <h2 class='ticket-title'>Талон пользователя</h2>
            <div class='ticket-content__dotted-line'></div>
            <div class='ticket-detail__content'>
                <ul class='content'>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Имя:
                        </p>
                        <p class='ticket-info__field'>
                            ##FirstName##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Фамилия:
                        </p>
                        <p class='ticket-info__field'>
                            ##LastName##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'
                        *ngIf='ticket?.patronymic'>
                        <p class='ticket-info__label'>
                            Отчество:
                        </p>
                        <p class='ticket-info__field'>
                            ##Patronymic##
                        </p>
                    </li>
                    <li class='ticket-content__field' ;=; style='background: url(https://i.ibb.co/g4WybG2/stars.png); height: 6px; width: 100%; margin: .6em 0 1em 0;'></li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            товар/Услуга:
                        </p>
                        <p class='ticket-info__field'>
                            ##DiscountName##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Поставщик:
                        </p>
                        <p class='ticket-info__field'>
                            ##VendorName##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Электронная почта:
                        </p>
                        <p class='ticket-info__field'>
                            ##VendorEmail##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Контактный телефон:
                        </p>
                        <p class='ticket-info__field'>
                            ##VendorPhone##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Дата подтверждения:
                        </p>
                        <p class='ticket-info__field'>
                            ##Date##
                        </p>
                    </li>
                    <li *ngIf='ticket?.promoCode'
                        class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Промокод:
                        </p>
                        <p class='ticket-info__field'>
                            ##Promocode##
                        </p>
                    </li>
                </ul>
            </div>
            <div class='ticket-discount'>
                <p class='ticket-info__label'>Discount: ##DiscountValue##%</p>
            </div>
            <div class='ticket-content__dotted-line'></div>
        </div>

    </div>
    </div>
</body>
</html>
", "Email template for user in russian. Words like ##Word## are replaced with values from the database.");
            AddEmailTemplate("Email body for Vendor in Russian", @"
<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>
<html xmlns='http://www.w3.org/1999/xhtml' xmlns:o='urn:schemas-microsoft-com:office:office' style='width:100%;font-family:arvo, courier, georgia, serif;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0'>
<head>
    <meta content='width=device-width, initial-scale=1' name='viewport' />
    <meta charset='UTF-8' />
    <meta name='x-apple-disable-message-reformatting' />
    <meta http-equiv='X-UA-Compatible' content='IE=edge' />
    <meta content='telephone=no' name='format-detection' />
    <title>Message to vendor Rus</title>
    <link href='https://fonts.googleapis.com/css?family=Arvo:400,400i,700,700i' rel='stylesheet' />
    <style type='text/css'>
        .ticket {
            font-size: 1.2em;
            top: 0;
        }

        .ticket-title {
            text-align: center;
        }

        .ticket-content {
            color: #3a3939;
            justify-content: center;
            align-items: center;
            box-sizing: border-box;
            height: 100%;
            width: 25%;
            margin: 0 auto;
        }

        .ticket-content__dotted-line {
            background: url(https://i.ibb.co/g4WybG2/stars.png);
            height: 6px;
            width: 100%;
            margin: .6em 0 1em 0;
        }

        .logo-img {
            width: 40%;
        }

        .ticket-info {
            margin-top: 5px;
        }

        .ticket-info__label {
            margin-right: 2em;
        }

        .ticket-info__field {
            margin-left: auto;
            font-size: 1em;
            font-weight: 400;
        }

        .ticket-discount {
            text-align: center;
            font-size: 1em;
            font-weight: bold;
        }

        .discount-amount {
            margin-left: .3em;
        }

        .ticket-date {
            margin-left: 5px;
        }

        .ticket-date__confirmation {
            font-size: 1em;
        }

        .ticket-content__field {
            list-style: none;
            display: flex;
        }

        .content {
            padding: 0;
        }
    </style>
</head>
<body>
    <div class='ticket' ;=; style='background-color:#F6F6F6'>
        <div class='ticket-content'>
            <div align='left' style='padding:0;Margin:0;font-size:0px'><img src='https://naqgik.stripocdn.email/content/guids/CABINET_034eaea83c8d1d71346c232bbb2726eb/images/35461613885865928.png' alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt alt=alt style='display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic' width='180' /></div>
            <h2 class='ticket-title'>Уведомление о заказе</h2>
            <div class='ticket-content__dotted-line'></div>
            <div class='ticket-detail__content'>
                <ul class='content'>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Имя:
                        </p>
                        <p class='ticket-info__field'>
                            ##FirstName##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Фамилия:
                        </p>
                        <p class='ticket-info__field'>
                            ##LastName##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'
                        *ngIf='ticket?.patronymic'>
                        <p class='ticket-info__label'>
                            Отчество:
                        </p>
                        <p class='ticket-info__field'>
                            ##Patronymic##
                        </p>
                    </li>
                    <li class='ticket-content__field' ;=; style='background: url(https://i.ibb.co/g4WybG2/stars.png); height: 6px; width: 100%; margin: .6em 0 1em 0;'></li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            товар/Услуга:
                        </p>
                        <p class='ticket-info__field'>
                            ##DiscountName##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Поставщик:
                        </p>
                        <p class='ticket-info__field'>
                            ##VendorName##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Электронная почта:
                        </p>
                        <p class='ticket-info__field'>
                            ##VendorEmail##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Контактный телефон:
                        </p>
                        <p class='ticket-info__field'>
                            ##VendorPhone##
                        </p>
                    </li>
                    <li class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Дата подтверждения:
                        </p>
                        <p class='ticket-info__field'>
                            ##Date##
                        </p>
                    </li>
                    <li *ngIf='ticket?.promoCode'
                        class='ticket-content__field'
                        fxLayout='row'
                        fxLayoutAlign='space-between'>
                        <p class='ticket-info__label'>
                            Промокод:
                        </p>
                        <p class='ticket-info__field'>
                            ##Promocode##
                        </p>
                    </li>
                </ul>
            </div>
            <div class='ticket-discount'>
                <p class='ticket-info__label'>Discount: ##DiscountValue##%</p>
            </div>
            <div class='ticket-content__dotted-line'></div>
        </div>

    </div>
    </div>
</body>
</html>
", "Email template for vendor in russian. Words like ##Word## are replaced with values from the database.");
        }
    }
}