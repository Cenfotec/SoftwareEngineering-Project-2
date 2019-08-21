using Core;
using CoreAPI;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;

namespace SolicitarChatBot
{
    class Program
    {
        public static int contador = 0;
        public static List<InfoChatBot> reservaciones = new List<InfoChatBot>();
        private static Dictionary<int, InfoChatBot> infoReservacion = new Dictionary<int, InfoChatBot>();
        public static InfoChatBot reservacion;
        private static readonly TelegramBotClient Bot = new TelegramBotClient("key");
        static void Main(string[] args)
        {
           
            
            // le decimos q reciba un mensaje 
            Bot.OnMessage += BotOnMessageReceived;
            

            //  reciba un objeto de tipo callback

            Bot.OnCallbackQuery += BotOnCallbackQueryReceived;

            Bot.OnCallbackQuery += BotOnCallbackQueryReceived2;




            Bot.OnReceiveError += BotOnReceiveError;

            Bot.StartReceiving();
            Console.WriteLine("Bot levantado");
            Console.ReadLine();
            Bot.StopReceiving();
        }



        private static InfoChatBot GetInfo(int fkSubreserva)
        {
           
                var manager = new InfoChatBotManagement();
                InfoChatBot lst = manager.RetrieveAllById(fkSubreserva);
            
            return lst;
        }

        private static int GetFkSubReservacion(string userName)
        {
            int fkSubReservacion = 0;
            var manager = new InfoChatBotManagement();
            Check check = manager.GetSubReservacion(userName);
            if (check.FkSubReservacion.Equals("")){}
            else
            {
                fkSubReservacion = Int32.Parse(check.FkSubReservacion);
            }

            Console.WriteLine(fkSubReservacion);

            return fkSubReservacion;
        }

        private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var keyboard1 = new InlineKeyboardMarkup(new[]
                        {
                        new []
                        {
                            InlineKeyboardButton.WithCallbackData(text:"¿Cuál hotel he reservado?", callbackData:"hotel")
                        },

                        new []
                        {

                            InlineKeyboardButton.WithCallbackData(text:"Dime cuándo realice mi check-in", callbackData:"checkin")
                            //Despues de tal hora
                        },

                        new []
                        {
                            InlineKeyboardButton.WithCallbackData
                            (text:"¿Cuándo realice mi check-out?", callbackData:"checkout")
                            //Entre esta hora y esta
                        },

                        new []
                        {
                         InlineKeyboardButton.WithCallbackData(text:"¿Cuál es el precio de mi reservación?", callbackData:"precio")
                        },

                        new []
                        {
                            InlineKeyboardButton.WithCallbackData(text:"¿Cuál tipo de habitación he reservado?", callbackData:"tipohabitacion")
                        },

                        new []
                        {
                           InlineKeyboardButton.WithCallbackData(text:"¿Cómo llegar al hotel?",
                           callbackData:"ubicacion")
                            //reservacion.Latitude+reservacion.Longitude
                        }
            });
            var userName = messageEventArgs.Message.Chat.Username;

            var message = messageEventArgs.Message;

            if(userName == null)
            {
                await Bot.SendTextMessageAsync(message.Chat.Id,
                            "Bievenido " + message.Chat.LastName + ".\n"
                            + "Mi nombre es Francis, es un placer conocerte" +
                            ", lo sentimos ocurrió un error. Quizá no tengas un alias en Telegram" +
                            " verificálo y ven a conocerme");
            }
            else
            {
                var fkSubreservacion = GetFkSubReservacion(userName);
                if (message != null && fkSubreservacion != 0)
                {
                    await Bot.SendTextMessageAsync(message.Chat.Id,
                                "Bievenido " + message.Chat.LastName + ".\n"
                                + "Mi nombre es Francis, es un placer conocerte" +
                                ", puedes consultar información" +
                                " de tu estadía en el hotel presionando algún botón", replyMarkup: keyboard1);
                        
                
                }
                else
                {
                    await Bot.SendTextMessageAsync(message.Chat.Id,
                                "Bievenido " + message.Chat.LastName + ".\n"
                                + "Mi nombre es Francis, es un placer conocerte" +
                                ", al parecer no tienes cuenta en StaynChill o quizá" +
                                " no tienes reservaciones pendientes o activas " +
                                "reserva una habitación en Stay n' Chill para poder conversar conmigo.");
                }
            }

