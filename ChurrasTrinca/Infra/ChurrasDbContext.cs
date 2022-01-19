﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public class ChurrasDbContext : DbContext
    {
        public virtual DbSet<Churrasco> Churrascos { get; set; }
        public virtual DbSet<Participante> Participantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ModelConfiguration.ChurrascoModelConfiguration());
            modelBuilder.ApplyConfiguration(new ModelConfiguration.ParticipantesModelConfiguration());
        }


    }


}