﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Design;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MicrosfferToDo.DAL
{
    /// <summary>
    /// Classe que serve para o contexto do web api
    /// Trabalha a conexão com o banco através do nome da base
    /// <author>Mauricio Junior</author>
    /// </summary>
    public class DBContextToDo : DbContext
    {
        /// <summary>
        /// Construtor da classe
        /// </summary>
        public DBContextToDo() : base("name=ConexaoPadrao")
        {
            Database.SetInitializer<DBContextToDo>(null);
        }

        /// <summary>
        /// Método da convenção para não deixar o nome da tabela ficar no plural
        /// </summary>
        /// <param name="modelBuilder">DbModelBuilder</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }

        /// <summary>
        /// Nome da tabela do banco de dados criada dinamicamente
        /// </summary>
        public System.Data.Entity.DbSet<MicrosfferToDo.Models.AtividadesToDo> AtividadesToDo { get; set; }
    }
}