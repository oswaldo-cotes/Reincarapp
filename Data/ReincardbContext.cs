using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Reincarapp.Models.reincardb;

namespace Reincarapp.Data
{
    public partial class reincardbContext : DbContext
    {
        public reincardbContext()
        {
        }

        public reincardbContext(DbContextOptions<reincardbContext> options) : base(options)
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Reincarapp.Models.reincardb.ActCampoCoomultrasan>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.AsigGestAux>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.Bktarea>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.CdRepetidasPersona>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.Citibank4>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaAgrup>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.Comparendos>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.ConsCvC1>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.ConsCvC12>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.ConsCvC13>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.ConsCvC14>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.ConsCvC1Credidos>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.ConsCvC1Progresa>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.CoomTempcd>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.Coomultdic>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.Docs>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.GestionesCoomuTemp>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.InfSaludcoop>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.JamarJuridica>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.ResEve>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.ResEveC3>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.TempEveToDelete>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.TempIdcoomulstrasan>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.TempIdcoomulstrasan2>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.TmpClienteDeudaEstado>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.TmpDatoPerBor>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.TmpDecEst>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.TmpEventoSaludcoop>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.TmpGestCooJur>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.TmpUsuario>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.Tmpcambiotip>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.ZzzProcAvv>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas>().HasNoKey();

