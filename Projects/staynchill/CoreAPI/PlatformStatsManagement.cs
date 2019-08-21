using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class PlatformStatsManagement
    {
        private PlatformStatsCrud crudPlatStats;

        public PlatformStatsManagement() => crudPlatStats = new PlatformStatsCrud();

        public PlatformStats RetAllPromGanaciasComision() => crudPlatStats.RetAllPromGanaciasComision<PlatformStats>();

        public PlatformStats RetAllPromGanaciasMembresia() => crudPlatStats.RetAllPromGanaciasMembresia<PlatformStats>();

        public PlatformStats RetAllGanaciasComision() => crudPlatStats.RetAllGanaciasComision<PlatformStats>();
        
        public PlatformStats RetAllGanaciasMembresia() => crudPlatStats.RetAllGanaciasMembresia<PlatformStats>();

        public PlatformStats RetAllGanaciasPlataforma() => crudPlatStats.RetAllGanaciasPlataforma<PlatformStats>();

        public PlatformStats RetAllHoteles() => crudPlatStats.RetAllHoteles<PlatformStats>();

        public PlatformStats RetAllMembresiaPlataforma() => crudPlatStats.RetAllMembresiaPlataforma<PlatformStats>();

        public PlatformStats RetAllUsuarios() => crudPlatStats.RetAllUsuarios<PlatformStats>();

    }
}