            //reservaciones = GetInfo(message.Text.Split().First());
            //    for (var i = 0; i < reservaciones.Count; i++)
            //    {

            //        reservacion = reservaciones[i];
            //        var fechaStart = reservacion.StartDate.ToString("dddd, dd MMMM yyyy");
            //        var fechaFin = reservacion.EndDate.ToString("dddd, dd MMMM yyyy");
            //        var hotel = reservacion.Hotel;
            //        var hora = reservacion.CheckIn.ToString("hh:mm tt");
            //        var checkOut = reservacion.CheckOut.ToString("hh:mm tt");
            //        var numHab = reservacion.RoomNumber;
            //        var tipoHab = reservacion.RoomType;
            //        var lat = float.Parse(reservacion.Latitude, CultureInfo.InvariantCulture.NumberFormat);
            //        var longi = float.Parse(reservacion.Longitude, CultureInfo.InvariantCulture.NumberFormat);
            //        var info = "Tiene una reservación pendiente del: \n" + fechaStart + "   al   " + fechaFin
            //                   + "\n en el hotel " + hotel + " ,habitación número: " + numHab + "  en una habitación tipo: " + tipoHab + ",\n la hora de check_in es a las " + hora;

            //        await Bot.SendTextMessageAsync(message.Chat.Id,
            //                info);
            //    }
            //    //await Bot.SendLocationAsync(
            //    //    chatId: message.Chat.Id,
            //    //    latitude: lat,
            //    //    longitude: longi);
            //    //--------------------------------------------------
            //    var keyboard1 = new InlineKeyboardMarkup(new[]
            //        {
            //            new []
            //            {
            //                InlineKeyboardButton.WithCallbackData(
            //                    text:"Imagen",
            //                    callbackData:"imagen"
            //                    ),

            //                InlineKeyboardButton.WithCallbackData(
            //                    text:"Ubicacion",
            //                    callbackData:reservacion.Latitude+reservacion.Longitude),

            //            }
            //    });

        }

        //-----------------------
        //switch (message.Text.Split().First())
        //{
        //    case "/Informacion":

        //        //simula que el bot está escribiendo
        //        await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

        //        await Task.Delay(50);

        //        var keyboard1 = new InlineKeyboardMarkup(new[]
        //        {
        //            new []
        //            {
        //                InlineKeyboardButton.WithCallbackData(
        //                    text:"Imagen",
        //                    callbackData:"imagen"
        //                    ),

        //                InlineKeyboardButton.WithCallbackData(
        //                    text:"Ubicacion",
        //                    callbackData:"ubicación"),

        //            },
        //            new []
        //            {
        //                InlineKeyboardButton.WithCallbackData(
        //                    text:"mapita + info",//ubicación + info
        //                    callbackData:"mapita + info"),
        //                 InlineKeyboardButton.WithCallbackData(
        //                    text:"Contacto",//
        //                    callbackData:"contacto"),


        //            },
        //            new[]
        //            {
        //                 InlineKeyboardButton.WithCallbackData(
        //                    text:"Animación",
        //                    callbackData:"animation"),
        //                 InlineKeyboardButton.WithCallbackData(
        //                    text:"Documento",
        //                    callbackData:"document"),



        //            }
        //        });

        //    await Bot.SendTextMessageAsync(
        //        message.Chat.Id,
        //        "Elija una opción",
        //        replyMarkup: keyboard1
        //        );
        //    break;

        //case "/reservacion":

        //    //simula que el bot está escribiendo
        //    await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

        //await Task.Delay(50);

        //            var keyboard2 = new InlineKeyboardMarkup(new[]
        //            {
        //                new []
        //                {
        //                    InlineKeyboardButton.WithCallbackData(
        //                        text:"Imagen2",
        //                        callbackData:"imagen2"),

        //                    InlineKeyboardButton.WithCallbackData(
        //                        text:"Ubicacion",
        //                        callbackData:"ubicación"),

