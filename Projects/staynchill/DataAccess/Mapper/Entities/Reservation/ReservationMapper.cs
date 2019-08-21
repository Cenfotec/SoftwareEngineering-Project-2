using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class ReservationMapper : EntityMapperGeneric
    {
        public ReservationMapper() : base(dB_PR_BASE_NAME: "RESERVACIONES") { }

        public SqlOperation GetCreateReservationReturn(Reservation reservation)
        {
            var operation = new SqlOperation { ProcedureName = $"CRE_RESERVACIONES_RETURN_PR" };
            operation.AddIntParam("ID", reservation.Id);
            operation.AddIntParam("FK_USUARIO", reservation.FkUser);
            operation.AddIntParam("FK_HOTEL", reservation.FkHotel);
            operation.AddDateParam("FECHA_INCIO", reservation.StartDate);
            operation.AddDateParam("FECHA_FIN", reservation.EndDate);
            operation.AddDecimalParam("PRECIO", reservation.Price);
            operation.AddIntParam("FK_HABITACION", reservation.FKRoom);
            operation.AddIntParam("FK_RESERVACION", reservation.FkReservation);
            operation.AddIntParam("FK_SUBRESERVACION", reservation.FkSubreservation);
            operation.AddVarcharParam("ESTADO", reservation.State);
            return operation;
        }

        public SqlOperation GetCreateSubreservation(Reservation reservation, User user)
        {
            var operation = new SqlOperation { ProcedureName = $"CRE_SUBRESERVACION_INVITADO_PR" };
            operation.AddIntParam("ID", reservation.Id);
            operation.AddIntParam("FK_USUARIO", reservation.FkUser);
            operation.AddIntParam("FK_HOTEL", reservation.FkHotel);
            operation.AddDateParam("FECHA_INCIO", reservation.StartDate);
            operation.AddDateParam("FECHA_FIN", reservation.EndDate);
            operation.AddDecimalParam("PRECIO", reservation.Price);
            operation.AddIntParam("FK_HABITACION", reservation.FKRoom);
            operation.AddIntParam("FK_RESERVACION", reservation.FkReservation);
            operation.AddIntParam("FK_SUBRESERVACION", reservation.FkSubreservation);
            operation.AddVarcharParam("ESTADO", reservation.State);
            operation.AddIntParam("ID_USUARIO_INVITADO", user.Id);
            return operation;
        }

        public SqlOperation GetRetAllByIdStatement(int usuario)
        {
            var operation = new SqlOperation { ProcedureName = $"RET_RESERVACIONES_BY_USER_ID_PR" };
            operation.AddIntParam("USER",usuario);
            return operation;
        }
    }
}