            builder.Entity<Reincarapp.Models.reincardb.Acueducto>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Acueducto)
              .HasForeignKey(i => i.Id_Cliente_Deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.AsignacionGestor>()
              .HasOne(i => i.Persona)
              .WithMany(i => i.AsignacionGestor)
              .HasForeignKey(i => i.Id_Persona)
              .HasPrincipalKey(i => i.Id_Persona);

            builder.Entity<Reincarapp.Models.reincardb.AsignacionGestor>()
              .HasOne(i => i.Usuario)
              .WithMany(i => i.AsignacionGestor)
              .HasForeignKey(i => i.Id_Usuario)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.AsignacionGestor>()
              .HasOne(i => i.Usuario1)
              .WithMany(i => i.AsignacionGestor1)
              .HasForeignKey(i => i.Id_Usuario_Asignado)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.Avvillas>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Avvillas)
              .HasForeignKey(i => i.Id_Cliente_Deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Avvillasbuc>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Avvillasbuc)
              .HasForeignKey(i => i.Id_Cliente_Deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Bancobogota>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Bancobogota)
              .HasForeignKey(i => i.id_cliente_deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Bancoomeva>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Bancoomeva)
              .HasForeignKey(i => i.id_cliente_deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Base>()
              .HasOne(i => i.Cliente)
              .WithMany(i => i.Base)
              .HasForeignKey(i => i.IdCliente)
              .HasPrincipalKey(i => i.Id_Cliente);

            builder.Entity<Reincarapp.Models.reincardb.Base>()
              .HasOne(i => i.Tipobase)
              .WithMany(i => i.Base)
              .HasForeignKey(i => i.IdTipoBase)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Reincarapp.Models.reincardb.Base>()
              .HasOne(i => i.Usuario)
              .WithMany(i => i.Base)
              .HasForeignKey(i => i.IdUsuario)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.Base>()
              .HasOne(i => i.Usuario1)
              .WithMany(i => i.Base1)
              .HasForeignKey(i => i.IdUsuarioAct)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.BaseJuridica>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.BaseJuridica)
              .HasForeignKey(i => i.id_cliente_deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Basecampo>()
              .HasOne(i => i.Base)
              .WithMany(i => i.Basecampo)
              .HasForeignKey(i => i.BaseId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Reincarapp.Models.reincardb.Basecampo>()
              .HasOne(i => i.Campoclave)
              .WithMany(i => i.Basecampo)
              .HasForeignKey(i => i.CampoClaveId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Reincarapp.Models.reincardb.Bloqueocontacto>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Bloqueocontacto)
              .HasForeignKey(i => i.IdClienteDeuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Bloqueocontacto>()
              .HasOne(i => i.Evento)
              .WithMany(i => i.Bloqueocontacto)
              .HasForeignKey(i => i.IdEvento)
              .HasPrincipalKey(i => i.Id_Evento);

            builder.Entity<Reincarapp.Models.reincardb.Bloqueocontacto>()
              .HasOne(i => i.Usuario)
              .WithMany(i => i.Bloqueocontacto)
              .HasForeignKey(i => i.IdUsuario)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.CampoHonorario>()
              .HasOne(i => i.Cliente)
              .WithMany(i => i.CampoHonorario)
              .HasForeignKey(i => i.id_cliente)
              .HasPrincipalKey(i => i.Id_Cliente);

            builder.Entity<Reincarapp.Models.reincardb.Censprejuridico>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Censprejuridico)
              .HasForeignKey(i => i.IdClienteDeuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Checprejuridico>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Checprejuridico)
              .HasForeignKey(i => i.IdClienteDeuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Citibank>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Citibank)
              .HasForeignKey(i => i.Id_Cliente_Deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Citibank2>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Citibank2)
              .HasForeignKey(i => i.Id_Cliente_Deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.ClasificacionAdicional>()
              .HasOne(i => i.Cliente)
              .WithMany(i => i.ClasificacionAdicional)
              .HasForeignKey(i => i.Id_Cliente)
              .HasPrincipalKey(i => i.Id_Cliente);

            builder.Entity<Reincarapp.Models.reincardb.ClasificacionAdicional>()
              .HasOne(i => i.TipoClasificacionAdicional)
              .WithMany(i => i.ClasificacionAdicional)
              .HasForeignKey(i => i.Id_Tipo_Clasificacion_Adicional)
              .HasPrincipalKey(i => i.Id_Tipo_Clasificacion_Adicional);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeuda>()
              .HasOne(i => i.Asignacion)
              .WithMany(i => i.ClienteDeuda)
              .HasForeignKey(i => i.Id_Asignacion)
              .HasPrincipalKey(i => i.Id_Asignacion);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeuda>()
              .HasOne(i => i.Cliente)
              .WithMany(i => i.ClienteDeuda)
              .HasForeignKey(i => i.Id_Cliente)
              .HasPrincipalKey(i => i.Id_Cliente);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeuda>()
              .HasOne(i => i.EstadoClienteDeuda)
              .WithMany(i => i.ClienteDeuda)
              .HasForeignKey(i => i.Id_Estado_Cliente_Deuda)
              .HasPrincipalKey(i => i.Id_Estado_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeuda>()
              .HasOne(i => i.ResultadoEvento)
              .WithMany(i => i.ClienteDeuda)
              .HasForeignKey(i => i.Id_Mejor_Gestion)
              .HasPrincipalKey(i => i.Id_Resultado_Evento);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeuda>()
              .HasOne(i => i.Persona)
              .WithMany(i => i.ClienteDeuda)
              .HasForeignKey(i => i.Id_Persona)
              .HasPrincipalKey(i => i.Id_Persona);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeuda>()
              .HasOne(i => i.ResultadoEvento1)
              .WithMany(i => i.ClienteDeuda1)
              .HasForeignKey(i => i.Id_Ultima_Gestion)
              .HasPrincipalKey(i => i.Id_Resultado_Evento);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeuda>()
              .HasOne(i => i.Usuario)
              .WithMany(i => i.ClienteDeuda)
              .HasForeignKey(i => i.Id_Usuario)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeuda>()
              .HasOne(i => i.Usuario1)
              .WithMany(i => i.ClienteDeuda1)
              .HasForeignKey(i => i.Id_Usuario_Asignado)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaCons>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.ClienteDeudaCons)
              .HasForeignKey(i => i.id_cliente_deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaCons>()
              .HasOne(i => i.Evento)
              .WithMany(i => i.ClienteDeudaCons)
              .HasForeignKey(i => i.id_evento_mejor_gestion)
              .HasPrincipalKey(i => i.Id_Evento);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaCons>()
              .HasOne(i => i.Evento1)
              .WithMany(i => i.ClienteDeudaCons1)
              .HasForeignKey(i => i.id_evento_ultima_gestion)
              .HasPrincipalKey(i => i.Id_Evento);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaDato>()
              .HasOne(i => i.Cliente)
              .WithMany(i => i.ClienteDeudaDato)
              .HasForeignKey(i => i.Id_Cliente)
              .HasPrincipalKey(i => i.Id_Cliente);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaDato>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.ClienteDeudaDato)
              .HasForeignKey(i => i.Id_Cliente_Deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaHonorario>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.ClienteDeudaHonorario)
              .HasForeignKey(i => i.id_cliente_deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaHonorario>()
              .HasOne(i => i.Evento)
              .WithMany(i => i.ClienteDeudaHonorario)
              .HasForeignKey(i => i.id_evento_fin)
              .HasPrincipalKey(i => i.Id_Evento);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaHonorario>()
              .HasOne(i => i.Usuario)
              .WithMany(i => i.ClienteDeudaHonorario)
              .HasForeignKey(i => i.id_usuario)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaUsuario>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.ClienteDeudaUsuario)
              .HasForeignKey(i => i.Id_Cliente_Deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaUsuario>()
              .HasOne(i => i.Usuario)
              .WithMany(i => i.ClienteDeudaUsuario)
              .HasForeignKey(i => i.Id_Usuario)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaUsuario>()
              .HasOne(i => i.Usuario1)
              .WithMany(i => i.ClienteDeudaUsuario1)
              .HasForeignKey(i => i.Id_Usuario_Asignado)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.CoomultrasanCastigo>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.CoomultrasanCastigo)
              .HasForeignKey(i => i.id_cliente_deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.CoomultrasanJuridica>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.CoomultrasanJuridica)
              .HasForeignKey(i => i.id_cliente_deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.CoomultrasanLey79>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.CoomultrasanLey79)
              .HasForeignKey(i => i.id_cliente_deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.CoomultrasanTemprana>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.CoomultrasanTemprana)
              .HasForeignKey(i => i.Id_Cliente_Deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Coopetrol>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Coopetrol)
              .HasForeignKey(i => i.id_cliente_deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Correspondencia>()
              .HasOne(i => i.Evento)
              .WithMany(i => i.Correspondencia)
              .HasForeignKey(i => i.Id_Evento)
              .HasPrincipalKey(i => i.Id_Evento);

            builder.Entity<Reincarapp.Models.reincardb.Credidos>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Credidos)
              .HasForeignKey(i => i.Id_Cliente_Deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Credivalores>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Credivalores)
              .HasForeignKey(i => i.Id_Cliente_Deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Credivalores2>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Credivalores2)
              .HasForeignKey(i => i.Id_Cliente_Deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Credivaloresalt>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Credivaloresalt)
              .HasForeignKey(i => i.Id_Cliente_Deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.DatoClienteDeuda>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.DatoClienteDeuda)
              .HasForeignKey(i => i.Id_Cliente_Deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.DatoPersona>()
              .HasOne(i => i.Departamento)
              .WithMany(i => i.DatoPersona)
              .HasForeignKey(i => i.Id_Departamento)
              .HasPrincipalKey(i => i.Id_Departamento);

            builder.Entity<Reincarapp.Models.reincardb.DatoPersona>()
              .HasOne(i => i.Municipio)
              .WithMany(i => i.DatoPersona)
              .HasForeignKey(i => i.Id_Municipio)
              .HasPrincipalKey(i => i.Id_Municipio);

            builder.Entity<Reincarapp.Models.reincardb.DatoPersona>()
              .HasOne(i => i.Persona)
              .WithMany(i => i.DatoPersona)
              .HasForeignKey(i => i.Id_Persona)
              .HasPrincipalKey(i => i.Id_Persona);

            builder.Entity<Reincarapp.Models.reincardb.DatoPersona>()
              .HasOne(i => i.TipoDatoPersona)
              .WithMany(i => i.DatoPersona)
              .HasForeignKey(i => i.Id_Tipo_Dato_Persona)
              .HasPrincipalKey(i => i.Id_Tipo_Dato_Persona);

            builder.Entity<Reincarapp.Models.reincardb.DatoPersona>()
              .HasOne(i => i.TipoVia)
              .WithMany(i => i.DatoPersona)
              .HasForeignKey(i => i.Id_Tipo_Via)
              .HasPrincipalKey(i => i.Id_Tipo_Via);

            builder.Entity<Reincarapp.Models.reincardb.DatoPersona>()
              .HasOne(i => i.ZonaUbicacion)
              .WithMany(i => i.DatoPersona)
              .HasForeignKey(i => i.Id_Zona_Ubicacion)
              .HasPrincipalKey(i => i.Id_Zona_Ubicacion);

            builder.Entity<Reincarapp.Models.reincardb.DatoPersona>()
              .HasOne(i => i.ZonaUbicacion1)
              .WithMany(i => i.DatoPersona1)
              .HasForeignKey(i => i.Id_Zona_Ubicacion_1)
              .HasPrincipalKey(i => i.Id_Zona_Ubicacion);

            builder.Entity<Reincarapp.Models.reincardb.DatoPersona>()
              .HasOne(i => i.ZonaUbicacion2)
              .WithMany(i => i.DatoPersona2)
              .HasForeignKey(i => i.Id_Zona_Ubicacion_2)
              .HasPrincipalKey(i => i.Id_Zona_Ubicacion);

            builder.Entity<Reincarapp.Models.reincardb.DatoPersona>()
              .HasOne(i => i.ZonaUbicacion3)
              .WithMany(i => i.DatoPersona3)
              .HasForeignKey(i => i.Id_Zona_Ubicacion_3)
              .HasPrincipalKey(i => i.Id_Zona_Ubicacion);

            builder.Entity<Reincarapp.Models.reincardb.DecisionEstado>()
              .HasOne(i => i.Cliente)
              .WithMany(i => i.DecisionEstado)
              .HasForeignKey(i => i.Id_Cliente)
              .HasPrincipalKey(i => i.Id_Cliente);

            builder.Entity<Reincarapp.Models.reincardb.DecisionEstado>()
              .HasOne(i => i.EstadoClienteDeuda)
              .WithMany(i => i.DecisionEstado)
              .HasForeignKey(i => i.Id_Estado_Cliente_Deuda)
              .HasPrincipalKey(i => i.Id_Estado_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.DecisionEstado>()
              .HasOne(i => i.ResultadoEvento)
              .WithMany(i => i.DecisionEstado)
              .HasForeignKey(i => i.Id_Resultado_Evento)
              .HasPrincipalKey(i => i.Id_Resultado_Evento);

            builder.Entity<Reincarapp.Models.reincardb.DecisionEstado>()
              .HasOne(i => i.TipoComunicacion)
              .WithMany(i => i.DecisionEstado)
              .HasForeignKey(i => i.Id_Tipo_Comunicacion)
              .HasPrincipalKey(i => i.Id_Tipo_Comunicacion);

            builder.Entity<Reincarapp.Models.reincardb.DecisionEstado>()
              .HasOne(i => i.Usuario)
              .WithMany(i => i.DecisionEstado)
              .HasForeignKey(i => i.Id_Usuario_Creador)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.Evento>()
              .HasOne(i => i.Aspnetusers)
              .WithMany(i => i.Evento)
              .HasForeignKey(i => i.CreatedBy)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Reincarapp.Models.reincardb.Evento>()
              .HasOne(i => i.ClasificacionAdicional)
              .WithMany(i => i.Evento)
              .HasForeignKey(i => i.Id_Clasificacion_Adicional)
              .HasPrincipalKey(i => i.Id_Clasificacion_Adicional);

            builder.Entity<Reincarapp.Models.reincardb.Evento>()
              .HasOne(i => i.ClasificacionAdicional1)
              .WithMany(i => i.Evento1)
              .HasForeignKey(i => i.Id_Clasificacion_Adicional_1)
              .HasPrincipalKey(i => i.Id_Clasificacion_Adicional);

            builder.Entity<Reincarapp.Models.reincardb.Evento>()
              .HasOne(i => i.ClasificacionAdicional2)
              .WithMany(i => i.Evento2)
              .HasForeignKey(i => i.Id_Clasificacion_Adicional_2)
              .HasPrincipalKey(i => i.Id_Clasificacion_Adicional);

            builder.Entity<Reincarapp.Models.reincardb.Evento>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Evento)
              .HasForeignKey(i => i.Id_Cliente_Deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Evento>()
              .HasOne(i => i.DatoPersona)
              .WithMany(i => i.Evento)
              .HasForeignKey(i => i.Id_Dato_Persona)
              .HasPrincipalKey(i => i.Id_Dato_Persona);

            builder.Entity<Reincarapp.Models.reincardb.Evento>()
              .HasOne(i => i.ClasificacionAdicional3)
              .WithMany(i => i.Evento3)
              .HasForeignKey(i => i.Id_Marca)
              .HasPrincipalKey(i => i.Id_Clasificacion_Adicional);

            builder.Entity<Reincarapp.Models.reincardb.Evento>()
              .HasOne(i => i.ClasificacionAdicional4)
              .WithMany(i => i.Evento4)
              .HasForeignKey(i => i.Id_Medio_De_Pago)
              .HasPrincipalKey(i => i.Id_Clasificacion_Adicional);

            builder.Entity<Reincarapp.Models.reincardb.Evento>()
              .HasOne(i => i.ClasificacionAdicional5)
              .WithMany(i => i.Evento5)
              .HasForeignKey(i => i.Id_Razon_Mora)
              .HasPrincipalKey(i => i.Id_Clasificacion_Adicional);

            builder.Entity<Reincarapp.Models.reincardb.Evento>()
              .HasOne(i => i.ClasificacionAdicional6)
              .WithMany(i => i.Evento6)
              .HasForeignKey(i => i.Id_Razones_Posible_Extracto)
              .HasPrincipalKey(i => i.Id_Clasificacion_Adicional);

            builder.Entity<Reincarapp.Models.reincardb.Evento>()
              .HasOne(i => i.ResultadoEvento)
              .WithMany(i => i.Evento)
              .HasForeignKey(i => i.Id_Resultado_Evento)
              .HasPrincipalKey(i => i.Id_Resultado_Evento);

            builder.Entity<Reincarapp.Models.reincardb.Evento>()
              .HasOne(i => i.Tarea)
              .WithMany(i => i.Evento)
              .HasForeignKey(i => i.Id_Tarea)
              .HasPrincipalKey(i => i.Id_Tarea);

            builder.Entity<Reincarapp.Models.reincardb.Evento>()
              .HasOne(i => i.TipoComunicacion)
              .WithMany(i => i.Evento)
              .HasForeignKey(i => i.Id_Tipo_Comunicacion)
              .HasPrincipalKey(i => i.Id_Tipo_Comunicacion);

            builder.Entity<Reincarapp.Models.reincardb.Evento>()
              .HasOne(i => i.Usuario)
              .WithMany(i => i.Evento)
              .HasForeignKey(i => i.Id_Usuario)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.Evento>()
              .HasOne(i => i.Usuario1)
              .WithMany(i => i.Evento1)
              .HasForeignKey(i => i.Id_Usuario_Evento)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.Evento>()
              .HasOne(i => i.Aspnetusers1)
              .WithMany(i => i.Evento1)
              .HasForeignKey(i => i.UpdatedBy)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Reincarapp.Models.reincardb.EventoArchivo>()
              .HasOne(i => i.Evento)
              .WithMany(i => i.EventoArchivo)
              .HasForeignKey(i => i.id_evento)
              .HasPrincipalKey(i => i.Id_Evento);

            builder.Entity<Reincarapp.Models.reincardb.EventoArchivo>()
              .HasOne(i => i.TipoArchivo)
              .WithMany(i => i.EventoArchivo)
              .HasForeignKey(i => i.id_tipo_archivo)
              .HasPrincipalKey(i => i.id_tipo_archivo);

            builder.Entity<Reincarapp.Models.reincardb.EventoDet>()
              .HasOne(i => i.ClasificacionAdicional)
              .WithMany(i => i.EventoDet)
              .HasForeignKey(i => i.Id_Contactado_Por)
              .HasPrincipalKey(i => i.Id_Clasificacion_Adicional);

            builder.Entity<Reincarapp.Models.reincardb.EventoDet>()
              .HasOne(i => i.Evento)
              .WithMany(i => i.EventoDet)
              .HasForeignKey(i => i.id_evento)
              .HasPrincipalKey(i => i.Id_Evento);

            builder.Entity<Reincarapp.Models.reincardb.HonorarioAvvillas>()
              .HasOne(i => i.CampoHonorario)
              .WithMany(i => i.HonorarioAvvillas)
              .HasForeignKey(i => i.id_campo_honorario)
              .HasPrincipalKey(i => i.id_campo_honorario);

            builder.Entity<Reincarapp.Models.reincardb.HonorarioAvvillas>()
              .HasOne(i => i.ClasificacionAdicional)
              .WithMany(i => i.HonorarioAvvillas)
              .HasForeignKey(i => i.id_clasificacion_honorario)
              .HasPrincipalKey(i => i.Id_Clasificacion_Adicional);

            builder.Entity<Reincarapp.Models.reincardb.HonorarioAvvillas>()
              .HasOne(i => i.Cliente)
              .WithMany(i => i.HonorarioAvvillas)
              .HasForeignKey(i => i.id_cliente)
              .HasPrincipalKey(i => i.Id_Cliente);

            builder.Entity<Reincarapp.Models.reincardb.HonorarioAvvillas>()
              .HasOne(i => i.TipoRecaudo)
              .WithMany(i => i.HonorarioAvvillas)
              .HasForeignKey(i => i.id_tipo_recaudo)
              .HasPrincipalKey(i => i.id_tipo_recaudo);

            builder.Entity<Reincarapp.Models.reincardb.HonorarioAvvillas>()
              .HasOne(i => i.Usuario)
              .WithMany(i => i.HonorarioAvvillas)
              .HasForeignKey(i => i.id_usuario)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.Jamar>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Jamar)
              .HasForeignKey(i => i.id_cliente_deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.LogClienteDeudaEstado>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.LogClienteDeudaEstado)
              .HasForeignKey(i => i.id_cliente_deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.LogClienteDeudaEstado>()
              .HasOne(i => i.EstadoClienteDeuda)
              .WithMany(i => i.LogClienteDeudaEstado)
              .HasForeignKey(i => i.id_estado_cliente_deuda_act)
              .HasPrincipalKey(i => i.Id_Estado_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.LogClienteDeudaEstado>()
              .HasOne(i => i.EstadoClienteDeuda1)
              .WithMany(i => i.LogClienteDeudaEstado1)
              .HasForeignKey(i => i.id_estado_cliente_deuda_ant)
              .HasPrincipalKey(i => i.Id_Estado_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.LogDatoPersona>()
              .HasOne(i => i.DatoPersona)
              .WithMany(i => i.LogDatoPersona)
              .HasForeignKey(i => i.id_dato_persona)
              .HasPrincipalKey(i => i.Id_Dato_Persona);

            builder.Entity<Reincarapp.Models.reincardb.LogDatoPersona>()
              .HasOne(i => i.Tarea)
              .WithMany(i => i.LogDatoPersona)
              .HasForeignKey(i => i.id_tarea)
              .HasPrincipalKey(i => i.Id_Tarea);

            builder.Entity<Reincarapp.Models.reincardb.LogDatoPersona>()
              .HasOne(i => i.TipoDatoPersona)
              .WithMany(i => i.LogDatoPersona)
              .HasForeignKey(i => i.id_tipo_dato_persona_new)
              .HasPrincipalKey(i => i.Id_Tipo_Dato_Persona);

            builder.Entity<Reincarapp.Models.reincardb.LogDatoPersona>()
              .HasOne(i => i.TipoDatoPersona1)
              .WithMany(i => i.LogDatoPersona1)
              .HasForeignKey(i => i.id_tipo_dato_persona_old)
              .HasPrincipalKey(i => i.Id_Tipo_Dato_Persona);

            builder.Entity<Reincarapp.Models.reincardb.LogDatoPersona>()
              .HasOne(i => i.Usuario)
              .WithMany(i => i.LogDatoPersona)
              .HasForeignKey(i => i.id_usuario)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.MCita>()
              .HasOne(i => i.MEspecialidad)
              .WithMany(i => i.MCita)
              .HasForeignKey(i => i.IdEspecialidad)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Reincarapp.Models.reincardb.MCita>()
              .HasOne(i => i.MEstadoCita)
              .WithMany(i => i.MCita)
              .HasForeignKey(i => i.IdEstado)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Reincarapp.Models.reincardb.MCita>()
              .HasOne(i => i.MMedico)
              .WithMany(i => i.MCita)
              .HasForeignKey(i => i.IdMedico)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Reincarapp.Models.reincardb.MCita>()
              .HasOne(i => i.Persona)
              .WithMany(i => i.MCita)
              .HasForeignKey(i => i.IdPersona)
              .HasPrincipalKey(i => i.Id_Persona);

            builder.Entity<Reincarapp.Models.reincardb.MCita>()
              .HasOne(i => i.MSede)
              .WithMany(i => i.MCita)
              .HasForeignKey(i => i.IdSede)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Reincarapp.Models.reincardb.MEspecialidadMedico>()
              .HasOne(i => i.MEspecialidad)
              .WithMany(i => i.MEspecialidadMedico)
              .HasForeignKey(i => i.IdEspecialidad)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Reincarapp.Models.reincardb.MEspecialidadMedico>()
              .HasOne(i => i.MMedico)
              .WithMany(i => i.MEspecialidadMedico)
              .HasForeignKey(i => i.IdMedico)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Reincarapp.Models.reincardb.Maf>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Maf)
              .HasForeignKey(i => i.id_cliente_deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Menco>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Menco)
              .HasForeignKey(i => i.id_cliente_deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Municipio>()
              .HasOne(i => i.Departamento)
              .WithMany(i => i.Municipio)
              .HasForeignKey(i => i.Id_Departamento)
              .HasPrincipalKey(i => i.Id_Departamento);

            builder.Entity<Reincarapp.Models.reincardb.ParametroValor>()
              .HasOne(i => i.Parametro)
              .WithMany(i => i.ParametroValor)
              .HasForeignKey(i => i.Id_Parametro)
              .HasPrincipalKey(i => i.Id_Parametro);

            builder.Entity<Reincarapp.Models.reincardb.Persona>()
              .HasOne(i => i.TipoDocumento)
              .WithMany(i => i.Persona)
              .HasForeignKey(i => i.Id_Tipo_Documento)
              .HasPrincipalKey(i => i.Id_Tipo_Documento);

            builder.Entity<Reincarapp.Models.reincardb.Promotora>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Promotora)
              .HasForeignKey(i => i.id_cliente_deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Rediferido>()
              .HasOne(i => i.Municipio)
              .WithMany(i => i.Rediferido)
              .HasForeignKey(i => i.id_ciudad)
              .HasPrincipalKey(i => i.Id_Municipio);

            builder.Entity<Reincarapp.Models.reincardb.Rediferido>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Rediferido)
              .HasForeignKey(i => i.id_cliente_deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Rediferido>()
              .HasOne(i => i.Credivalores)
              .WithMany(i => i.Rediferido)
              .HasForeignKey(i => i.id_credivalores)
              .HasPrincipalKey(i => i.Id_Credivalores);

            builder.Entity<Reincarapp.Models.reincardb.Rediferido>()
              .HasOne(i => i.Franja)
              .WithMany(i => i.Rediferido)
              .HasForeignKey(i => i.id_franja)
              .HasPrincipalKey(i => i.id_franja);

            builder.Entity<Reincarapp.Models.reincardb.Rediferido>()
              .HasOne(i => i.TipoRediferido)
              .WithMany(i => i.Rediferido)
              .HasForeignKey(i => i.id_tipo_rediferido)
              .HasPrincipalKey(i => i.id_tipo_rediferido);

            builder.Entity<Reincarapp.Models.reincardb.Rediferido>()
              .HasOne(i => i.Usuario)
              .WithMany(i => i.Rediferido)
              .HasForeignKey(i => i.id_usuario)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.Rediferido>()
              .HasOne(i => i.Tasa1)
              .WithMany(i => i.Rediferido)
              .HasForeignKey(i => i.tasa)
              .HasPrincipalKey(i => i.id_tasa);

            builder.Entity<Reincarapp.Models.reincardb.ResultadoEvento>()
              .HasOne(i => i.Cliente)
              .WithMany(i => i.ResultadoEvento)
              .HasForeignKey(i => i.id_cliente)
              .HasPrincipalKey(i => i.Id_Cliente);

            builder.Entity<Reincarapp.Models.reincardb.Saludcoop>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Saludcoop)
              .HasForeignKey(i => i.Id_Cliente_Deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Sms>()
              .HasOne(i => i.Evento)
              .WithMany(i => i.Sms)
              .HasForeignKey(i => i.Id_Evento)
              .HasPrincipalKey(i => i.Id_Evento);

            builder.Entity<Reincarapp.Models.reincardb.SubrepartoUsuario>()
              .HasOne(i => i.Usuario)
              .WithMany(i => i.SubrepartoUsuario)
              .HasForeignKey(i => i.IdUsuario)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.SubrepartoUsuario>()
              .HasOne(i => i.Usuario1)
              .WithMany(i => i.SubrepartoUsuario1)
              .HasForeignKey(i => i.UsuarioActualizacion)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.SubrepartoUsuario>()
              .HasOne(i => i.Usuario2)
              .WithMany(i => i.SubrepartoUsuario2)
              .HasForeignKey(i => i.UsuarioCreacion)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.Tarea>()
              .HasOne(i => i.Aspnetusers)
              .WithMany(i => i.Tarea)
              .HasForeignKey(i => i.CreatedBy)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Reincarapp.Models.reincardb.Tarea>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Tarea)
              .HasForeignKey(i => i.Id_Cliente_Deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Tarea>()
              .HasOne(i => i.Evento1)
              .WithMany(i => i.Tarea1)
              .HasForeignKey(i => i.Id_Evento)
              .HasPrincipalKey(i => i.Id_Evento);

            builder.Entity<Reincarapp.Models.reincardb.Tarea>()
              .HasOne(i => i.TipoComunicacion)
              .WithMany(i => i.Tarea)
              .HasForeignKey(i => i.Id_Tipo_Comunicacion)
              .HasPrincipalKey(i => i.Id_Tipo_Comunicacion);

            builder.Entity<Reincarapp.Models.reincardb.Tarea>()
              .HasOne(i => i.TipoTarea)
              .WithMany(i => i.Tarea)
              .HasForeignKey(i => i.id_tipo_tarea)
              .HasPrincipalKey(i => i.id_tipo_tarea);

            builder.Entity<Reincarapp.Models.reincardb.Tarea>()
              .HasOne(i => i.Usuario)
              .WithMany(i => i.Tarea)
              .HasForeignKey(i => i.Id_Usuario)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.Tarea>()
              .HasOne(i => i.Usuario1)
              .WithMany(i => i.Tarea1)
              .HasForeignKey(i => i.Id_Usuario_Tarea)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.Tarea>()
              .HasOne(i => i.Aspnetusers1)
              .WithMany(i => i.Tarea1)
              .HasForeignKey(i => i.ProcessedBy)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Reincarapp.Models.reincardb.Tarea>()
              .HasOne(i => i.Aspnetusers2)
              .WithMany(i => i.Tarea2)
              .HasForeignKey(i => i.UpdatedBy)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Reincarapp.Models.reincardb.Tiempofuera>()
              .HasOne(i => i.Razontiempofuera)
              .WithMany(i => i.Tiempofuera)
              .HasForeignKey(i => i.IdRazonTiempoFuera)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Reincarapp.Models.reincardb.Tiempofuera>()
              .HasOne(i => i.Usuario)
              .WithMany(i => i.Tiempofuera)
              .HasForeignKey(i => i.IdUsuario)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.TipoComunicacion>()
              .HasOne(i => i.Cliente)
              .WithMany(i => i.TipoComunicacion)
              .HasForeignKey(i => i.Id_Cliente)
              .HasPrincipalKey(i => i.Id_Cliente);

            builder.Entity<Reincarapp.Models.reincardb.TipoComunicacionResultadoEvento>()
              .HasOne(i => i.Cliente)
              .WithMany(i => i.TipoComunicacionResultadoEvento)
              .HasForeignKey(i => i.id_cliente)
              .HasPrincipalKey(i => i.Id_Cliente);

            builder.Entity<Reincarapp.Models.reincardb.TipoComunicacionResultadoEvento>()
              .HasOne(i => i.ResultadoEvento)
              .WithMany(i => i.TipoComunicacionResultadoEvento)
              .HasForeignKey(i => i.id_resultado_evento)
              .HasPrincipalKey(i => i.Id_Resultado_Evento);

            builder.Entity<Reincarapp.Models.reincardb.TipoComunicacionResultadoEvento>()
              .HasOne(i => i.TipoComunicacion)
              .WithMany(i => i.TipoComunicacionResultadoEvento)
              .HasForeignKey(i => i.id_tipo_comunicacion)
              .HasPrincipalKey(i => i.Id_Tipo_Comunicacion);

            builder.Entity<Reincarapp.Models.reincardb.TipoDatoPersona>()
              .HasOne(i => i.Cliente)
              .WithMany(i => i.TipoDatoPersona)
              .HasForeignKey(i => i.Id_Cliente)
              .HasPrincipalKey(i => i.Id_Cliente);

            builder.Entity<Reincarapp.Models.reincardb.Transito>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Transito)
              .HasForeignKey(i => i.ID_CLIENTE_DEUDA)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Transitobuc>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Transitobuc)
              .HasForeignKey(i => i.id_cliente_deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Transitoflo>()
              .HasOne(i => i.ClienteDeuda)
              .WithMany(i => i.Transitoflo)
              .HasForeignKey(i => i.id_cliente_deuda)
              .HasPrincipalKey(i => i.Id_Cliente_Deuda);

            builder.Entity<Reincarapp.Models.reincardb.Usuario>()
              .HasOne(i => i.EstadoUsuario)
              .WithMany(i => i.Usuario)
              .HasForeignKey(i => i.Estado)
              .HasPrincipalKey(i => i.id_estado_usuario);

            builder.Entity<Reincarapp.Models.reincardb.UsuarioCliente>()
              .HasOne(i => i.Aspnetusers)
              .WithMany(i => i.UsuarioCliente)
              .HasForeignKey(i => i.AspNetUserId)
              .HasPrincipalKey(i => i.Id);

            builder.Entity<Reincarapp.Models.reincardb.UsuarioCliente>()
              .HasOne(i => i.Cliente)
              .WithMany(i => i.UsuarioCliente)
              .HasForeignKey(i => i.Id_Cliente)
              .HasPrincipalKey(i => i.Id_Cliente);

            builder.Entity<Reincarapp.Models.reincardb.UsuarioCliente>()
              .HasOne(i => i.Usuario)
              .WithMany(i => i.UsuarioCliente)
              .HasForeignKey(i => i.Id_Usuario)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.UsuarioRol>()
              .HasOne(i => i.Rol)
              .WithMany(i => i.UsuarioRol)
              .HasForeignKey(i => i.Id_Rol)
              .HasPrincipalKey(i => i.Id_Rol);

            builder.Entity<Reincarapp.Models.reincardb.UsuarioRol>()
              .HasOne(i => i.Usuario)
              .WithMany(i => i.UsuarioRol)
              .HasForeignKey(i => i.Id_Usuario)
              .HasPrincipalKey(i => i.Id_Usuario);

            builder.Entity<Reincarapp.Models.reincardb.Acueducto>()
              .Property(p => p.fecha_inicial)
              .HasDefaultValueSql(@"CURRENT_TIMESTAMP");

            builder.Entity<Reincarapp.Models.reincardb.AsigGestAux>()
              .Property(p => p.Fecha_Inicio_Asignacion)
              .HasDefaultValueSql(@"CURRENT_TIMESTAMP");

            builder.Entity<Reincarapp.Models.reincardb.AsignacionGestor>()
              .Property(p => p.Fecha_Inicio_Asignacion)
              .HasDefaultValueSql(@"CURRENT_TIMESTAMP");

            builder.Entity<Reincarapp.Models.reincardb.Base>()
              .Property(p => p.FechaCre)
              .HasDefaultValueSql(@"CURRENT_TIMESTAMP");

            builder.Entity<Reincarapp.Models.reincardb.Base>()
              .Property(p => p.FechaAct)
              .HasDefaultValueSql(@"CURRENT_TIMESTAMP");

            builder.Entity<Reincarapp.Models.reincardb.Bktarea>()
              .Property(p => p.Fecha_Creacion_Tarea)
              .HasDefaultValueSql(@"CURRENT_TIMESTAMP");

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeuda>()
              .Property(p => p.Fecha_Creacion)
              .HasDefaultValueSql(@"CURRENT_TIMESTAMP");

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaAgrup>()
              .Property(p => p.fecha_creacion)
              .HasDefaultValueSql(@"'0000-00-00 00:00:00'");

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaAux>()
              .Property(p => p.Fecha_Creacion)
              .HasDefaultValueSql(@"CURRENT_TIMESTAMP");

            builder.Entity<Reincarapp.Models.reincardb.CoomultrasanJuridica>()
              .Property(p => p.FECHA_IMPORTACION)
              .HasDefaultValueSql(@"CURRENT_TIMESTAMP");

            builder.Entity<Reincarapp.Models.reincardb.CoomultrasanLey79>()
              .Property(p => p.FECHA_IMPORTACION)
              .HasDefaultValueSql(@"CURRENT_TIMESTAMP");

            builder.Entity<Reincarapp.Models.reincardb.CoomultrasanTemprana>()
              .Property(p => p.FECHA_IMPORTACION)
              .HasDefaultValueSql(@"CURRENT_TIMESTAMP");

            builder.Entity<Reincarapp.Models.reincardb.Evento>()
              .Property(p => p.Fecha_Creacion_Evento)
              .HasDefaultValueSql(@"CURRENT_TIMESTAMP");

            builder.Entity<Reincarapp.Models.reincardb.LogClienteDeudaEstado>()
              .Property(p => p.fecha_inicial)
              .HasDefaultValueSql(@"CURRENT_TIMESTAMP");

            builder.Entity<Reincarapp.Models.reincardb.Logapp>()
              .Property(p => p.FechaCreacion)
              .HasDefaultValueSql(@"CURRENT_TIMESTAMP");

            builder.Entity<Reincarapp.Models.reincardb.Rediferido>()
              .Property(p => p.fecha_creacion)
              .HasDefaultValueSql(@"CURRENT_TIMESTAMP");

            builder.Entity<Reincarapp.Models.reincardb.SubrepartoUsuario>()
              .Property(p => p.FechaCreacion)
              .HasDefaultValueSql(@"CURRENT_TIMESTAMP");

            builder.Entity<Reincarapp.Models.reincardb.Tarea>()
              .Property(p => p.Fecha_Creacion_Tarea)
              .HasDefaultValueSql(@"CURRENT_TIMESTAMP");

            builder.Entity<Reincarapp.Models.reincardb.Acueducto>()
              .Property(p => p.F_VISITA)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Acueducto>()
              .Property(p => p.CAMPANA)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Acueducto>()
              .Property(p => p.FECHA_ACUERDO_PAGO)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Acueducto>()
              .Property(p => p.fecha_inicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Acueducto>()
              .Property(p => p.fecha_final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Avvillas>()
              .Property(p => p.FECHA_COMPROM_CONTACT)
              .HasColumnType("datetime(6)");

            builder.Entity<Reincarapp.Models.reincardb.Avvillas>()
              .Property(p => p.FECHA_CORTE)
              .HasColumnType("datetime(6)");

            builder.Entity<Reincarapp.Models.reincardb.Avvillas>()
              .Property(p => p.Fecha_Inicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Avvillas>()
              .Property(p => p.Fecha_Final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Avvillasbuc>()
              .Property(p => p.FECHA_COMPROM_CONTACT)
              .HasColumnType("datetime(6)");

            builder.Entity<Reincarapp.Models.reincardb.Avvillasbuc>()
              .Property(p => p.FECHA_CORTE)
              .HasColumnType("datetime(6)");

            builder.Entity<Reincarapp.Models.reincardb.Avvillasbuc>()
              .Property(p => p.Fecha_Inicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Avvillasbuc>()
              .Property(p => p.Fecha_Final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Bancobogota>()
              .Property(p => p.fecha_inicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Bancobogota>()
              .Property(p => p.fecha_final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Bancoomeva>()
              .Property(p => p.FECHA_DE_CASTIGO)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Bancoomeva>()
              .Property(p => p.fecha_inicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Bancoomeva>()
              .Property(p => p.fecha_final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Base>()
              .Property(p => p.FechaCre)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Base>()
              .Property(p => p.FechaAct)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.BaseJuridica>()
              .Property(p => p.fecha_inicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.BaseJuridica>()
              .Property(p => p.fecha_final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Bktarea>()
              .Property(p => p.Fecha_Realizacion_Tarea)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Bloqueocontacto>()
              .Property(p => p.FechaCreacion)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Censprejuridico>()
              .Property(p => p.FechaInicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Censprejuridico>()
              .Property(p => p.FechaFinal)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Checprejuridico>()
              .Property(p => p.FechaInicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Checprejuridico>()
              .Property(p => p.FechaFinal)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Citibank>()
              .Property(p => p.FECHA_ULTIMO_CONTACTO)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Citibank4>()
              .Property(p => p.FECHA_ULTIMO_CONTACTO)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeuda>()
              .Property(p => p.Fecha_Inicio_Deuda)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeuda>()
              .Property(p => p.Fecha_Cierre_Deuda)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaAgrup>()
              .Property(p => p.fecha_inicio)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaAgrup>()
              .Property(p => p.fecha_creacion)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaAux>()
              .Property(p => p.Fecha_Inicio_Deuda)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaAux>()
              .Property(p => p.Fecha_Cierre_Deuda)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaDato>()
              .Property(p => p.Fecha_Inicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaDato>()
              .Property(p => p.Fecha_Final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaHonorario>()
              .Property(p => p.fecha_creacion)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaUsuario>()
              .Property(p => p.Fecha_Inicio_Asignacion)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.ConsCvC1>()
              .Property(p => p.max_fecha_creacion)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.ConsCvC12>()
              .Property(p => p.max_fecha_creacion)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.ConsCvC13>()
              .Property(p => p.max_fecha_creacion)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.ConsCvC14>()
              .Property(p => p.max_fecha_creacion)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.ConsCvC1Credidos>()
              .Property(p => p.max_fecha_creacion)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.ConsCvC1Progresa>()
              .Property(p => p.max_fecha_creacion)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.CoomultrasanCastigo>()
              .Property(p => p.fecha_inicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.CoomultrasanCastigo>()
              .Property(p => p.fecha_final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.CoomultrasanJuridica>()
              .Property(p => p.FECHA_IMPORTACION)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.CoomultrasanJuridica>()
              .Property(p => p.Fecha_Final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.CoomultrasanLey79>()
              .Property(p => p.FECHA_IMPORTACION)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.CoomultrasanLey79>()
              .Property(p => p.Fecha_Final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.CoomultrasanTemprana>()
              .Property(p => p.FECHA_IMPORTACION)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Coopetrol>()
              .Property(p => p.FECHA_LIQUIDACION)
              .HasColumnType("datetime(6)");

            builder.Entity<Reincarapp.Models.reincardb.Coopetrol>()
              .Property(p => p.FECHA_MORA)
              .HasColumnType("datetime(6)");

            builder.Entity<Reincarapp.Models.reincardb.Coopetrol>()
              .Property(p => p.fecha_inicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Coopetrol>()
              .Property(p => p.fecha_final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Credidos>()
              .Property(p => p.Fecha_Inicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Credidos>()
              .Property(p => p.Fecha_Final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Credivalores>()
              .Property(p => p.Fecha_Inicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Credivalores>()
              .Property(p => p.Fecha_Final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Credivalores2>()
              .Property(p => p.Fecha_Inicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Credivalores2>()
              .Property(p => p.Fecha_Final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Credivaloresalt>()
              .Property(p => p.Fecha_Inicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Credivaloresalt>()
              .Property(p => p.Fecha_Final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.DecisionEstado>()
              .Property(p => p.Fecha_Inicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.DecisionEstado>()
              .Property(p => p.Fecha_Final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Evento>()
              .Property(p => p.Fecha_Realizacion_Evento)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Evento>()
              .Property(p => p.Fecha_Creacion_Registro)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Jamar>()
              .Property(p => p.proroga)
              .HasColumnType("datetime(6)");

            builder.Entity<Reincarapp.Models.reincardb.Jamar>()
              .Property(p => p.fecha_de_emision)
              .HasColumnType("datetime(6)");

            builder.Entity<Reincarapp.Models.reincardb.Jamar>()
              .Property(p => p.fecha_ultimo_pago)
              .HasColumnType("datetime(6)");

            builder.Entity<Reincarapp.Models.reincardb.Jamar>()
              .Property(p => p.fecha_vencimiento_mes)
              .HasColumnType("datetime(6)");

            builder.Entity<Reincarapp.Models.reincardb.Jamar>()
              .Property(p => p.fecha_inicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Jamar>()
              .Property(p => p.fecha_final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.LogDatoPersona>()
              .Property(p => p.fecha_creacion)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Logapp>()
              .Property(p => p.FechaCreacion)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.MCita>()
              .Property(p => p.Fecha_Inicio)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.MCita>()
              .Property(p => p.Fecha_Fin)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Maf>()
              .Property(p => p.fecha_inicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Maf>()
              .Property(p => p.fecha_final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Menco>()
              .Property(p => p.fecha_inicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Menco>()
              .Property(p => p.fecha_final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.ParametroValor>()
              .Property(p => p.Fecha_Inicio_Vigencia)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.ParametroValor>()
              .Property(p => p.Fecha_Fin_Vigencia)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Promotora>()
              .Property(p => p.fecha_inicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Promotora>()
              .Property(p => p.fecha_final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Rediferido>()
              .Property(p => p.fecha_envio)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Rediferido>()
              .Property(p => p.fecha_creacion)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Sms>()
              .Property(p => p.Fecha_Creacion)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Sms>()
              .Property(p => p.Fecha_Envio)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.SubrepartoUsuario>()
              .Property(p => p.FechaCreacion)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.SubrepartoUsuario>()
              .Property(p => p.FechaActualizacion)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Tarea>()
              .Property(p => p.Fecha_Realizacion_Tarea)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.TiempoEvento>()
              .Property(p => p.Fecha_Inicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.TiempoEvento>()
              .Property(p => p.Fecha_Final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Tiempofuera>()
              .Property(p => p.FechaInicio)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Tiempofuera>()
              .Property(p => p.FechaFin)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Transito>()
              .Property(p => p.FECHA_MODIFICACION)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Transito>()
              .Property(p => p.FECHA_ALTA)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Transitobuc>()
              .Property(p => p.fecha_inicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Transitobuc>()
              .Property(p => p.fecha_final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Transitoflo>()
              .Property(p => p.fecha_inicial)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Transitoflo>()
              .Property(p => p.fecha_final)
              .HasColumnType("datetime");

            builder.Entity<Reincarapp.Models.reincardb.Aspnetusers>()
              .Property(p => p.LockoutEnd)
              .HasColumnType("datetime(6)");

            builder.Entity<Reincarapp.Models.reincardb.AsigGestAux>()
              .Property(p => p.Porcentaje_Honorarios)
              .HasPrecision(8,2);

            builder.Entity<Reincarapp.Models.reincardb.AsignacionGestor>()
              .Property(p => p.Porcentaje_Honorarios)
              .HasPrecision(8,2);

            builder.Entity<Reincarapp.Models.reincardb.Avvillas>()
              .Property(p => p.CAP_LIBROS_INI)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.Avvillasbuc>()
              .Property(p => p.CAP_LIBROS_INI)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.Bktarea>()
              .Property(p => p.monto)
              .HasPrecision(18,2);

            builder.Entity<Reincarapp.Models.reincardb.Citibank2>()
              .Property(p => p.Saldo_capital)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeuda>()
              .Property(p => p.Monto)
              .HasPrecision(18,2);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaAgrup>()
              .Property(p => p.monto)
              .HasPrecision(40,2);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaAux>()
              .Property(p => p.Monto)
              .HasPrecision(18,2);

            builder.Entity<Reincarapp.Models.reincardb.ClienteDeudaUsuario>()
              .Property(p => p.Porcentaje_Honorarios)
              .HasPrecision(8,2);

            builder.Entity<Reincarapp.Models.reincardb.CoomultrasanTemprana>()
              .Property(p => p.SALDOCREDITO)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.CoomultrasanTemprana>()
              .Property(p => p.SALDO_VENC)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.CoomultrasanTemprana>()
              .Property(p => p.VALORCUOTA)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.Coopetrol>()
              .Property(p => p.SALDO_CAPITAL)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.Coopetrol>()
              .Property(p => p.CAPITAL_VENCIDO)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.Coopetrol>()
              .Property(p => p.INT_CORRIENTES)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.Coopetrol>()
              .Property(p => p.INT_MORA)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.Coopetrol>()
              .Property(p => p.SEGUROS)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.Coopetrol>()
              .Property(p => p.SUB_TOTAL_VENCIDO)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.Coopetrol>()
              .Property(p => p.SALDO_TOTAL)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.Evento>()
              .Property(p => p.Monto)
              .HasPrecision(18,2);

            builder.Entity<Reincarapp.Models.reincardb.Jamar>()
              .Property(p => p.salario)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.Jamar>()
              .Property(p => p.Saldo)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.Jamar>()
              .Property(p => p.saldo_vencido_inicial)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.Jamar>()
              .Property(p => p.Intereses)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.Jamar>()
              .Property(p => p.gasto_cobranza)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.Jamar>()
              .Property(p => p.saldo_capital)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.Jamar>()
              .Property(p => p.total_saldo_vencido)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.Jamar>()
              .Property(p => p.total_credito)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.Jamar>()
              .Property(p => p.honorarios)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.Jamar>()
              .Property(p => p.valor_honorarios)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.Jamar>()
              .Property(p => p.valor_total_a_pagar)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.JamarJuridica>()
              .Property(p => p.intereses)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.JamarJuridica>()
              .Property(p => p.honorarios)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.JamarJuridica>()
              .Property(p => p.valor_honorarios)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.JamarJuridica>()
              .Property(p => p.valor_total_a_pagar)
              .HasPrecision(19,4);

            builder.Entity<Reincarapp.Models.reincardb.ParametroValor>()
              .Property(p => p.Valor_Parametro_Numero)
              .HasPrecision(18,2);

            builder.Entity<Reincarapp.Models.reincardb.Saludcoop>()
              .Property(p => p.Edad_Mora)
              .HasPrecision(18,0);

            builder.Entity<Reincarapp.Models.reincardb.Saludcoop>()
              .Property(p => p.Maxima_Edad)
              .HasPrecision(18,0);

            builder.Entity<Reincarapp.Models.reincardb.Saludcoop>()
              .Property(p => p.Valor_Cotizacion)
              .HasPrecision(18,2);

            builder.Entity<Reincarapp.Models.reincardb.Tarea>()
              .Property(p => p.monto)
              .HasPrecision(18,2);
            this.OnModelBuilding(builder);
        }

        public DbSet<Reincarapp.Models.reincardb.ActCampoCoomultrasan> ActCampoCoomultrasan { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Acueducto> Acueducto { get; set; }

        public DbSet<Reincarapp.Models.reincardb.AsigGestAux> AsigGestAux { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Asignacion> Asignacion { get; set; }

        public DbSet<Reincarapp.Models.reincardb.AsignacionGestor> AsignacionGestor { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Avvillas> Avvillas { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Avvillasbuc> Avvillasbuc { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Bancobogota> Bancobogota { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Bancoomeva> Bancoomeva { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Base> Base { get; set; }

        public DbSet<Reincarapp.Models.reincardb.BaseJuridica> BaseJuridica { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Basecampo> Basecampo { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Bktarea> Bktarea { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Bloqueocontacto> Bloqueocontacto { get; set; }

        public DbSet<Reincarapp.Models.reincardb.CampoHonorario> CampoHonorario { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Campoclave> Campoclave { get; set; }

        public DbSet<Reincarapp.Models.reincardb.CdRepetidasPersona> CdRepetidasPersona { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Cedulaborrar> Cedulaborrar { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Censprejuridico> Censprejuridico { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Checprejuridico> Checprejuridico { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Citibank> Citibank { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Citibank2> Citibank2 { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Citibank4> Citibank4 { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ClasificacionAdicional> ClasificacionAdicional { get; set; }

        public DbSet<Reincarapp.Models.reincardb.CliDeuProc> CliDeuProc { get; set; }

        public DbSet<Reincarapp.Models.reincardb.CliDeuProc1> CliDeuProc1 { get; set; }

        public DbSet<Reincarapp.Models.reincardb.CliDeuProc2> CliDeuProc2 { get; set; }

        public DbSet<Reincarapp.Models.reincardb.CliDeuProc3> CliDeuProc3 { get; set; }

        public DbSet<Reincarapp.Models.reincardb.CliDeuProcTranBuc> CliDeuProcTranBuc { get; set; }

        public DbSet<Reincarapp.Models.reincardb.CliDeuProcTranFlo> CliDeuProcTranFlo { get; set; }

        public DbSet<Reincarapp.Models.reincardb.CliDeuProcTran1> CliDeuProcTran1 { get; set; }

        public DbSet<Reincarapp.Models.reincardb.CliDeuProcTran2> CliDeuProcTran2 { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Cliente> Cliente { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ClienteDeuda> ClienteDeuda { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ClienteDeudaAgrup> ClienteDeudaAgrup { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ClienteDeudaAux> ClienteDeudaAux { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ClienteDeudaCons> ClienteDeudaCons { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ClienteDeudaDato> ClienteDeudaDato { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ClienteDeudaHonorario> ClienteDeudaHonorario { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ClienteDeudaUsuario> ClienteDeudaUsuario { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Clientedeudaborrar> Clientedeudaborrar { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Comparendos> Comparendos { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ConsCvC1> ConsCvC1 { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ConsCvC12> ConsCvC12 { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ConsCvC13> ConsCvC13 { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ConsCvC14> ConsCvC14 { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ConsCvC1Credidos> ConsCvC1Credidos { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ConsCvC1Progresa> ConsCvC1Progresa { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ConsInfTransitoBuc> ConsInfTransitoBuc { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ConsInfTransitoBucFinal> ConsInfTransitoBucFinal { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ConsInfTransitoFlo> ConsInfTransitoFlo { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ConsInfTransitoFloFinal> ConsInfTransitoFloFinal { get; set; }

        public DbSet<Reincarapp.Models.reincardb.CoomTempcd> CoomTempcd { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Coomultdic> Coomultdic { get; set; }

        public DbSet<Reincarapp.Models.reincardb.CoomultrasanCastigo> CoomultrasanCastigo { get; set; }

        public DbSet<Reincarapp.Models.reincardb.CoomultrasanJuridica> CoomultrasanJuridica { get; set; }

        public DbSet<Reincarapp.Models.reincardb.CoomultrasanLey79> CoomultrasanLey79 { get; set; }

        public DbSet<Reincarapp.Models.reincardb.CoomultrasanTemprana> CoomultrasanTemprana { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Coopetrol> Coopetrol { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Correspondencia> Correspondencia { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Credidos> Credidos { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Credivalores> Credivalores { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Credivalores2> Credivalores2 { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Credivaloresalt> Credivaloresalt { get; set; }

        public DbSet<Reincarapp.Models.reincardb.DatoClienteDeuda> DatoClienteDeuda { get; set; }

        public DbSet<Reincarapp.Models.reincardb.DatoPersona> DatoPersona { get; set; }

        public DbSet<Reincarapp.Models.reincardb.DecisionEstado> DecisionEstado { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Departamento> Departamento { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Docs> Docs { get; set; }

        public DbSet<Reincarapp.Models.reincardb.EmpSaludcoop> EmpSaludcoop { get; set; }

        public DbSet<Reincarapp.Models.reincardb.EstadoClienteDeuda> EstadoClienteDeuda { get; set; }

        public DbSet<Reincarapp.Models.reincardb.EstadoUsuario> EstadoUsuario { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Evento> Evento { get; set; }

        public DbSet<Reincarapp.Models.reincardb.EventoArchivo> EventoArchivo { get; set; }

        public DbSet<Reincarapp.Models.reincardb.EventoDet> EventoDet { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Franja> Franja { get; set; }

        public DbSet<Reincarapp.Models.reincardb.GestionesCoomuTemp> GestionesCoomuTemp { get; set; }

        public DbSet<Reincarapp.Models.reincardb.HonorarioAvvillas> HonorarioAvvillas { get; set; }

        public DbSet<Reincarapp.Models.reincardb.InfSaludcoop> InfSaludcoop { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Informe> Informe { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Jamar> Jamar { get; set; }

        public DbSet<Reincarapp.Models.reincardb.JamarJuridica> JamarJuridica { get; set; }

        public DbSet<Reincarapp.Models.reincardb.LogClienteDeudaEstado> LogClienteDeudaEstado { get; set; }

        public DbSet<Reincarapp.Models.reincardb.LogDatoPersona> LogDatoPersona { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Logapp> Logapp { get; set; }

        public DbSet<Reincarapp.Models.reincardb.MCita> MCita { get; set; }

        public DbSet<Reincarapp.Models.reincardb.MEspecialidad> MEspecialidad { get; set; }

        public DbSet<Reincarapp.Models.reincardb.MEspecialidadMedico> MEspecialidadMedico { get; set; }

        public DbSet<Reincarapp.Models.reincardb.MEstadoCita> MEstadoCita { get; set; }

        public DbSet<Reincarapp.Models.reincardb.MMedico> MMedico { get; set; }

        public DbSet<Reincarapp.Models.reincardb.MSede> MSede { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Maf> Maf { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Menco> Menco { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Municipio> Municipio { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Parametro> Parametro { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ParametroValor> ParametroValor { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Persona> Persona { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Promotora> Promotora { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Razontiempofuera> Razontiempofuera { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Rediferido> Rediferido { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ResEve> ResEve { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ResEveC3> ResEveC3 { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ResultadoEvento> ResultadoEvento { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Rol> Rol { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Saludcoop> Saludcoop { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Saludcoopcd> Saludcoopcd { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Sms> Sms { get; set; }

        public DbSet<Reincarapp.Models.reincardb.SubrepartoUsuario> SubrepartoUsuario { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Tarea> Tarea { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Tasa> Tasa { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TblDelete> TblDelete { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TempEveToDelete> TempEveToDelete { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TempEveToUpd> TempEveToUpd { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TempIdcoomulstrasan> TempIdcoomulstrasan { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TempIdcoomulstrasan2> TempIdcoomulstrasan2 { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TiempoEvento> TiempoEvento { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Tiempofuera> Tiempofuera { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TipoArchivo> TipoArchivo { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TipoClasificacionAdicional> TipoClasificacionAdicional { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TipoCliente> TipoCliente { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TipoComunicacion> TipoComunicacion { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TipoComunicacionResultadoEvento> TipoComunicacionResultadoEvento { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TipoDatoPersona> TipoDatoPersona { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TipoDocumento> TipoDocumento { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TipoRecaudo> TipoRecaudo { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TipoRediferido> TipoRediferido { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TipoTarea> TipoTarea { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TipoVia> TipoVia { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Tipobase> Tipobase { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TmpClienteDeudaDic> TmpClienteDeudaDic { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TmpClienteDeudaEstado> TmpClienteDeudaEstado { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TmpDatoPerBor> TmpDatoPerBor { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TmpDatoPersona> TmpDatoPersona { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TmpDecEst> TmpDecEst { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TmpEventoSaludcoop> TmpEventoSaludcoop { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TmpGestCooJur> TmpGestCooJur { get; set; }

        public DbSet<Reincarapp.Models.reincardb.TmpUsuario> TmpUsuario { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Tmpcambiotip> Tmpcambiotip { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Transito> Transito { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Transitobuc> Transitobuc { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Transitoflo> Transitoflo { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Usuario> Usuario { get; set; }

        public DbSet<Reincarapp.Models.reincardb.UsuarioCliente> UsuarioCliente { get; set; }

        public DbSet<Reincarapp.Models.reincardb.UsuarioRol> UsuarioRol { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ZonaUbicacion> ZonaUbicacion { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ZzzProcAvv> ZzzProcAvv { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas> ZzzTmpBorrarAvvillas { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas1> ZzzTmpBorrarAvvillas1 { get; set; }

        public DbSet<Reincarapp.Models.reincardb.ZzzTmpToDelTransito> ZzzTmpToDelTransito { get; set; }

        public DbSet<Reincarapp.Models.reincardb.Aspnetusers> Aspnetusers { get; set; }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Add(_ => new BlankTriggerAddingConvention());
        }
    }
}