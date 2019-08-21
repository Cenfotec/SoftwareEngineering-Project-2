using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DataAccess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using ZXing;
using ZXing.QrCode;

namespace CoreAPI
{
    public class QRCodeManagement
    {

        public static Cloudinary cloudinary;
        public const string CLOUD_NAME = "cloud_name";
        public const string API_KEY = "api_key";
        public const string API_SECRET = "api_secret";

        private QRCodeCrud crudQRCode;

        public QRCodeManagement() => crudQRCode = new QRCodeCrud();

        public QRCode Create(QRCode code, string state)
        {

            try
            {

                string JsonInfo = code.FK_SubReservation.ToString();

                var info = code.Id.ToString() +","+ code.FK_SubReservation.ToString();

                

                var idPublic = GenerateQrCode(info);

                code.Value = idPublic;

                // Disabled
                code.State = state;

                crudQRCode.Create(code);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return code;
        }

        public string GenerateQrCode(string value)
        {
            Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
            cloudinary = new Cloudinary(account);

            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Width = 400,
                    Height = 400
                }
            };
            var result = writer.Write(value);
            var SigBase64 = "";

            using (var ms = new MemoryStream())
            {
                using (var bitmap = new Bitmap(result))
                {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    SigBase64 = Convert.ToBase64String(ms.GetBuffer()); //Get Base64
                }
            }

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(@"data:image/png;base64,"+SigBase64)
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            var publicId = uploadResult.PublicId;
            return publicId;
            
        }

        public List<QRCode> RetrieveAll() => crudQRCode.RetrieveAll<QRCode>();

        public QRCode RetrieveById(QRCode code) => crudQRCode.Retrieve<QRCode>(code);

        public void Update(QRCode code) => crudQRCode.Update(code);

        public void Delete(QRCode code) => crudQRCode.Delete(code);

        public async Task SendEmail(User user, string qrCodeValue) => await crudQRCode.SendEmail(user, qrCodeValue);

        public QRCode RetrieveByReservationId(int idReservation) => crudQRCode.RetrieveByReservationId<QRCode>(idReservation);

        public List<QRCode> RetrieveAllByReservationId(int idReservation) => crudQRCode.RetrieveAllByReservationId(idReservation);

        public async Task SendEmailWithFactura(User user, string qrCodeValue, ReservationInvoice reservationInvoice) => await crudQRCode.SendEmailWithFactura(user, qrCodeValue, reservationInvoice);
    }
}

