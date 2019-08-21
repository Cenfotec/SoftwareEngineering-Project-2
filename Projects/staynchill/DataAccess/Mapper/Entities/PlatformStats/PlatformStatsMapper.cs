using DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.Entities.PlatformStats
{
    public class PlatformStatsMapper : EntityMapperGeneric
    {
        public PlatformStatsMapper() : base("PLATFORM_STATICS") { }

        public SqlOperation GetRetAllPromGanaciasComision()
        {
            var operation = new SqlOperation { ProcedureName = $"CALC_PROMEDIO_GANANCIAS_COMISIONES_PLATAFORMA_PR" };
            return operation;
        }

        public SqlOperation GetRetAllPromGanaciasMembresia()
        {
            var operation = new SqlOperation { ProcedureName = $"CALC_PROMEDIO_GANANCIAS_MEMBRESIAS_PLATAFORMA_PR" };
            return operation;
        }

        public SqlOperation GetRetAllGanaciasComision()
        {
            var operation = new SqlOperation { ProcedureName = $"CALC_TOTAL_GANANCIAS_COMISIONES_PLATAFORMA_PR" };
            return operation;
        }

        public SqlOperation GetRetAllGanaciasMembresia()
        {
            var operation = new SqlOperation { ProcedureName = $"CALC_TOTAL_GANANCIAS_MEMBRESIA_PLATAFORMA_PR" };
            return operation;
        }

        public SqlOperation GetRetAllGanaciasPlataforma(){
            var operation = new SqlOperation { ProcedureName = $"[CALC_TOTAL_GANANCIAS_PLATAFORMA_PR]" };
            return operation;
        }

        public SqlOperation GetRetAllHoteles() {
            var operation = new SqlOperation { ProcedureName = $"[CALC_TOTAL_HOTELES_PLATAFORMA_PR]" };
            return operation;
        }

        public SqlOperation GetRetAllMembresiaPlataforma() {
            var operation = new SqlOperation { ProcedureName = $"[CALC_TOTAL_MEMBRESIAS_PLATAFORMA_PR]" };
            return operation;
        }

        public SqlOperation GetRetAllUsuarios() {
            var operation = new SqlOperation { ProcedureName = $"[CALC_TOTAL_USUARIOS_PLATAFORMA_PR]" };
            return operation;
        }

    }
}