        //                },
        //                new []
        //                {
        //                    InlineKeyboardButton.WithCallbackData(
        //                        text:"mapita + info",//ubicación + info
        //                        callbackData:"mapita + info"),
        //                     InlineKeyboardButton.WithCallbackData(
        //                        text:"Contacto",//
        //                        callbackData:"contacto"),


        //                },
        //                new[]
        //                {
        //                     InlineKeyboardButton.WithCallbackData(
        //                        text:"Animación",
        //                        callbackData:"animation"),
        //                     InlineKeyboardButton.WithCallbackData(
        //                        text:"Documento",
        //                        callbackData:"document"),



        //                }
        //            });

        //            await Bot.SendTextMessageAsync(
        //                message.Chat.Id,
        //                "Elija una opción",
        //                replyMarkup: keyboard2
        //                );
            // break;

            

            
        

        private static async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs callback)
        {
            var keyboard2 = new InlineKeyboardMarkup(new[]
                        {
                        new []
                        {
                            InlineKeyboardButton.WithCallbackData(text:"¿Cuál hotel he reservado?", callbackData:"hotel")
                        },

                        new []
                        {

                            InlineKeyboardButton.WithCallbackData(text:"Dime cuándo realice mi check-in", callbackData:"checkin")
                            //Despues de tal hora
                        },

                        new []
                        {
                            InlineKeyboardButton.WithCallbackData
                            (text:"¿Cuándo realice mi check-out?", callbackData:"checkout")
                            //Entre esta hora y esta
                        },

                        new []
                        {
                         InlineKeyboardButton.WithCallbackData(text:"¿Cuál es el precio de mi reservación?", callbackData:"precio")
                        },

                        new []
                        {
                            InlineKeyboardButton.WithCallbackData(text:"¿Cuál tipo de habitación he reservado?", callbackData:"tipohabitacion")
                        },

                        new []
                        {
                           InlineKeyboardButton.WithCallbackData(text:"¿Cómo llegar al hotel?",
                           callbackData:"ubicacion")
                            //reservacion.Latitude+reservacion.Longitude
                        }
            });

            var keyboard3 = new InlineKeyboardMarkup(new[]
                        {
                        new []
                        {
                            InlineKeyboardButton.WithCallbackData(text:"Sí, porfavor", callbackData:"si")
                        },

                        new []
                        {

                            InlineKeyboardButton.WithCallbackData(text:"No, gracias", callbackData:"no")
                            
                        }
            });

            var keyboard4 = new InlineKeyboardMarkup(new[]
                        {
                        new []
                        {
                            InlineKeyboardButton.WithCallbackData(text:"Sí, porfavor", callbackData:"siIn")
                        },

                        new []
                        {

                            InlineKeyboardButton.WithCallbackData(text:"No, gracias", callbackData:"noIn")

                        }
            });

            var keyboard5 = new InlineKeyboardMarkup(new[]
            {
                        new []
                        {
                            InlineKeyboardButton.WithCallbackData(text:"Sí, porfavor", callbackData:"siOut")
                        },

                        new []
                        {

                            InlineKeyboardButton.WithCallbackData(text:"No, gracias", callbackData:"noOut")

                        }
            });
            var respuesta = callback.CallbackQuery;
            var userName = respuesta.Message.Chat.Username;
            var id = respuesta.Message.Chat.Id;
            var LastName = respuesta.Message.Chat.LastName;
            await Bot.SendChatActionAsync(callback.CallbackQuery.Message.Chat.Id, ChatAction.Typing);

            await Task.Delay(2000);

            switch (respuesta.Data)
            {
                case "hotel":
                    int fkSubreservacion = 0;
                    InfoChatBot info = new InfoChatBot();
                    fkSubreservacion = GetFkSubReservacion(userName);
                    info = GetInfo(fkSubreservacion);
                    await Bot.SendTextMessageAsync(id,
                                "Haciendo memoria recuerdo saber que reservaste en el hotel " + info.Hotel +
                                " para el día " + info.StartDate.ToString("yyyy/MM/dd"));

                    await Bot.SendChatActionAsync(callback.CallbackQuery.Message.Chat.Id, ChatAction.Typing);
                    await Task.Delay(2000);
                    await Bot.SendTextMessageAsync(id,
                                "¿Tienes alguna otra pregunta? Con gusto te atenderé", replyMarkup: keyboard2);
                    break;

                case "checkin":
                    fkSubreservacion = GetFkSubReservacion(userName);
                    info = GetInfo(fkSubreservacion);
                    await Bot.SendTextMessageAsync(id,
                                "Has hecho check-in a las: " + info.CheckIn.ToString("hh:mm tt") + ", incluso se que lo hiciste el día " +
                                "" + info.CheckIn.ToString("yyyy/MM/dd"));


                    await Bot.SendChatActionAsync(callback.CallbackQuery.Message.Chat.Id, ChatAction.Typing);
                    await Task.Delay(2000);


                    await Bot.SendTextMessageAsync(id,
                                "¿Te gustaría saber a que horas se habilita el check-in en tu habitación?", replyMarkup: keyboard4);

                    break;

                case "checkout":
                    fkSubreservacion = GetFkSubReservacion(userName);
                    info = GetInfo(fkSubreservacion);
                    if (info.CheckOut.ToString("hh:mm tt") == DateTime.Now.ToString("hh:mm tt"))
                    {
                        await Bot.SendChatActionAsync(callback.CallbackQuery.Message.Chat.Id, ChatAction.Typing);
                        await Task.Delay(18000);


                        await Bot.SendTextMessageAsync(id,
                                "Al parecer no has hecho check-out. " +
                                " Pero acabo de recordar que hay algo importante que debo decirte... verás el día que deberás de hacer checkout es: " +
                                info.EndDate.ToString("yyyy/MM/dd") +
                                " pero es importante que sepas que tampoco puedes hacer check-out antes de las: " + info.HorarioIn.ToString("hh:mm tt") +
                                " . Ya que antes de esa probablemente están en mantenimiento o no hay nadie atendiendo el sistema" +
                                "... Y bueno a decir verdad dentro de la página principal de Stay n' Chill también puedes reducir" +
                                " tu estadía en el hotel y por ende cancelar tu cuenta " +
                                "el día que desees y esa opción cambiará el día en el cuál debes hacer checkout" +
                                " eso sí, en caso de que tengas amigos invitados que paguen con cuenta propia ellos deberán cancelar sus cuentas" +
                                " el mismo día que finaliza tu estadía, por lo que es importante que se los digas. Por aquello que intentes realizar" +
                                " el check-out y el sistema no te lo permita, es probable que se deba a que uno de ellos no haya pagado su cuenta");


                        await Bot.SendChatActionAsync(callback.CallbackQuery.Message.Chat.Id, ChatAction.Typing);
                        await Task.Delay(20000);


                        await Bot.SendTextMessageAsync(id,
                                    "¿Te gustaría saber a que horas se habilita el check-out en tu habitación?", replyMarkup: keyboard5);

                    }
                    else
                    {
                        await Bot.SendTextMessageAsync(id,
                                "Analizando los datos me he enterado de que has hecho check-out a el día " + info.CheckOut.ToString("yyyy/MM/dd") + " a las " + info.CheckOut.ToString("hh:mm tt"));
                        await Bot.SendChatActionAsync(callback.CallbackQuery.Message.Chat.Id, ChatAction.Typing);

                        await Task.Delay(9000);
                        await Bot.SendTextMessageAsync(id,
                                    "Oye por cierto por aquello de que un día no puedas realizar check-out " +
                                    "es importante que sepas que si tienes amigos invitados con cuentas propias, eres responsable de ellos " +
                                    " ellos deben cancelar su cuenta el mismo día en el cancelarás tu cuenta, y en caso de que ellos no paguen no podrás" +
                                    " realizar check-out");
                        await Bot.SendChatActionAsync(callback.CallbackQuery.Message.Chat.Id, ChatAction.Typing);

                        await Task.Delay(9000);
                        await Bot.SendTextMessageAsync(id,
                                    "¿Quieres saber algo más? Tengo información que te puede ser util", replyMarkup: keyboard2);
                        break;
                    }

                    break;

                case "precio":
                    fkSubreservacion = GetFkSubReservacion(userName);
                    info = GetInfo(fkSubreservacion);

                    await Bot.SendTextMessageAsync(id,
                                "El precio que pagaste por tu reservacion fue " + info.Price);

                    await Task.Delay(3000);
                    await Bot.SendTextMessageAsync(id,
                                "Hoy es un buen día para hacer amigos ¿qué tal si me preguntas algo mas?", replyMarkup: keyboard2);

                    break;

                case "tipohabitacion":
                    fkSubreservacion = GetFkSubReservacion(userName);
                    info = GetInfo(fkSubreservacion);

                    await Bot.SendTextMessageAsync(id,
                                "El tipo de habitación reservada tiene un nombre especial que seguro lograste ver al reservarla es " + info.RoomType +
                                " y en este tipo de habitación está permitido solo " + info.AmountPeople + " persona (s)" + " además tu número de habitación es "
                                 + info.RoomNumber);
                    await Task.Delay(3000);
                    await Task.Delay(3000);
                    await Bot.SendTextMessageAsync(id,
                                "Tengo mas respuestas para ofrecer, ¿qué más quieres saber?", replyMarkup: keyboard2);

                    break;

                case "ubicacion":
                    fkSubreservacion = GetFkSubReservacion(userName);
                    info = GetInfo(fkSubreservacion);
                    float lat = Convert.ToSingle(info.Latitude);
                    float longi = Convert.ToSingle(info.Longitude); 


                    await Bot.SendLocationAsync(
                            chatId:id,
                            latitude: lat,
                            longitude: longi);

                    //Setee la ubicacion


                    await Bot.SendTextMessageAsync(id,
                                "Lo siento ha ocurrido un error, por el momento no tengo acceso a esa infomación, " +
                                "pero que te parece hacerme otra pregunta," +
                                " estoy a tus servicios ", replyMarkup: keyboard2);
                    break;
            }
            //var hotel = "Marriot" + "en la siguiente fecha";
            //var fecha = "2019-12-10";
            //var msgHotel = "Hola, tiene una reservación en el hotel" + hotel;


            //var final = "la hora de check in es: 11 am";
            //if (callbackQuery.Data == reservacion.Latitude + reservacion.Longitude)
            //{
            //    var lat = reservacion.Latitude;
            //    var longi = reservacion.Latitude;

            //}

            //switch (callbackQuery.Data)
            //{
            //    case "keyboard":
            //        ReplyKeyboardMarkup tipoContacto = new[]
            //        {
            //            new[] {"Opción 1","Opción 2" },
            //            new[] {"Opción 1","Opción 2" },
            //        };

            //        await Bot.SendTextMessageAsync(
            //            chatId: callbackQuery.Message.Chat.Id,
            //            text: "Keyboard personalizado",
            //            replyMarkup: tipoContacto
            //            );
            //        break;
            //    //case reservacion.Latitude + reservacion.Longitude:
            //    //     await Bot.SendLocationAsync(
            //    //        chatId: callbackQuery.Message.Chat.Id,
            //    //        latitude: lat,
            //    //        longitude: longi);
            //    //    break;

            //    case "info":
            //        await Bot.SendPhotoAsync(
            //            chatId: callbackQuery.Message.Chat.Id,
            //            photo: "https://cdn.vox-cdn.com/thumbor/ZxsqpInKWEvGcFRsnNJhBTwkQGA=/0x0:4200x2513/920x613/filters:focal(1764x921:2436x1593):format(webp)/cdn.vox-cdn.com/uploads/chorus_image/image/62602032/GettyImages_801081276.0.jpg");
            //        break;

            //    case "animation":
            //        await Bot.SendAnimationAsync(
            //            chatId: callbackQuery.Message.Chat.Id,
            //            animation: "");
            //        break;

            //    case "video":
            //        await Bot.SendVideoAsync(
            //            chatId: callbackQuery.Message.Chat.Id,
            //            video: "https://elmundo.sv/tom-brady-se-lanza-junto-a-su-hija-de-un-acantilado/");
            //        break;

            //    case "document":
            //        await Bot.SendDocumentAsync(
            //            chatId: callbackQuery.Message.Chat.Id,
            //            document: "");
            //        break;

            //    case "formato":
            //        await Bot.SendTextMessageAsync(
            //            chatId: callbackQuery.Message.Chat.Id,
            //            text: "<b>bold</b>,<strong>bold</strong>",
            //            parseMode: ParseMode.Html);
            //        await Bot.SendTextMessageAsync(
            //            chatId: callbackQuery.Message.Chat.Id,
            //            text: "< i > italic </ i >,< em > italic </ em > ",
            //            parseMode: ParseMode.Html);
            //        break;

            //    case "reply":
            //        await Bot.SendTextMessageAsync(
            //            chatId: callbackQuery.Message.Chat.Id,
            //            text: "ID" + callbackQuery.Message.MessageId + " - " + callbackQuery.Message.Text,
            //            replyToMessageId: callbackQuery.Message.MessageId);
            //        break;

            //    case "contacto":
            //        await Bot.SendContactAsync(
            //            chatId: callbackQuery.Message.Chat.Id,
            //            phoneNumber: fecha,
            //            firstName: "lala",
            //            lastName: final
            //            );
            //        break;

            //    case "forceReplay":
            //        await Bot.SendTextMessageAsync(
            //            chatId: callbackQuery.Message.Chat.Id,
            //            text: "Rorzar respuesta de este mensaje ",
            //            replyMarkup: new ForceReplyMarkup());
            //        break;

            //    case "reenviar":
            //        await Bot.ForwardMessageAsync(
            //            chatId: callbackQuery.Message.Chat.Id,
            //            fromChatId: "Rorzar respuesta de este mensaje ",
            //            messageId: callbackQuery.Message.MessageId);
            //        break;



            //}
        }

        private static async void BotOnCallbackQueryReceived2(object sender, CallbackQueryEventArgs callback)
        {
            var keyboard2 = new InlineKeyboardMarkup(new[]
                        {
                        new []
                        {
                            InlineKeyboardButton.WithCallbackData(text:"¿Cuál hotel he reservado?", callbackData:"hotel")
                        },

                        new []
                        {

                            InlineKeyboardButton.WithCallbackData(text:"¿Dime cuándo realicé mi check-in?", callbackData:"checkin")
                            //Despues de tal hora
                        },

                        new []
                        {
                            InlineKeyboardButton.WithCallbackData
                            (text:"¿Cuál es la hora en la que puedo realizar mi check-out?", callbackData:"checkout")
                            //Entre esta hora y esta
                        },

                        new []
                        {
                         InlineKeyboardButton.WithCallbackData(text:"¿Cuál es el precio de mi reservación?", callbackData:"precio")
                        },

                        new []
                        {
                            InlineKeyboardButton.WithCallbackData(text:"¿Cuál tipo de habitación he reservado?", callbackData:"tipohabitacion")
                        },

                        new []
                        {
                           InlineKeyboardButton.WithCallbackData(text:"¿Cómo llegar al hotel?",
                           callbackData:"ubicacion")
                            //reservacion.Latitude+reservacion.Longitude
                        }
            });

            var respuesta = callback.CallbackQuery;
            var userName = respuesta.Message.Chat.Username;
            var id = respuesta.Message.Chat.Id;
            var LastName = respuesta.Message.Chat.LastName;
            await Bot.SendChatActionAsync(callback.CallbackQuery.Message.Chat.Id, ChatAction.Typing);

            await Task.Delay(2000);

            switch (respuesta.Data)
            {
                case "si":
                    int fkSubreservacion = 0;

                    fkSubreservacion = GetFkSubReservacion(userName);
                    InfoChatBot info = new InfoChatBot();
                    info = GetInfo(fkSubreservacion);

                    await Bot.SendTextMessageAsync(id,
                                "El dia del desalojo es");
                    await Bot.SendChatActionAsync(callback.CallbackQuery.Message.Chat.Id, ChatAction.Typing);

                    await Task.Delay(2000);
                    await Bot.SendTextMessageAsync(id,
                                "¿Tienes alguna otra pregunta? Con gusto te atenderé", replyMarkup: keyboard2);
                    break;

                case "siIn":
                    fkSubreservacion = GetFkSubReservacion(userName);

                    info = GetInfo(fkSubreservacion);
                    await Bot.SendChatActionAsync(callback.CallbackQuery.Message.Chat.Id, ChatAction.Typing);

                    await Task.Delay(9000);
                    await Bot.SendTextMessageAsync(id,
                                "¡Claro! Es una buena pregunta, ya que los recepcionistas del hotel permanecen solo a ciertas horas " +
                                "atentiendo, por lo que es importante que sepas a qué horas se habilita el check-in en tu habitación.");
                    await Bot.SendChatActionAsync(callback.CallbackQuery.Message.Chat.Id, ChatAction.Typing);

                    await Task.Delay(9000);
                    await Bot.SendTextMessageAsync(id,
                                "Para un caso como el tuyo el check-in se debe hacer a las: " + info.HorarioIn.ToString("hh:mm tt"));
                    await Bot.SendChatActionAsync(callback.CallbackQuery.Message.Chat.Id, ChatAction.Typing);

                    await Task.Delay(5000);
                    await Bot.SendTextMessageAsync(id,
                                "Te aclaro que estoy para ayudarte entonces que no te de pena hacerme otra pregunta" +
                                " estoy disponible para ti", replyMarkup: keyboard2);
                    break;

                case "noIn":
                    fkSubreservacion = GetFkSubReservacion(userName);
                    info = GetInfo(fkSubreservacion);

                    await Bot.SendTextMessageAsync(id,
                                "Nada que agradecer aquí, yo realmente hago mi trabajo.");

                    await Bot.SendChatActionAsync(callback.CallbackQuery.Message.Chat.Id, ChatAction.Typing);

                    await Task.Delay(2000);
                    await Bot.SendTextMessageAsync(id,
                                "¿Tienes alguna otra pregunta? Con gusto te atenderé", replyMarkup: keyboard2);

                    break;

                case "siOut":
                    fkSubreservacion = GetFkSubReservacion(userName);

                    info = GetInfo(fkSubreservacion);
                    await Bot.SendChatActionAsync(callback.CallbackQuery.Message.Chat.Id, ChatAction.Typing);

                    await Task.Delay(9000);
                    await Bot.SendTextMessageAsync(id,
                                "Como antes te mencioné hay horas establecidas para hacer check-out, primero debe ser la fecha en la que se te indicó." +
                                " Y además deberá ser entre los a horarios de " + info.HorarioIn.ToString("hh: mm tt") +
                                " a " + info.HorarioOut.ToString("hh: mm tt"));
                    await Bot.SendChatActionAsync(callback.CallbackQuery.Message.Chat.Id, ChatAction.Typing);

                    await Task.Delay(8000);
                    await Bot.SendTextMessageAsync(id,
                                "Para un caso como el tuyo el check-out se debe hacer a las: " + info.HorarioOut.ToString("hh:mm tt"));
                    await Bot.SendChatActionAsync(callback.CallbackQuery.Message.Chat.Id, ChatAction.Typing);

                    await Task.Delay(2000);
                    await Bot.SendTextMessageAsync(id,
                                "Preguntáme otra cosa si gustas", replyMarkup: keyboard2);
                    break;

                case "noOut":
                    fkSubreservacion = GetFkSubReservacion(userName);
                    info = GetInfo(fkSubreservacion);

                    await Bot.SendTextMessageAsync(id,
                                "No te preocupes, para mi es un placer.");

                    await Bot.SendChatActionAsync(callback.CallbackQuery.Message.Chat.Id, ChatAction.Typing);

                    await Task.Delay(2000);
                    await Bot.SendTextMessageAsync(id,
                                "¿Qué mas quieres averiguar acerca de tu estadía en el hotel?", replyMarkup: keyboard2);

                    break;

                case "no":

                    fkSubreservacion = GetFkSubReservacion(userName);
                    info = GetInfo(fkSubreservacion);

                    await Bot.SendTextMessageAsync(id,
                                "Gracias a usted mas bien.", replyMarkup: keyboard2);
                    await Bot.SendChatActionAsync(callback.CallbackQuery.Message.Chat.Id, ChatAction.Typing);

                    await Task.Delay(300);
                    await Bot.SendTextMessageAsync(id,
                                "¿Se te ofrece algo más?", replyMarkup: keyboard2);
                    break;
            }
        }

        private static void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs)
        {
            Console.WriteLine("Received error: {0} - {1}",
                receiveErrorEventArgs.ApiRequestException.ErrorCode,
                receiveErrorEventArgs.ApiRequestException.Message);
        }
    }
}
