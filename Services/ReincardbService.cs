using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Radzen;

using Reincarapp.Data;

namespace Reincarapp
{
    public partial class reincardbService
    {
        reincardbContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly reincardbContext context;
        private readonly NavigationManager navigationManager;

        public reincardbService(reincardbContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);

        public void ApplyQuery<T>(ref IQueryable<T> items, Query query = null)
        {
            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }
        }


        public async Task ExportActCampoCoomultrasanToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/actcampocoomultrasan/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/actcampocoomultrasan/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportActCampoCoomultrasanToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/actcampocoomultrasan/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/actcampocoomultrasan/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnActCampoCoomultrasanRead(ref IQueryable<Reincarapp.Models.reincardb.ActCampoCoomultrasan> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ActCampoCoomultrasan>> GetActCampoCoomultrasan(Query query = null)
        {
            var items = Context.ActCampoCoomultrasan.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnActCampoCoomultrasanRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportAcueductoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/acueducto/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/acueducto/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAcueductoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/acueducto/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/acueducto/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAcueductoRead(ref IQueryable<Reincarapp.Models.reincardb.Acueducto> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Acueducto>> GetAcueducto(Query query = null)
        {
            var items = Context.Acueducto.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnAcueductoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAcueductoGet(Reincarapp.Models.reincardb.Acueducto item);
        partial void OnGetAcueductoByIdAcueducto(ref IQueryable<Reincarapp.Models.reincardb.Acueducto> items);


        public async Task<Reincarapp.Models.reincardb.Acueducto> GetAcueductoByIdAcueducto(long idacueducto)
        {
            var items = Context.Acueducto
                              .AsNoTracking()
                              .Where(i => i.Id_Acueducto == idacueducto);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetAcueductoByIdAcueducto(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnAcueductoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAcueductoCreated(Reincarapp.Models.reincardb.Acueducto item);
        partial void OnAfterAcueductoCreated(Reincarapp.Models.reincardb.Acueducto item);

        public async Task<Reincarapp.Models.reincardb.Acueducto> CreateAcueducto(Reincarapp.Models.reincardb.Acueducto acueducto)
        {
            OnAcueductoCreated(acueducto);

            var existingItem = Context.Acueducto
                              .Where(i => i.Id_Acueducto == acueducto.Id_Acueducto)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Acueducto.Add(acueducto);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(acueducto).State = EntityState.Detached;
                throw;
            }

            OnAfterAcueductoCreated(acueducto);

            return acueducto;
        }

        public async Task<Reincarapp.Models.reincardb.Acueducto> CancelAcueductoChanges(Reincarapp.Models.reincardb.Acueducto item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAcueductoUpdated(Reincarapp.Models.reincardb.Acueducto item);
        partial void OnAfterAcueductoUpdated(Reincarapp.Models.reincardb.Acueducto item);

        public async Task<Reincarapp.Models.reincardb.Acueducto> UpdateAcueducto(long idacueducto, Reincarapp.Models.reincardb.Acueducto acueducto)
        {
            OnAcueductoUpdated(acueducto);

            var itemToUpdate = Context.Acueducto
                              .Where(i => i.Id_Acueducto == acueducto.Id_Acueducto)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(acueducto);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAcueductoUpdated(acueducto);

            return acueducto;
        }

        partial void OnAcueductoDeleted(Reincarapp.Models.reincardb.Acueducto item);
        partial void OnAfterAcueductoDeleted(Reincarapp.Models.reincardb.Acueducto item);

        public async Task<Reincarapp.Models.reincardb.Acueducto> DeleteAcueducto(long idacueducto)
        {
            var itemToDelete = Context.Acueducto
                              .Where(i => i.Id_Acueducto == idacueducto)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAcueductoDeleted(itemToDelete);


            Context.Acueducto.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAcueductoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAsigGestAuxToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/asiggestaux/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/asiggestaux/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAsigGestAuxToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/asiggestaux/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/asiggestaux/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAsigGestAuxRead(ref IQueryable<Reincarapp.Models.reincardb.AsigGestAux> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.AsigGestAux>> GetAsigGestAux(Query query = null)
        {
            var items = Context.AsigGestAux.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnAsigGestAuxRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportAsignacionToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/asignacion/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/asignacion/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAsignacionToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/asignacion/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/asignacion/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAsignacionRead(ref IQueryable<Reincarapp.Models.reincardb.Asignacion> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Asignacion>> GetAsignacion(Query query = null)
        {
            var items = Context.Asignacion.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnAsignacionRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAsignacionGet(Reincarapp.Models.reincardb.Asignacion item);
        partial void OnGetAsignacionByIdAsignacion(ref IQueryable<Reincarapp.Models.reincardb.Asignacion> items);


        public async Task<Reincarapp.Models.reincardb.Asignacion> GetAsignacionByIdAsignacion(string idasignacion)
        {
            var items = Context.Asignacion
                              .AsNoTracking()
                              .Where(i => i.Id_Asignacion == idasignacion);

 
            OnGetAsignacionByIdAsignacion(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnAsignacionGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAsignacionCreated(Reincarapp.Models.reincardb.Asignacion item);
        partial void OnAfterAsignacionCreated(Reincarapp.Models.reincardb.Asignacion item);

        public async Task<Reincarapp.Models.reincardb.Asignacion> CreateAsignacion(Reincarapp.Models.reincardb.Asignacion asignacion)
        {
            OnAsignacionCreated(asignacion);

            var existingItem = Context.Asignacion
                              .Where(i => i.Id_Asignacion == asignacion.Id_Asignacion)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Asignacion.Add(asignacion);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(asignacion).State = EntityState.Detached;
                throw;
            }

            OnAfterAsignacionCreated(asignacion);

            return asignacion;
        }

        public async Task<Reincarapp.Models.reincardb.Asignacion> CancelAsignacionChanges(Reincarapp.Models.reincardb.Asignacion item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAsignacionUpdated(Reincarapp.Models.reincardb.Asignacion item);
        partial void OnAfterAsignacionUpdated(Reincarapp.Models.reincardb.Asignacion item);

        public async Task<Reincarapp.Models.reincardb.Asignacion> UpdateAsignacion(string idasignacion, Reincarapp.Models.reincardb.Asignacion asignacion)
        {
            OnAsignacionUpdated(asignacion);

            var itemToUpdate = Context.Asignacion
                              .Where(i => i.Id_Asignacion == asignacion.Id_Asignacion)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(asignacion);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAsignacionUpdated(asignacion);

            return asignacion;
        }

        partial void OnAsignacionDeleted(Reincarapp.Models.reincardb.Asignacion item);
        partial void OnAfterAsignacionDeleted(Reincarapp.Models.reincardb.Asignacion item);

        public async Task<Reincarapp.Models.reincardb.Asignacion> DeleteAsignacion(string idasignacion)
        {
            var itemToDelete = Context.Asignacion
                              .Where(i => i.Id_Asignacion == idasignacion)
                              .Include(i => i.ClienteDeuda)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAsignacionDeleted(itemToDelete);


            Context.Asignacion.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAsignacionDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAsignacionGestorToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/asignaciongestor/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/asignaciongestor/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAsignacionGestorToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/asignaciongestor/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/asignaciongestor/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAsignacionGestorRead(ref IQueryable<Reincarapp.Models.reincardb.AsignacionGestor> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.AsignacionGestor>> GetAsignacionGestor(Query query = null)
        {
            var items = Context.AsignacionGestor.AsQueryable();

            items = items.Include(i => i.Persona);
            items = items.Include(i => i.Usuario);
            items = items.Include(i => i.Usuario1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnAsignacionGestorRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAsignacionGestorGet(Reincarapp.Models.reincardb.AsignacionGestor item);
        partial void OnGetAsignacionGestorByIdAsignacionGestor(ref IQueryable<Reincarapp.Models.reincardb.AsignacionGestor> items);


        public async Task<Reincarapp.Models.reincardb.AsignacionGestor> GetAsignacionGestorByIdAsignacionGestor(long idasignaciongestor)
        {
            var items = Context.AsignacionGestor
                              .AsNoTracking()
                              .Where(i => i.Id_Asignacion_Gestor == idasignaciongestor);

            items = items.Include(i => i.Persona);
            items = items.Include(i => i.Usuario);
            items = items.Include(i => i.Usuario1);
 
            OnGetAsignacionGestorByIdAsignacionGestor(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnAsignacionGestorGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAsignacionGestorCreated(Reincarapp.Models.reincardb.AsignacionGestor item);
        partial void OnAfterAsignacionGestorCreated(Reincarapp.Models.reincardb.AsignacionGestor item);

        public async Task<Reincarapp.Models.reincardb.AsignacionGestor> CreateAsignacionGestor(Reincarapp.Models.reincardb.AsignacionGestor asignaciongestor)
        {
            OnAsignacionGestorCreated(asignaciongestor);

            var existingItem = Context.AsignacionGestor
                              .Where(i => i.Id_Asignacion_Gestor == asignaciongestor.Id_Asignacion_Gestor)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AsignacionGestor.Add(asignaciongestor);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(asignaciongestor).State = EntityState.Detached;
                throw;
            }

            OnAfterAsignacionGestorCreated(asignaciongestor);

            return asignaciongestor;
        }

        public async Task<Reincarapp.Models.reincardb.AsignacionGestor> CancelAsignacionGestorChanges(Reincarapp.Models.reincardb.AsignacionGestor item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAsignacionGestorUpdated(Reincarapp.Models.reincardb.AsignacionGestor item);
        partial void OnAfterAsignacionGestorUpdated(Reincarapp.Models.reincardb.AsignacionGestor item);

        public async Task<Reincarapp.Models.reincardb.AsignacionGestor> UpdateAsignacionGestor(long idasignaciongestor, Reincarapp.Models.reincardb.AsignacionGestor asignaciongestor)
        {
            OnAsignacionGestorUpdated(asignaciongestor);

            var itemToUpdate = Context.AsignacionGestor
                              .Where(i => i.Id_Asignacion_Gestor == asignaciongestor.Id_Asignacion_Gestor)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(asignaciongestor);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAsignacionGestorUpdated(asignaciongestor);

            return asignaciongestor;
        }

        partial void OnAsignacionGestorDeleted(Reincarapp.Models.reincardb.AsignacionGestor item);
        partial void OnAfterAsignacionGestorDeleted(Reincarapp.Models.reincardb.AsignacionGestor item);

        public async Task<Reincarapp.Models.reincardb.AsignacionGestor> DeleteAsignacionGestor(long idasignaciongestor)
        {
            var itemToDelete = Context.AsignacionGestor
                              .Where(i => i.Id_Asignacion_Gestor == idasignaciongestor)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAsignacionGestorDeleted(itemToDelete);


            Context.AsignacionGestor.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAsignacionGestorDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAvvillasToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/avvillas/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/avvillas/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAvvillasToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/avvillas/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/avvillas/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAvvillasRead(ref IQueryable<Reincarapp.Models.reincardb.Avvillas> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Avvillas>> GetAvvillas(Query query = null)
        {
            var items = Context.Avvillas.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnAvvillasRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAvvillasGet(Reincarapp.Models.reincardb.Avvillas item);
        partial void OnGetAvvillasByIdAvVillas(ref IQueryable<Reincarapp.Models.reincardb.Avvillas> items);


        public async Task<Reincarapp.Models.reincardb.Avvillas> GetAvvillasByIdAvVillas(long idavvillas)
        {
            var items = Context.Avvillas
                              .AsNoTracking()
                              .Where(i => i.Id_AvVillas == idavvillas);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetAvvillasByIdAvVillas(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnAvvillasGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAvvillasCreated(Reincarapp.Models.reincardb.Avvillas item);
        partial void OnAfterAvvillasCreated(Reincarapp.Models.reincardb.Avvillas item);

        public async Task<Reincarapp.Models.reincardb.Avvillas> CreateAvvillas(Reincarapp.Models.reincardb.Avvillas avvillas)
        {
            OnAvvillasCreated(avvillas);

            var existingItem = Context.Avvillas
                              .Where(i => i.Id_AvVillas == avvillas.Id_AvVillas)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Avvillas.Add(avvillas);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(avvillas).State = EntityState.Detached;
                throw;
            }

            OnAfterAvvillasCreated(avvillas);

            return avvillas;
        }

        public async Task<Reincarapp.Models.reincardb.Avvillas> CancelAvvillasChanges(Reincarapp.Models.reincardb.Avvillas item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAvvillasUpdated(Reincarapp.Models.reincardb.Avvillas item);
        partial void OnAfterAvvillasUpdated(Reincarapp.Models.reincardb.Avvillas item);

        public async Task<Reincarapp.Models.reincardb.Avvillas> UpdateAvvillas(long idavvillas, Reincarapp.Models.reincardb.Avvillas avvillas)
        {
            OnAvvillasUpdated(avvillas);

            var itemToUpdate = Context.Avvillas
                              .Where(i => i.Id_AvVillas == avvillas.Id_AvVillas)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(avvillas);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAvvillasUpdated(avvillas);

            return avvillas;
        }

        partial void OnAvvillasDeleted(Reincarapp.Models.reincardb.Avvillas item);
        partial void OnAfterAvvillasDeleted(Reincarapp.Models.reincardb.Avvillas item);

        public async Task<Reincarapp.Models.reincardb.Avvillas> DeleteAvvillas(long idavvillas)
        {
            var itemToDelete = Context.Avvillas
                              .Where(i => i.Id_AvVillas == idavvillas)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAvvillasDeleted(itemToDelete);


            Context.Avvillas.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAvvillasDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAvvillasbucToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/avvillasbuc/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/avvillasbuc/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAvvillasbucToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/avvillasbuc/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/avvillasbuc/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAvvillasbucRead(ref IQueryable<Reincarapp.Models.reincardb.Avvillasbuc> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Avvillasbuc>> GetAvvillasbuc(Query query = null)
        {
            var items = Context.Avvillasbuc.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnAvvillasbucRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAvvillasbucGet(Reincarapp.Models.reincardb.Avvillasbuc item);
        partial void OnGetAvvillasbucByIdAvVillasbuc(ref IQueryable<Reincarapp.Models.reincardb.Avvillasbuc> items);


        public async Task<Reincarapp.Models.reincardb.Avvillasbuc> GetAvvillasbucByIdAvVillasbuc(long idavvillasbuc)
        {
            var items = Context.Avvillasbuc
                              .AsNoTracking()
                              .Where(i => i.Id_AvVillasbuc == idavvillasbuc);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetAvvillasbucByIdAvVillasbuc(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnAvvillasbucGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAvvillasbucCreated(Reincarapp.Models.reincardb.Avvillasbuc item);
        partial void OnAfterAvvillasbucCreated(Reincarapp.Models.reincardb.Avvillasbuc item);

        public async Task<Reincarapp.Models.reincardb.Avvillasbuc> CreateAvvillasbuc(Reincarapp.Models.reincardb.Avvillasbuc avvillasbuc)
        {
            OnAvvillasbucCreated(avvillasbuc);

            var existingItem = Context.Avvillasbuc
                              .Where(i => i.Id_AvVillasbuc == avvillasbuc.Id_AvVillasbuc)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Avvillasbuc.Add(avvillasbuc);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(avvillasbuc).State = EntityState.Detached;
                throw;
            }

            OnAfterAvvillasbucCreated(avvillasbuc);

            return avvillasbuc;
        }

        public async Task<Reincarapp.Models.reincardb.Avvillasbuc> CancelAvvillasbucChanges(Reincarapp.Models.reincardb.Avvillasbuc item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAvvillasbucUpdated(Reincarapp.Models.reincardb.Avvillasbuc item);
        partial void OnAfterAvvillasbucUpdated(Reincarapp.Models.reincardb.Avvillasbuc item);

        public async Task<Reincarapp.Models.reincardb.Avvillasbuc> UpdateAvvillasbuc(long idavvillasbuc, Reincarapp.Models.reincardb.Avvillasbuc avvillasbuc)
        {
            OnAvvillasbucUpdated(avvillasbuc);

            var itemToUpdate = Context.Avvillasbuc
                              .Where(i => i.Id_AvVillasbuc == avvillasbuc.Id_AvVillasbuc)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(avvillasbuc);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAvvillasbucUpdated(avvillasbuc);

            return avvillasbuc;
        }

        partial void OnAvvillasbucDeleted(Reincarapp.Models.reincardb.Avvillasbuc item);
        partial void OnAfterAvvillasbucDeleted(Reincarapp.Models.reincardb.Avvillasbuc item);

        public async Task<Reincarapp.Models.reincardb.Avvillasbuc> DeleteAvvillasbuc(long idavvillasbuc)
        {
            var itemToDelete = Context.Avvillasbuc
                              .Where(i => i.Id_AvVillasbuc == idavvillasbuc)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAvvillasbucDeleted(itemToDelete);


            Context.Avvillasbuc.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAvvillasbucDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportBancobogotaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/bancobogota/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/bancobogota/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBancobogotaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/bancobogota/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/bancobogota/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBancobogotaRead(ref IQueryable<Reincarapp.Models.reincardb.Bancobogota> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Bancobogota>> GetBancobogota(Query query = null)
        {
            var items = Context.Bancobogota.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnBancobogotaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBancobogotaGet(Reincarapp.Models.reincardb.Bancobogota item);
        partial void OnGetBancobogotaByIdbancobogota(ref IQueryable<Reincarapp.Models.reincardb.Bancobogota> items);


        public async Task<Reincarapp.Models.reincardb.Bancobogota> GetBancobogotaByIdbancobogota(long idbancobogota)
        {
            var items = Context.Bancobogota
                              .AsNoTracking()
                              .Where(i => i.idbancobogota == idbancobogota);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetBancobogotaByIdbancobogota(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnBancobogotaGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnBancobogotaCreated(Reincarapp.Models.reincardb.Bancobogota item);
        partial void OnAfterBancobogotaCreated(Reincarapp.Models.reincardb.Bancobogota item);

        public async Task<Reincarapp.Models.reincardb.Bancobogota> CreateBancobogota(Reincarapp.Models.reincardb.Bancobogota bancobogota)
        {
            OnBancobogotaCreated(bancobogota);

            var existingItem = Context.Bancobogota
                              .Where(i => i.idbancobogota == bancobogota.idbancobogota)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Bancobogota.Add(bancobogota);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(bancobogota).State = EntityState.Detached;
                throw;
            }

            OnAfterBancobogotaCreated(bancobogota);

            return bancobogota;
        }

        public async Task<Reincarapp.Models.reincardb.Bancobogota> CancelBancobogotaChanges(Reincarapp.Models.reincardb.Bancobogota item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBancobogotaUpdated(Reincarapp.Models.reincardb.Bancobogota item);
        partial void OnAfterBancobogotaUpdated(Reincarapp.Models.reincardb.Bancobogota item);

        public async Task<Reincarapp.Models.reincardb.Bancobogota> UpdateBancobogota(long idbancobogota, Reincarapp.Models.reincardb.Bancobogota bancobogota)
        {
            OnBancobogotaUpdated(bancobogota);

            var itemToUpdate = Context.Bancobogota
                              .Where(i => i.idbancobogota == bancobogota.idbancobogota)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(bancobogota);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterBancobogotaUpdated(bancobogota);

            return bancobogota;
        }

        partial void OnBancobogotaDeleted(Reincarapp.Models.reincardb.Bancobogota item);
        partial void OnAfterBancobogotaDeleted(Reincarapp.Models.reincardb.Bancobogota item);

        public async Task<Reincarapp.Models.reincardb.Bancobogota> DeleteBancobogota(long idbancobogota)
        {
            var itemToDelete = Context.Bancobogota
                              .Where(i => i.idbancobogota == idbancobogota)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBancobogotaDeleted(itemToDelete);


            Context.Bancobogota.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBancobogotaDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportBancoomevaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/bancoomeva/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/bancoomeva/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBancoomevaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/bancoomeva/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/bancoomeva/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBancoomevaRead(ref IQueryable<Reincarapp.Models.reincardb.Bancoomeva> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Bancoomeva>> GetBancoomeva(Query query = null)
        {
            var items = Context.Bancoomeva.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnBancoomevaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBancoomevaGet(Reincarapp.Models.reincardb.Bancoomeva item);
        partial void OnGetBancoomevaByIdBancoomeva(ref IQueryable<Reincarapp.Models.reincardb.Bancoomeva> items);


        public async Task<Reincarapp.Models.reincardb.Bancoomeva> GetBancoomevaByIdBancoomeva(long idbancoomeva)
        {
            var items = Context.Bancoomeva
                              .AsNoTracking()
                              .Where(i => i.id_bancoomeva == idbancoomeva);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetBancoomevaByIdBancoomeva(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnBancoomevaGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnBancoomevaCreated(Reincarapp.Models.reincardb.Bancoomeva item);
        partial void OnAfterBancoomevaCreated(Reincarapp.Models.reincardb.Bancoomeva item);

        public async Task<Reincarapp.Models.reincardb.Bancoomeva> CreateBancoomeva(Reincarapp.Models.reincardb.Bancoomeva bancoomeva)
        {
            OnBancoomevaCreated(bancoomeva);

            var existingItem = Context.Bancoomeva
                              .Where(i => i.id_bancoomeva == bancoomeva.id_bancoomeva)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Bancoomeva.Add(bancoomeva);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(bancoomeva).State = EntityState.Detached;
                throw;
            }

            OnAfterBancoomevaCreated(bancoomeva);

            return bancoomeva;
        }

        public async Task<Reincarapp.Models.reincardb.Bancoomeva> CancelBancoomevaChanges(Reincarapp.Models.reincardb.Bancoomeva item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBancoomevaUpdated(Reincarapp.Models.reincardb.Bancoomeva item);
        partial void OnAfterBancoomevaUpdated(Reincarapp.Models.reincardb.Bancoomeva item);

        public async Task<Reincarapp.Models.reincardb.Bancoomeva> UpdateBancoomeva(long idbancoomeva, Reincarapp.Models.reincardb.Bancoomeva bancoomeva)
        {
            OnBancoomevaUpdated(bancoomeva);

            var itemToUpdate = Context.Bancoomeva
                              .Where(i => i.id_bancoomeva == bancoomeva.id_bancoomeva)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(bancoomeva);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterBancoomevaUpdated(bancoomeva);

            return bancoomeva;
        }

        partial void OnBancoomevaDeleted(Reincarapp.Models.reincardb.Bancoomeva item);
        partial void OnAfterBancoomevaDeleted(Reincarapp.Models.reincardb.Bancoomeva item);

        public async Task<Reincarapp.Models.reincardb.Bancoomeva> DeleteBancoomeva(long idbancoomeva)
        {
            var itemToDelete = Context.Bancoomeva
                              .Where(i => i.id_bancoomeva == idbancoomeva)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBancoomevaDeleted(itemToDelete);


            Context.Bancoomeva.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBancoomevaDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportBaseToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/base/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/base/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBaseToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/base/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/base/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBaseRead(ref IQueryable<Reincarapp.Models.reincardb.Base> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Base>> GetBase(Query query = null)
        {
            var items = Context.Base.AsQueryable();

            items = items.Include(i => i.Cliente);
            items = items.Include(i => i.Tipobase);
            items = items.Include(i => i.Usuario);
            items = items.Include(i => i.Usuario1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnBaseRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBaseGet(Reincarapp.Models.reincardb.Base item);
        partial void OnGetBaseById(ref IQueryable<Reincarapp.Models.reincardb.Base> items);


        public async Task<Reincarapp.Models.reincardb.Base> GetBaseById(long id)
        {
            var items = Context.Base
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Cliente);
            items = items.Include(i => i.Tipobase);
            items = items.Include(i => i.Usuario);
            items = items.Include(i => i.Usuario1);
 
            OnGetBaseById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnBaseGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnBaseCreated(Reincarapp.Models.reincardb.Base item);
        partial void OnAfterBaseCreated(Reincarapp.Models.reincardb.Base item);

        public async Task<Reincarapp.Models.reincardb.Base> CreateBase(Reincarapp.Models.reincardb.Base _base)
        {
            OnBaseCreated(_base);

            var existingItem = Context.Base
                              .Where(i => i.Id == _base.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Base.Add(_base);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(_base).State = EntityState.Detached;
                throw;
            }

            OnAfterBaseCreated(_base);

            return _base;
        }

        public async Task<Reincarapp.Models.reincardb.Base> CancelBaseChanges(Reincarapp.Models.reincardb.Base item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBaseUpdated(Reincarapp.Models.reincardb.Base item);
        partial void OnAfterBaseUpdated(Reincarapp.Models.reincardb.Base item);

        public async Task<Reincarapp.Models.reincardb.Base> UpdateBase(long id, Reincarapp.Models.reincardb.Base _base)
        {
            OnBaseUpdated(_base);

            var itemToUpdate = Context.Base
                              .Where(i => i.Id == _base.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(_base);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterBaseUpdated(_base);

            return _base;
        }

        partial void OnBaseDeleted(Reincarapp.Models.reincardb.Base item);
        partial void OnAfterBaseDeleted(Reincarapp.Models.reincardb.Base item);

        public async Task<Reincarapp.Models.reincardb.Base> DeleteBase(long id)
        {
            var itemToDelete = Context.Base
                              .Where(i => i.Id == id)
                              .Include(i => i.Basecampo)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBaseDeleted(itemToDelete);


            Context.Base.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBaseDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportBaseJuridicaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/basejuridica/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/basejuridica/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBaseJuridicaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/basejuridica/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/basejuridica/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBaseJuridicaRead(ref IQueryable<Reincarapp.Models.reincardb.BaseJuridica> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.BaseJuridica>> GetBaseJuridica(Query query = null)
        {
            var items = Context.BaseJuridica.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnBaseJuridicaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBaseJuridicaGet(Reincarapp.Models.reincardb.BaseJuridica item);
        partial void OnGetBaseJuridicaByIdBaseJuridica(ref IQueryable<Reincarapp.Models.reincardb.BaseJuridica> items);


        public async Task<Reincarapp.Models.reincardb.BaseJuridica> GetBaseJuridicaByIdBaseJuridica(long idbasejuridica)
        {
            var items = Context.BaseJuridica
                              .AsNoTracking()
                              .Where(i => i.id_base_juridica == idbasejuridica);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetBaseJuridicaByIdBaseJuridica(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnBaseJuridicaGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnBaseJuridicaCreated(Reincarapp.Models.reincardb.BaseJuridica item);
        partial void OnAfterBaseJuridicaCreated(Reincarapp.Models.reincardb.BaseJuridica item);

        public async Task<Reincarapp.Models.reincardb.BaseJuridica> CreateBaseJuridica(Reincarapp.Models.reincardb.BaseJuridica basejuridica)
        {
            OnBaseJuridicaCreated(basejuridica);

            var existingItem = Context.BaseJuridica
                              .Where(i => i.id_base_juridica == basejuridica.id_base_juridica)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.BaseJuridica.Add(basejuridica);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(basejuridica).State = EntityState.Detached;
                throw;
            }

            OnAfterBaseJuridicaCreated(basejuridica);

            return basejuridica;
        }

        public async Task<Reincarapp.Models.reincardb.BaseJuridica> CancelBaseJuridicaChanges(Reincarapp.Models.reincardb.BaseJuridica item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBaseJuridicaUpdated(Reincarapp.Models.reincardb.BaseJuridica item);
        partial void OnAfterBaseJuridicaUpdated(Reincarapp.Models.reincardb.BaseJuridica item);

        public async Task<Reincarapp.Models.reincardb.BaseJuridica> UpdateBaseJuridica(long idbasejuridica, Reincarapp.Models.reincardb.BaseJuridica basejuridica)
        {
            OnBaseJuridicaUpdated(basejuridica);

            var itemToUpdate = Context.BaseJuridica
                              .Where(i => i.id_base_juridica == basejuridica.id_base_juridica)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(basejuridica);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterBaseJuridicaUpdated(basejuridica);

            return basejuridica;
        }

        partial void OnBaseJuridicaDeleted(Reincarapp.Models.reincardb.BaseJuridica item);
        partial void OnAfterBaseJuridicaDeleted(Reincarapp.Models.reincardb.BaseJuridica item);

        public async Task<Reincarapp.Models.reincardb.BaseJuridica> DeleteBaseJuridica(long idbasejuridica)
        {
            var itemToDelete = Context.BaseJuridica
                              .Where(i => i.id_base_juridica == idbasejuridica)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBaseJuridicaDeleted(itemToDelete);


            Context.BaseJuridica.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBaseJuridicaDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportBasecampoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/basecampo/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/basecampo/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBasecampoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/basecampo/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/basecampo/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBasecampoRead(ref IQueryable<Reincarapp.Models.reincardb.Basecampo> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Basecampo>> GetBasecampo(Query query = null)
        {
            var items = Context.Basecampo.AsQueryable();

            items = items.Include(i => i.Base);
            items = items.Include(i => i.Campoclave);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnBasecampoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBasecampoGet(Reincarapp.Models.reincardb.Basecampo item);
        partial void OnGetBasecampoById(ref IQueryable<Reincarapp.Models.reincardb.Basecampo> items);


        public async Task<Reincarapp.Models.reincardb.Basecampo> GetBasecampoById(long id)
        {
            var items = Context.Basecampo
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Base);
            items = items.Include(i => i.Campoclave);
 
            OnGetBasecampoById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnBasecampoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnBasecampoCreated(Reincarapp.Models.reincardb.Basecampo item);
        partial void OnAfterBasecampoCreated(Reincarapp.Models.reincardb.Basecampo item);

        public async Task<Reincarapp.Models.reincardb.Basecampo> CreateBasecampo(Reincarapp.Models.reincardb.Basecampo basecampo)
        {
            OnBasecampoCreated(basecampo);

            var existingItem = Context.Basecampo
                              .Where(i => i.Id == basecampo.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Basecampo.Add(basecampo);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(basecampo).State = EntityState.Detached;
                throw;
            }

            OnAfterBasecampoCreated(basecampo);

            return basecampo;
        }

        public async Task<Reincarapp.Models.reincardb.Basecampo> CancelBasecampoChanges(Reincarapp.Models.reincardb.Basecampo item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBasecampoUpdated(Reincarapp.Models.reincardb.Basecampo item);
        partial void OnAfterBasecampoUpdated(Reincarapp.Models.reincardb.Basecampo item);

        public async Task<Reincarapp.Models.reincardb.Basecampo> UpdateBasecampo(long id, Reincarapp.Models.reincardb.Basecampo basecampo)
        {
            OnBasecampoUpdated(basecampo);

            var itemToUpdate = Context.Basecampo
                              .Where(i => i.Id == basecampo.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(basecampo);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterBasecampoUpdated(basecampo);

            return basecampo;
        }

        partial void OnBasecampoDeleted(Reincarapp.Models.reincardb.Basecampo item);
        partial void OnAfterBasecampoDeleted(Reincarapp.Models.reincardb.Basecampo item);

        public async Task<Reincarapp.Models.reincardb.Basecampo> DeleteBasecampo(long id)
        {
            var itemToDelete = Context.Basecampo
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBasecampoDeleted(itemToDelete);


            Context.Basecampo.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBasecampoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportBktareaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/bktarea/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/bktarea/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBktareaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/bktarea/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/bktarea/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBktareaRead(ref IQueryable<Reincarapp.Models.reincardb.Bktarea> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Bktarea>> GetBktarea(Query query = null)
        {
            var items = Context.Bktarea.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnBktareaRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportBloqueocontactoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/bloqueocontacto/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/bloqueocontacto/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBloqueocontactoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/bloqueocontacto/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/bloqueocontacto/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBloqueocontactoRead(ref IQueryable<Reincarapp.Models.reincardb.Bloqueocontacto> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Bloqueocontacto>> GetBloqueocontacto(Query query = null)
        {
            var items = Context.Bloqueocontacto.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);
            items = items.Include(i => i.Evento);
            items = items.Include(i => i.Usuario);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnBloqueocontactoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBloqueocontactoGet(Reincarapp.Models.reincardb.Bloqueocontacto item);
        partial void OnGetBloqueocontactoByIdBloqueoContacto(ref IQueryable<Reincarapp.Models.reincardb.Bloqueocontacto> items);


        public async Task<Reincarapp.Models.reincardb.Bloqueocontacto> GetBloqueocontactoByIdBloqueoContacto(long idbloqueocontacto)
        {
            var items = Context.Bloqueocontacto
                              .AsNoTracking()
                              .Where(i => i.IdBloqueoContacto == idbloqueocontacto);

            items = items.Include(i => i.ClienteDeuda);
            items = items.Include(i => i.Evento);
            items = items.Include(i => i.Usuario);
 
            OnGetBloqueocontactoByIdBloqueoContacto(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnBloqueocontactoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnBloqueocontactoCreated(Reincarapp.Models.reincardb.Bloqueocontacto item);
        partial void OnAfterBloqueocontactoCreated(Reincarapp.Models.reincardb.Bloqueocontacto item);

        public async Task<Reincarapp.Models.reincardb.Bloqueocontacto> CreateBloqueocontacto(Reincarapp.Models.reincardb.Bloqueocontacto bloqueocontacto)
        {
            OnBloqueocontactoCreated(bloqueocontacto);

            var existingItem = Context.Bloqueocontacto
                              .Where(i => i.IdBloqueoContacto == bloqueocontacto.IdBloqueoContacto)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Bloqueocontacto.Add(bloqueocontacto);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(bloqueocontacto).State = EntityState.Detached;
                throw;
            }

            OnAfterBloqueocontactoCreated(bloqueocontacto);

            return bloqueocontacto;
        }

        public async Task<Reincarapp.Models.reincardb.Bloqueocontacto> CancelBloqueocontactoChanges(Reincarapp.Models.reincardb.Bloqueocontacto item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBloqueocontactoUpdated(Reincarapp.Models.reincardb.Bloqueocontacto item);
        partial void OnAfterBloqueocontactoUpdated(Reincarapp.Models.reincardb.Bloqueocontacto item);

        public async Task<Reincarapp.Models.reincardb.Bloqueocontacto> UpdateBloqueocontacto(long idbloqueocontacto, Reincarapp.Models.reincardb.Bloqueocontacto bloqueocontacto)
        {
            OnBloqueocontactoUpdated(bloqueocontacto);

            var itemToUpdate = Context.Bloqueocontacto
                              .Where(i => i.IdBloqueoContacto == bloqueocontacto.IdBloqueoContacto)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(bloqueocontacto);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterBloqueocontactoUpdated(bloqueocontacto);

            return bloqueocontacto;
        }

        partial void OnBloqueocontactoDeleted(Reincarapp.Models.reincardb.Bloqueocontacto item);
        partial void OnAfterBloqueocontactoDeleted(Reincarapp.Models.reincardb.Bloqueocontacto item);

        public async Task<Reincarapp.Models.reincardb.Bloqueocontacto> DeleteBloqueocontacto(long idbloqueocontacto)
        {
            var itemToDelete = Context.Bloqueocontacto
                              .Where(i => i.IdBloqueoContacto == idbloqueocontacto)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBloqueocontactoDeleted(itemToDelete);


            Context.Bloqueocontacto.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBloqueocontactoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCampoHonorarioToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/campohonorario/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/campohonorario/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCampoHonorarioToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/campohonorario/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/campohonorario/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCampoHonorarioRead(ref IQueryable<Reincarapp.Models.reincardb.CampoHonorario> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.CampoHonorario>> GetCampoHonorario(Query query = null)
        {
            var items = Context.CampoHonorario.AsQueryable();

            items = items.Include(i => i.Cliente);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCampoHonorarioRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCampoHonorarioGet(Reincarapp.Models.reincardb.CampoHonorario item);
        partial void OnGetCampoHonorarioByIdCampoHonorario(ref IQueryable<Reincarapp.Models.reincardb.CampoHonorario> items);


        public async Task<Reincarapp.Models.reincardb.CampoHonorario> GetCampoHonorarioByIdCampoHonorario(long idcampohonorario)
        {
            var items = Context.CampoHonorario
                              .AsNoTracking()
                              .Where(i => i.id_campo_honorario == idcampohonorario);

            items = items.Include(i => i.Cliente);
 
            OnGetCampoHonorarioByIdCampoHonorario(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCampoHonorarioGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCampoHonorarioCreated(Reincarapp.Models.reincardb.CampoHonorario item);
        partial void OnAfterCampoHonorarioCreated(Reincarapp.Models.reincardb.CampoHonorario item);

        public async Task<Reincarapp.Models.reincardb.CampoHonorario> CreateCampoHonorario(Reincarapp.Models.reincardb.CampoHonorario campohonorario)
        {
            OnCampoHonorarioCreated(campohonorario);

            var existingItem = Context.CampoHonorario
                              .Where(i => i.id_campo_honorario == campohonorario.id_campo_honorario)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CampoHonorario.Add(campohonorario);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(campohonorario).State = EntityState.Detached;
                throw;
            }

            OnAfterCampoHonorarioCreated(campohonorario);

            return campohonorario;
        }

        public async Task<Reincarapp.Models.reincardb.CampoHonorario> CancelCampoHonorarioChanges(Reincarapp.Models.reincardb.CampoHonorario item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCampoHonorarioUpdated(Reincarapp.Models.reincardb.CampoHonorario item);
        partial void OnAfterCampoHonorarioUpdated(Reincarapp.Models.reincardb.CampoHonorario item);

        public async Task<Reincarapp.Models.reincardb.CampoHonorario> UpdateCampoHonorario(long idcampohonorario, Reincarapp.Models.reincardb.CampoHonorario campohonorario)
        {
            OnCampoHonorarioUpdated(campohonorario);

            var itemToUpdate = Context.CampoHonorario
                              .Where(i => i.id_campo_honorario == campohonorario.id_campo_honorario)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(campohonorario);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCampoHonorarioUpdated(campohonorario);

            return campohonorario;
        }

        partial void OnCampoHonorarioDeleted(Reincarapp.Models.reincardb.CampoHonorario item);
        partial void OnAfterCampoHonorarioDeleted(Reincarapp.Models.reincardb.CampoHonorario item);

        public async Task<Reincarapp.Models.reincardb.CampoHonorario> DeleteCampoHonorario(long idcampohonorario)
        {
            var itemToDelete = Context.CampoHonorario
                              .Where(i => i.id_campo_honorario == idcampohonorario)
                              .Include(i => i.HonorarioAvvillas)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCampoHonorarioDeleted(itemToDelete);


            Context.CampoHonorario.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCampoHonorarioDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCampoclaveToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/campoclave/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/campoclave/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCampoclaveToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/campoclave/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/campoclave/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCampoclaveRead(ref IQueryable<Reincarapp.Models.reincardb.Campoclave> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Campoclave>> GetCampoclave(Query query = null)
        {
            var items = Context.Campoclave.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCampoclaveRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCampoclaveGet(Reincarapp.Models.reincardb.Campoclave item);
        partial void OnGetCampoclaveById(ref IQueryable<Reincarapp.Models.reincardb.Campoclave> items);


        public async Task<Reincarapp.Models.reincardb.Campoclave> GetCampoclaveById(long id)
        {
            var items = Context.Campoclave
                              .AsNoTracking()
                              .Where(i => i.Id == id);

 
            OnGetCampoclaveById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCampoclaveGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCampoclaveCreated(Reincarapp.Models.reincardb.Campoclave item);
        partial void OnAfterCampoclaveCreated(Reincarapp.Models.reincardb.Campoclave item);

        public async Task<Reincarapp.Models.reincardb.Campoclave> CreateCampoclave(Reincarapp.Models.reincardb.Campoclave campoclave)
        {
            OnCampoclaveCreated(campoclave);

            var existingItem = Context.Campoclave
                              .Where(i => i.Id == campoclave.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Campoclave.Add(campoclave);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(campoclave).State = EntityState.Detached;
                throw;
            }

            OnAfterCampoclaveCreated(campoclave);

            return campoclave;
        }

        public async Task<Reincarapp.Models.reincardb.Campoclave> CancelCampoclaveChanges(Reincarapp.Models.reincardb.Campoclave item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCampoclaveUpdated(Reincarapp.Models.reincardb.Campoclave item);
        partial void OnAfterCampoclaveUpdated(Reincarapp.Models.reincardb.Campoclave item);

        public async Task<Reincarapp.Models.reincardb.Campoclave> UpdateCampoclave(long id, Reincarapp.Models.reincardb.Campoclave campoclave)
        {
            OnCampoclaveUpdated(campoclave);

            var itemToUpdate = Context.Campoclave
                              .Where(i => i.Id == campoclave.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(campoclave);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCampoclaveUpdated(campoclave);

            return campoclave;
        }

        partial void OnCampoclaveDeleted(Reincarapp.Models.reincardb.Campoclave item);
        partial void OnAfterCampoclaveDeleted(Reincarapp.Models.reincardb.Campoclave item);

        public async Task<Reincarapp.Models.reincardb.Campoclave> DeleteCampoclave(long id)
        {
            var itemToDelete = Context.Campoclave
                              .Where(i => i.Id == id)
                              .Include(i => i.Basecampo)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCampoclaveDeleted(itemToDelete);


            Context.Campoclave.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCampoclaveDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCdRepetidasPersonaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/cdrepetidaspersona/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/cdrepetidaspersona/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCdRepetidasPersonaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/cdrepetidaspersona/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/cdrepetidaspersona/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCdRepetidasPersonaRead(ref IQueryable<Reincarapp.Models.reincardb.CdRepetidasPersona> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.CdRepetidasPersona>> GetCdRepetidasPersona(Query query = null)
        {
            var items = Context.CdRepetidasPersona.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCdRepetidasPersonaRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportCedulaborrarToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/cedulaborrar/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/cedulaborrar/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCedulaborrarToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/cedulaborrar/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/cedulaborrar/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCedulaborrarRead(ref IQueryable<Reincarapp.Models.reincardb.Cedulaborrar> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Cedulaborrar>> GetCedulaborrar(Query query = null)
        {
            var items = Context.Cedulaborrar.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCedulaborrarRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCedulaborrarGet(Reincarapp.Models.reincardb.Cedulaborrar item);
        partial void OnGetCedulaborrarByNumDocumento(ref IQueryable<Reincarapp.Models.reincardb.Cedulaborrar> items);


        public async Task<Reincarapp.Models.reincardb.Cedulaborrar> GetCedulaborrarByNumDocumento(string numdocumento)
        {
            var items = Context.Cedulaborrar
                              .AsNoTracking()
                              .Where(i => i.num_Documento == numdocumento);

 
            OnGetCedulaborrarByNumDocumento(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCedulaborrarGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCedulaborrarCreated(Reincarapp.Models.reincardb.Cedulaborrar item);
        partial void OnAfterCedulaborrarCreated(Reincarapp.Models.reincardb.Cedulaborrar item);

        public async Task<Reincarapp.Models.reincardb.Cedulaborrar> CreateCedulaborrar(Reincarapp.Models.reincardb.Cedulaborrar cedulaborrar)
        {
            OnCedulaborrarCreated(cedulaborrar);

            var existingItem = Context.Cedulaborrar
                              .Where(i => i.num_Documento == cedulaborrar.num_Documento)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Cedulaborrar.Add(cedulaborrar);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(cedulaborrar).State = EntityState.Detached;
                throw;
            }

            OnAfterCedulaborrarCreated(cedulaborrar);

            return cedulaborrar;
        }

        public async Task<Reincarapp.Models.reincardb.Cedulaborrar> CancelCedulaborrarChanges(Reincarapp.Models.reincardb.Cedulaborrar item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCedulaborrarUpdated(Reincarapp.Models.reincardb.Cedulaborrar item);
        partial void OnAfterCedulaborrarUpdated(Reincarapp.Models.reincardb.Cedulaborrar item);

        public async Task<Reincarapp.Models.reincardb.Cedulaborrar> UpdateCedulaborrar(string numdocumento, Reincarapp.Models.reincardb.Cedulaborrar cedulaborrar)
        {
            OnCedulaborrarUpdated(cedulaborrar);

            var itemToUpdate = Context.Cedulaborrar
                              .Where(i => i.num_Documento == cedulaborrar.num_Documento)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(cedulaborrar);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCedulaborrarUpdated(cedulaborrar);

            return cedulaborrar;
        }

        partial void OnCedulaborrarDeleted(Reincarapp.Models.reincardb.Cedulaborrar item);
        partial void OnAfterCedulaborrarDeleted(Reincarapp.Models.reincardb.Cedulaborrar item);

        public async Task<Reincarapp.Models.reincardb.Cedulaborrar> DeleteCedulaborrar(string numdocumento)
        {
            var itemToDelete = Context.Cedulaborrar
                              .Where(i => i.num_Documento == numdocumento)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCedulaborrarDeleted(itemToDelete);


            Context.Cedulaborrar.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCedulaborrarDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCensprejuridicoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/censprejuridico/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/censprejuridico/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCensprejuridicoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/censprejuridico/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/censprejuridico/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCensprejuridicoRead(ref IQueryable<Reincarapp.Models.reincardb.Censprejuridico> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Censprejuridico>> GetCensprejuridico(Query query = null)
        {
            var items = Context.Censprejuridico.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCensprejuridicoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCensprejuridicoGet(Reincarapp.Models.reincardb.Censprejuridico item);
        partial void OnGetCensprejuridicoByIdCensPrejuridico(ref IQueryable<Reincarapp.Models.reincardb.Censprejuridico> items);


        public async Task<Reincarapp.Models.reincardb.Censprejuridico> GetCensprejuridicoByIdCensPrejuridico(long idcensprejuridico)
        {
            var items = Context.Censprejuridico
                              .AsNoTracking()
                              .Where(i => i.IdCensPrejuridico == idcensprejuridico);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetCensprejuridicoByIdCensPrejuridico(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCensprejuridicoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCensprejuridicoCreated(Reincarapp.Models.reincardb.Censprejuridico item);
        partial void OnAfterCensprejuridicoCreated(Reincarapp.Models.reincardb.Censprejuridico item);

        public async Task<Reincarapp.Models.reincardb.Censprejuridico> CreateCensprejuridico(Reincarapp.Models.reincardb.Censprejuridico censprejuridico)
        {
            OnCensprejuridicoCreated(censprejuridico);

            var existingItem = Context.Censprejuridico
                              .Where(i => i.IdCensPrejuridico == censprejuridico.IdCensPrejuridico)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Censprejuridico.Add(censprejuridico);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(censprejuridico).State = EntityState.Detached;
                throw;
            }

            OnAfterCensprejuridicoCreated(censprejuridico);

            return censprejuridico;
        }

        public async Task<Reincarapp.Models.reincardb.Censprejuridico> CancelCensprejuridicoChanges(Reincarapp.Models.reincardb.Censprejuridico item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCensprejuridicoUpdated(Reincarapp.Models.reincardb.Censprejuridico item);
        partial void OnAfterCensprejuridicoUpdated(Reincarapp.Models.reincardb.Censprejuridico item);

        public async Task<Reincarapp.Models.reincardb.Censprejuridico> UpdateCensprejuridico(long idcensprejuridico, Reincarapp.Models.reincardb.Censprejuridico censprejuridico)
        {
            OnCensprejuridicoUpdated(censprejuridico);

            var itemToUpdate = Context.Censprejuridico
                              .Where(i => i.IdCensPrejuridico == censprejuridico.IdCensPrejuridico)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(censprejuridico);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCensprejuridicoUpdated(censprejuridico);

            return censprejuridico;
        }

        partial void OnCensprejuridicoDeleted(Reincarapp.Models.reincardb.Censprejuridico item);
        partial void OnAfterCensprejuridicoDeleted(Reincarapp.Models.reincardb.Censprejuridico item);

        public async Task<Reincarapp.Models.reincardb.Censprejuridico> DeleteCensprejuridico(long idcensprejuridico)
        {
            var itemToDelete = Context.Censprejuridico
                              .Where(i => i.IdCensPrejuridico == idcensprejuridico)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCensprejuridicoDeleted(itemToDelete);


            Context.Censprejuridico.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCensprejuridicoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportChecprejuridicoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/checprejuridico/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/checprejuridico/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportChecprejuridicoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/checprejuridico/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/checprejuridico/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnChecprejuridicoRead(ref IQueryable<Reincarapp.Models.reincardb.Checprejuridico> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Checprejuridico>> GetChecprejuridico(Query query = null)
        {
            var items = Context.Checprejuridico.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnChecprejuridicoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnChecprejuridicoGet(Reincarapp.Models.reincardb.Checprejuridico item);
        partial void OnGetChecprejuridicoByIdChecPrejuridico(ref IQueryable<Reincarapp.Models.reincardb.Checprejuridico> items);


        public async Task<Reincarapp.Models.reincardb.Checprejuridico> GetChecprejuridicoByIdChecPrejuridico(long idchecprejuridico)
        {
            var items = Context.Checprejuridico
                              .AsNoTracking()
                              .Where(i => i.IdChecPrejuridico == idchecprejuridico);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetChecprejuridicoByIdChecPrejuridico(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnChecprejuridicoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnChecprejuridicoCreated(Reincarapp.Models.reincardb.Checprejuridico item);
        partial void OnAfterChecprejuridicoCreated(Reincarapp.Models.reincardb.Checprejuridico item);

        public async Task<Reincarapp.Models.reincardb.Checprejuridico> CreateChecprejuridico(Reincarapp.Models.reincardb.Checprejuridico checprejuridico)
        {
            OnChecprejuridicoCreated(checprejuridico);

            var existingItem = Context.Checprejuridico
                              .Where(i => i.IdChecPrejuridico == checprejuridico.IdChecPrejuridico)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Checprejuridico.Add(checprejuridico);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(checprejuridico).State = EntityState.Detached;
                throw;
            }

            OnAfterChecprejuridicoCreated(checprejuridico);

            return checprejuridico;
        }

        public async Task<Reincarapp.Models.reincardb.Checprejuridico> CancelChecprejuridicoChanges(Reincarapp.Models.reincardb.Checprejuridico item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnChecprejuridicoUpdated(Reincarapp.Models.reincardb.Checprejuridico item);
        partial void OnAfterChecprejuridicoUpdated(Reincarapp.Models.reincardb.Checprejuridico item);

        public async Task<Reincarapp.Models.reincardb.Checprejuridico> UpdateChecprejuridico(long idchecprejuridico, Reincarapp.Models.reincardb.Checprejuridico checprejuridico)
        {
            OnChecprejuridicoUpdated(checprejuridico);

            var itemToUpdate = Context.Checprejuridico
                              .Where(i => i.IdChecPrejuridico == checprejuridico.IdChecPrejuridico)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(checprejuridico);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterChecprejuridicoUpdated(checprejuridico);

            return checprejuridico;
        }

        partial void OnChecprejuridicoDeleted(Reincarapp.Models.reincardb.Checprejuridico item);
        partial void OnAfterChecprejuridicoDeleted(Reincarapp.Models.reincardb.Checprejuridico item);

        public async Task<Reincarapp.Models.reincardb.Checprejuridico> DeleteChecprejuridico(long idchecprejuridico)
        {
            var itemToDelete = Context.Checprejuridico
                              .Where(i => i.IdChecPrejuridico == idchecprejuridico)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnChecprejuridicoDeleted(itemToDelete);


            Context.Checprejuridico.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterChecprejuridicoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCitibankToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/citibank/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/citibank/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCitibankToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/citibank/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/citibank/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCitibankRead(ref IQueryable<Reincarapp.Models.reincardb.Citibank> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Citibank>> GetCitibank(Query query = null)
        {
            var items = Context.Citibank.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCitibankRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCitibankGet(Reincarapp.Models.reincardb.Citibank item);
        partial void OnGetCitibankByIdCitiBank(ref IQueryable<Reincarapp.Models.reincardb.Citibank> items);


        public async Task<Reincarapp.Models.reincardb.Citibank> GetCitibankByIdCitiBank(long idcitibank)
        {
            var items = Context.Citibank
                              .AsNoTracking()
                              .Where(i => i.Id_CitiBank == idcitibank);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetCitibankByIdCitiBank(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCitibankGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCitibankCreated(Reincarapp.Models.reincardb.Citibank item);
        partial void OnAfterCitibankCreated(Reincarapp.Models.reincardb.Citibank item);

        public async Task<Reincarapp.Models.reincardb.Citibank> CreateCitibank(Reincarapp.Models.reincardb.Citibank citibank)
        {
            OnCitibankCreated(citibank);

            var existingItem = Context.Citibank
                              .Where(i => i.Id_CitiBank == citibank.Id_CitiBank)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Citibank.Add(citibank);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(citibank).State = EntityState.Detached;
                throw;
            }

            OnAfterCitibankCreated(citibank);

            return citibank;
        }

        public async Task<Reincarapp.Models.reincardb.Citibank> CancelCitibankChanges(Reincarapp.Models.reincardb.Citibank item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCitibankUpdated(Reincarapp.Models.reincardb.Citibank item);
        partial void OnAfterCitibankUpdated(Reincarapp.Models.reincardb.Citibank item);

        public async Task<Reincarapp.Models.reincardb.Citibank> UpdateCitibank(long idcitibank, Reincarapp.Models.reincardb.Citibank citibank)
        {
            OnCitibankUpdated(citibank);

            var itemToUpdate = Context.Citibank
                              .Where(i => i.Id_CitiBank == citibank.Id_CitiBank)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(citibank);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCitibankUpdated(citibank);

            return citibank;
        }

        partial void OnCitibankDeleted(Reincarapp.Models.reincardb.Citibank item);
        partial void OnAfterCitibankDeleted(Reincarapp.Models.reincardb.Citibank item);

        public async Task<Reincarapp.Models.reincardb.Citibank> DeleteCitibank(long idcitibank)
        {
            var itemToDelete = Context.Citibank
                              .Where(i => i.Id_CitiBank == idcitibank)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCitibankDeleted(itemToDelete);


            Context.Citibank.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCitibankDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCitibank2ToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/citibank2/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/citibank2/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCitibank2ToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/citibank2/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/citibank2/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCitibank2Read(ref IQueryable<Reincarapp.Models.reincardb.Citibank2> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Citibank2>> GetCitibank2(Query query = null)
        {
            var items = Context.Citibank2.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCitibank2Read(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCitibank2Get(Reincarapp.Models.reincardb.Citibank2 item);
        partial void OnGetCitibank2ByIdCitibank2(ref IQueryable<Reincarapp.Models.reincardb.Citibank2> items);


        public async Task<Reincarapp.Models.reincardb.Citibank2> GetCitibank2ByIdCitibank2(long idcitibank2)
        {
            var items = Context.Citibank2
                              .AsNoTracking()
                              .Where(i => i.Id_Citibank2 == idcitibank2);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetCitibank2ByIdCitibank2(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCitibank2Get(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCitibank2Created(Reincarapp.Models.reincardb.Citibank2 item);
        partial void OnAfterCitibank2Created(Reincarapp.Models.reincardb.Citibank2 item);

        public async Task<Reincarapp.Models.reincardb.Citibank2> CreateCitibank2(Reincarapp.Models.reincardb.Citibank2 citibank2)
        {
            OnCitibank2Created(citibank2);

            var existingItem = Context.Citibank2
                              .Where(i => i.Id_Citibank2 == citibank2.Id_Citibank2)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Citibank2.Add(citibank2);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(citibank2).State = EntityState.Detached;
                throw;
            }

            OnAfterCitibank2Created(citibank2);

            return citibank2;
        }

        public async Task<Reincarapp.Models.reincardb.Citibank2> CancelCitibank2Changes(Reincarapp.Models.reincardb.Citibank2 item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCitibank2Updated(Reincarapp.Models.reincardb.Citibank2 item);
        partial void OnAfterCitibank2Updated(Reincarapp.Models.reincardb.Citibank2 item);

        public async Task<Reincarapp.Models.reincardb.Citibank2> UpdateCitibank2(long idcitibank2, Reincarapp.Models.reincardb.Citibank2 citibank2)
        {
            OnCitibank2Updated(citibank2);

            var itemToUpdate = Context.Citibank2
                              .Where(i => i.Id_Citibank2 == citibank2.Id_Citibank2)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(citibank2);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCitibank2Updated(citibank2);

            return citibank2;
        }

        partial void OnCitibank2Deleted(Reincarapp.Models.reincardb.Citibank2 item);
        partial void OnAfterCitibank2Deleted(Reincarapp.Models.reincardb.Citibank2 item);

        public async Task<Reincarapp.Models.reincardb.Citibank2> DeleteCitibank2(long idcitibank2)
        {
            var itemToDelete = Context.Citibank2
                              .Where(i => i.Id_Citibank2 == idcitibank2)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCitibank2Deleted(itemToDelete);


            Context.Citibank2.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCitibank2Deleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCitibank4ToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/citibank4/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/citibank4/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCitibank4ToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/citibank4/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/citibank4/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCitibank4Read(ref IQueryable<Reincarapp.Models.reincardb.Citibank4> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Citibank4>> GetCitibank4(Query query = null)
        {
            var items = Context.Citibank4.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCitibank4Read(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportClasificacionAdicionalToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clasificacionadicional/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clasificacionadicional/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClasificacionAdicionalToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clasificacionadicional/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clasificacionadicional/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClasificacionAdicionalRead(ref IQueryable<Reincarapp.Models.reincardb.ClasificacionAdicional> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ClasificacionAdicional>> GetClasificacionAdicional(Query query = null)
        {
            var items = Context.ClasificacionAdicional.AsQueryable();

            items = items.Include(i => i.Cliente);
            items = items.Include(i => i.TipoClasificacionAdicional);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnClasificacionAdicionalRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnClasificacionAdicionalGet(Reincarapp.Models.reincardb.ClasificacionAdicional item);
        partial void OnGetClasificacionAdicionalByIdClasificacionAdicional(ref IQueryable<Reincarapp.Models.reincardb.ClasificacionAdicional> items);


        public async Task<Reincarapp.Models.reincardb.ClasificacionAdicional> GetClasificacionAdicionalByIdClasificacionAdicional(long idclasificacionadicional)
        {
            var items = Context.ClasificacionAdicional
                              .AsNoTracking()
                              .Where(i => i.Id_Clasificacion_Adicional == idclasificacionadicional);

            items = items.Include(i => i.Cliente);
            items = items.Include(i => i.TipoClasificacionAdicional);
 
            OnGetClasificacionAdicionalByIdClasificacionAdicional(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnClasificacionAdicionalGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnClasificacionAdicionalCreated(Reincarapp.Models.reincardb.ClasificacionAdicional item);
        partial void OnAfterClasificacionAdicionalCreated(Reincarapp.Models.reincardb.ClasificacionAdicional item);

        public async Task<Reincarapp.Models.reincardb.ClasificacionAdicional> CreateClasificacionAdicional(Reincarapp.Models.reincardb.ClasificacionAdicional clasificacionadicional)
        {
            OnClasificacionAdicionalCreated(clasificacionadicional);

            var existingItem = Context.ClasificacionAdicional
                              .Where(i => i.Id_Clasificacion_Adicional == clasificacionadicional.Id_Clasificacion_Adicional)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ClasificacionAdicional.Add(clasificacionadicional);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(clasificacionadicional).State = EntityState.Detached;
                throw;
            }

            OnAfterClasificacionAdicionalCreated(clasificacionadicional);

            return clasificacionadicional;
        }

        public async Task<Reincarapp.Models.reincardb.ClasificacionAdicional> CancelClasificacionAdicionalChanges(Reincarapp.Models.reincardb.ClasificacionAdicional item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnClasificacionAdicionalUpdated(Reincarapp.Models.reincardb.ClasificacionAdicional item);
        partial void OnAfterClasificacionAdicionalUpdated(Reincarapp.Models.reincardb.ClasificacionAdicional item);

        public async Task<Reincarapp.Models.reincardb.ClasificacionAdicional> UpdateClasificacionAdicional(long idclasificacionadicional, Reincarapp.Models.reincardb.ClasificacionAdicional clasificacionadicional)
        {
            OnClasificacionAdicionalUpdated(clasificacionadicional);

            var itemToUpdate = Context.ClasificacionAdicional
                              .Where(i => i.Id_Clasificacion_Adicional == clasificacionadicional.Id_Clasificacion_Adicional)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(clasificacionadicional);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterClasificacionAdicionalUpdated(clasificacionadicional);

            return clasificacionadicional;
        }

        partial void OnClasificacionAdicionalDeleted(Reincarapp.Models.reincardb.ClasificacionAdicional item);
        partial void OnAfterClasificacionAdicionalDeleted(Reincarapp.Models.reincardb.ClasificacionAdicional item);

        public async Task<Reincarapp.Models.reincardb.ClasificacionAdicional> DeleteClasificacionAdicional(long idclasificacionadicional)
        {
            var itemToDelete = Context.ClasificacionAdicional
                              .Where(i => i.Id_Clasificacion_Adicional == idclasificacionadicional)
                              .Include(i => i.Evento)
                              .Include(i => i.Evento1)
                              .Include(i => i.Evento2)
                              .Include(i => i.Evento3)
                              .Include(i => i.Evento4)
                              .Include(i => i.Evento5)
                              .Include(i => i.Evento6)
                              .Include(i => i.EventoDet)
                              .Include(i => i.HonorarioAvvillas)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnClasificacionAdicionalDeleted(itemToDelete);


            Context.ClasificacionAdicional.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterClasificacionAdicionalDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCliDeuProcToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clideuproc/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clideuproc/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCliDeuProcToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clideuproc/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clideuproc/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCliDeuProcRead(ref IQueryable<Reincarapp.Models.reincardb.CliDeuProc> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.CliDeuProc>> GetCliDeuProc(Query query = null)
        {
            var items = Context.CliDeuProc.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCliDeuProcRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCliDeuProcGet(Reincarapp.Models.reincardb.CliDeuProc item);
        partial void OnGetCliDeuProcByIdCliDeuProc(ref IQueryable<Reincarapp.Models.reincardb.CliDeuProc> items);


        public async Task<Reincarapp.Models.reincardb.CliDeuProc> GetCliDeuProcByIdCliDeuProc(long idclideuproc)
        {
            var items = Context.CliDeuProc
                              .AsNoTracking()
                              .Where(i => i.id_cli_deu_proc == idclideuproc);

 
            OnGetCliDeuProcByIdCliDeuProc(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCliDeuProcGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCliDeuProcCreated(Reincarapp.Models.reincardb.CliDeuProc item);
        partial void OnAfterCliDeuProcCreated(Reincarapp.Models.reincardb.CliDeuProc item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProc> CreateCliDeuProc(Reincarapp.Models.reincardb.CliDeuProc clideuproc)
        {
            OnCliDeuProcCreated(clideuproc);

            var existingItem = Context.CliDeuProc
                              .Where(i => i.id_cli_deu_proc == clideuproc.id_cli_deu_proc)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CliDeuProc.Add(clideuproc);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(clideuproc).State = EntityState.Detached;
                throw;
            }

            OnAfterCliDeuProcCreated(clideuproc);

            return clideuproc;
        }

        public async Task<Reincarapp.Models.reincardb.CliDeuProc> CancelCliDeuProcChanges(Reincarapp.Models.reincardb.CliDeuProc item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCliDeuProcUpdated(Reincarapp.Models.reincardb.CliDeuProc item);
        partial void OnAfterCliDeuProcUpdated(Reincarapp.Models.reincardb.CliDeuProc item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProc> UpdateCliDeuProc(long idclideuproc, Reincarapp.Models.reincardb.CliDeuProc clideuproc)
        {
            OnCliDeuProcUpdated(clideuproc);

            var itemToUpdate = Context.CliDeuProc
                              .Where(i => i.id_cli_deu_proc == clideuproc.id_cli_deu_proc)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(clideuproc);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCliDeuProcUpdated(clideuproc);

            return clideuproc;
        }

        partial void OnCliDeuProcDeleted(Reincarapp.Models.reincardb.CliDeuProc item);
        partial void OnAfterCliDeuProcDeleted(Reincarapp.Models.reincardb.CliDeuProc item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProc> DeleteCliDeuProc(long idclideuproc)
        {
            var itemToDelete = Context.CliDeuProc
                              .Where(i => i.id_cli_deu_proc == idclideuproc)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCliDeuProcDeleted(itemToDelete);


            Context.CliDeuProc.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCliDeuProcDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCliDeuProc1ToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clideuproc1/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clideuproc1/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCliDeuProc1ToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clideuproc1/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clideuproc1/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCliDeuProc1Read(ref IQueryable<Reincarapp.Models.reincardb.CliDeuProc1> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.CliDeuProc1>> GetCliDeuProc1(Query query = null)
        {
            var items = Context.CliDeuProc1.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCliDeuProc1Read(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCliDeuProc1Get(Reincarapp.Models.reincardb.CliDeuProc1 item);
        partial void OnGetCliDeuProc1ByIdCliDeuProc(ref IQueryable<Reincarapp.Models.reincardb.CliDeuProc1> items);


        public async Task<Reincarapp.Models.reincardb.CliDeuProc1> GetCliDeuProc1ByIdCliDeuProc(long idclideuproc)
        {
            var items = Context.CliDeuProc1
                              .AsNoTracking()
                              .Where(i => i.id_cli_deu_proc == idclideuproc);

 
            OnGetCliDeuProc1ByIdCliDeuProc(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCliDeuProc1Get(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCliDeuProc1Created(Reincarapp.Models.reincardb.CliDeuProc1 item);
        partial void OnAfterCliDeuProc1Created(Reincarapp.Models.reincardb.CliDeuProc1 item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProc1> CreateCliDeuProc1(Reincarapp.Models.reincardb.CliDeuProc1 clideuproc1)
        {
            OnCliDeuProc1Created(clideuproc1);

            var existingItem = Context.CliDeuProc1
                              .Where(i => i.id_cli_deu_proc == clideuproc1.id_cli_deu_proc)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CliDeuProc1.Add(clideuproc1);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(clideuproc1).State = EntityState.Detached;
                throw;
            }

            OnAfterCliDeuProc1Created(clideuproc1);

            return clideuproc1;
        }

        public async Task<Reincarapp.Models.reincardb.CliDeuProc1> CancelCliDeuProc1Changes(Reincarapp.Models.reincardb.CliDeuProc1 item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCliDeuProc1Updated(Reincarapp.Models.reincardb.CliDeuProc1 item);
        partial void OnAfterCliDeuProc1Updated(Reincarapp.Models.reincardb.CliDeuProc1 item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProc1> UpdateCliDeuProc1(long idclideuproc, Reincarapp.Models.reincardb.CliDeuProc1 clideuproc1)
        {
            OnCliDeuProc1Updated(clideuproc1);

            var itemToUpdate = Context.CliDeuProc1
                              .Where(i => i.id_cli_deu_proc == clideuproc1.id_cli_deu_proc)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(clideuproc1);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCliDeuProc1Updated(clideuproc1);

            return clideuproc1;
        }

        partial void OnCliDeuProc1Deleted(Reincarapp.Models.reincardb.CliDeuProc1 item);
        partial void OnAfterCliDeuProc1Deleted(Reincarapp.Models.reincardb.CliDeuProc1 item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProc1> DeleteCliDeuProc1(long idclideuproc)
        {
            var itemToDelete = Context.CliDeuProc1
                              .Where(i => i.id_cli_deu_proc == idclideuproc)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCliDeuProc1Deleted(itemToDelete);


            Context.CliDeuProc1.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCliDeuProc1Deleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCliDeuProc2ToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clideuproc2/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clideuproc2/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCliDeuProc2ToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clideuproc2/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clideuproc2/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCliDeuProc2Read(ref IQueryable<Reincarapp.Models.reincardb.CliDeuProc2> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.CliDeuProc2>> GetCliDeuProc2(Query query = null)
        {
            var items = Context.CliDeuProc2.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCliDeuProc2Read(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCliDeuProc2Get(Reincarapp.Models.reincardb.CliDeuProc2 item);
        partial void OnGetCliDeuProc2ByIdCliDeuProc(ref IQueryable<Reincarapp.Models.reincardb.CliDeuProc2> items);


        public async Task<Reincarapp.Models.reincardb.CliDeuProc2> GetCliDeuProc2ByIdCliDeuProc(long idclideuproc)
        {
            var items = Context.CliDeuProc2
                              .AsNoTracking()
                              .Where(i => i.id_cli_deu_proc == idclideuproc);

 
            OnGetCliDeuProc2ByIdCliDeuProc(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCliDeuProc2Get(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCliDeuProc2Created(Reincarapp.Models.reincardb.CliDeuProc2 item);
        partial void OnAfterCliDeuProc2Created(Reincarapp.Models.reincardb.CliDeuProc2 item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProc2> CreateCliDeuProc2(Reincarapp.Models.reincardb.CliDeuProc2 clideuproc2)
        {
            OnCliDeuProc2Created(clideuproc2);

            var existingItem = Context.CliDeuProc2
                              .Where(i => i.id_cli_deu_proc == clideuproc2.id_cli_deu_proc)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CliDeuProc2.Add(clideuproc2);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(clideuproc2).State = EntityState.Detached;
                throw;
            }

            OnAfterCliDeuProc2Created(clideuproc2);

            return clideuproc2;
        }

        public async Task<Reincarapp.Models.reincardb.CliDeuProc2> CancelCliDeuProc2Changes(Reincarapp.Models.reincardb.CliDeuProc2 item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCliDeuProc2Updated(Reincarapp.Models.reincardb.CliDeuProc2 item);
        partial void OnAfterCliDeuProc2Updated(Reincarapp.Models.reincardb.CliDeuProc2 item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProc2> UpdateCliDeuProc2(long idclideuproc, Reincarapp.Models.reincardb.CliDeuProc2 clideuproc2)
        {
            OnCliDeuProc2Updated(clideuproc2);

            var itemToUpdate = Context.CliDeuProc2
                              .Where(i => i.id_cli_deu_proc == clideuproc2.id_cli_deu_proc)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(clideuproc2);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCliDeuProc2Updated(clideuproc2);

            return clideuproc2;
        }

        partial void OnCliDeuProc2Deleted(Reincarapp.Models.reincardb.CliDeuProc2 item);
        partial void OnAfterCliDeuProc2Deleted(Reincarapp.Models.reincardb.CliDeuProc2 item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProc2> DeleteCliDeuProc2(long idclideuproc)
        {
            var itemToDelete = Context.CliDeuProc2
                              .Where(i => i.id_cli_deu_proc == idclideuproc)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCliDeuProc2Deleted(itemToDelete);


            Context.CliDeuProc2.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCliDeuProc2Deleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCliDeuProc3ToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clideuproc3/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clideuproc3/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCliDeuProc3ToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clideuproc3/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clideuproc3/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCliDeuProc3Read(ref IQueryable<Reincarapp.Models.reincardb.CliDeuProc3> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.CliDeuProc3>> GetCliDeuProc3(Query query = null)
        {
            var items = Context.CliDeuProc3.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCliDeuProc3Read(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCliDeuProc3Get(Reincarapp.Models.reincardb.CliDeuProc3 item);
        partial void OnGetCliDeuProc3ByIdCliDeuProc(ref IQueryable<Reincarapp.Models.reincardb.CliDeuProc3> items);


        public async Task<Reincarapp.Models.reincardb.CliDeuProc3> GetCliDeuProc3ByIdCliDeuProc(long idclideuproc)
        {
            var items = Context.CliDeuProc3
                              .AsNoTracking()
                              .Where(i => i.id_cli_deu_proc == idclideuproc);

 
            OnGetCliDeuProc3ByIdCliDeuProc(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCliDeuProc3Get(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCliDeuProc3Created(Reincarapp.Models.reincardb.CliDeuProc3 item);
        partial void OnAfterCliDeuProc3Created(Reincarapp.Models.reincardb.CliDeuProc3 item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProc3> CreateCliDeuProc3(Reincarapp.Models.reincardb.CliDeuProc3 clideuproc3)
        {
            OnCliDeuProc3Created(clideuproc3);

            var existingItem = Context.CliDeuProc3
                              .Where(i => i.id_cli_deu_proc == clideuproc3.id_cli_deu_proc)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CliDeuProc3.Add(clideuproc3);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(clideuproc3).State = EntityState.Detached;
                throw;
            }

            OnAfterCliDeuProc3Created(clideuproc3);

            return clideuproc3;
        }

        public async Task<Reincarapp.Models.reincardb.CliDeuProc3> CancelCliDeuProc3Changes(Reincarapp.Models.reincardb.CliDeuProc3 item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCliDeuProc3Updated(Reincarapp.Models.reincardb.CliDeuProc3 item);
        partial void OnAfterCliDeuProc3Updated(Reincarapp.Models.reincardb.CliDeuProc3 item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProc3> UpdateCliDeuProc3(long idclideuproc, Reincarapp.Models.reincardb.CliDeuProc3 clideuproc3)
        {
            OnCliDeuProc3Updated(clideuproc3);

            var itemToUpdate = Context.CliDeuProc3
                              .Where(i => i.id_cli_deu_proc == clideuproc3.id_cli_deu_proc)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(clideuproc3);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCliDeuProc3Updated(clideuproc3);

            return clideuproc3;
        }

        partial void OnCliDeuProc3Deleted(Reincarapp.Models.reincardb.CliDeuProc3 item);
        partial void OnAfterCliDeuProc3Deleted(Reincarapp.Models.reincardb.CliDeuProc3 item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProc3> DeleteCliDeuProc3(long idclideuproc)
        {
            var itemToDelete = Context.CliDeuProc3
                              .Where(i => i.id_cli_deu_proc == idclideuproc)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCliDeuProc3Deleted(itemToDelete);


            Context.CliDeuProc3.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCliDeuProc3Deleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCliDeuProcTranBucToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clideuproctranbuc/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clideuproctranbuc/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCliDeuProcTranBucToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clideuproctranbuc/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clideuproctranbuc/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCliDeuProcTranBucRead(ref IQueryable<Reincarapp.Models.reincardb.CliDeuProcTranBuc> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.CliDeuProcTranBuc>> GetCliDeuProcTranBuc(Query query = null)
        {
            var items = Context.CliDeuProcTranBuc.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCliDeuProcTranBucRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCliDeuProcTranBucGet(Reincarapp.Models.reincardb.CliDeuProcTranBuc item);
        partial void OnGetCliDeuProcTranBucByIdCliDeuProc(ref IQueryable<Reincarapp.Models.reincardb.CliDeuProcTranBuc> items);


        public async Task<Reincarapp.Models.reincardb.CliDeuProcTranBuc> GetCliDeuProcTranBucByIdCliDeuProc(long idclideuproc)
        {
            var items = Context.CliDeuProcTranBuc
                              .AsNoTracking()
                              .Where(i => i.id_cli_deu_proc == idclideuproc);

 
            OnGetCliDeuProcTranBucByIdCliDeuProc(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCliDeuProcTranBucGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCliDeuProcTranBucCreated(Reincarapp.Models.reincardb.CliDeuProcTranBuc item);
        partial void OnAfterCliDeuProcTranBucCreated(Reincarapp.Models.reincardb.CliDeuProcTranBuc item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProcTranBuc> CreateCliDeuProcTranBuc(Reincarapp.Models.reincardb.CliDeuProcTranBuc clideuproctranbuc)
        {
            OnCliDeuProcTranBucCreated(clideuproctranbuc);

            var existingItem = Context.CliDeuProcTranBuc
                              .Where(i => i.id_cli_deu_proc == clideuproctranbuc.id_cli_deu_proc)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CliDeuProcTranBuc.Add(clideuproctranbuc);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(clideuproctranbuc).State = EntityState.Detached;
                throw;
            }

            OnAfterCliDeuProcTranBucCreated(clideuproctranbuc);

            return clideuproctranbuc;
        }

        public async Task<Reincarapp.Models.reincardb.CliDeuProcTranBuc> CancelCliDeuProcTranBucChanges(Reincarapp.Models.reincardb.CliDeuProcTranBuc item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCliDeuProcTranBucUpdated(Reincarapp.Models.reincardb.CliDeuProcTranBuc item);
        partial void OnAfterCliDeuProcTranBucUpdated(Reincarapp.Models.reincardb.CliDeuProcTranBuc item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProcTranBuc> UpdateCliDeuProcTranBuc(long idclideuproc, Reincarapp.Models.reincardb.CliDeuProcTranBuc clideuproctranbuc)
        {
            OnCliDeuProcTranBucUpdated(clideuproctranbuc);

            var itemToUpdate = Context.CliDeuProcTranBuc
                              .Where(i => i.id_cli_deu_proc == clideuproctranbuc.id_cli_deu_proc)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(clideuproctranbuc);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCliDeuProcTranBucUpdated(clideuproctranbuc);

            return clideuproctranbuc;
        }

        partial void OnCliDeuProcTranBucDeleted(Reincarapp.Models.reincardb.CliDeuProcTranBuc item);
        partial void OnAfterCliDeuProcTranBucDeleted(Reincarapp.Models.reincardb.CliDeuProcTranBuc item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProcTranBuc> DeleteCliDeuProcTranBuc(long idclideuproc)
        {
            var itemToDelete = Context.CliDeuProcTranBuc
                              .Where(i => i.id_cli_deu_proc == idclideuproc)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCliDeuProcTranBucDeleted(itemToDelete);


            Context.CliDeuProcTranBuc.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCliDeuProcTranBucDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCliDeuProcTranFloToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clideuproctranflo/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clideuproctranflo/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCliDeuProcTranFloToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clideuproctranflo/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clideuproctranflo/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCliDeuProcTranFloRead(ref IQueryable<Reincarapp.Models.reincardb.CliDeuProcTranFlo> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.CliDeuProcTranFlo>> GetCliDeuProcTranFlo(Query query = null)
        {
            var items = Context.CliDeuProcTranFlo.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCliDeuProcTranFloRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCliDeuProcTranFloGet(Reincarapp.Models.reincardb.CliDeuProcTranFlo item);
        partial void OnGetCliDeuProcTranFloByIdCliDeuProc(ref IQueryable<Reincarapp.Models.reincardb.CliDeuProcTranFlo> items);


        public async Task<Reincarapp.Models.reincardb.CliDeuProcTranFlo> GetCliDeuProcTranFloByIdCliDeuProc(long idclideuproc)
        {
            var items = Context.CliDeuProcTranFlo
                              .AsNoTracking()
                              .Where(i => i.id_cli_deu_proc == idclideuproc);

 
            OnGetCliDeuProcTranFloByIdCliDeuProc(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCliDeuProcTranFloGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCliDeuProcTranFloCreated(Reincarapp.Models.reincardb.CliDeuProcTranFlo item);
        partial void OnAfterCliDeuProcTranFloCreated(Reincarapp.Models.reincardb.CliDeuProcTranFlo item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProcTranFlo> CreateCliDeuProcTranFlo(Reincarapp.Models.reincardb.CliDeuProcTranFlo clideuproctranflo)
        {
            OnCliDeuProcTranFloCreated(clideuproctranflo);

            var existingItem = Context.CliDeuProcTranFlo
                              .Where(i => i.id_cli_deu_proc == clideuproctranflo.id_cli_deu_proc)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CliDeuProcTranFlo.Add(clideuproctranflo);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(clideuproctranflo).State = EntityState.Detached;
                throw;
            }

            OnAfterCliDeuProcTranFloCreated(clideuproctranflo);

            return clideuproctranflo;
        }

        public async Task<Reincarapp.Models.reincardb.CliDeuProcTranFlo> CancelCliDeuProcTranFloChanges(Reincarapp.Models.reincardb.CliDeuProcTranFlo item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCliDeuProcTranFloUpdated(Reincarapp.Models.reincardb.CliDeuProcTranFlo item);
        partial void OnAfterCliDeuProcTranFloUpdated(Reincarapp.Models.reincardb.CliDeuProcTranFlo item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProcTranFlo> UpdateCliDeuProcTranFlo(long idclideuproc, Reincarapp.Models.reincardb.CliDeuProcTranFlo clideuproctranflo)
        {
            OnCliDeuProcTranFloUpdated(clideuproctranflo);

            var itemToUpdate = Context.CliDeuProcTranFlo
                              .Where(i => i.id_cli_deu_proc == clideuproctranflo.id_cli_deu_proc)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(clideuproctranflo);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCliDeuProcTranFloUpdated(clideuproctranflo);

            return clideuproctranflo;
        }

        partial void OnCliDeuProcTranFloDeleted(Reincarapp.Models.reincardb.CliDeuProcTranFlo item);
        partial void OnAfterCliDeuProcTranFloDeleted(Reincarapp.Models.reincardb.CliDeuProcTranFlo item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProcTranFlo> DeleteCliDeuProcTranFlo(long idclideuproc)
        {
            var itemToDelete = Context.CliDeuProcTranFlo
                              .Where(i => i.id_cli_deu_proc == idclideuproc)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCliDeuProcTranFloDeleted(itemToDelete);


            Context.CliDeuProcTranFlo.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCliDeuProcTranFloDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCliDeuProcTran1ToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clideuproctran1/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clideuproctran1/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCliDeuProcTran1ToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clideuproctran1/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clideuproctran1/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCliDeuProcTran1Read(ref IQueryable<Reincarapp.Models.reincardb.CliDeuProcTran1> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.CliDeuProcTran1>> GetCliDeuProcTran1(Query query = null)
        {
            var items = Context.CliDeuProcTran1.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCliDeuProcTran1Read(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCliDeuProcTran1Get(Reincarapp.Models.reincardb.CliDeuProcTran1 item);
        partial void OnGetCliDeuProcTran1ByIdCliDeuProc(ref IQueryable<Reincarapp.Models.reincardb.CliDeuProcTran1> items);


        public async Task<Reincarapp.Models.reincardb.CliDeuProcTran1> GetCliDeuProcTran1ByIdCliDeuProc(long idclideuproc)
        {
            var items = Context.CliDeuProcTran1
                              .AsNoTracking()
                              .Where(i => i.id_cli_deu_proc == idclideuproc);

 
            OnGetCliDeuProcTran1ByIdCliDeuProc(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCliDeuProcTran1Get(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCliDeuProcTran1Created(Reincarapp.Models.reincardb.CliDeuProcTran1 item);
        partial void OnAfterCliDeuProcTran1Created(Reincarapp.Models.reincardb.CliDeuProcTran1 item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProcTran1> CreateCliDeuProcTran1(Reincarapp.Models.reincardb.CliDeuProcTran1 clideuproctran1)
        {
            OnCliDeuProcTran1Created(clideuproctran1);

            var existingItem = Context.CliDeuProcTran1
                              .Where(i => i.id_cli_deu_proc == clideuproctran1.id_cli_deu_proc)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CliDeuProcTran1.Add(clideuproctran1);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(clideuproctran1).State = EntityState.Detached;
                throw;
            }

            OnAfterCliDeuProcTran1Created(clideuproctran1);

            return clideuproctran1;
        }

        public async Task<Reincarapp.Models.reincardb.CliDeuProcTran1> CancelCliDeuProcTran1Changes(Reincarapp.Models.reincardb.CliDeuProcTran1 item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCliDeuProcTran1Updated(Reincarapp.Models.reincardb.CliDeuProcTran1 item);
        partial void OnAfterCliDeuProcTran1Updated(Reincarapp.Models.reincardb.CliDeuProcTran1 item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProcTran1> UpdateCliDeuProcTran1(long idclideuproc, Reincarapp.Models.reincardb.CliDeuProcTran1 clideuproctran1)
        {
            OnCliDeuProcTran1Updated(clideuproctran1);

            var itemToUpdate = Context.CliDeuProcTran1
                              .Where(i => i.id_cli_deu_proc == clideuproctran1.id_cli_deu_proc)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(clideuproctran1);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCliDeuProcTran1Updated(clideuproctran1);

            return clideuproctran1;
        }

        partial void OnCliDeuProcTran1Deleted(Reincarapp.Models.reincardb.CliDeuProcTran1 item);
        partial void OnAfterCliDeuProcTran1Deleted(Reincarapp.Models.reincardb.CliDeuProcTran1 item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProcTran1> DeleteCliDeuProcTran1(long idclideuproc)
        {
            var itemToDelete = Context.CliDeuProcTran1
                              .Where(i => i.id_cli_deu_proc == idclideuproc)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCliDeuProcTran1Deleted(itemToDelete);


            Context.CliDeuProcTran1.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCliDeuProcTran1Deleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCliDeuProcTran2ToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clideuproctran2/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clideuproctran2/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCliDeuProcTran2ToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clideuproctran2/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clideuproctran2/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCliDeuProcTran2Read(ref IQueryable<Reincarapp.Models.reincardb.CliDeuProcTran2> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.CliDeuProcTran2>> GetCliDeuProcTran2(Query query = null)
        {
            var items = Context.CliDeuProcTran2.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCliDeuProcTran2Read(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCliDeuProcTran2Get(Reincarapp.Models.reincardb.CliDeuProcTran2 item);
        partial void OnGetCliDeuProcTran2ByIdCliDeuProc(ref IQueryable<Reincarapp.Models.reincardb.CliDeuProcTran2> items);


        public async Task<Reincarapp.Models.reincardb.CliDeuProcTran2> GetCliDeuProcTran2ByIdCliDeuProc(long idclideuproc)
        {
            var items = Context.CliDeuProcTran2
                              .AsNoTracking()
                              .Where(i => i.id_cli_deu_proc == idclideuproc);

 
            OnGetCliDeuProcTran2ByIdCliDeuProc(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCliDeuProcTran2Get(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCliDeuProcTran2Created(Reincarapp.Models.reincardb.CliDeuProcTran2 item);
        partial void OnAfterCliDeuProcTran2Created(Reincarapp.Models.reincardb.CliDeuProcTran2 item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProcTran2> CreateCliDeuProcTran2(Reincarapp.Models.reincardb.CliDeuProcTran2 clideuproctran2)
        {
            OnCliDeuProcTran2Created(clideuproctran2);

            var existingItem = Context.CliDeuProcTran2
                              .Where(i => i.id_cli_deu_proc == clideuproctran2.id_cli_deu_proc)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CliDeuProcTran2.Add(clideuproctran2);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(clideuproctran2).State = EntityState.Detached;
                throw;
            }

            OnAfterCliDeuProcTran2Created(clideuproctran2);

            return clideuproctran2;
        }

        public async Task<Reincarapp.Models.reincardb.CliDeuProcTran2> CancelCliDeuProcTran2Changes(Reincarapp.Models.reincardb.CliDeuProcTran2 item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCliDeuProcTran2Updated(Reincarapp.Models.reincardb.CliDeuProcTran2 item);
        partial void OnAfterCliDeuProcTran2Updated(Reincarapp.Models.reincardb.CliDeuProcTran2 item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProcTran2> UpdateCliDeuProcTran2(long idclideuproc, Reincarapp.Models.reincardb.CliDeuProcTran2 clideuproctran2)
        {
            OnCliDeuProcTran2Updated(clideuproctran2);

            var itemToUpdate = Context.CliDeuProcTran2
                              .Where(i => i.id_cli_deu_proc == clideuproctran2.id_cli_deu_proc)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(clideuproctran2);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCliDeuProcTran2Updated(clideuproctran2);

            return clideuproctran2;
        }

        partial void OnCliDeuProcTran2Deleted(Reincarapp.Models.reincardb.CliDeuProcTran2 item);
        partial void OnAfterCliDeuProcTran2Deleted(Reincarapp.Models.reincardb.CliDeuProcTran2 item);

        public async Task<Reincarapp.Models.reincardb.CliDeuProcTran2> DeleteCliDeuProcTran2(long idclideuproc)
        {
            var itemToDelete = Context.CliDeuProcTran2
                              .Where(i => i.id_cli_deu_proc == idclideuproc)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCliDeuProcTran2Deleted(itemToDelete);


            Context.CliDeuProcTran2.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCliDeuProcTran2Deleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportClienteToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/cliente/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/cliente/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClienteToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/cliente/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/cliente/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClienteRead(ref IQueryable<Reincarapp.Models.reincardb.Cliente> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Cliente>> GetCliente(Query query = null)
        {
            var items = Context.Cliente.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnClienteRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnClienteGet(Reincarapp.Models.reincardb.Cliente item);
        partial void OnGetClienteByIdCliente(ref IQueryable<Reincarapp.Models.reincardb.Cliente> items);


        public async Task<Reincarapp.Models.reincardb.Cliente> GetClienteByIdCliente(long idcliente)
        {
            var items = Context.Cliente
                              .AsNoTracking()
                              .Where(i => i.Id_Cliente == idcliente);

 
            OnGetClienteByIdCliente(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnClienteGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnClienteCreated(Reincarapp.Models.reincardb.Cliente item);
        partial void OnAfterClienteCreated(Reincarapp.Models.reincardb.Cliente item);

        public async Task<Reincarapp.Models.reincardb.Cliente> CreateCliente(Reincarapp.Models.reincardb.Cliente cliente)
        {
            OnClienteCreated(cliente);

            var existingItem = Context.Cliente
                              .Where(i => i.Id_Cliente == cliente.Id_Cliente)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Cliente.Add(cliente);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(cliente).State = EntityState.Detached;
                throw;
            }

            OnAfterClienteCreated(cliente);

            return cliente;
        }

        public async Task<Reincarapp.Models.reincardb.Cliente> CancelClienteChanges(Reincarapp.Models.reincardb.Cliente item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnClienteUpdated(Reincarapp.Models.reincardb.Cliente item);
        partial void OnAfterClienteUpdated(Reincarapp.Models.reincardb.Cliente item);

        public async Task<Reincarapp.Models.reincardb.Cliente> UpdateCliente(long idcliente, Reincarapp.Models.reincardb.Cliente cliente)
        {
            OnClienteUpdated(cliente);

            var itemToUpdate = Context.Cliente
                              .Where(i => i.Id_Cliente == cliente.Id_Cliente)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(cliente);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterClienteUpdated(cliente);

            return cliente;
        }

        partial void OnClienteDeleted(Reincarapp.Models.reincardb.Cliente item);
        partial void OnAfterClienteDeleted(Reincarapp.Models.reincardb.Cliente item);

        public async Task<Reincarapp.Models.reincardb.Cliente> DeleteCliente(long idcliente)
        {
            var itemToDelete = Context.Cliente
                              .Where(i => i.Id_Cliente == idcliente)
                              .Include(i => i.Base)
                              .Include(i => i.CampoHonorario)
                              .Include(i => i.ClasificacionAdicional)
                              .Include(i => i.ClienteDeuda)
                              .Include(i => i.ClienteDeudaDato)
                              .Include(i => i.DecisionEstado)
                              .Include(i => i.HonorarioAvvillas)
                              .Include(i => i.ResultadoEvento)
                              .Include(i => i.TipoComunicacion)
                              .Include(i => i.TipoComunicacionResultadoEvento)
                              .Include(i => i.TipoDatoPersona)
                              .Include(i => i.UsuarioCliente)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnClienteDeleted(itemToDelete);


            Context.Cliente.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterClienteDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportClienteDeudaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clientedeuda/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clientedeuda/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClienteDeudaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clientedeuda/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clientedeuda/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClienteDeudaRead(ref IQueryable<Reincarapp.Models.reincardb.ClienteDeuda> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ClienteDeuda>> GetClienteDeuda(Query query = null)
        {
            var items = Context.ClienteDeuda.AsQueryable();

            items = items.Include(i => i.Asignacion);
            items = items.Include(i => i.Cliente);
            items = items.Include(i => i.EstadoClienteDeuda);
            items = items.Include(i => i.ResultadoEvento);
            items = items.Include(i => i.Persona);
            items = items.Include(i => i.ResultadoEvento1);
            items = items.Include(i => i.Usuario);
            items = items.Include(i => i.Usuario1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnClienteDeudaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnClienteDeudaGet(Reincarapp.Models.reincardb.ClienteDeuda item);
        partial void OnGetClienteDeudaByIdClienteDeuda(ref IQueryable<Reincarapp.Models.reincardb.ClienteDeuda> items);


        public async Task<Reincarapp.Models.reincardb.ClienteDeuda> GetClienteDeudaByIdClienteDeuda(long idclientedeuda)
        {
            var items = Context.ClienteDeuda
                              .AsNoTracking()
                              .Where(i => i.Id_Cliente_Deuda == idclientedeuda);

            items = items.Include(i => i.Asignacion);
            items = items.Include(i => i.Cliente);
            items = items.Include(i => i.EstadoClienteDeuda);
            items = items.Include(i => i.ResultadoEvento);
            items = items.Include(i => i.Persona);
            items = items.Include(i => i.ResultadoEvento1);
            items = items.Include(i => i.Usuario);
            items = items.Include(i => i.Usuario1);
 
            OnGetClienteDeudaByIdClienteDeuda(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnClienteDeudaGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnClienteDeudaCreated(Reincarapp.Models.reincardb.ClienteDeuda item);
        partial void OnAfterClienteDeudaCreated(Reincarapp.Models.reincardb.ClienteDeuda item);

        public async Task<Reincarapp.Models.reincardb.ClienteDeuda> CreateClienteDeuda(Reincarapp.Models.reincardb.ClienteDeuda clientedeuda)
        {
            OnClienteDeudaCreated(clientedeuda);

            var existingItem = Context.ClienteDeuda
                              .Where(i => i.Id_Cliente_Deuda == clientedeuda.Id_Cliente_Deuda)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ClienteDeuda.Add(clientedeuda);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(clientedeuda).State = EntityState.Detached;
                throw;
            }

            OnAfterClienteDeudaCreated(clientedeuda);

            return clientedeuda;
        }

        public async Task<Reincarapp.Models.reincardb.ClienteDeuda> CancelClienteDeudaChanges(Reincarapp.Models.reincardb.ClienteDeuda item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnClienteDeudaUpdated(Reincarapp.Models.reincardb.ClienteDeuda item);
        partial void OnAfterClienteDeudaUpdated(Reincarapp.Models.reincardb.ClienteDeuda item);

        public async Task<Reincarapp.Models.reincardb.ClienteDeuda> UpdateClienteDeuda(long idclientedeuda, Reincarapp.Models.reincardb.ClienteDeuda clientedeuda)
        {
            OnClienteDeudaUpdated(clientedeuda);

            var itemToUpdate = Context.ClienteDeuda
                              .Where(i => i.Id_Cliente_Deuda == clientedeuda.Id_Cliente_Deuda)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(clientedeuda);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterClienteDeudaUpdated(clientedeuda);

            return clientedeuda;
        }

        partial void OnClienteDeudaDeleted(Reincarapp.Models.reincardb.ClienteDeuda item);
        partial void OnAfterClienteDeudaDeleted(Reincarapp.Models.reincardb.ClienteDeuda item);

        public async Task<Reincarapp.Models.reincardb.ClienteDeuda> DeleteClienteDeuda(long idclientedeuda)
        {
            var itemToDelete = Context.ClienteDeuda
                              .Where(i => i.Id_Cliente_Deuda == idclientedeuda)
                              .Include(i => i.Acueducto)
                              .Include(i => i.Avvillas)
                              .Include(i => i.Avvillasbuc)
                              .Include(i => i.Bancobogota)
                              .Include(i => i.Bancoomeva)
                              .Include(i => i.BaseJuridica)
                              .Include(i => i.Bloqueocontacto)
                              .Include(i => i.Censprejuridico)
                              .Include(i => i.Checprejuridico)
                              .Include(i => i.Citibank)
                              .Include(i => i.Citibank2)
                              .Include(i => i.ClienteDeudaCons)
                              .Include(i => i.ClienteDeudaDato)
                              .Include(i => i.ClienteDeudaHonorario)
                              .Include(i => i.ClienteDeudaUsuario)
                              .Include(i => i.CoomultrasanCastigo)
                              .Include(i => i.CoomultrasanJuridica)
                              .Include(i => i.CoomultrasanLey79)
                              .Include(i => i.CoomultrasanTemprana)
                              .Include(i => i.Coopetrol)
                              .Include(i => i.Credidos)
                              .Include(i => i.Credivalores)
                              .Include(i => i.Credivalores2)
                              .Include(i => i.Credivaloresalt)
                              .Include(i => i.DatoClienteDeuda)
                              .Include(i => i.Evento)
                              .Include(i => i.Jamar)
                              .Include(i => i.LogClienteDeudaEstado)
                              .Include(i => i.Maf)
                              .Include(i => i.Menco)
                              .Include(i => i.Promotora)
                              .Include(i => i.Rediferido)
                              .Include(i => i.Saludcoop)
                              .Include(i => i.Tarea)
                              .Include(i => i.Transito)
                              .Include(i => i.Transitobuc)
                              .Include(i => i.Transitoflo)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnClienteDeudaDeleted(itemToDelete);


            Context.ClienteDeuda.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterClienteDeudaDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportClienteDeudaAgrupToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clientedeudaagrup/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clientedeudaagrup/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClienteDeudaAgrupToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clientedeudaagrup/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clientedeudaagrup/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClienteDeudaAgrupRead(ref IQueryable<Reincarapp.Models.reincardb.ClienteDeudaAgrup> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ClienteDeudaAgrup>> GetClienteDeudaAgrup(Query query = null)
        {
            var items = Context.ClienteDeudaAgrup.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnClienteDeudaAgrupRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportClienteDeudaAuxToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clientedeudaaux/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clientedeudaaux/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClienteDeudaAuxToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clientedeudaaux/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clientedeudaaux/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClienteDeudaAuxRead(ref IQueryable<Reincarapp.Models.reincardb.ClienteDeudaAux> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ClienteDeudaAux>> GetClienteDeudaAux(Query query = null)
        {
            var items = Context.ClienteDeudaAux.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnClienteDeudaAuxRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnClienteDeudaAuxGet(Reincarapp.Models.reincardb.ClienteDeudaAux item);
        partial void OnGetClienteDeudaAuxByIdClienteDeuda(ref IQueryable<Reincarapp.Models.reincardb.ClienteDeudaAux> items);


        public async Task<Reincarapp.Models.reincardb.ClienteDeudaAux> GetClienteDeudaAuxByIdClienteDeuda(long idclientedeuda)
        {
            var items = Context.ClienteDeudaAux
                              .AsNoTracking()
                              .Where(i => i.Id_Cliente_Deuda == idclientedeuda);

 
            OnGetClienteDeudaAuxByIdClienteDeuda(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnClienteDeudaAuxGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnClienteDeudaAuxCreated(Reincarapp.Models.reincardb.ClienteDeudaAux item);
        partial void OnAfterClienteDeudaAuxCreated(Reincarapp.Models.reincardb.ClienteDeudaAux item);

        public async Task<Reincarapp.Models.reincardb.ClienteDeudaAux> CreateClienteDeudaAux(Reincarapp.Models.reincardb.ClienteDeudaAux clientedeudaaux)
        {
            OnClienteDeudaAuxCreated(clientedeudaaux);

            var existingItem = Context.ClienteDeudaAux
                              .Where(i => i.Id_Cliente_Deuda == clientedeudaaux.Id_Cliente_Deuda)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ClienteDeudaAux.Add(clientedeudaaux);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(clientedeudaaux).State = EntityState.Detached;
                throw;
            }

            OnAfterClienteDeudaAuxCreated(clientedeudaaux);

            return clientedeudaaux;
        }

        public async Task<Reincarapp.Models.reincardb.ClienteDeudaAux> CancelClienteDeudaAuxChanges(Reincarapp.Models.reincardb.ClienteDeudaAux item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnClienteDeudaAuxUpdated(Reincarapp.Models.reincardb.ClienteDeudaAux item);
        partial void OnAfterClienteDeudaAuxUpdated(Reincarapp.Models.reincardb.ClienteDeudaAux item);

        public async Task<Reincarapp.Models.reincardb.ClienteDeudaAux> UpdateClienteDeudaAux(long idclientedeuda, Reincarapp.Models.reincardb.ClienteDeudaAux clientedeudaaux)
        {
            OnClienteDeudaAuxUpdated(clientedeudaaux);

            var itemToUpdate = Context.ClienteDeudaAux
                              .Where(i => i.Id_Cliente_Deuda == clientedeudaaux.Id_Cliente_Deuda)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(clientedeudaaux);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterClienteDeudaAuxUpdated(clientedeudaaux);

            return clientedeudaaux;
        }

        partial void OnClienteDeudaAuxDeleted(Reincarapp.Models.reincardb.ClienteDeudaAux item);
        partial void OnAfterClienteDeudaAuxDeleted(Reincarapp.Models.reincardb.ClienteDeudaAux item);

        public async Task<Reincarapp.Models.reincardb.ClienteDeudaAux> DeleteClienteDeudaAux(long idclientedeuda)
        {
            var itemToDelete = Context.ClienteDeudaAux
                              .Where(i => i.Id_Cliente_Deuda == idclientedeuda)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnClienteDeudaAuxDeleted(itemToDelete);


            Context.ClienteDeudaAux.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterClienteDeudaAuxDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportClienteDeudaConsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clientedeudacons/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clientedeudacons/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClienteDeudaConsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clientedeudacons/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clientedeudacons/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClienteDeudaConsRead(ref IQueryable<Reincarapp.Models.reincardb.ClienteDeudaCons> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ClienteDeudaCons>> GetClienteDeudaCons(Query query = null)
        {
            var items = Context.ClienteDeudaCons.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);
            items = items.Include(i => i.Evento);
            items = items.Include(i => i.Evento1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnClienteDeudaConsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnClienteDeudaConsGet(Reincarapp.Models.reincardb.ClienteDeudaCons item);
        partial void OnGetClienteDeudaConsByIdClienteDeudaCons(ref IQueryable<Reincarapp.Models.reincardb.ClienteDeudaCons> items);


        public async Task<Reincarapp.Models.reincardb.ClienteDeudaCons> GetClienteDeudaConsByIdClienteDeudaCons(long idclientedeudacons)
        {
            var items = Context.ClienteDeudaCons
                              .AsNoTracking()
                              .Where(i => i.id_cliente_deuda_cons == idclientedeudacons);

            items = items.Include(i => i.ClienteDeuda);
            items = items.Include(i => i.Evento);
            items = items.Include(i => i.Evento1);
 
            OnGetClienteDeudaConsByIdClienteDeudaCons(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnClienteDeudaConsGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnClienteDeudaConsCreated(Reincarapp.Models.reincardb.ClienteDeudaCons item);
        partial void OnAfterClienteDeudaConsCreated(Reincarapp.Models.reincardb.ClienteDeudaCons item);

        public async Task<Reincarapp.Models.reincardb.ClienteDeudaCons> CreateClienteDeudaCons(Reincarapp.Models.reincardb.ClienteDeudaCons clientedeudacons)
        {
            OnClienteDeudaConsCreated(clientedeudacons);

            var existingItem = Context.ClienteDeudaCons
                              .Where(i => i.id_cliente_deuda_cons == clientedeudacons.id_cliente_deuda_cons)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ClienteDeudaCons.Add(clientedeudacons);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(clientedeudacons).State = EntityState.Detached;
                throw;
            }

            OnAfterClienteDeudaConsCreated(clientedeudacons);

            return clientedeudacons;
        }

        public async Task<Reincarapp.Models.reincardb.ClienteDeudaCons> CancelClienteDeudaConsChanges(Reincarapp.Models.reincardb.ClienteDeudaCons item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnClienteDeudaConsUpdated(Reincarapp.Models.reincardb.ClienteDeudaCons item);
        partial void OnAfterClienteDeudaConsUpdated(Reincarapp.Models.reincardb.ClienteDeudaCons item);

        public async Task<Reincarapp.Models.reincardb.ClienteDeudaCons> UpdateClienteDeudaCons(long idclientedeudacons, Reincarapp.Models.reincardb.ClienteDeudaCons clientedeudacons)
        {
            OnClienteDeudaConsUpdated(clientedeudacons);

            var itemToUpdate = Context.ClienteDeudaCons
                              .Where(i => i.id_cliente_deuda_cons == clientedeudacons.id_cliente_deuda_cons)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(clientedeudacons);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterClienteDeudaConsUpdated(clientedeudacons);

            return clientedeudacons;
        }

        partial void OnClienteDeudaConsDeleted(Reincarapp.Models.reincardb.ClienteDeudaCons item);
        partial void OnAfterClienteDeudaConsDeleted(Reincarapp.Models.reincardb.ClienteDeudaCons item);

        public async Task<Reincarapp.Models.reincardb.ClienteDeudaCons> DeleteClienteDeudaCons(long idclientedeudacons)
        {
            var itemToDelete = Context.ClienteDeudaCons
                              .Where(i => i.id_cliente_deuda_cons == idclientedeudacons)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnClienteDeudaConsDeleted(itemToDelete);


            Context.ClienteDeudaCons.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterClienteDeudaConsDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportClienteDeudaDatoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clientedeudadato/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clientedeudadato/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClienteDeudaDatoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clientedeudadato/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clientedeudadato/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClienteDeudaDatoRead(ref IQueryable<Reincarapp.Models.reincardb.ClienteDeudaDato> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ClienteDeudaDato>> GetClienteDeudaDato(Query query = null)
        {
            var items = Context.ClienteDeudaDato.AsQueryable();

            items = items.Include(i => i.Cliente);
            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnClienteDeudaDatoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnClienteDeudaDatoGet(Reincarapp.Models.reincardb.ClienteDeudaDato item);
        partial void OnGetClienteDeudaDatoById(ref IQueryable<Reincarapp.Models.reincardb.ClienteDeudaDato> items);


        public async Task<Reincarapp.Models.reincardb.ClienteDeudaDato> GetClienteDeudaDatoById(long id)
        {
            var items = Context.ClienteDeudaDato
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Cliente);
            items = items.Include(i => i.ClienteDeuda);
 
            OnGetClienteDeudaDatoById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnClienteDeudaDatoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnClienteDeudaDatoCreated(Reincarapp.Models.reincardb.ClienteDeudaDato item);
        partial void OnAfterClienteDeudaDatoCreated(Reincarapp.Models.reincardb.ClienteDeudaDato item);

        public async Task<Reincarapp.Models.reincardb.ClienteDeudaDato> CreateClienteDeudaDato(Reincarapp.Models.reincardb.ClienteDeudaDato clientedeudadato)
        {
            OnClienteDeudaDatoCreated(clientedeudadato);

            var existingItem = Context.ClienteDeudaDato
                              .Where(i => i.Id == clientedeudadato.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ClienteDeudaDato.Add(clientedeudadato);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(clientedeudadato).State = EntityState.Detached;
                throw;
            }

            OnAfterClienteDeudaDatoCreated(clientedeudadato);

            return clientedeudadato;
        }

        public async Task<Reincarapp.Models.reincardb.ClienteDeudaDato> CancelClienteDeudaDatoChanges(Reincarapp.Models.reincardb.ClienteDeudaDato item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnClienteDeudaDatoUpdated(Reincarapp.Models.reincardb.ClienteDeudaDato item);
        partial void OnAfterClienteDeudaDatoUpdated(Reincarapp.Models.reincardb.ClienteDeudaDato item);

        public async Task<Reincarapp.Models.reincardb.ClienteDeudaDato> UpdateClienteDeudaDato(long id, Reincarapp.Models.reincardb.ClienteDeudaDato clientedeudadato)
        {
            OnClienteDeudaDatoUpdated(clientedeudadato);

            var itemToUpdate = Context.ClienteDeudaDato
                              .Where(i => i.Id == clientedeudadato.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(clientedeudadato);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterClienteDeudaDatoUpdated(clientedeudadato);

            return clientedeudadato;
        }

        partial void OnClienteDeudaDatoDeleted(Reincarapp.Models.reincardb.ClienteDeudaDato item);
        partial void OnAfterClienteDeudaDatoDeleted(Reincarapp.Models.reincardb.ClienteDeudaDato item);

        public async Task<Reincarapp.Models.reincardb.ClienteDeudaDato> DeleteClienteDeudaDato(long id)
        {
            var itemToDelete = Context.ClienteDeudaDato
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnClienteDeudaDatoDeleted(itemToDelete);


            Context.ClienteDeudaDato.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterClienteDeudaDatoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportClienteDeudaHonorarioToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clientedeudahonorario/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clientedeudahonorario/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClienteDeudaHonorarioToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clientedeudahonorario/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clientedeudahonorario/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClienteDeudaHonorarioRead(ref IQueryable<Reincarapp.Models.reincardb.ClienteDeudaHonorario> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ClienteDeudaHonorario>> GetClienteDeudaHonorario(Query query = null)
        {
            var items = Context.ClienteDeudaHonorario.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);
            items = items.Include(i => i.Evento);
            items = items.Include(i => i.Usuario);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnClienteDeudaHonorarioRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnClienteDeudaHonorarioGet(Reincarapp.Models.reincardb.ClienteDeudaHonorario item);
        partial void OnGetClienteDeudaHonorarioByIdClienteDeudaHonorario(ref IQueryable<Reincarapp.Models.reincardb.ClienteDeudaHonorario> items);


        public async Task<Reincarapp.Models.reincardb.ClienteDeudaHonorario> GetClienteDeudaHonorarioByIdClienteDeudaHonorario(long idclientedeudahonorario)
        {
            var items = Context.ClienteDeudaHonorario
                              .AsNoTracking()
                              .Where(i => i.id_cliente_deuda_honorario == idclientedeudahonorario);

            items = items.Include(i => i.ClienteDeuda);
            items = items.Include(i => i.Evento);
            items = items.Include(i => i.Usuario);
 
            OnGetClienteDeudaHonorarioByIdClienteDeudaHonorario(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnClienteDeudaHonorarioGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnClienteDeudaHonorarioCreated(Reincarapp.Models.reincardb.ClienteDeudaHonorario item);
        partial void OnAfterClienteDeudaHonorarioCreated(Reincarapp.Models.reincardb.ClienteDeudaHonorario item);

        public async Task<Reincarapp.Models.reincardb.ClienteDeudaHonorario> CreateClienteDeudaHonorario(Reincarapp.Models.reincardb.ClienteDeudaHonorario clientedeudahonorario)
        {
            OnClienteDeudaHonorarioCreated(clientedeudahonorario);

            var existingItem = Context.ClienteDeudaHonorario
                              .Where(i => i.id_cliente_deuda_honorario == clientedeudahonorario.id_cliente_deuda_honorario)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ClienteDeudaHonorario.Add(clientedeudahonorario);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(clientedeudahonorario).State = EntityState.Detached;
                throw;
            }

            OnAfterClienteDeudaHonorarioCreated(clientedeudahonorario);

            return clientedeudahonorario;
        }

        public async Task<Reincarapp.Models.reincardb.ClienteDeudaHonorario> CancelClienteDeudaHonorarioChanges(Reincarapp.Models.reincardb.ClienteDeudaHonorario item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnClienteDeudaHonorarioUpdated(Reincarapp.Models.reincardb.ClienteDeudaHonorario item);
        partial void OnAfterClienteDeudaHonorarioUpdated(Reincarapp.Models.reincardb.ClienteDeudaHonorario item);

        public async Task<Reincarapp.Models.reincardb.ClienteDeudaHonorario> UpdateClienteDeudaHonorario(long idclientedeudahonorario, Reincarapp.Models.reincardb.ClienteDeudaHonorario clientedeudahonorario)
        {
            OnClienteDeudaHonorarioUpdated(clientedeudahonorario);

            var itemToUpdate = Context.ClienteDeudaHonorario
                              .Where(i => i.id_cliente_deuda_honorario == clientedeudahonorario.id_cliente_deuda_honorario)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(clientedeudahonorario);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterClienteDeudaHonorarioUpdated(clientedeudahonorario);

            return clientedeudahonorario;
        }

        partial void OnClienteDeudaHonorarioDeleted(Reincarapp.Models.reincardb.ClienteDeudaHonorario item);
        partial void OnAfterClienteDeudaHonorarioDeleted(Reincarapp.Models.reincardb.ClienteDeudaHonorario item);

        public async Task<Reincarapp.Models.reincardb.ClienteDeudaHonorario> DeleteClienteDeudaHonorario(long idclientedeudahonorario)
        {
            var itemToDelete = Context.ClienteDeudaHonorario
                              .Where(i => i.id_cliente_deuda_honorario == idclientedeudahonorario)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnClienteDeudaHonorarioDeleted(itemToDelete);


            Context.ClienteDeudaHonorario.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterClienteDeudaHonorarioDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportClienteDeudaUsuarioToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clientedeudausuario/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clientedeudausuario/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClienteDeudaUsuarioToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clientedeudausuario/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clientedeudausuario/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClienteDeudaUsuarioRead(ref IQueryable<Reincarapp.Models.reincardb.ClienteDeudaUsuario> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ClienteDeudaUsuario>> GetClienteDeudaUsuario(Query query = null)
        {
            var items = Context.ClienteDeudaUsuario.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);
            items = items.Include(i => i.Usuario);
            items = items.Include(i => i.Usuario1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnClienteDeudaUsuarioRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnClienteDeudaUsuarioGet(Reincarapp.Models.reincardb.ClienteDeudaUsuario item);
        partial void OnGetClienteDeudaUsuarioByIdClienteDeudaUsuario(ref IQueryable<Reincarapp.Models.reincardb.ClienteDeudaUsuario> items);


        public async Task<Reincarapp.Models.reincardb.ClienteDeudaUsuario> GetClienteDeudaUsuarioByIdClienteDeudaUsuario(long idclientedeudausuario)
        {
            var items = Context.ClienteDeudaUsuario
                              .AsNoTracking()
                              .Where(i => i.Id_Cliente_Deuda_Usuario == idclientedeudausuario);

            items = items.Include(i => i.ClienteDeuda);
            items = items.Include(i => i.Usuario);
            items = items.Include(i => i.Usuario1);
 
            OnGetClienteDeudaUsuarioByIdClienteDeudaUsuario(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnClienteDeudaUsuarioGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnClienteDeudaUsuarioCreated(Reincarapp.Models.reincardb.ClienteDeudaUsuario item);
        partial void OnAfterClienteDeudaUsuarioCreated(Reincarapp.Models.reincardb.ClienteDeudaUsuario item);

        public async Task<Reincarapp.Models.reincardb.ClienteDeudaUsuario> CreateClienteDeudaUsuario(Reincarapp.Models.reincardb.ClienteDeudaUsuario clientedeudausuario)
        {
            OnClienteDeudaUsuarioCreated(clientedeudausuario);

            var existingItem = Context.ClienteDeudaUsuario
                              .Where(i => i.Id_Cliente_Deuda_Usuario == clientedeudausuario.Id_Cliente_Deuda_Usuario)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ClienteDeudaUsuario.Add(clientedeudausuario);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(clientedeudausuario).State = EntityState.Detached;
                throw;
            }

            OnAfterClienteDeudaUsuarioCreated(clientedeudausuario);

            return clientedeudausuario;
        }

        public async Task<Reincarapp.Models.reincardb.ClienteDeudaUsuario> CancelClienteDeudaUsuarioChanges(Reincarapp.Models.reincardb.ClienteDeudaUsuario item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnClienteDeudaUsuarioUpdated(Reincarapp.Models.reincardb.ClienteDeudaUsuario item);
        partial void OnAfterClienteDeudaUsuarioUpdated(Reincarapp.Models.reincardb.ClienteDeudaUsuario item);

        public async Task<Reincarapp.Models.reincardb.ClienteDeudaUsuario> UpdateClienteDeudaUsuario(long idclientedeudausuario, Reincarapp.Models.reincardb.ClienteDeudaUsuario clientedeudausuario)
        {
            OnClienteDeudaUsuarioUpdated(clientedeudausuario);

            var itemToUpdate = Context.ClienteDeudaUsuario
                              .Where(i => i.Id_Cliente_Deuda_Usuario == clientedeudausuario.Id_Cliente_Deuda_Usuario)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(clientedeudausuario);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterClienteDeudaUsuarioUpdated(clientedeudausuario);

            return clientedeudausuario;
        }

        partial void OnClienteDeudaUsuarioDeleted(Reincarapp.Models.reincardb.ClienteDeudaUsuario item);
        partial void OnAfterClienteDeudaUsuarioDeleted(Reincarapp.Models.reincardb.ClienteDeudaUsuario item);

        public async Task<Reincarapp.Models.reincardb.ClienteDeudaUsuario> DeleteClienteDeudaUsuario(long idclientedeudausuario)
        {
            var itemToDelete = Context.ClienteDeudaUsuario
                              .Where(i => i.Id_Cliente_Deuda_Usuario == idclientedeudausuario)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnClienteDeudaUsuarioDeleted(itemToDelete);


            Context.ClienteDeudaUsuario.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterClienteDeudaUsuarioDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportClientedeudaborrarToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clientedeudaborrar/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clientedeudaborrar/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClientedeudaborrarToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/clientedeudaborrar/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/clientedeudaborrar/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClientedeudaborrarRead(ref IQueryable<Reincarapp.Models.reincardb.Clientedeudaborrar> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Clientedeudaborrar>> GetClientedeudaborrar(Query query = null)
        {
            var items = Context.Clientedeudaborrar.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnClientedeudaborrarRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnClientedeudaborrarGet(Reincarapp.Models.reincardb.Clientedeudaborrar item);
        partial void OnGetClientedeudaborrarByIdClienteDeuda(ref IQueryable<Reincarapp.Models.reincardb.Clientedeudaborrar> items);


        public async Task<Reincarapp.Models.reincardb.Clientedeudaborrar> GetClientedeudaborrarByIdClienteDeuda(long idclientedeuda)
        {
            var items = Context.Clientedeudaborrar
                              .AsNoTracking()
                              .Where(i => i.id_Cliente_Deuda == idclientedeuda);

 
            OnGetClientedeudaborrarByIdClienteDeuda(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnClientedeudaborrarGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnClientedeudaborrarCreated(Reincarapp.Models.reincardb.Clientedeudaborrar item);
        partial void OnAfterClientedeudaborrarCreated(Reincarapp.Models.reincardb.Clientedeudaborrar item);

        public async Task<Reincarapp.Models.reincardb.Clientedeudaborrar> CreateClientedeudaborrar(Reincarapp.Models.reincardb.Clientedeudaborrar clientedeudaborrar)
        {
            OnClientedeudaborrarCreated(clientedeudaborrar);

            var existingItem = Context.Clientedeudaborrar
                              .Where(i => i.id_Cliente_Deuda == clientedeudaborrar.id_Cliente_Deuda)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Clientedeudaborrar.Add(clientedeudaborrar);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(clientedeudaborrar).State = EntityState.Detached;
                throw;
            }

            OnAfterClientedeudaborrarCreated(clientedeudaborrar);

            return clientedeudaborrar;
        }

        public async Task<Reincarapp.Models.reincardb.Clientedeudaborrar> CancelClientedeudaborrarChanges(Reincarapp.Models.reincardb.Clientedeudaborrar item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnClientedeudaborrarUpdated(Reincarapp.Models.reincardb.Clientedeudaborrar item);
        partial void OnAfterClientedeudaborrarUpdated(Reincarapp.Models.reincardb.Clientedeudaborrar item);

        public async Task<Reincarapp.Models.reincardb.Clientedeudaborrar> UpdateClientedeudaborrar(long idclientedeuda, Reincarapp.Models.reincardb.Clientedeudaborrar clientedeudaborrar)
        {
            OnClientedeudaborrarUpdated(clientedeudaborrar);

            var itemToUpdate = Context.Clientedeudaborrar
                              .Where(i => i.id_Cliente_Deuda == clientedeudaborrar.id_Cliente_Deuda)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(clientedeudaborrar);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterClientedeudaborrarUpdated(clientedeudaborrar);

            return clientedeudaborrar;
        }

        partial void OnClientedeudaborrarDeleted(Reincarapp.Models.reincardb.Clientedeudaborrar item);
        partial void OnAfterClientedeudaborrarDeleted(Reincarapp.Models.reincardb.Clientedeudaborrar item);

        public async Task<Reincarapp.Models.reincardb.Clientedeudaborrar> DeleteClientedeudaborrar(long idclientedeuda)
        {
            var itemToDelete = Context.Clientedeudaborrar
                              .Where(i => i.id_Cliente_Deuda == idclientedeuda)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnClientedeudaborrarDeleted(itemToDelete);


            Context.Clientedeudaborrar.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterClientedeudaborrarDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportComparendosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/comparendos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/comparendos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportComparendosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/comparendos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/comparendos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnComparendosRead(ref IQueryable<Reincarapp.Models.reincardb.Comparendos> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Comparendos>> GetComparendos(Query query = null)
        {
            var items = Context.Comparendos.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnComparendosRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportConsCvC1ToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/conscvc1/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/conscvc1/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportConsCvC1ToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/conscvc1/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/conscvc1/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnConsCvC1Read(ref IQueryable<Reincarapp.Models.reincardb.ConsCvC1> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ConsCvC1>> GetConsCvC1(Query query = null)
        {
            var items = Context.ConsCvC1.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnConsCvC1Read(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportConsCvC12ToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/conscvc12/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/conscvc12/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportConsCvC12ToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/conscvc12/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/conscvc12/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnConsCvC12Read(ref IQueryable<Reincarapp.Models.reincardb.ConsCvC12> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ConsCvC12>> GetConsCvC12(Query query = null)
        {
            var items = Context.ConsCvC12.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnConsCvC12Read(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportConsCvC13ToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/conscvc13/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/conscvc13/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportConsCvC13ToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/conscvc13/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/conscvc13/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnConsCvC13Read(ref IQueryable<Reincarapp.Models.reincardb.ConsCvC13> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ConsCvC13>> GetConsCvC13(Query query = null)
        {
            var items = Context.ConsCvC13.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnConsCvC13Read(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportConsCvC14ToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/conscvc14/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/conscvc14/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportConsCvC14ToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/conscvc14/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/conscvc14/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnConsCvC14Read(ref IQueryable<Reincarapp.Models.reincardb.ConsCvC14> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ConsCvC14>> GetConsCvC14(Query query = null)
        {
            var items = Context.ConsCvC14.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnConsCvC14Read(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportConsCvC1CredidosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/conscvc1credidos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/conscvc1credidos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportConsCvC1CredidosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/conscvc1credidos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/conscvc1credidos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnConsCvC1CredidosRead(ref IQueryable<Reincarapp.Models.reincardb.ConsCvC1Credidos> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ConsCvC1Credidos>> GetConsCvC1Credidos(Query query = null)
        {
            var items = Context.ConsCvC1Credidos.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnConsCvC1CredidosRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportConsCvC1ProgresaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/conscvc1progresa/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/conscvc1progresa/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportConsCvC1ProgresaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/conscvc1progresa/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/conscvc1progresa/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnConsCvC1ProgresaRead(ref IQueryable<Reincarapp.Models.reincardb.ConsCvC1Progresa> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ConsCvC1Progresa>> GetConsCvC1Progresa(Query query = null)
        {
            var items = Context.ConsCvC1Progresa.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnConsCvC1ProgresaRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportConsInfTransitoBucToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/consinftransitobuc/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/consinftransitobuc/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportConsInfTransitoBucToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/consinftransitobuc/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/consinftransitobuc/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnConsInfTransitoBucRead(ref IQueryable<Reincarapp.Models.reincardb.ConsInfTransitoBuc> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ConsInfTransitoBuc>> GetConsInfTransitoBuc(Query query = null)
        {
            var items = Context.ConsInfTransitoBuc.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnConsInfTransitoBucRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnConsInfTransitoBucGet(Reincarapp.Models.reincardb.ConsInfTransitoBuc item);
        partial void OnGetConsInfTransitoBucByIdTransitoBuc(ref IQueryable<Reincarapp.Models.reincardb.ConsInfTransitoBuc> items);


        public async Task<Reincarapp.Models.reincardb.ConsInfTransitoBuc> GetConsInfTransitoBucByIdTransitoBuc(long idtransitobuc)
        {
            var items = Context.ConsInfTransitoBuc
                              .AsNoTracking()
                              .Where(i => i.id_transito_buc == idtransitobuc);

 
            OnGetConsInfTransitoBucByIdTransitoBuc(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnConsInfTransitoBucGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnConsInfTransitoBucCreated(Reincarapp.Models.reincardb.ConsInfTransitoBuc item);
        partial void OnAfterConsInfTransitoBucCreated(Reincarapp.Models.reincardb.ConsInfTransitoBuc item);

        public async Task<Reincarapp.Models.reincardb.ConsInfTransitoBuc> CreateConsInfTransitoBuc(Reincarapp.Models.reincardb.ConsInfTransitoBuc consinftransitobuc)
        {
            OnConsInfTransitoBucCreated(consinftransitobuc);

            var existingItem = Context.ConsInfTransitoBuc
                              .Where(i => i.id_transito_buc == consinftransitobuc.id_transito_buc)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ConsInfTransitoBuc.Add(consinftransitobuc);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(consinftransitobuc).State = EntityState.Detached;
                throw;
            }

            OnAfterConsInfTransitoBucCreated(consinftransitobuc);

            return consinftransitobuc;
        }

        public async Task<Reincarapp.Models.reincardb.ConsInfTransitoBuc> CancelConsInfTransitoBucChanges(Reincarapp.Models.reincardb.ConsInfTransitoBuc item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnConsInfTransitoBucUpdated(Reincarapp.Models.reincardb.ConsInfTransitoBuc item);
        partial void OnAfterConsInfTransitoBucUpdated(Reincarapp.Models.reincardb.ConsInfTransitoBuc item);

        public async Task<Reincarapp.Models.reincardb.ConsInfTransitoBuc> UpdateConsInfTransitoBuc(long idtransitobuc, Reincarapp.Models.reincardb.ConsInfTransitoBuc consinftransitobuc)
        {
            OnConsInfTransitoBucUpdated(consinftransitobuc);

            var itemToUpdate = Context.ConsInfTransitoBuc
                              .Where(i => i.id_transito_buc == consinftransitobuc.id_transito_buc)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(consinftransitobuc);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterConsInfTransitoBucUpdated(consinftransitobuc);

            return consinftransitobuc;
        }

        partial void OnConsInfTransitoBucDeleted(Reincarapp.Models.reincardb.ConsInfTransitoBuc item);
        partial void OnAfterConsInfTransitoBucDeleted(Reincarapp.Models.reincardb.ConsInfTransitoBuc item);

        public async Task<Reincarapp.Models.reincardb.ConsInfTransitoBuc> DeleteConsInfTransitoBuc(long idtransitobuc)
        {
            var itemToDelete = Context.ConsInfTransitoBuc
                              .Where(i => i.id_transito_buc == idtransitobuc)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnConsInfTransitoBucDeleted(itemToDelete);


            Context.ConsInfTransitoBuc.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterConsInfTransitoBucDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportConsInfTransitoBucFinalToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/consinftransitobucfinal/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/consinftransitobucfinal/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportConsInfTransitoBucFinalToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/consinftransitobucfinal/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/consinftransitobucfinal/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnConsInfTransitoBucFinalRead(ref IQueryable<Reincarapp.Models.reincardb.ConsInfTransitoBucFinal> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ConsInfTransitoBucFinal>> GetConsInfTransitoBucFinal(Query query = null)
        {
            var items = Context.ConsInfTransitoBucFinal.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnConsInfTransitoBucFinalRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnConsInfTransitoBucFinalGet(Reincarapp.Models.reincardb.ConsInfTransitoBucFinal item);
        partial void OnGetConsInfTransitoBucFinalByIdTransitoBuc(ref IQueryable<Reincarapp.Models.reincardb.ConsInfTransitoBucFinal> items);


        public async Task<Reincarapp.Models.reincardb.ConsInfTransitoBucFinal> GetConsInfTransitoBucFinalByIdTransitoBuc(long idtransitobuc)
        {
            var items = Context.ConsInfTransitoBucFinal
                              .AsNoTracking()
                              .Where(i => i.id_transito_buc == idtransitobuc);

 
            OnGetConsInfTransitoBucFinalByIdTransitoBuc(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnConsInfTransitoBucFinalGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnConsInfTransitoBucFinalCreated(Reincarapp.Models.reincardb.ConsInfTransitoBucFinal item);
        partial void OnAfterConsInfTransitoBucFinalCreated(Reincarapp.Models.reincardb.ConsInfTransitoBucFinal item);

        public async Task<Reincarapp.Models.reincardb.ConsInfTransitoBucFinal> CreateConsInfTransitoBucFinal(Reincarapp.Models.reincardb.ConsInfTransitoBucFinal consinftransitobucfinal)
        {
            OnConsInfTransitoBucFinalCreated(consinftransitobucfinal);

            var existingItem = Context.ConsInfTransitoBucFinal
                              .Where(i => i.id_transito_buc == consinftransitobucfinal.id_transito_buc)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ConsInfTransitoBucFinal.Add(consinftransitobucfinal);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(consinftransitobucfinal).State = EntityState.Detached;
                throw;
            }

            OnAfterConsInfTransitoBucFinalCreated(consinftransitobucfinal);

            return consinftransitobucfinal;
        }

        public async Task<Reincarapp.Models.reincardb.ConsInfTransitoBucFinal> CancelConsInfTransitoBucFinalChanges(Reincarapp.Models.reincardb.ConsInfTransitoBucFinal item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnConsInfTransitoBucFinalUpdated(Reincarapp.Models.reincardb.ConsInfTransitoBucFinal item);
        partial void OnAfterConsInfTransitoBucFinalUpdated(Reincarapp.Models.reincardb.ConsInfTransitoBucFinal item);

        public async Task<Reincarapp.Models.reincardb.ConsInfTransitoBucFinal> UpdateConsInfTransitoBucFinal(long idtransitobuc, Reincarapp.Models.reincardb.ConsInfTransitoBucFinal consinftransitobucfinal)
        {
            OnConsInfTransitoBucFinalUpdated(consinftransitobucfinal);

            var itemToUpdate = Context.ConsInfTransitoBucFinal
                              .Where(i => i.id_transito_buc == consinftransitobucfinal.id_transito_buc)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(consinftransitobucfinal);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterConsInfTransitoBucFinalUpdated(consinftransitobucfinal);

            return consinftransitobucfinal;
        }

        partial void OnConsInfTransitoBucFinalDeleted(Reincarapp.Models.reincardb.ConsInfTransitoBucFinal item);
        partial void OnAfterConsInfTransitoBucFinalDeleted(Reincarapp.Models.reincardb.ConsInfTransitoBucFinal item);

        public async Task<Reincarapp.Models.reincardb.ConsInfTransitoBucFinal> DeleteConsInfTransitoBucFinal(long idtransitobuc)
        {
            var itemToDelete = Context.ConsInfTransitoBucFinal
                              .Where(i => i.id_transito_buc == idtransitobuc)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnConsInfTransitoBucFinalDeleted(itemToDelete);


            Context.ConsInfTransitoBucFinal.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterConsInfTransitoBucFinalDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportConsInfTransitoFloToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/consinftransitoflo/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/consinftransitoflo/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportConsInfTransitoFloToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/consinftransitoflo/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/consinftransitoflo/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnConsInfTransitoFloRead(ref IQueryable<Reincarapp.Models.reincardb.ConsInfTransitoFlo> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ConsInfTransitoFlo>> GetConsInfTransitoFlo(Query query = null)
        {
            var items = Context.ConsInfTransitoFlo.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnConsInfTransitoFloRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnConsInfTransitoFloGet(Reincarapp.Models.reincardb.ConsInfTransitoFlo item);
        partial void OnGetConsInfTransitoFloByIdTransitoFlo(ref IQueryable<Reincarapp.Models.reincardb.ConsInfTransitoFlo> items);


        public async Task<Reincarapp.Models.reincardb.ConsInfTransitoFlo> GetConsInfTransitoFloByIdTransitoFlo(long idtransitoflo)
        {
            var items = Context.ConsInfTransitoFlo
                              .AsNoTracking()
                              .Where(i => i.id_transito_flo == idtransitoflo);

 
            OnGetConsInfTransitoFloByIdTransitoFlo(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnConsInfTransitoFloGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnConsInfTransitoFloCreated(Reincarapp.Models.reincardb.ConsInfTransitoFlo item);
        partial void OnAfterConsInfTransitoFloCreated(Reincarapp.Models.reincardb.ConsInfTransitoFlo item);

        public async Task<Reincarapp.Models.reincardb.ConsInfTransitoFlo> CreateConsInfTransitoFlo(Reincarapp.Models.reincardb.ConsInfTransitoFlo consinftransitoflo)
        {
            OnConsInfTransitoFloCreated(consinftransitoflo);

            var existingItem = Context.ConsInfTransitoFlo
                              .Where(i => i.id_transito_flo == consinftransitoflo.id_transito_flo)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ConsInfTransitoFlo.Add(consinftransitoflo);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(consinftransitoflo).State = EntityState.Detached;
                throw;
            }

            OnAfterConsInfTransitoFloCreated(consinftransitoflo);

            return consinftransitoflo;
        }

        public async Task<Reincarapp.Models.reincardb.ConsInfTransitoFlo> CancelConsInfTransitoFloChanges(Reincarapp.Models.reincardb.ConsInfTransitoFlo item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnConsInfTransitoFloUpdated(Reincarapp.Models.reincardb.ConsInfTransitoFlo item);
        partial void OnAfterConsInfTransitoFloUpdated(Reincarapp.Models.reincardb.ConsInfTransitoFlo item);

        public async Task<Reincarapp.Models.reincardb.ConsInfTransitoFlo> UpdateConsInfTransitoFlo(long idtransitoflo, Reincarapp.Models.reincardb.ConsInfTransitoFlo consinftransitoflo)
        {
            OnConsInfTransitoFloUpdated(consinftransitoflo);

            var itemToUpdate = Context.ConsInfTransitoFlo
                              .Where(i => i.id_transito_flo == consinftransitoflo.id_transito_flo)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(consinftransitoflo);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterConsInfTransitoFloUpdated(consinftransitoflo);

            return consinftransitoflo;
        }

        partial void OnConsInfTransitoFloDeleted(Reincarapp.Models.reincardb.ConsInfTransitoFlo item);
        partial void OnAfterConsInfTransitoFloDeleted(Reincarapp.Models.reincardb.ConsInfTransitoFlo item);

        public async Task<Reincarapp.Models.reincardb.ConsInfTransitoFlo> DeleteConsInfTransitoFlo(long idtransitoflo)
        {
            var itemToDelete = Context.ConsInfTransitoFlo
                              .Where(i => i.id_transito_flo == idtransitoflo)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnConsInfTransitoFloDeleted(itemToDelete);


            Context.ConsInfTransitoFlo.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterConsInfTransitoFloDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportConsInfTransitoFloFinalToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/consinftransitoflofinal/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/consinftransitoflofinal/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportConsInfTransitoFloFinalToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/consinftransitoflofinal/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/consinftransitoflofinal/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnConsInfTransitoFloFinalRead(ref IQueryable<Reincarapp.Models.reincardb.ConsInfTransitoFloFinal> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ConsInfTransitoFloFinal>> GetConsInfTransitoFloFinal(Query query = null)
        {
            var items = Context.ConsInfTransitoFloFinal.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnConsInfTransitoFloFinalRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnConsInfTransitoFloFinalGet(Reincarapp.Models.reincardb.ConsInfTransitoFloFinal item);
        partial void OnGetConsInfTransitoFloFinalByIdTransitoFlo(ref IQueryable<Reincarapp.Models.reincardb.ConsInfTransitoFloFinal> items);


        public async Task<Reincarapp.Models.reincardb.ConsInfTransitoFloFinal> GetConsInfTransitoFloFinalByIdTransitoFlo(long idtransitoflo)
        {
            var items = Context.ConsInfTransitoFloFinal
                              .AsNoTracking()
                              .Where(i => i.id_transito_flo == idtransitoflo);

 
            OnGetConsInfTransitoFloFinalByIdTransitoFlo(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnConsInfTransitoFloFinalGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnConsInfTransitoFloFinalCreated(Reincarapp.Models.reincardb.ConsInfTransitoFloFinal item);
        partial void OnAfterConsInfTransitoFloFinalCreated(Reincarapp.Models.reincardb.ConsInfTransitoFloFinal item);

        public async Task<Reincarapp.Models.reincardb.ConsInfTransitoFloFinal> CreateConsInfTransitoFloFinal(Reincarapp.Models.reincardb.ConsInfTransitoFloFinal consinftransitoflofinal)
        {
            OnConsInfTransitoFloFinalCreated(consinftransitoflofinal);

            var existingItem = Context.ConsInfTransitoFloFinal
                              .Where(i => i.id_transito_flo == consinftransitoflofinal.id_transito_flo)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ConsInfTransitoFloFinal.Add(consinftransitoflofinal);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(consinftransitoflofinal).State = EntityState.Detached;
                throw;
            }

            OnAfterConsInfTransitoFloFinalCreated(consinftransitoflofinal);

            return consinftransitoflofinal;
        }

        public async Task<Reincarapp.Models.reincardb.ConsInfTransitoFloFinal> CancelConsInfTransitoFloFinalChanges(Reincarapp.Models.reincardb.ConsInfTransitoFloFinal item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnConsInfTransitoFloFinalUpdated(Reincarapp.Models.reincardb.ConsInfTransitoFloFinal item);
        partial void OnAfterConsInfTransitoFloFinalUpdated(Reincarapp.Models.reincardb.ConsInfTransitoFloFinal item);

        public async Task<Reincarapp.Models.reincardb.ConsInfTransitoFloFinal> UpdateConsInfTransitoFloFinal(long idtransitoflo, Reincarapp.Models.reincardb.ConsInfTransitoFloFinal consinftransitoflofinal)
        {
            OnConsInfTransitoFloFinalUpdated(consinftransitoflofinal);

            var itemToUpdate = Context.ConsInfTransitoFloFinal
                              .Where(i => i.id_transito_flo == consinftransitoflofinal.id_transito_flo)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(consinftransitoflofinal);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterConsInfTransitoFloFinalUpdated(consinftransitoflofinal);

            return consinftransitoflofinal;
        }

        partial void OnConsInfTransitoFloFinalDeleted(Reincarapp.Models.reincardb.ConsInfTransitoFloFinal item);
        partial void OnAfterConsInfTransitoFloFinalDeleted(Reincarapp.Models.reincardb.ConsInfTransitoFloFinal item);

        public async Task<Reincarapp.Models.reincardb.ConsInfTransitoFloFinal> DeleteConsInfTransitoFloFinal(long idtransitoflo)
        {
            var itemToDelete = Context.ConsInfTransitoFloFinal
                              .Where(i => i.id_transito_flo == idtransitoflo)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnConsInfTransitoFloFinalDeleted(itemToDelete);


            Context.ConsInfTransitoFloFinal.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterConsInfTransitoFloFinalDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCoomTempcdToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/coomtempcd/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/coomtempcd/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCoomTempcdToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/coomtempcd/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/coomtempcd/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCoomTempcdRead(ref IQueryable<Reincarapp.Models.reincardb.CoomTempcd> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.CoomTempcd>> GetCoomTempcd(Query query = null)
        {
            var items = Context.CoomTempcd.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCoomTempcdRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportCoomultdicToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/coomultdic/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/coomultdic/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCoomultdicToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/coomultdic/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/coomultdic/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCoomultdicRead(ref IQueryable<Reincarapp.Models.reincardb.Coomultdic> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Coomultdic>> GetCoomultdic(Query query = null)
        {
            var items = Context.Coomultdic.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCoomultdicRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportCoomultrasanCastigoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/coomultrasancastigo/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/coomultrasancastigo/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCoomultrasanCastigoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/coomultrasancastigo/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/coomultrasancastigo/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCoomultrasanCastigoRead(ref IQueryable<Reincarapp.Models.reincardb.CoomultrasanCastigo> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.CoomultrasanCastigo>> GetCoomultrasanCastigo(Query query = null)
        {
            var items = Context.CoomultrasanCastigo.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCoomultrasanCastigoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCoomultrasanCastigoGet(Reincarapp.Models.reincardb.CoomultrasanCastigo item);
        partial void OnGetCoomultrasanCastigoByIdCoomultrasanCastigo(ref IQueryable<Reincarapp.Models.reincardb.CoomultrasanCastigo> items);


        public async Task<Reincarapp.Models.reincardb.CoomultrasanCastigo> GetCoomultrasanCastigoByIdCoomultrasanCastigo(long idcoomultrasancastigo)
        {
            var items = Context.CoomultrasanCastigo
                              .AsNoTracking()
                              .Where(i => i.id_coomultrasan_castigo == idcoomultrasancastigo);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetCoomultrasanCastigoByIdCoomultrasanCastigo(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCoomultrasanCastigoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCoomultrasanCastigoCreated(Reincarapp.Models.reincardb.CoomultrasanCastigo item);
        partial void OnAfterCoomultrasanCastigoCreated(Reincarapp.Models.reincardb.CoomultrasanCastigo item);

        public async Task<Reincarapp.Models.reincardb.CoomultrasanCastigo> CreateCoomultrasanCastigo(Reincarapp.Models.reincardb.CoomultrasanCastigo coomultrasancastigo)
        {
            OnCoomultrasanCastigoCreated(coomultrasancastigo);

            var existingItem = Context.CoomultrasanCastigo
                              .Where(i => i.id_coomultrasan_castigo == coomultrasancastigo.id_coomultrasan_castigo)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CoomultrasanCastigo.Add(coomultrasancastigo);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(coomultrasancastigo).State = EntityState.Detached;
                throw;
            }

            OnAfterCoomultrasanCastigoCreated(coomultrasancastigo);

            return coomultrasancastigo;
        }

        public async Task<Reincarapp.Models.reincardb.CoomultrasanCastigo> CancelCoomultrasanCastigoChanges(Reincarapp.Models.reincardb.CoomultrasanCastigo item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCoomultrasanCastigoUpdated(Reincarapp.Models.reincardb.CoomultrasanCastigo item);
        partial void OnAfterCoomultrasanCastigoUpdated(Reincarapp.Models.reincardb.CoomultrasanCastigo item);

        public async Task<Reincarapp.Models.reincardb.CoomultrasanCastigo> UpdateCoomultrasanCastigo(long idcoomultrasancastigo, Reincarapp.Models.reincardb.CoomultrasanCastigo coomultrasancastigo)
        {
            OnCoomultrasanCastigoUpdated(coomultrasancastigo);

            var itemToUpdate = Context.CoomultrasanCastigo
                              .Where(i => i.id_coomultrasan_castigo == coomultrasancastigo.id_coomultrasan_castigo)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(coomultrasancastigo);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCoomultrasanCastigoUpdated(coomultrasancastigo);

            return coomultrasancastigo;
        }

        partial void OnCoomultrasanCastigoDeleted(Reincarapp.Models.reincardb.CoomultrasanCastigo item);
        partial void OnAfterCoomultrasanCastigoDeleted(Reincarapp.Models.reincardb.CoomultrasanCastigo item);

        public async Task<Reincarapp.Models.reincardb.CoomultrasanCastigo> DeleteCoomultrasanCastigo(long idcoomultrasancastigo)
        {
            var itemToDelete = Context.CoomultrasanCastigo
                              .Where(i => i.id_coomultrasan_castigo == idcoomultrasancastigo)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCoomultrasanCastigoDeleted(itemToDelete);


            Context.CoomultrasanCastigo.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCoomultrasanCastigoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCoomultrasanJuridicaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/coomultrasanjuridica/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/coomultrasanjuridica/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCoomultrasanJuridicaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/coomultrasanjuridica/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/coomultrasanjuridica/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCoomultrasanJuridicaRead(ref IQueryable<Reincarapp.Models.reincardb.CoomultrasanJuridica> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.CoomultrasanJuridica>> GetCoomultrasanJuridica(Query query = null)
        {
            var items = Context.CoomultrasanJuridica.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCoomultrasanJuridicaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCoomultrasanJuridicaGet(Reincarapp.Models.reincardb.CoomultrasanJuridica item);
        partial void OnGetCoomultrasanJuridicaByIdCoomultrasanJuridica(ref IQueryable<Reincarapp.Models.reincardb.CoomultrasanJuridica> items);


        public async Task<Reincarapp.Models.reincardb.CoomultrasanJuridica> GetCoomultrasanJuridicaByIdCoomultrasanJuridica(long idcoomultrasanjuridica)
        {
            var items = Context.CoomultrasanJuridica
                              .AsNoTracking()
                              .Where(i => i.id_Coomultrasan_Juridica == idcoomultrasanjuridica);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetCoomultrasanJuridicaByIdCoomultrasanJuridica(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCoomultrasanJuridicaGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCoomultrasanJuridicaCreated(Reincarapp.Models.reincardb.CoomultrasanJuridica item);
        partial void OnAfterCoomultrasanJuridicaCreated(Reincarapp.Models.reincardb.CoomultrasanJuridica item);

        public async Task<Reincarapp.Models.reincardb.CoomultrasanJuridica> CreateCoomultrasanJuridica(Reincarapp.Models.reincardb.CoomultrasanJuridica coomultrasanjuridica)
        {
            OnCoomultrasanJuridicaCreated(coomultrasanjuridica);

            var existingItem = Context.CoomultrasanJuridica
                              .Where(i => i.id_Coomultrasan_Juridica == coomultrasanjuridica.id_Coomultrasan_Juridica)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CoomultrasanJuridica.Add(coomultrasanjuridica);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(coomultrasanjuridica).State = EntityState.Detached;
                throw;
            }

            OnAfterCoomultrasanJuridicaCreated(coomultrasanjuridica);

            return coomultrasanjuridica;
        }

        public async Task<Reincarapp.Models.reincardb.CoomultrasanJuridica> CancelCoomultrasanJuridicaChanges(Reincarapp.Models.reincardb.CoomultrasanJuridica item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCoomultrasanJuridicaUpdated(Reincarapp.Models.reincardb.CoomultrasanJuridica item);
        partial void OnAfterCoomultrasanJuridicaUpdated(Reincarapp.Models.reincardb.CoomultrasanJuridica item);

        public async Task<Reincarapp.Models.reincardb.CoomultrasanJuridica> UpdateCoomultrasanJuridica(long idcoomultrasanjuridica, Reincarapp.Models.reincardb.CoomultrasanJuridica coomultrasanjuridica)
        {
            OnCoomultrasanJuridicaUpdated(coomultrasanjuridica);

            var itemToUpdate = Context.CoomultrasanJuridica
                              .Where(i => i.id_Coomultrasan_Juridica == coomultrasanjuridica.id_Coomultrasan_Juridica)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(coomultrasanjuridica);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCoomultrasanJuridicaUpdated(coomultrasanjuridica);

            return coomultrasanjuridica;
        }

        partial void OnCoomultrasanJuridicaDeleted(Reincarapp.Models.reincardb.CoomultrasanJuridica item);
        partial void OnAfterCoomultrasanJuridicaDeleted(Reincarapp.Models.reincardb.CoomultrasanJuridica item);

        public async Task<Reincarapp.Models.reincardb.CoomultrasanJuridica> DeleteCoomultrasanJuridica(long idcoomultrasanjuridica)
        {
            var itemToDelete = Context.CoomultrasanJuridica
                              .Where(i => i.id_Coomultrasan_Juridica == idcoomultrasanjuridica)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCoomultrasanJuridicaDeleted(itemToDelete);


            Context.CoomultrasanJuridica.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCoomultrasanJuridicaDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCoomultrasanLey79ToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/coomultrasanley79/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/coomultrasanley79/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCoomultrasanLey79ToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/coomultrasanley79/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/coomultrasanley79/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCoomultrasanLey79Read(ref IQueryable<Reincarapp.Models.reincardb.CoomultrasanLey79> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.CoomultrasanLey79>> GetCoomultrasanLey79(Query query = null)
        {
            var items = Context.CoomultrasanLey79.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCoomultrasanLey79Read(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCoomultrasanLey79Get(Reincarapp.Models.reincardb.CoomultrasanLey79 item);
        partial void OnGetCoomultrasanLey79ByIdCoomultrasanLey79(ref IQueryable<Reincarapp.Models.reincardb.CoomultrasanLey79> items);


        public async Task<Reincarapp.Models.reincardb.CoomultrasanLey79> GetCoomultrasanLey79ByIdCoomultrasanLey79(long idcoomultrasanley79)
        {
            var items = Context.CoomultrasanLey79
                              .AsNoTracking()
                              .Where(i => i.id_Coomultrasan_ley79 == idcoomultrasanley79);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetCoomultrasanLey79ByIdCoomultrasanLey79(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCoomultrasanLey79Get(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCoomultrasanLey79Created(Reincarapp.Models.reincardb.CoomultrasanLey79 item);
        partial void OnAfterCoomultrasanLey79Created(Reincarapp.Models.reincardb.CoomultrasanLey79 item);

        public async Task<Reincarapp.Models.reincardb.CoomultrasanLey79> CreateCoomultrasanLey79(Reincarapp.Models.reincardb.CoomultrasanLey79 coomultrasanley79)
        {
            OnCoomultrasanLey79Created(coomultrasanley79);

            var existingItem = Context.CoomultrasanLey79
                              .Where(i => i.id_Coomultrasan_ley79 == coomultrasanley79.id_Coomultrasan_ley79)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CoomultrasanLey79.Add(coomultrasanley79);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(coomultrasanley79).State = EntityState.Detached;
                throw;
            }

            OnAfterCoomultrasanLey79Created(coomultrasanley79);

            return coomultrasanley79;
        }

        public async Task<Reincarapp.Models.reincardb.CoomultrasanLey79> CancelCoomultrasanLey79Changes(Reincarapp.Models.reincardb.CoomultrasanLey79 item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCoomultrasanLey79Updated(Reincarapp.Models.reincardb.CoomultrasanLey79 item);
        partial void OnAfterCoomultrasanLey79Updated(Reincarapp.Models.reincardb.CoomultrasanLey79 item);

        public async Task<Reincarapp.Models.reincardb.CoomultrasanLey79> UpdateCoomultrasanLey79(long idcoomultrasanley79, Reincarapp.Models.reincardb.CoomultrasanLey79 coomultrasanley79)
        {
            OnCoomultrasanLey79Updated(coomultrasanley79);

            var itemToUpdate = Context.CoomultrasanLey79
                              .Where(i => i.id_Coomultrasan_ley79 == coomultrasanley79.id_Coomultrasan_ley79)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(coomultrasanley79);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCoomultrasanLey79Updated(coomultrasanley79);

            return coomultrasanley79;
        }

        partial void OnCoomultrasanLey79Deleted(Reincarapp.Models.reincardb.CoomultrasanLey79 item);
        partial void OnAfterCoomultrasanLey79Deleted(Reincarapp.Models.reincardb.CoomultrasanLey79 item);

        public async Task<Reincarapp.Models.reincardb.CoomultrasanLey79> DeleteCoomultrasanLey79(long idcoomultrasanley79)
        {
            var itemToDelete = Context.CoomultrasanLey79
                              .Where(i => i.id_Coomultrasan_ley79 == idcoomultrasanley79)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCoomultrasanLey79Deleted(itemToDelete);


            Context.CoomultrasanLey79.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCoomultrasanLey79Deleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCoomultrasanTempranaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/coomultrasantemprana/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/coomultrasantemprana/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCoomultrasanTempranaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/coomultrasantemprana/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/coomultrasantemprana/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCoomultrasanTempranaRead(ref IQueryable<Reincarapp.Models.reincardb.CoomultrasanTemprana> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.CoomultrasanTemprana>> GetCoomultrasanTemprana(Query query = null)
        {
            var items = Context.CoomultrasanTemprana.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCoomultrasanTempranaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCoomultrasanTempranaGet(Reincarapp.Models.reincardb.CoomultrasanTemprana item);
        partial void OnGetCoomultrasanTempranaByIdCoomultrasan(ref IQueryable<Reincarapp.Models.reincardb.CoomultrasanTemprana> items);


        public async Task<Reincarapp.Models.reincardb.CoomultrasanTemprana> GetCoomultrasanTempranaByIdCoomultrasan(long idcoomultrasan)
        {
            var items = Context.CoomultrasanTemprana
                              .AsNoTracking()
                              .Where(i => i.Id_Coomultrasan == idcoomultrasan);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetCoomultrasanTempranaByIdCoomultrasan(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCoomultrasanTempranaGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCoomultrasanTempranaCreated(Reincarapp.Models.reincardb.CoomultrasanTemprana item);
        partial void OnAfterCoomultrasanTempranaCreated(Reincarapp.Models.reincardb.CoomultrasanTemprana item);

        public async Task<Reincarapp.Models.reincardb.CoomultrasanTemprana> CreateCoomultrasanTemprana(Reincarapp.Models.reincardb.CoomultrasanTemprana coomultrasantemprana)
        {
            OnCoomultrasanTempranaCreated(coomultrasantemprana);

            var existingItem = Context.CoomultrasanTemprana
                              .Where(i => i.Id_Coomultrasan == coomultrasantemprana.Id_Coomultrasan)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CoomultrasanTemprana.Add(coomultrasantemprana);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(coomultrasantemprana).State = EntityState.Detached;
                throw;
            }

            OnAfterCoomultrasanTempranaCreated(coomultrasantemprana);

            return coomultrasantemprana;
        }

        public async Task<Reincarapp.Models.reincardb.CoomultrasanTemprana> CancelCoomultrasanTempranaChanges(Reincarapp.Models.reincardb.CoomultrasanTemprana item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCoomultrasanTempranaUpdated(Reincarapp.Models.reincardb.CoomultrasanTemprana item);
        partial void OnAfterCoomultrasanTempranaUpdated(Reincarapp.Models.reincardb.CoomultrasanTemprana item);

        public async Task<Reincarapp.Models.reincardb.CoomultrasanTemprana> UpdateCoomultrasanTemprana(long idcoomultrasan, Reincarapp.Models.reincardb.CoomultrasanTemprana coomultrasantemprana)
        {
            OnCoomultrasanTempranaUpdated(coomultrasantemprana);

            var itemToUpdate = Context.CoomultrasanTemprana
                              .Where(i => i.Id_Coomultrasan == coomultrasantemprana.Id_Coomultrasan)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(coomultrasantemprana);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCoomultrasanTempranaUpdated(coomultrasantemprana);

            return coomultrasantemprana;
        }

        partial void OnCoomultrasanTempranaDeleted(Reincarapp.Models.reincardb.CoomultrasanTemprana item);
        partial void OnAfterCoomultrasanTempranaDeleted(Reincarapp.Models.reincardb.CoomultrasanTemprana item);

        public async Task<Reincarapp.Models.reincardb.CoomultrasanTemprana> DeleteCoomultrasanTemprana(long idcoomultrasan)
        {
            var itemToDelete = Context.CoomultrasanTemprana
                              .Where(i => i.Id_Coomultrasan == idcoomultrasan)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCoomultrasanTempranaDeleted(itemToDelete);


            Context.CoomultrasanTemprana.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCoomultrasanTempranaDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCoopetrolToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/coopetrol/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/coopetrol/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCoopetrolToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/coopetrol/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/coopetrol/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCoopetrolRead(ref IQueryable<Reincarapp.Models.reincardb.Coopetrol> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Coopetrol>> GetCoopetrol(Query query = null)
        {
            var items = Context.Coopetrol.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCoopetrolRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCoopetrolGet(Reincarapp.Models.reincardb.Coopetrol item);
        partial void OnGetCoopetrolByIdcoopetrol(ref IQueryable<Reincarapp.Models.reincardb.Coopetrol> items);


        public async Task<Reincarapp.Models.reincardb.Coopetrol> GetCoopetrolByIdcoopetrol(long idcoopetrol)
        {
            var items = Context.Coopetrol
                              .AsNoTracking()
                              .Where(i => i.idcoopetrol == idcoopetrol);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetCoopetrolByIdcoopetrol(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCoopetrolGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCoopetrolCreated(Reincarapp.Models.reincardb.Coopetrol item);
        partial void OnAfterCoopetrolCreated(Reincarapp.Models.reincardb.Coopetrol item);

        public async Task<Reincarapp.Models.reincardb.Coopetrol> CreateCoopetrol(Reincarapp.Models.reincardb.Coopetrol coopetrol)
        {
            OnCoopetrolCreated(coopetrol);

            var existingItem = Context.Coopetrol
                              .Where(i => i.idcoopetrol == coopetrol.idcoopetrol)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Coopetrol.Add(coopetrol);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(coopetrol).State = EntityState.Detached;
                throw;
            }

            OnAfterCoopetrolCreated(coopetrol);

            return coopetrol;
        }

        public async Task<Reincarapp.Models.reincardb.Coopetrol> CancelCoopetrolChanges(Reincarapp.Models.reincardb.Coopetrol item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCoopetrolUpdated(Reincarapp.Models.reincardb.Coopetrol item);
        partial void OnAfterCoopetrolUpdated(Reincarapp.Models.reincardb.Coopetrol item);

        public async Task<Reincarapp.Models.reincardb.Coopetrol> UpdateCoopetrol(long idcoopetrol, Reincarapp.Models.reincardb.Coopetrol coopetrol)
        {
            OnCoopetrolUpdated(coopetrol);

            var itemToUpdate = Context.Coopetrol
                              .Where(i => i.idcoopetrol == coopetrol.idcoopetrol)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(coopetrol);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCoopetrolUpdated(coopetrol);

            return coopetrol;
        }

        partial void OnCoopetrolDeleted(Reincarapp.Models.reincardb.Coopetrol item);
        partial void OnAfterCoopetrolDeleted(Reincarapp.Models.reincardb.Coopetrol item);

        public async Task<Reincarapp.Models.reincardb.Coopetrol> DeleteCoopetrol(long idcoopetrol)
        {
            var itemToDelete = Context.Coopetrol
                              .Where(i => i.idcoopetrol == idcoopetrol)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCoopetrolDeleted(itemToDelete);


            Context.Coopetrol.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCoopetrolDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCorrespondenciaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/correspondencia/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/correspondencia/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCorrespondenciaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/correspondencia/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/correspondencia/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCorrespondenciaRead(ref IQueryable<Reincarapp.Models.reincardb.Correspondencia> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Correspondencia>> GetCorrespondencia(Query query = null)
        {
            var items = Context.Correspondencia.AsQueryable();

            items = items.Include(i => i.Evento);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCorrespondenciaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCorrespondenciaGet(Reincarapp.Models.reincardb.Correspondencia item);
        partial void OnGetCorrespondenciaByIdCorrespondencia(ref IQueryable<Reincarapp.Models.reincardb.Correspondencia> items);


        public async Task<Reincarapp.Models.reincardb.Correspondencia> GetCorrespondenciaByIdCorrespondencia(long idcorrespondencia)
        {
            var items = Context.Correspondencia
                              .AsNoTracking()
                              .Where(i => i.Id_Correspondencia == idcorrespondencia);

            items = items.Include(i => i.Evento);
 
            OnGetCorrespondenciaByIdCorrespondencia(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCorrespondenciaGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCorrespondenciaCreated(Reincarapp.Models.reincardb.Correspondencia item);
        partial void OnAfterCorrespondenciaCreated(Reincarapp.Models.reincardb.Correspondencia item);

        public async Task<Reincarapp.Models.reincardb.Correspondencia> CreateCorrespondencia(Reincarapp.Models.reincardb.Correspondencia correspondencia)
        {
            OnCorrespondenciaCreated(correspondencia);

            var existingItem = Context.Correspondencia
                              .Where(i => i.Id_Correspondencia == correspondencia.Id_Correspondencia)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Correspondencia.Add(correspondencia);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(correspondencia).State = EntityState.Detached;
                throw;
            }

            OnAfterCorrespondenciaCreated(correspondencia);

            return correspondencia;
        }

        public async Task<Reincarapp.Models.reincardb.Correspondencia> CancelCorrespondenciaChanges(Reincarapp.Models.reincardb.Correspondencia item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCorrespondenciaUpdated(Reincarapp.Models.reincardb.Correspondencia item);
        partial void OnAfterCorrespondenciaUpdated(Reincarapp.Models.reincardb.Correspondencia item);

        public async Task<Reincarapp.Models.reincardb.Correspondencia> UpdateCorrespondencia(long idcorrespondencia, Reincarapp.Models.reincardb.Correspondencia correspondencia)
        {
            OnCorrespondenciaUpdated(correspondencia);

            var itemToUpdate = Context.Correspondencia
                              .Where(i => i.Id_Correspondencia == correspondencia.Id_Correspondencia)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(correspondencia);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCorrespondenciaUpdated(correspondencia);

            return correspondencia;
        }

        partial void OnCorrespondenciaDeleted(Reincarapp.Models.reincardb.Correspondencia item);
        partial void OnAfterCorrespondenciaDeleted(Reincarapp.Models.reincardb.Correspondencia item);

        public async Task<Reincarapp.Models.reincardb.Correspondencia> DeleteCorrespondencia(long idcorrespondencia)
        {
            var itemToDelete = Context.Correspondencia
                              .Where(i => i.Id_Correspondencia == idcorrespondencia)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCorrespondenciaDeleted(itemToDelete);


            Context.Correspondencia.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCorrespondenciaDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCredidosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/credidos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/credidos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCredidosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/credidos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/credidos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCredidosRead(ref IQueryable<Reincarapp.Models.reincardb.Credidos> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Credidos>> GetCredidos(Query query = null)
        {
            var items = Context.Credidos.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCredidosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCredidosGet(Reincarapp.Models.reincardb.Credidos item);
        partial void OnGetCredidosByIdCredidos(ref IQueryable<Reincarapp.Models.reincardb.Credidos> items);


        public async Task<Reincarapp.Models.reincardb.Credidos> GetCredidosByIdCredidos(long idcredidos)
        {
            var items = Context.Credidos
                              .AsNoTracking()
                              .Where(i => i.Id_Credidos == idcredidos);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetCredidosByIdCredidos(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCredidosGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCredidosCreated(Reincarapp.Models.reincardb.Credidos item);
        partial void OnAfterCredidosCreated(Reincarapp.Models.reincardb.Credidos item);

        public async Task<Reincarapp.Models.reincardb.Credidos> CreateCredidos(Reincarapp.Models.reincardb.Credidos credidos)
        {
            OnCredidosCreated(credidos);

            var existingItem = Context.Credidos
                              .Where(i => i.Id_Credidos == credidos.Id_Credidos)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Credidos.Add(credidos);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(credidos).State = EntityState.Detached;
                throw;
            }

            OnAfterCredidosCreated(credidos);

            return credidos;
        }

        public async Task<Reincarapp.Models.reincardb.Credidos> CancelCredidosChanges(Reincarapp.Models.reincardb.Credidos item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCredidosUpdated(Reincarapp.Models.reincardb.Credidos item);
        partial void OnAfterCredidosUpdated(Reincarapp.Models.reincardb.Credidos item);

        public async Task<Reincarapp.Models.reincardb.Credidos> UpdateCredidos(long idcredidos, Reincarapp.Models.reincardb.Credidos credidos)
        {
            OnCredidosUpdated(credidos);

            var itemToUpdate = Context.Credidos
                              .Where(i => i.Id_Credidos == credidos.Id_Credidos)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(credidos);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCredidosUpdated(credidos);

            return credidos;
        }

        partial void OnCredidosDeleted(Reincarapp.Models.reincardb.Credidos item);
        partial void OnAfterCredidosDeleted(Reincarapp.Models.reincardb.Credidos item);

        public async Task<Reincarapp.Models.reincardb.Credidos> DeleteCredidos(long idcredidos)
        {
            var itemToDelete = Context.Credidos
                              .Where(i => i.Id_Credidos == idcredidos)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCredidosDeleted(itemToDelete);


            Context.Credidos.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCredidosDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCredivaloresToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/credivalores/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/credivalores/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCredivaloresToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/credivalores/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/credivalores/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCredivaloresRead(ref IQueryable<Reincarapp.Models.reincardb.Credivalores> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Credivalores>> GetCredivalores(Query query = null)
        {
            var items = Context.Credivalores.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCredivaloresRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCredivaloresGet(Reincarapp.Models.reincardb.Credivalores item);
        partial void OnGetCredivaloresByIdCredivalores(ref IQueryable<Reincarapp.Models.reincardb.Credivalores> items);


        public async Task<Reincarapp.Models.reincardb.Credivalores> GetCredivaloresByIdCredivalores(long idcredivalores)
        {
            var items = Context.Credivalores
                              .AsNoTracking()
                              .Where(i => i.Id_Credivalores == idcredivalores);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetCredivaloresByIdCredivalores(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCredivaloresGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCredivaloresCreated(Reincarapp.Models.reincardb.Credivalores item);
        partial void OnAfterCredivaloresCreated(Reincarapp.Models.reincardb.Credivalores item);

        public async Task<Reincarapp.Models.reincardb.Credivalores> CreateCredivalores(Reincarapp.Models.reincardb.Credivalores credivalores)
        {
            OnCredivaloresCreated(credivalores);

            var existingItem = Context.Credivalores
                              .Where(i => i.Id_Credivalores == credivalores.Id_Credivalores)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Credivalores.Add(credivalores);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(credivalores).State = EntityState.Detached;
                throw;
            }

            OnAfterCredivaloresCreated(credivalores);

            return credivalores;
        }

        public async Task<Reincarapp.Models.reincardb.Credivalores> CancelCredivaloresChanges(Reincarapp.Models.reincardb.Credivalores item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCredivaloresUpdated(Reincarapp.Models.reincardb.Credivalores item);
        partial void OnAfterCredivaloresUpdated(Reincarapp.Models.reincardb.Credivalores item);

        public async Task<Reincarapp.Models.reincardb.Credivalores> UpdateCredivalores(long idcredivalores, Reincarapp.Models.reincardb.Credivalores credivalores)
        {
            OnCredivaloresUpdated(credivalores);

            var itemToUpdate = Context.Credivalores
                              .Where(i => i.Id_Credivalores == credivalores.Id_Credivalores)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(credivalores);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCredivaloresUpdated(credivalores);

            return credivalores;
        }

        partial void OnCredivaloresDeleted(Reincarapp.Models.reincardb.Credivalores item);
        partial void OnAfterCredivaloresDeleted(Reincarapp.Models.reincardb.Credivalores item);

        public async Task<Reincarapp.Models.reincardb.Credivalores> DeleteCredivalores(long idcredivalores)
        {
            var itemToDelete = Context.Credivalores
                              .Where(i => i.Id_Credivalores == idcredivalores)
                              .Include(i => i.Rediferido)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCredivaloresDeleted(itemToDelete);


            Context.Credivalores.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCredivaloresDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCredivalores2ToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/credivalores2/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/credivalores2/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCredivalores2ToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/credivalores2/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/credivalores2/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCredivalores2Read(ref IQueryable<Reincarapp.Models.reincardb.Credivalores2> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Credivalores2>> GetCredivalores2(Query query = null)
        {
            var items = Context.Credivalores2.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCredivalores2Read(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCredivalores2Get(Reincarapp.Models.reincardb.Credivalores2 item);
        partial void OnGetCredivalores2ByIdCredivalores(ref IQueryable<Reincarapp.Models.reincardb.Credivalores2> items);


        public async Task<Reincarapp.Models.reincardb.Credivalores2> GetCredivalores2ByIdCredivalores(long idcredivalores)
        {
            var items = Context.Credivalores2
                              .AsNoTracking()
                              .Where(i => i.Id_Credivalores == idcredivalores);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetCredivalores2ByIdCredivalores(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCredivalores2Get(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCredivalores2Created(Reincarapp.Models.reincardb.Credivalores2 item);
        partial void OnAfterCredivalores2Created(Reincarapp.Models.reincardb.Credivalores2 item);

        public async Task<Reincarapp.Models.reincardb.Credivalores2> CreateCredivalores2(Reincarapp.Models.reincardb.Credivalores2 credivalores2)
        {
            OnCredivalores2Created(credivalores2);

            var existingItem = Context.Credivalores2
                              .Where(i => i.Id_Credivalores == credivalores2.Id_Credivalores)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Credivalores2.Add(credivalores2);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(credivalores2).State = EntityState.Detached;
                throw;
            }

            OnAfterCredivalores2Created(credivalores2);

            return credivalores2;
        }

        public async Task<Reincarapp.Models.reincardb.Credivalores2> CancelCredivalores2Changes(Reincarapp.Models.reincardb.Credivalores2 item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCredivalores2Updated(Reincarapp.Models.reincardb.Credivalores2 item);
        partial void OnAfterCredivalores2Updated(Reincarapp.Models.reincardb.Credivalores2 item);

        public async Task<Reincarapp.Models.reincardb.Credivalores2> UpdateCredivalores2(long idcredivalores, Reincarapp.Models.reincardb.Credivalores2 credivalores2)
        {
            OnCredivalores2Updated(credivalores2);

            var itemToUpdate = Context.Credivalores2
                              .Where(i => i.Id_Credivalores == credivalores2.Id_Credivalores)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(credivalores2);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCredivalores2Updated(credivalores2);

            return credivalores2;
        }

        partial void OnCredivalores2Deleted(Reincarapp.Models.reincardb.Credivalores2 item);
        partial void OnAfterCredivalores2Deleted(Reincarapp.Models.reincardb.Credivalores2 item);

        public async Task<Reincarapp.Models.reincardb.Credivalores2> DeleteCredivalores2(long idcredivalores)
        {
            var itemToDelete = Context.Credivalores2
                              .Where(i => i.Id_Credivalores == idcredivalores)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCredivalores2Deleted(itemToDelete);


            Context.Credivalores2.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCredivalores2Deleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCredivaloresaltToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/credivaloresalt/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/credivaloresalt/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCredivaloresaltToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/credivaloresalt/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/credivaloresalt/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCredivaloresaltRead(ref IQueryable<Reincarapp.Models.reincardb.Credivaloresalt> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Credivaloresalt>> GetCredivaloresalt(Query query = null)
        {
            var items = Context.Credivaloresalt.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnCredivaloresaltRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCredivaloresaltGet(Reincarapp.Models.reincardb.Credivaloresalt item);
        partial void OnGetCredivaloresaltByIdCredivalores(ref IQueryable<Reincarapp.Models.reincardb.Credivaloresalt> items);


        public async Task<Reincarapp.Models.reincardb.Credivaloresalt> GetCredivaloresaltByIdCredivalores(long idcredivalores)
        {
            var items = Context.Credivaloresalt
                              .AsNoTracking()
                              .Where(i => i.Id_Credivalores == idcredivalores);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetCredivaloresaltByIdCredivalores(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnCredivaloresaltGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCredivaloresaltCreated(Reincarapp.Models.reincardb.Credivaloresalt item);
        partial void OnAfterCredivaloresaltCreated(Reincarapp.Models.reincardb.Credivaloresalt item);

        public async Task<Reincarapp.Models.reincardb.Credivaloresalt> CreateCredivaloresalt(Reincarapp.Models.reincardb.Credivaloresalt credivaloresalt)
        {
            OnCredivaloresaltCreated(credivaloresalt);

            var existingItem = Context.Credivaloresalt
                              .Where(i => i.Id_Credivalores == credivaloresalt.Id_Credivalores)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Credivaloresalt.Add(credivaloresalt);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(credivaloresalt).State = EntityState.Detached;
                throw;
            }

            OnAfterCredivaloresaltCreated(credivaloresalt);

            return credivaloresalt;
        }

        public async Task<Reincarapp.Models.reincardb.Credivaloresalt> CancelCredivaloresaltChanges(Reincarapp.Models.reincardb.Credivaloresalt item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCredivaloresaltUpdated(Reincarapp.Models.reincardb.Credivaloresalt item);
        partial void OnAfterCredivaloresaltUpdated(Reincarapp.Models.reincardb.Credivaloresalt item);

        public async Task<Reincarapp.Models.reincardb.Credivaloresalt> UpdateCredivaloresalt(long idcredivalores, Reincarapp.Models.reincardb.Credivaloresalt credivaloresalt)
        {
            OnCredivaloresaltUpdated(credivaloresalt);

            var itemToUpdate = Context.Credivaloresalt
                              .Where(i => i.Id_Credivalores == credivaloresalt.Id_Credivalores)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(credivaloresalt);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCredivaloresaltUpdated(credivaloresalt);

            return credivaloresalt;
        }

        partial void OnCredivaloresaltDeleted(Reincarapp.Models.reincardb.Credivaloresalt item);
        partial void OnAfterCredivaloresaltDeleted(Reincarapp.Models.reincardb.Credivaloresalt item);

        public async Task<Reincarapp.Models.reincardb.Credivaloresalt> DeleteCredivaloresalt(long idcredivalores)
        {
            var itemToDelete = Context.Credivaloresalt
                              .Where(i => i.Id_Credivalores == idcredivalores)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCredivaloresaltDeleted(itemToDelete);


            Context.Credivaloresalt.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCredivaloresaltDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportDatoClienteDeudaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/datoclientedeuda/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/datoclientedeuda/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDatoClienteDeudaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/datoclientedeuda/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/datoclientedeuda/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDatoClienteDeudaRead(ref IQueryable<Reincarapp.Models.reincardb.DatoClienteDeuda> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.DatoClienteDeuda>> GetDatoClienteDeuda(Query query = null)
        {
            var items = Context.DatoClienteDeuda.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnDatoClienteDeudaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnDatoClienteDeudaGet(Reincarapp.Models.reincardb.DatoClienteDeuda item);
        partial void OnGetDatoClienteDeudaByIdDatoClienteDeuda(ref IQueryable<Reincarapp.Models.reincardb.DatoClienteDeuda> items);


        public async Task<Reincarapp.Models.reincardb.DatoClienteDeuda> GetDatoClienteDeudaByIdDatoClienteDeuda(long iddatoclientedeuda)
        {
            var items = Context.DatoClienteDeuda
                              .AsNoTracking()
                              .Where(i => i.Id_Dato_Cliente_Deuda == iddatoclientedeuda);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetDatoClienteDeudaByIdDatoClienteDeuda(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnDatoClienteDeudaGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnDatoClienteDeudaCreated(Reincarapp.Models.reincardb.DatoClienteDeuda item);
        partial void OnAfterDatoClienteDeudaCreated(Reincarapp.Models.reincardb.DatoClienteDeuda item);

        public async Task<Reincarapp.Models.reincardb.DatoClienteDeuda> CreateDatoClienteDeuda(Reincarapp.Models.reincardb.DatoClienteDeuda datoclientedeuda)
        {
            OnDatoClienteDeudaCreated(datoclientedeuda);

            var existingItem = Context.DatoClienteDeuda
                              .Where(i => i.Id_Dato_Cliente_Deuda == datoclientedeuda.Id_Dato_Cliente_Deuda)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.DatoClienteDeuda.Add(datoclientedeuda);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(datoclientedeuda).State = EntityState.Detached;
                throw;
            }

            OnAfterDatoClienteDeudaCreated(datoclientedeuda);

            return datoclientedeuda;
        }

        public async Task<Reincarapp.Models.reincardb.DatoClienteDeuda> CancelDatoClienteDeudaChanges(Reincarapp.Models.reincardb.DatoClienteDeuda item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDatoClienteDeudaUpdated(Reincarapp.Models.reincardb.DatoClienteDeuda item);
        partial void OnAfterDatoClienteDeudaUpdated(Reincarapp.Models.reincardb.DatoClienteDeuda item);

        public async Task<Reincarapp.Models.reincardb.DatoClienteDeuda> UpdateDatoClienteDeuda(long iddatoclientedeuda, Reincarapp.Models.reincardb.DatoClienteDeuda datoclientedeuda)
        {
            OnDatoClienteDeudaUpdated(datoclientedeuda);

            var itemToUpdate = Context.DatoClienteDeuda
                              .Where(i => i.Id_Dato_Cliente_Deuda == datoclientedeuda.Id_Dato_Cliente_Deuda)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(datoclientedeuda);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterDatoClienteDeudaUpdated(datoclientedeuda);

            return datoclientedeuda;
        }

        partial void OnDatoClienteDeudaDeleted(Reincarapp.Models.reincardb.DatoClienteDeuda item);
        partial void OnAfterDatoClienteDeudaDeleted(Reincarapp.Models.reincardb.DatoClienteDeuda item);

        public async Task<Reincarapp.Models.reincardb.DatoClienteDeuda> DeleteDatoClienteDeuda(long iddatoclientedeuda)
        {
            var itemToDelete = Context.DatoClienteDeuda
                              .Where(i => i.Id_Dato_Cliente_Deuda == iddatoclientedeuda)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnDatoClienteDeudaDeleted(itemToDelete);


            Context.DatoClienteDeuda.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterDatoClienteDeudaDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportDatoPersonaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/datopersona/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/datopersona/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDatoPersonaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/datopersona/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/datopersona/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDatoPersonaRead(ref IQueryable<Reincarapp.Models.reincardb.DatoPersona> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.DatoPersona>> GetDatoPersona(Query query = null)
        {
            var items = Context.DatoPersona.AsQueryable();

            items = items.Include(i => i.Departamento);
            items = items.Include(i => i.Municipio);
            items = items.Include(i => i.Persona);
            items = items.Include(i => i.TipoDatoPersona);
            items = items.Include(i => i.TipoVia);
            items = items.Include(i => i.ZonaUbicacion);
            items = items.Include(i => i.ZonaUbicacion1);
            items = items.Include(i => i.ZonaUbicacion2);
            items = items.Include(i => i.ZonaUbicacion3);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnDatoPersonaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnDatoPersonaGet(Reincarapp.Models.reincardb.DatoPersona item);
        partial void OnGetDatoPersonaByIdDatoPersona(ref IQueryable<Reincarapp.Models.reincardb.DatoPersona> items);


        public async Task<Reincarapp.Models.reincardb.DatoPersona> GetDatoPersonaByIdDatoPersona(long iddatopersona)
        {
            var items = Context.DatoPersona
                              .AsNoTracking()
                              .Where(i => i.Id_Dato_Persona == iddatopersona);

            items = items.Include(i => i.Departamento);
            items = items.Include(i => i.Municipio);
            items = items.Include(i => i.Persona);
            items = items.Include(i => i.TipoDatoPersona);
            items = items.Include(i => i.TipoVia);
            items = items.Include(i => i.ZonaUbicacion);
            items = items.Include(i => i.ZonaUbicacion1);
            items = items.Include(i => i.ZonaUbicacion2);
            items = items.Include(i => i.ZonaUbicacion3);
 
            OnGetDatoPersonaByIdDatoPersona(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnDatoPersonaGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnDatoPersonaCreated(Reincarapp.Models.reincardb.DatoPersona item);
        partial void OnAfterDatoPersonaCreated(Reincarapp.Models.reincardb.DatoPersona item);

        public async Task<Reincarapp.Models.reincardb.DatoPersona> CreateDatoPersona(Reincarapp.Models.reincardb.DatoPersona datopersona)
        {
            OnDatoPersonaCreated(datopersona);

            var existingItem = Context.DatoPersona
                              .Where(i => i.Id_Dato_Persona == datopersona.Id_Dato_Persona)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.DatoPersona.Add(datopersona);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(datopersona).State = EntityState.Detached;
                throw;
            }

            OnAfterDatoPersonaCreated(datopersona);

            return datopersona;
        }

        public async Task<Reincarapp.Models.reincardb.DatoPersona> CancelDatoPersonaChanges(Reincarapp.Models.reincardb.DatoPersona item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDatoPersonaUpdated(Reincarapp.Models.reincardb.DatoPersona item);
        partial void OnAfterDatoPersonaUpdated(Reincarapp.Models.reincardb.DatoPersona item);

        public async Task<Reincarapp.Models.reincardb.DatoPersona> UpdateDatoPersona(long iddatopersona, Reincarapp.Models.reincardb.DatoPersona datopersona)
        {
            OnDatoPersonaUpdated(datopersona);

            var itemToUpdate = Context.DatoPersona
                              .Where(i => i.Id_Dato_Persona == datopersona.Id_Dato_Persona)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(datopersona);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterDatoPersonaUpdated(datopersona);

            return datopersona;
        }

        partial void OnDatoPersonaDeleted(Reincarapp.Models.reincardb.DatoPersona item);
        partial void OnAfterDatoPersonaDeleted(Reincarapp.Models.reincardb.DatoPersona item);

        public async Task<Reincarapp.Models.reincardb.DatoPersona> DeleteDatoPersona(long iddatopersona)
        {
            var itemToDelete = Context.DatoPersona
                              .Where(i => i.Id_Dato_Persona == iddatopersona)
                              .Include(i => i.Evento)
                              .Include(i => i.LogDatoPersona)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnDatoPersonaDeleted(itemToDelete);


            Context.DatoPersona.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterDatoPersonaDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportDecisionEstadoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/decisionestado/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/decisionestado/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDecisionEstadoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/decisionestado/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/decisionestado/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDecisionEstadoRead(ref IQueryable<Reincarapp.Models.reincardb.DecisionEstado> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.DecisionEstado>> GetDecisionEstado(Query query = null)
        {
            var items = Context.DecisionEstado.AsQueryable();

            items = items.Include(i => i.Cliente);
            items = items.Include(i => i.EstadoClienteDeuda);
            items = items.Include(i => i.ResultadoEvento);
            items = items.Include(i => i.TipoComunicacion);
            items = items.Include(i => i.Usuario);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnDecisionEstadoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnDecisionEstadoGet(Reincarapp.Models.reincardb.DecisionEstado item);
        partial void OnGetDecisionEstadoByIdDecisionEstado(ref IQueryable<Reincarapp.Models.reincardb.DecisionEstado> items);


        public async Task<Reincarapp.Models.reincardb.DecisionEstado> GetDecisionEstadoByIdDecisionEstado(long iddecisionestado)
        {
            var items = Context.DecisionEstado
                              .AsNoTracking()
                              .Where(i => i.Id_Decision_Estado == iddecisionestado);

            items = items.Include(i => i.Cliente);
            items = items.Include(i => i.EstadoClienteDeuda);
            items = items.Include(i => i.ResultadoEvento);
            items = items.Include(i => i.TipoComunicacion);
            items = items.Include(i => i.Usuario);
 
            OnGetDecisionEstadoByIdDecisionEstado(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnDecisionEstadoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnDecisionEstadoCreated(Reincarapp.Models.reincardb.DecisionEstado item);
        partial void OnAfterDecisionEstadoCreated(Reincarapp.Models.reincardb.DecisionEstado item);

        public async Task<Reincarapp.Models.reincardb.DecisionEstado> CreateDecisionEstado(Reincarapp.Models.reincardb.DecisionEstado decisionestado)
        {
            OnDecisionEstadoCreated(decisionestado);

            var existingItem = Context.DecisionEstado
                              .Where(i => i.Id_Decision_Estado == decisionestado.Id_Decision_Estado)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.DecisionEstado.Add(decisionestado);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(decisionestado).State = EntityState.Detached;
                throw;
            }

            OnAfterDecisionEstadoCreated(decisionestado);

            return decisionestado;
        }

        public async Task<Reincarapp.Models.reincardb.DecisionEstado> CancelDecisionEstadoChanges(Reincarapp.Models.reincardb.DecisionEstado item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDecisionEstadoUpdated(Reincarapp.Models.reincardb.DecisionEstado item);
        partial void OnAfterDecisionEstadoUpdated(Reincarapp.Models.reincardb.DecisionEstado item);

        public async Task<Reincarapp.Models.reincardb.DecisionEstado> UpdateDecisionEstado(long iddecisionestado, Reincarapp.Models.reincardb.DecisionEstado decisionestado)
        {
            OnDecisionEstadoUpdated(decisionestado);

            var itemToUpdate = Context.DecisionEstado
                              .Where(i => i.Id_Decision_Estado == decisionestado.Id_Decision_Estado)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(decisionestado);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterDecisionEstadoUpdated(decisionestado);

            return decisionestado;
        }

        partial void OnDecisionEstadoDeleted(Reincarapp.Models.reincardb.DecisionEstado item);
        partial void OnAfterDecisionEstadoDeleted(Reincarapp.Models.reincardb.DecisionEstado item);

        public async Task<Reincarapp.Models.reincardb.DecisionEstado> DeleteDecisionEstado(long iddecisionestado)
        {
            var itemToDelete = Context.DecisionEstado
                              .Where(i => i.Id_Decision_Estado == iddecisionestado)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnDecisionEstadoDeleted(itemToDelete);


            Context.DecisionEstado.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterDecisionEstadoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportDepartamentoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/departamento/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/departamento/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDepartamentoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/departamento/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/departamento/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDepartamentoRead(ref IQueryable<Reincarapp.Models.reincardb.Departamento> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Departamento>> GetDepartamento(Query query = null)
        {
            var items = Context.Departamento.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnDepartamentoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnDepartamentoGet(Reincarapp.Models.reincardb.Departamento item);
        partial void OnGetDepartamentoByIdDepartamento(ref IQueryable<Reincarapp.Models.reincardb.Departamento> items);


        public async Task<Reincarapp.Models.reincardb.Departamento> GetDepartamentoByIdDepartamento(long iddepartamento)
        {
            var items = Context.Departamento
                              .AsNoTracking()
                              .Where(i => i.Id_Departamento == iddepartamento);

 
            OnGetDepartamentoByIdDepartamento(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnDepartamentoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnDepartamentoCreated(Reincarapp.Models.reincardb.Departamento item);
        partial void OnAfterDepartamentoCreated(Reincarapp.Models.reincardb.Departamento item);

        public async Task<Reincarapp.Models.reincardb.Departamento> CreateDepartamento(Reincarapp.Models.reincardb.Departamento departamento)
        {
            OnDepartamentoCreated(departamento);

            var existingItem = Context.Departamento
                              .Where(i => i.Id_Departamento == departamento.Id_Departamento)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Departamento.Add(departamento);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(departamento).State = EntityState.Detached;
                throw;
            }

            OnAfterDepartamentoCreated(departamento);

            return departamento;
        }

        public async Task<Reincarapp.Models.reincardb.Departamento> CancelDepartamentoChanges(Reincarapp.Models.reincardb.Departamento item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDepartamentoUpdated(Reincarapp.Models.reincardb.Departamento item);
        partial void OnAfterDepartamentoUpdated(Reincarapp.Models.reincardb.Departamento item);

        public async Task<Reincarapp.Models.reincardb.Departamento> UpdateDepartamento(long iddepartamento, Reincarapp.Models.reincardb.Departamento departamento)
        {
            OnDepartamentoUpdated(departamento);

            var itemToUpdate = Context.Departamento
                              .Where(i => i.Id_Departamento == departamento.Id_Departamento)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(departamento);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterDepartamentoUpdated(departamento);

            return departamento;
        }

        partial void OnDepartamentoDeleted(Reincarapp.Models.reincardb.Departamento item);
        partial void OnAfterDepartamentoDeleted(Reincarapp.Models.reincardb.Departamento item);

        public async Task<Reincarapp.Models.reincardb.Departamento> DeleteDepartamento(long iddepartamento)
        {
            var itemToDelete = Context.Departamento
                              .Where(i => i.Id_Departamento == iddepartamento)
                              .Include(i => i.DatoPersona)
                              .Include(i => i.Municipio)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnDepartamentoDeleted(itemToDelete);


            Context.Departamento.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterDepartamentoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportDocsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/docs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/docs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDocsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/docs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/docs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDocsRead(ref IQueryable<Reincarapp.Models.reincardb.Docs> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Docs>> GetDocs(Query query = null)
        {
            var items = Context.Docs.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnDocsRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportEmpSaludcoopToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/empsaludcoop/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/empsaludcoop/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEmpSaludcoopToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/empsaludcoop/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/empsaludcoop/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEmpSaludcoopRead(ref IQueryable<Reincarapp.Models.reincardb.EmpSaludcoop> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.EmpSaludcoop>> GetEmpSaludcoop(Query query = null)
        {
            var items = Context.EmpSaludcoop.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnEmpSaludcoopRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEmpSaludcoopGet(Reincarapp.Models.reincardb.EmpSaludcoop item);
        partial void OnGetEmpSaludcoopByIdEmpresa(ref IQueryable<Reincarapp.Models.reincardb.EmpSaludcoop> items);


        public async Task<Reincarapp.Models.reincardb.EmpSaludcoop> GetEmpSaludcoopByIdEmpresa(long idempresa)
        {
            var items = Context.EmpSaludcoop
                              .AsNoTracking()
                              .Where(i => i.Id_Empresa == idempresa);

 
            OnGetEmpSaludcoopByIdEmpresa(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnEmpSaludcoopGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnEmpSaludcoopCreated(Reincarapp.Models.reincardb.EmpSaludcoop item);
        partial void OnAfterEmpSaludcoopCreated(Reincarapp.Models.reincardb.EmpSaludcoop item);

        public async Task<Reincarapp.Models.reincardb.EmpSaludcoop> CreateEmpSaludcoop(Reincarapp.Models.reincardb.EmpSaludcoop empsaludcoop)
        {
            OnEmpSaludcoopCreated(empsaludcoop);

            var existingItem = Context.EmpSaludcoop
                              .Where(i => i.Id_Empresa == empsaludcoop.Id_Empresa)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.EmpSaludcoop.Add(empsaludcoop);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(empsaludcoop).State = EntityState.Detached;
                throw;
            }

            OnAfterEmpSaludcoopCreated(empsaludcoop);

            return empsaludcoop;
        }

        public async Task<Reincarapp.Models.reincardb.EmpSaludcoop> CancelEmpSaludcoopChanges(Reincarapp.Models.reincardb.EmpSaludcoop item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnEmpSaludcoopUpdated(Reincarapp.Models.reincardb.EmpSaludcoop item);
        partial void OnAfterEmpSaludcoopUpdated(Reincarapp.Models.reincardb.EmpSaludcoop item);

        public async Task<Reincarapp.Models.reincardb.EmpSaludcoop> UpdateEmpSaludcoop(long idempresa, Reincarapp.Models.reincardb.EmpSaludcoop empsaludcoop)
        {
            OnEmpSaludcoopUpdated(empsaludcoop);

            var itemToUpdate = Context.EmpSaludcoop
                              .Where(i => i.Id_Empresa == empsaludcoop.Id_Empresa)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(empsaludcoop);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterEmpSaludcoopUpdated(empsaludcoop);

            return empsaludcoop;
        }

        partial void OnEmpSaludcoopDeleted(Reincarapp.Models.reincardb.EmpSaludcoop item);
        partial void OnAfterEmpSaludcoopDeleted(Reincarapp.Models.reincardb.EmpSaludcoop item);

        public async Task<Reincarapp.Models.reincardb.EmpSaludcoop> DeleteEmpSaludcoop(long idempresa)
        {
            var itemToDelete = Context.EmpSaludcoop
                              .Where(i => i.Id_Empresa == idempresa)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEmpSaludcoopDeleted(itemToDelete);


            Context.EmpSaludcoop.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEmpSaludcoopDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportEstadoClienteDeudaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/estadoclientedeuda/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/estadoclientedeuda/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEstadoClienteDeudaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/estadoclientedeuda/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/estadoclientedeuda/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEstadoClienteDeudaRead(ref IQueryable<Reincarapp.Models.reincardb.EstadoClienteDeuda> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.EstadoClienteDeuda>> GetEstadoClienteDeuda(Query query = null)
        {
            var items = Context.EstadoClienteDeuda.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnEstadoClienteDeudaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEstadoClienteDeudaGet(Reincarapp.Models.reincardb.EstadoClienteDeuda item);
        partial void OnGetEstadoClienteDeudaByIdEstadoClienteDeuda(ref IQueryable<Reincarapp.Models.reincardb.EstadoClienteDeuda> items);


        public async Task<Reincarapp.Models.reincardb.EstadoClienteDeuda> GetEstadoClienteDeudaByIdEstadoClienteDeuda(long idestadoclientedeuda)
        {
            var items = Context.EstadoClienteDeuda
                              .AsNoTracking()
                              .Where(i => i.Id_Estado_Cliente_Deuda == idestadoclientedeuda);

 
            OnGetEstadoClienteDeudaByIdEstadoClienteDeuda(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnEstadoClienteDeudaGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnEstadoClienteDeudaCreated(Reincarapp.Models.reincardb.EstadoClienteDeuda item);
        partial void OnAfterEstadoClienteDeudaCreated(Reincarapp.Models.reincardb.EstadoClienteDeuda item);

        public async Task<Reincarapp.Models.reincardb.EstadoClienteDeuda> CreateEstadoClienteDeuda(Reincarapp.Models.reincardb.EstadoClienteDeuda estadoclientedeuda)
        {
            OnEstadoClienteDeudaCreated(estadoclientedeuda);

            var existingItem = Context.EstadoClienteDeuda
                              .Where(i => i.Id_Estado_Cliente_Deuda == estadoclientedeuda.Id_Estado_Cliente_Deuda)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.EstadoClienteDeuda.Add(estadoclientedeuda);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(estadoclientedeuda).State = EntityState.Detached;
                throw;
            }

            OnAfterEstadoClienteDeudaCreated(estadoclientedeuda);

            return estadoclientedeuda;
        }

        public async Task<Reincarapp.Models.reincardb.EstadoClienteDeuda> CancelEstadoClienteDeudaChanges(Reincarapp.Models.reincardb.EstadoClienteDeuda item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnEstadoClienteDeudaUpdated(Reincarapp.Models.reincardb.EstadoClienteDeuda item);
        partial void OnAfterEstadoClienteDeudaUpdated(Reincarapp.Models.reincardb.EstadoClienteDeuda item);

        public async Task<Reincarapp.Models.reincardb.EstadoClienteDeuda> UpdateEstadoClienteDeuda(long idestadoclientedeuda, Reincarapp.Models.reincardb.EstadoClienteDeuda estadoclientedeuda)
        {
            OnEstadoClienteDeudaUpdated(estadoclientedeuda);

            var itemToUpdate = Context.EstadoClienteDeuda
                              .Where(i => i.Id_Estado_Cliente_Deuda == estadoclientedeuda.Id_Estado_Cliente_Deuda)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(estadoclientedeuda);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterEstadoClienteDeudaUpdated(estadoclientedeuda);

            return estadoclientedeuda;
        }

        partial void OnEstadoClienteDeudaDeleted(Reincarapp.Models.reincardb.EstadoClienteDeuda item);
        partial void OnAfterEstadoClienteDeudaDeleted(Reincarapp.Models.reincardb.EstadoClienteDeuda item);

        public async Task<Reincarapp.Models.reincardb.EstadoClienteDeuda> DeleteEstadoClienteDeuda(long idestadoclientedeuda)
        {
            var itemToDelete = Context.EstadoClienteDeuda
                              .Where(i => i.Id_Estado_Cliente_Deuda == idestadoclientedeuda)
                              .Include(i => i.ClienteDeuda)
                              .Include(i => i.DecisionEstado)
                              .Include(i => i.LogClienteDeudaEstado)
                              .Include(i => i.LogClienteDeudaEstado1)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEstadoClienteDeudaDeleted(itemToDelete);


            Context.EstadoClienteDeuda.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEstadoClienteDeudaDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportEstadoUsuarioToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/estadousuario/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/estadousuario/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEstadoUsuarioToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/estadousuario/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/estadousuario/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEstadoUsuarioRead(ref IQueryable<Reincarapp.Models.reincardb.EstadoUsuario> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.EstadoUsuario>> GetEstadoUsuario(Query query = null)
        {
            var items = Context.EstadoUsuario.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnEstadoUsuarioRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEstadoUsuarioGet(Reincarapp.Models.reincardb.EstadoUsuario item);
        partial void OnGetEstadoUsuarioByIdEstadoUsuario(ref IQueryable<Reincarapp.Models.reincardb.EstadoUsuario> items);


        public async Task<Reincarapp.Models.reincardb.EstadoUsuario> GetEstadoUsuarioByIdEstadoUsuario(bool idestadousuario)
        {
            var items = Context.EstadoUsuario
                              .AsNoTracking()
                              .Where(i => i.id_estado_usuario == idestadousuario);

 
            OnGetEstadoUsuarioByIdEstadoUsuario(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnEstadoUsuarioGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnEstadoUsuarioCreated(Reincarapp.Models.reincardb.EstadoUsuario item);
        partial void OnAfterEstadoUsuarioCreated(Reincarapp.Models.reincardb.EstadoUsuario item);

        public async Task<Reincarapp.Models.reincardb.EstadoUsuario> CreateEstadoUsuario(Reincarapp.Models.reincardb.EstadoUsuario estadousuario)
        {
            OnEstadoUsuarioCreated(estadousuario);

            var existingItem = Context.EstadoUsuario
                              .Where(i => i.id_estado_usuario == estadousuario.id_estado_usuario)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.EstadoUsuario.Add(estadousuario);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(estadousuario).State = EntityState.Detached;
                throw;
            }

            OnAfterEstadoUsuarioCreated(estadousuario);

            return estadousuario;
        }

        public async Task<Reincarapp.Models.reincardb.EstadoUsuario> CancelEstadoUsuarioChanges(Reincarapp.Models.reincardb.EstadoUsuario item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnEstadoUsuarioUpdated(Reincarapp.Models.reincardb.EstadoUsuario item);
        partial void OnAfterEstadoUsuarioUpdated(Reincarapp.Models.reincardb.EstadoUsuario item);

        public async Task<Reincarapp.Models.reincardb.EstadoUsuario> UpdateEstadoUsuario(bool idestadousuario, Reincarapp.Models.reincardb.EstadoUsuario estadousuario)
        {
            OnEstadoUsuarioUpdated(estadousuario);

            var itemToUpdate = Context.EstadoUsuario
                              .Where(i => i.id_estado_usuario == estadousuario.id_estado_usuario)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(estadousuario);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterEstadoUsuarioUpdated(estadousuario);

            return estadousuario;
        }

        partial void OnEstadoUsuarioDeleted(Reincarapp.Models.reincardb.EstadoUsuario item);
        partial void OnAfterEstadoUsuarioDeleted(Reincarapp.Models.reincardb.EstadoUsuario item);

        public async Task<Reincarapp.Models.reincardb.EstadoUsuario> DeleteEstadoUsuario(bool idestadousuario)
        {
            var itemToDelete = Context.EstadoUsuario
                              .Where(i => i.id_estado_usuario == idestadousuario)
                              .Include(i => i.Usuario)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEstadoUsuarioDeleted(itemToDelete);


            Context.EstadoUsuario.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEstadoUsuarioDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportEventoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/evento/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/evento/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEventoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/evento/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/evento/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEventoRead(ref IQueryable<Reincarapp.Models.reincardb.Evento> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Evento>> GetEvento(Query query = null)
        {
            var items = Context.Evento.AsQueryable();

            items = items.Include(i => i.Aspnetusers);
            items = items.Include(i => i.ClasificacionAdicional);
            items = items.Include(i => i.ClasificacionAdicional1);
            items = items.Include(i => i.ClasificacionAdicional2);
            items = items.Include(i => i.ClienteDeuda);
            items = items.Include(i => i.DatoPersona);
            items = items.Include(i => i.ClasificacionAdicional3);
            items = items.Include(i => i.ClasificacionAdicional4);
            items = items.Include(i => i.ClasificacionAdicional5);
            items = items.Include(i => i.ClasificacionAdicional6);
            items = items.Include(i => i.ResultadoEvento);
            items = items.Include(i => i.Tarea);
            items = items.Include(i => i.TipoComunicacion);
            items = items.Include(i => i.Usuario);
            items = items.Include(i => i.Usuario1);
            items = items.Include(i => i.Aspnetusers1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnEventoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEventoGet(Reincarapp.Models.reincardb.Evento item);
        partial void OnGetEventoByIdEvento(ref IQueryable<Reincarapp.Models.reincardb.Evento> items);


        public async Task<Reincarapp.Models.reincardb.Evento> GetEventoByIdEvento(long idevento)
        {
            var items = Context.Evento
                              .AsNoTracking()
                              .Where(i => i.Id_Evento == idevento);

            items = items.Include(i => i.Aspnetusers);
            items = items.Include(i => i.ClasificacionAdicional);
            items = items.Include(i => i.ClasificacionAdicional1);
            items = items.Include(i => i.ClasificacionAdicional2);
            items = items.Include(i => i.ClienteDeuda);
            items = items.Include(i => i.DatoPersona);
            items = items.Include(i => i.ClasificacionAdicional3);
            items = items.Include(i => i.ClasificacionAdicional4);
            items = items.Include(i => i.ClasificacionAdicional5);
            items = items.Include(i => i.ClasificacionAdicional6);
            items = items.Include(i => i.ResultadoEvento);
            items = items.Include(i => i.Tarea);
            items = items.Include(i => i.TipoComunicacion);
            items = items.Include(i => i.Usuario);
            items = items.Include(i => i.Usuario1);
            items = items.Include(i => i.Aspnetusers1);
 
            OnGetEventoByIdEvento(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnEventoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnEventoCreated(Reincarapp.Models.reincardb.Evento item);
        partial void OnAfterEventoCreated(Reincarapp.Models.reincardb.Evento item);

        public async Task<Reincarapp.Models.reincardb.Evento> CreateEvento(Reincarapp.Models.reincardb.Evento evento)
        {
            OnEventoCreated(evento);

            var existingItem = Context.Evento
                              .Where(i => i.Id_Evento == evento.Id_Evento)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Evento.Add(evento);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(evento).State = EntityState.Detached;
                throw;
            }

            OnAfterEventoCreated(evento);

            return evento;
        }

        public async Task<Reincarapp.Models.reincardb.Evento> CancelEventoChanges(Reincarapp.Models.reincardb.Evento item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnEventoUpdated(Reincarapp.Models.reincardb.Evento item);
        partial void OnAfterEventoUpdated(Reincarapp.Models.reincardb.Evento item);

        public async Task<Reincarapp.Models.reincardb.Evento> UpdateEvento(long idevento, Reincarapp.Models.reincardb.Evento evento)
        {
            OnEventoUpdated(evento);

            var itemToUpdate = Context.Evento
                              .Where(i => i.Id_Evento == evento.Id_Evento)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(evento);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterEventoUpdated(evento);

            return evento;
        }

        partial void OnEventoDeleted(Reincarapp.Models.reincardb.Evento item);
        partial void OnAfterEventoDeleted(Reincarapp.Models.reincardb.Evento item);

        public async Task<Reincarapp.Models.reincardb.Evento> DeleteEvento(long idevento)
        {
            var itemToDelete = Context.Evento
                              .Where(i => i.Id_Evento == idevento)
                              .Include(i => i.Bloqueocontacto)
                              .Include(i => i.ClienteDeudaCons)
                              .Include(i => i.ClienteDeudaCons1)
                              .Include(i => i.ClienteDeudaHonorario)
                              .Include(i => i.Correspondencia)
                              .Include(i => i.EventoArchivo)
                              .Include(i => i.EventoDet)
                              .Include(i => i.Sms)
                              .Include(i => i.Tarea1)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEventoDeleted(itemToDelete);


            Context.Evento.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEventoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportEventoArchivoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/eventoarchivo/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/eventoarchivo/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEventoArchivoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/eventoarchivo/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/eventoarchivo/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEventoArchivoRead(ref IQueryable<Reincarapp.Models.reincardb.EventoArchivo> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.EventoArchivo>> GetEventoArchivo(Query query = null)
        {
            var items = Context.EventoArchivo.AsQueryable();

            items = items.Include(i => i.Evento);
            items = items.Include(i => i.TipoArchivo);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnEventoArchivoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEventoArchivoGet(Reincarapp.Models.reincardb.EventoArchivo item);
        partial void OnGetEventoArchivoByIdEventoArchivo(ref IQueryable<Reincarapp.Models.reincardb.EventoArchivo> items);


        public async Task<Reincarapp.Models.reincardb.EventoArchivo> GetEventoArchivoByIdEventoArchivo(long ideventoarchivo)
        {
            var items = Context.EventoArchivo
                              .AsNoTracking()
                              .Where(i => i.id_evento_archivo == ideventoarchivo);

            items = items.Include(i => i.Evento);
            items = items.Include(i => i.TipoArchivo);
 
            OnGetEventoArchivoByIdEventoArchivo(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnEventoArchivoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnEventoArchivoCreated(Reincarapp.Models.reincardb.EventoArchivo item);
        partial void OnAfterEventoArchivoCreated(Reincarapp.Models.reincardb.EventoArchivo item);

        public async Task<Reincarapp.Models.reincardb.EventoArchivo> CreateEventoArchivo(Reincarapp.Models.reincardb.EventoArchivo eventoarchivo)
        {
            OnEventoArchivoCreated(eventoarchivo);

            var existingItem = Context.EventoArchivo
                              .Where(i => i.id_evento_archivo == eventoarchivo.id_evento_archivo)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.EventoArchivo.Add(eventoarchivo);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(eventoarchivo).State = EntityState.Detached;
                throw;
            }

            OnAfterEventoArchivoCreated(eventoarchivo);

            return eventoarchivo;
        }

        public async Task<Reincarapp.Models.reincardb.EventoArchivo> CancelEventoArchivoChanges(Reincarapp.Models.reincardb.EventoArchivo item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnEventoArchivoUpdated(Reincarapp.Models.reincardb.EventoArchivo item);
        partial void OnAfterEventoArchivoUpdated(Reincarapp.Models.reincardb.EventoArchivo item);

        public async Task<Reincarapp.Models.reincardb.EventoArchivo> UpdateEventoArchivo(long ideventoarchivo, Reincarapp.Models.reincardb.EventoArchivo eventoarchivo)
        {
            OnEventoArchivoUpdated(eventoarchivo);

            var itemToUpdate = Context.EventoArchivo
                              .Where(i => i.id_evento_archivo == eventoarchivo.id_evento_archivo)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(eventoarchivo);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterEventoArchivoUpdated(eventoarchivo);

            return eventoarchivo;
        }

        partial void OnEventoArchivoDeleted(Reincarapp.Models.reincardb.EventoArchivo item);
        partial void OnAfterEventoArchivoDeleted(Reincarapp.Models.reincardb.EventoArchivo item);

        public async Task<Reincarapp.Models.reincardb.EventoArchivo> DeleteEventoArchivo(long ideventoarchivo)
        {
            var itemToDelete = Context.EventoArchivo
                              .Where(i => i.id_evento_archivo == ideventoarchivo)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEventoArchivoDeleted(itemToDelete);


            Context.EventoArchivo.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEventoArchivoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportEventoDetToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/eventodet/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/eventodet/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEventoDetToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/eventodet/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/eventodet/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEventoDetRead(ref IQueryable<Reincarapp.Models.reincardb.EventoDet> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.EventoDet>> GetEventoDet(Query query = null)
        {
            var items = Context.EventoDet.AsQueryable();

            items = items.Include(i => i.ClasificacionAdicional);
            items = items.Include(i => i.Evento);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnEventoDetRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEventoDetGet(Reincarapp.Models.reincardb.EventoDet item);
        partial void OnGetEventoDetByIdEventoDet(ref IQueryable<Reincarapp.Models.reincardb.EventoDet> items);


        public async Task<Reincarapp.Models.reincardb.EventoDet> GetEventoDetByIdEventoDet(int ideventodet)
        {
            var items = Context.EventoDet
                              .AsNoTracking()
                              .Where(i => i.id_evento_det == ideventodet);

            items = items.Include(i => i.ClasificacionAdicional);
            items = items.Include(i => i.Evento);
 
            OnGetEventoDetByIdEventoDet(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnEventoDetGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnEventoDetCreated(Reincarapp.Models.reincardb.EventoDet item);
        partial void OnAfterEventoDetCreated(Reincarapp.Models.reincardb.EventoDet item);

        public async Task<Reincarapp.Models.reincardb.EventoDet> CreateEventoDet(Reincarapp.Models.reincardb.EventoDet eventodet)
        {
            OnEventoDetCreated(eventodet);

            var existingItem = Context.EventoDet
                              .Where(i => i.id_evento_det == eventodet.id_evento_det)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.EventoDet.Add(eventodet);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(eventodet).State = EntityState.Detached;
                throw;
            }

            OnAfterEventoDetCreated(eventodet);

            return eventodet;
        }

        public async Task<Reincarapp.Models.reincardb.EventoDet> CancelEventoDetChanges(Reincarapp.Models.reincardb.EventoDet item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnEventoDetUpdated(Reincarapp.Models.reincardb.EventoDet item);
        partial void OnAfterEventoDetUpdated(Reincarapp.Models.reincardb.EventoDet item);

        public async Task<Reincarapp.Models.reincardb.EventoDet> UpdateEventoDet(int ideventodet, Reincarapp.Models.reincardb.EventoDet eventodet)
        {
            OnEventoDetUpdated(eventodet);

            var itemToUpdate = Context.EventoDet
                              .Where(i => i.id_evento_det == eventodet.id_evento_det)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(eventodet);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterEventoDetUpdated(eventodet);

            return eventodet;
        }

        partial void OnEventoDetDeleted(Reincarapp.Models.reincardb.EventoDet item);
        partial void OnAfterEventoDetDeleted(Reincarapp.Models.reincardb.EventoDet item);

        public async Task<Reincarapp.Models.reincardb.EventoDet> DeleteEventoDet(int ideventodet)
        {
            var itemToDelete = Context.EventoDet
                              .Where(i => i.id_evento_det == ideventodet)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEventoDetDeleted(itemToDelete);


            Context.EventoDet.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEventoDetDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportFranjaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/franja/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/franja/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFranjaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/franja/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/franja/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFranjaRead(ref IQueryable<Reincarapp.Models.reincardb.Franja> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Franja>> GetFranja(Query query = null)
        {
            var items = Context.Franja.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnFranjaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFranjaGet(Reincarapp.Models.reincardb.Franja item);
        partial void OnGetFranjaByIdFranja(ref IQueryable<Reincarapp.Models.reincardb.Franja> items);


        public async Task<Reincarapp.Models.reincardb.Franja> GetFranjaByIdFranja(long idfranja)
        {
            var items = Context.Franja
                              .AsNoTracking()
                              .Where(i => i.id_franja == idfranja);

 
            OnGetFranjaByIdFranja(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnFranjaGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnFranjaCreated(Reincarapp.Models.reincardb.Franja item);
        partial void OnAfterFranjaCreated(Reincarapp.Models.reincardb.Franja item);

        public async Task<Reincarapp.Models.reincardb.Franja> CreateFranja(Reincarapp.Models.reincardb.Franja franja)
        {
            OnFranjaCreated(franja);

            var existingItem = Context.Franja
                              .Where(i => i.id_franja == franja.id_franja)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Franja.Add(franja);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(franja).State = EntityState.Detached;
                throw;
            }

            OnAfterFranjaCreated(franja);

            return franja;
        }

        public async Task<Reincarapp.Models.reincardb.Franja> CancelFranjaChanges(Reincarapp.Models.reincardb.Franja item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnFranjaUpdated(Reincarapp.Models.reincardb.Franja item);
        partial void OnAfterFranjaUpdated(Reincarapp.Models.reincardb.Franja item);

        public async Task<Reincarapp.Models.reincardb.Franja> UpdateFranja(long idfranja, Reincarapp.Models.reincardb.Franja franja)
        {
            OnFranjaUpdated(franja);

            var itemToUpdate = Context.Franja
                              .Where(i => i.id_franja == franja.id_franja)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(franja);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterFranjaUpdated(franja);

            return franja;
        }

        partial void OnFranjaDeleted(Reincarapp.Models.reincardb.Franja item);
        partial void OnAfterFranjaDeleted(Reincarapp.Models.reincardb.Franja item);

        public async Task<Reincarapp.Models.reincardb.Franja> DeleteFranja(long idfranja)
        {
            var itemToDelete = Context.Franja
                              .Where(i => i.id_franja == idfranja)
                              .Include(i => i.Rediferido)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnFranjaDeleted(itemToDelete);


            Context.Franja.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterFranjaDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportGestionesCoomuTempToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/gestionescoomutemp/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/gestionescoomutemp/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportGestionesCoomuTempToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/gestionescoomutemp/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/gestionescoomutemp/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGestionesCoomuTempRead(ref IQueryable<Reincarapp.Models.reincardb.GestionesCoomuTemp> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.GestionesCoomuTemp>> GetGestionesCoomuTemp(Query query = null)
        {
            var items = Context.GestionesCoomuTemp.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnGestionesCoomuTempRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportHonorarioAvvillasToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/honorarioavvillas/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/honorarioavvillas/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHonorarioAvvillasToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/honorarioavvillas/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/honorarioavvillas/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHonorarioAvvillasRead(ref IQueryable<Reincarapp.Models.reincardb.HonorarioAvvillas> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.HonorarioAvvillas>> GetHonorarioAvvillas(Query query = null)
        {
            var items = Context.HonorarioAvvillas.AsQueryable();

            items = items.Include(i => i.CampoHonorario);
            items = items.Include(i => i.ClasificacionAdicional);
            items = items.Include(i => i.Cliente);
            items = items.Include(i => i.TipoRecaudo);
            items = items.Include(i => i.Usuario);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnHonorarioAvvillasRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHonorarioAvvillasGet(Reincarapp.Models.reincardb.HonorarioAvvillas item);
        partial void OnGetHonorarioAvvillasByIdHonorarioAvvillas(ref IQueryable<Reincarapp.Models.reincardb.HonorarioAvvillas> items);


        public async Task<Reincarapp.Models.reincardb.HonorarioAvvillas> GetHonorarioAvvillasByIdHonorarioAvvillas(long idhonorarioavvillas)
        {
            var items = Context.HonorarioAvvillas
                              .AsNoTracking()
                              .Where(i => i.id_honorario_avvillas == idhonorarioavvillas);

            items = items.Include(i => i.CampoHonorario);
            items = items.Include(i => i.ClasificacionAdicional);
            items = items.Include(i => i.Cliente);
            items = items.Include(i => i.TipoRecaudo);
            items = items.Include(i => i.Usuario);
 
            OnGetHonorarioAvvillasByIdHonorarioAvvillas(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnHonorarioAvvillasGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHonorarioAvvillasCreated(Reincarapp.Models.reincardb.HonorarioAvvillas item);
        partial void OnAfterHonorarioAvvillasCreated(Reincarapp.Models.reincardb.HonorarioAvvillas item);

        public async Task<Reincarapp.Models.reincardb.HonorarioAvvillas> CreateHonorarioAvvillas(Reincarapp.Models.reincardb.HonorarioAvvillas honorarioavvillas)
        {
            OnHonorarioAvvillasCreated(honorarioavvillas);

            var existingItem = Context.HonorarioAvvillas
                              .Where(i => i.id_honorario_avvillas == honorarioavvillas.id_honorario_avvillas)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HonorarioAvvillas.Add(honorarioavvillas);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(honorarioavvillas).State = EntityState.Detached;
                throw;
            }

            OnAfterHonorarioAvvillasCreated(honorarioavvillas);

            return honorarioavvillas;
        }

        public async Task<Reincarapp.Models.reincardb.HonorarioAvvillas> CancelHonorarioAvvillasChanges(Reincarapp.Models.reincardb.HonorarioAvvillas item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHonorarioAvvillasUpdated(Reincarapp.Models.reincardb.HonorarioAvvillas item);
        partial void OnAfterHonorarioAvvillasUpdated(Reincarapp.Models.reincardb.HonorarioAvvillas item);

        public async Task<Reincarapp.Models.reincardb.HonorarioAvvillas> UpdateHonorarioAvvillas(long idhonorarioavvillas, Reincarapp.Models.reincardb.HonorarioAvvillas honorarioavvillas)
        {
            OnHonorarioAvvillasUpdated(honorarioavvillas);

            var itemToUpdate = Context.HonorarioAvvillas
                              .Where(i => i.id_honorario_avvillas == honorarioavvillas.id_honorario_avvillas)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(honorarioavvillas);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHonorarioAvvillasUpdated(honorarioavvillas);

            return honorarioavvillas;
        }

        partial void OnHonorarioAvvillasDeleted(Reincarapp.Models.reincardb.HonorarioAvvillas item);
        partial void OnAfterHonorarioAvvillasDeleted(Reincarapp.Models.reincardb.HonorarioAvvillas item);

        public async Task<Reincarapp.Models.reincardb.HonorarioAvvillas> DeleteHonorarioAvvillas(long idhonorarioavvillas)
        {
            var itemToDelete = Context.HonorarioAvvillas
                              .Where(i => i.id_honorario_avvillas == idhonorarioavvillas)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHonorarioAvvillasDeleted(itemToDelete);


            Context.HonorarioAvvillas.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHonorarioAvvillasDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportInfSaludcoopToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/infsaludcoop/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/infsaludcoop/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInfSaludcoopToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/infsaludcoop/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/infsaludcoop/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInfSaludcoopRead(ref IQueryable<Reincarapp.Models.reincardb.InfSaludcoop> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.InfSaludcoop>> GetInfSaludcoop(Query query = null)
        {
            var items = Context.InfSaludcoop.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnInfSaludcoopRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportInformeToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/informe/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/informe/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInformeToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/informe/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/informe/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInformeRead(ref IQueryable<Reincarapp.Models.reincardb.Informe> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Informe>> GetInforme(Query query = null)
        {
            var items = Context.Informe.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnInformeRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnInformeGet(Reincarapp.Models.reincardb.Informe item);
        partial void OnGetInformeByIdInforme(ref IQueryable<Reincarapp.Models.reincardb.Informe> items);


        public async Task<Reincarapp.Models.reincardb.Informe> GetInformeByIdInforme(int idinforme)
        {
            var items = Context.Informe
                              .AsNoTracking()
                              .Where(i => i.idInforme == idinforme);

 
            OnGetInformeByIdInforme(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnInformeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnInformeCreated(Reincarapp.Models.reincardb.Informe item);
        partial void OnAfterInformeCreated(Reincarapp.Models.reincardb.Informe item);

        public async Task<Reincarapp.Models.reincardb.Informe> CreateInforme(Reincarapp.Models.reincardb.Informe informe)
        {
            OnInformeCreated(informe);

            var existingItem = Context.Informe
                              .Where(i => i.idInforme == informe.idInforme)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Informe.Add(informe);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(informe).State = EntityState.Detached;
                throw;
            }

            OnAfterInformeCreated(informe);

            return informe;
        }

        public async Task<Reincarapp.Models.reincardb.Informe> CancelInformeChanges(Reincarapp.Models.reincardb.Informe item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnInformeUpdated(Reincarapp.Models.reincardb.Informe item);
        partial void OnAfterInformeUpdated(Reincarapp.Models.reincardb.Informe item);

        public async Task<Reincarapp.Models.reincardb.Informe> UpdateInforme(int idinforme, Reincarapp.Models.reincardb.Informe informe)
        {
            OnInformeUpdated(informe);

            var itemToUpdate = Context.Informe
                              .Where(i => i.idInforme == informe.idInforme)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(informe);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterInformeUpdated(informe);

            return informe;
        }

        partial void OnInformeDeleted(Reincarapp.Models.reincardb.Informe item);
        partial void OnAfterInformeDeleted(Reincarapp.Models.reincardb.Informe item);

        public async Task<Reincarapp.Models.reincardb.Informe> DeleteInforme(int idinforme)
        {
            var itemToDelete = Context.Informe
                              .Where(i => i.idInforme == idinforme)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnInformeDeleted(itemToDelete);


            Context.Informe.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterInformeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportJamarToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/jamar/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/jamar/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportJamarToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/jamar/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/jamar/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnJamarRead(ref IQueryable<Reincarapp.Models.reincardb.Jamar> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Jamar>> GetJamar(Query query = null)
        {
            var items = Context.Jamar.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnJamarRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnJamarGet(Reincarapp.Models.reincardb.Jamar item);
        partial void OnGetJamarByIdJamar(ref IQueryable<Reincarapp.Models.reincardb.Jamar> items);


        public async Task<Reincarapp.Models.reincardb.Jamar> GetJamarByIdJamar(long idjamar)
        {
            var items = Context.Jamar
                              .AsNoTracking()
                              .Where(i => i.id_jamar == idjamar);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetJamarByIdJamar(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnJamarGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnJamarCreated(Reincarapp.Models.reincardb.Jamar item);
        partial void OnAfterJamarCreated(Reincarapp.Models.reincardb.Jamar item);

        public async Task<Reincarapp.Models.reincardb.Jamar> CreateJamar(Reincarapp.Models.reincardb.Jamar jamar)
        {
            OnJamarCreated(jamar);

            var existingItem = Context.Jamar
                              .Where(i => i.id_jamar == jamar.id_jamar)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Jamar.Add(jamar);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(jamar).State = EntityState.Detached;
                throw;
            }

            OnAfterJamarCreated(jamar);

            return jamar;
        }

        public async Task<Reincarapp.Models.reincardb.Jamar> CancelJamarChanges(Reincarapp.Models.reincardb.Jamar item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnJamarUpdated(Reincarapp.Models.reincardb.Jamar item);
        partial void OnAfterJamarUpdated(Reincarapp.Models.reincardb.Jamar item);

        public async Task<Reincarapp.Models.reincardb.Jamar> UpdateJamar(long idjamar, Reincarapp.Models.reincardb.Jamar jamar)
        {
            OnJamarUpdated(jamar);

            var itemToUpdate = Context.Jamar
                              .Where(i => i.id_jamar == jamar.id_jamar)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(jamar);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterJamarUpdated(jamar);

            return jamar;
        }

        partial void OnJamarDeleted(Reincarapp.Models.reincardb.Jamar item);
        partial void OnAfterJamarDeleted(Reincarapp.Models.reincardb.Jamar item);

        public async Task<Reincarapp.Models.reincardb.Jamar> DeleteJamar(long idjamar)
        {
            var itemToDelete = Context.Jamar
                              .Where(i => i.id_jamar == idjamar)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnJamarDeleted(itemToDelete);


            Context.Jamar.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterJamarDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportJamarJuridicaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/jamarjuridica/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/jamarjuridica/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportJamarJuridicaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/jamarjuridica/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/jamarjuridica/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnJamarJuridicaRead(ref IQueryable<Reincarapp.Models.reincardb.JamarJuridica> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.JamarJuridica>> GetJamarJuridica(Query query = null)
        {
            var items = Context.JamarJuridica.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnJamarJuridicaRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportLogClienteDeudaEstadoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/logclientedeudaestado/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/logclientedeudaestado/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportLogClienteDeudaEstadoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/logclientedeudaestado/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/logclientedeudaestado/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnLogClienteDeudaEstadoRead(ref IQueryable<Reincarapp.Models.reincardb.LogClienteDeudaEstado> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.LogClienteDeudaEstado>> GetLogClienteDeudaEstado(Query query = null)
        {
            var items = Context.LogClienteDeudaEstado.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);
            items = items.Include(i => i.EstadoClienteDeuda);
            items = items.Include(i => i.EstadoClienteDeuda1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnLogClienteDeudaEstadoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnLogClienteDeudaEstadoGet(Reincarapp.Models.reincardb.LogClienteDeudaEstado item);
        partial void OnGetLogClienteDeudaEstadoByIdLogClienteDeudaEstado(ref IQueryable<Reincarapp.Models.reincardb.LogClienteDeudaEstado> items);


        public async Task<Reincarapp.Models.reincardb.LogClienteDeudaEstado> GetLogClienteDeudaEstadoByIdLogClienteDeudaEstado(long idlogclientedeudaestado)
        {
            var items = Context.LogClienteDeudaEstado
                              .AsNoTracking()
                              .Where(i => i.id_log_cliente_deuda_estado == idlogclientedeudaestado);

            items = items.Include(i => i.ClienteDeuda);
            items = items.Include(i => i.EstadoClienteDeuda);
            items = items.Include(i => i.EstadoClienteDeuda1);
 
            OnGetLogClienteDeudaEstadoByIdLogClienteDeudaEstado(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnLogClienteDeudaEstadoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnLogClienteDeudaEstadoCreated(Reincarapp.Models.reincardb.LogClienteDeudaEstado item);
        partial void OnAfterLogClienteDeudaEstadoCreated(Reincarapp.Models.reincardb.LogClienteDeudaEstado item);

        public async Task<Reincarapp.Models.reincardb.LogClienteDeudaEstado> CreateLogClienteDeudaEstado(Reincarapp.Models.reincardb.LogClienteDeudaEstado logclientedeudaestado)
        {
            OnLogClienteDeudaEstadoCreated(logclientedeudaestado);

            var existingItem = Context.LogClienteDeudaEstado
                              .Where(i => i.id_log_cliente_deuda_estado == logclientedeudaestado.id_log_cliente_deuda_estado)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.LogClienteDeudaEstado.Add(logclientedeudaestado);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(logclientedeudaestado).State = EntityState.Detached;
                throw;
            }

            OnAfterLogClienteDeudaEstadoCreated(logclientedeudaestado);

            return logclientedeudaestado;
        }

        public async Task<Reincarapp.Models.reincardb.LogClienteDeudaEstado> CancelLogClienteDeudaEstadoChanges(Reincarapp.Models.reincardb.LogClienteDeudaEstado item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnLogClienteDeudaEstadoUpdated(Reincarapp.Models.reincardb.LogClienteDeudaEstado item);
        partial void OnAfterLogClienteDeudaEstadoUpdated(Reincarapp.Models.reincardb.LogClienteDeudaEstado item);

        public async Task<Reincarapp.Models.reincardb.LogClienteDeudaEstado> UpdateLogClienteDeudaEstado(long idlogclientedeudaestado, Reincarapp.Models.reincardb.LogClienteDeudaEstado logclientedeudaestado)
        {
            OnLogClienteDeudaEstadoUpdated(logclientedeudaestado);

            var itemToUpdate = Context.LogClienteDeudaEstado
                              .Where(i => i.id_log_cliente_deuda_estado == logclientedeudaestado.id_log_cliente_deuda_estado)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(logclientedeudaestado);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterLogClienteDeudaEstadoUpdated(logclientedeudaestado);

            return logclientedeudaestado;
        }

        partial void OnLogClienteDeudaEstadoDeleted(Reincarapp.Models.reincardb.LogClienteDeudaEstado item);
        partial void OnAfterLogClienteDeudaEstadoDeleted(Reincarapp.Models.reincardb.LogClienteDeudaEstado item);

        public async Task<Reincarapp.Models.reincardb.LogClienteDeudaEstado> DeleteLogClienteDeudaEstado(long idlogclientedeudaestado)
        {
            var itemToDelete = Context.LogClienteDeudaEstado
                              .Where(i => i.id_log_cliente_deuda_estado == idlogclientedeudaestado)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnLogClienteDeudaEstadoDeleted(itemToDelete);


            Context.LogClienteDeudaEstado.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterLogClienteDeudaEstadoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportLogDatoPersonaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/logdatopersona/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/logdatopersona/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportLogDatoPersonaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/logdatopersona/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/logdatopersona/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnLogDatoPersonaRead(ref IQueryable<Reincarapp.Models.reincardb.LogDatoPersona> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.LogDatoPersona>> GetLogDatoPersona(Query query = null)
        {
            var items = Context.LogDatoPersona.AsQueryable();

            items = items.Include(i => i.DatoPersona);
            items = items.Include(i => i.Tarea);
            items = items.Include(i => i.TipoDatoPersona);
            items = items.Include(i => i.TipoDatoPersona1);
            items = items.Include(i => i.Usuario);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnLogDatoPersonaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnLogDatoPersonaGet(Reincarapp.Models.reincardb.LogDatoPersona item);
        partial void OnGetLogDatoPersonaByIdLogDatoPersona(ref IQueryable<Reincarapp.Models.reincardb.LogDatoPersona> items);


        public async Task<Reincarapp.Models.reincardb.LogDatoPersona> GetLogDatoPersonaByIdLogDatoPersona(long idlogdatopersona)
        {
            var items = Context.LogDatoPersona
                              .AsNoTracking()
                              .Where(i => i.id_log_dato_persona == idlogdatopersona);

            items = items.Include(i => i.DatoPersona);
            items = items.Include(i => i.Tarea);
            items = items.Include(i => i.TipoDatoPersona);
            items = items.Include(i => i.TipoDatoPersona1);
            items = items.Include(i => i.Usuario);
 
            OnGetLogDatoPersonaByIdLogDatoPersona(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnLogDatoPersonaGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnLogDatoPersonaCreated(Reincarapp.Models.reincardb.LogDatoPersona item);
        partial void OnAfterLogDatoPersonaCreated(Reincarapp.Models.reincardb.LogDatoPersona item);

        public async Task<Reincarapp.Models.reincardb.LogDatoPersona> CreateLogDatoPersona(Reincarapp.Models.reincardb.LogDatoPersona logdatopersona)
        {
            OnLogDatoPersonaCreated(logdatopersona);

            var existingItem = Context.LogDatoPersona
                              .Where(i => i.id_log_dato_persona == logdatopersona.id_log_dato_persona)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.LogDatoPersona.Add(logdatopersona);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(logdatopersona).State = EntityState.Detached;
                throw;
            }

            OnAfterLogDatoPersonaCreated(logdatopersona);

            return logdatopersona;
        }

        public async Task<Reincarapp.Models.reincardb.LogDatoPersona> CancelLogDatoPersonaChanges(Reincarapp.Models.reincardb.LogDatoPersona item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnLogDatoPersonaUpdated(Reincarapp.Models.reincardb.LogDatoPersona item);
        partial void OnAfterLogDatoPersonaUpdated(Reincarapp.Models.reincardb.LogDatoPersona item);

        public async Task<Reincarapp.Models.reincardb.LogDatoPersona> UpdateLogDatoPersona(long idlogdatopersona, Reincarapp.Models.reincardb.LogDatoPersona logdatopersona)
        {
            OnLogDatoPersonaUpdated(logdatopersona);

            var itemToUpdate = Context.LogDatoPersona
                              .Where(i => i.id_log_dato_persona == logdatopersona.id_log_dato_persona)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(logdatopersona);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterLogDatoPersonaUpdated(logdatopersona);

            return logdatopersona;
        }

        partial void OnLogDatoPersonaDeleted(Reincarapp.Models.reincardb.LogDatoPersona item);
        partial void OnAfterLogDatoPersonaDeleted(Reincarapp.Models.reincardb.LogDatoPersona item);

        public async Task<Reincarapp.Models.reincardb.LogDatoPersona> DeleteLogDatoPersona(long idlogdatopersona)
        {
            var itemToDelete = Context.LogDatoPersona
                              .Where(i => i.id_log_dato_persona == idlogdatopersona)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnLogDatoPersonaDeleted(itemToDelete);


            Context.LogDatoPersona.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterLogDatoPersonaDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportLogappToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/logapp/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/logapp/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportLogappToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/logapp/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/logapp/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnLogappRead(ref IQueryable<Reincarapp.Models.reincardb.Logapp> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Logapp>> GetLogapp(Query query = null)
        {
            var items = Context.Logapp.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnLogappRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnLogappGet(Reincarapp.Models.reincardb.Logapp item);
        partial void OnGetLogappByIdLogApp(ref IQueryable<Reincarapp.Models.reincardb.Logapp> items);


        public async Task<Reincarapp.Models.reincardb.Logapp> GetLogappByIdLogApp(long idlogapp)
        {
            var items = Context.Logapp
                              .AsNoTracking()
                              .Where(i => i.IdLogApp == idlogapp);

 
            OnGetLogappByIdLogApp(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnLogappGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnLogappCreated(Reincarapp.Models.reincardb.Logapp item);
        partial void OnAfterLogappCreated(Reincarapp.Models.reincardb.Logapp item);

        public async Task<Reincarapp.Models.reincardb.Logapp> CreateLogapp(Reincarapp.Models.reincardb.Logapp logapp)
        {
            OnLogappCreated(logapp);

            var existingItem = Context.Logapp
                              .Where(i => i.IdLogApp == logapp.IdLogApp)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Logapp.Add(logapp);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(logapp).State = EntityState.Detached;
                throw;
            }

            OnAfterLogappCreated(logapp);

            return logapp;
        }

        public async Task<Reincarapp.Models.reincardb.Logapp> CancelLogappChanges(Reincarapp.Models.reincardb.Logapp item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnLogappUpdated(Reincarapp.Models.reincardb.Logapp item);
        partial void OnAfterLogappUpdated(Reincarapp.Models.reincardb.Logapp item);

        public async Task<Reincarapp.Models.reincardb.Logapp> UpdateLogapp(long idlogapp, Reincarapp.Models.reincardb.Logapp logapp)
        {
            OnLogappUpdated(logapp);

            var itemToUpdate = Context.Logapp
                              .Where(i => i.IdLogApp == logapp.IdLogApp)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(logapp);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterLogappUpdated(logapp);

            return logapp;
        }

        partial void OnLogappDeleted(Reincarapp.Models.reincardb.Logapp item);
        partial void OnAfterLogappDeleted(Reincarapp.Models.reincardb.Logapp item);

        public async Task<Reincarapp.Models.reincardb.Logapp> DeleteLogapp(long idlogapp)
        {
            var itemToDelete = Context.Logapp
                              .Where(i => i.IdLogApp == idlogapp)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnLogappDeleted(itemToDelete);


            Context.Logapp.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterLogappDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportMCitaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/mcita/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/mcita/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportMCitaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/mcita/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/mcita/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnMCitaRead(ref IQueryable<Reincarapp.Models.reincardb.MCita> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.MCita>> GetMCita(Query query = null)
        {
            var items = Context.MCita.AsQueryable();

            items = items.Include(i => i.MEspecialidad);
            items = items.Include(i => i.MEstadoCita);
            items = items.Include(i => i.MMedico);
            items = items.Include(i => i.Persona);
            items = items.Include(i => i.MSede);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnMCitaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnMCitaGet(Reincarapp.Models.reincardb.MCita item);
        partial void OnGetMCitaById(ref IQueryable<Reincarapp.Models.reincardb.MCita> items);


        public async Task<Reincarapp.Models.reincardb.MCita> GetMCitaById(long id)
        {
            var items = Context.MCita
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.MEspecialidad);
            items = items.Include(i => i.MEstadoCita);
            items = items.Include(i => i.MMedico);
            items = items.Include(i => i.Persona);
            items = items.Include(i => i.MSede);
 
            OnGetMCitaById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnMCitaGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnMCitaCreated(Reincarapp.Models.reincardb.MCita item);
        partial void OnAfterMCitaCreated(Reincarapp.Models.reincardb.MCita item);

        public async Task<Reincarapp.Models.reincardb.MCita> CreateMCita(Reincarapp.Models.reincardb.MCita mcita)
        {
            OnMCitaCreated(mcita);

            var existingItem = Context.MCita
                              .Where(i => i.Id == mcita.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.MCita.Add(mcita);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(mcita).State = EntityState.Detached;
                throw;
            }

            OnAfterMCitaCreated(mcita);

            return mcita;
        }

        public async Task<Reincarapp.Models.reincardb.MCita> CancelMCitaChanges(Reincarapp.Models.reincardb.MCita item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnMCitaUpdated(Reincarapp.Models.reincardb.MCita item);
        partial void OnAfterMCitaUpdated(Reincarapp.Models.reincardb.MCita item);

        public async Task<Reincarapp.Models.reincardb.MCita> UpdateMCita(long id, Reincarapp.Models.reincardb.MCita mcita)
        {
            OnMCitaUpdated(mcita);

            var itemToUpdate = Context.MCita
                              .Where(i => i.Id == mcita.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(mcita);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterMCitaUpdated(mcita);

            return mcita;
        }

        partial void OnMCitaDeleted(Reincarapp.Models.reincardb.MCita item);
        partial void OnAfterMCitaDeleted(Reincarapp.Models.reincardb.MCita item);

        public async Task<Reincarapp.Models.reincardb.MCita> DeleteMCita(long id)
        {
            var itemToDelete = Context.MCita
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnMCitaDeleted(itemToDelete);


            Context.MCita.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterMCitaDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportMEspecialidadToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/mespecialidad/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/mespecialidad/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportMEspecialidadToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/mespecialidad/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/mespecialidad/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnMEspecialidadRead(ref IQueryable<Reincarapp.Models.reincardb.MEspecialidad> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.MEspecialidad>> GetMEspecialidad(Query query = null)
        {
            var items = Context.MEspecialidad.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnMEspecialidadRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnMEspecialidadGet(Reincarapp.Models.reincardb.MEspecialidad item);
        partial void OnGetMEspecialidadById(ref IQueryable<Reincarapp.Models.reincardb.MEspecialidad> items);


        public async Task<Reincarapp.Models.reincardb.MEspecialidad> GetMEspecialidadById(long id)
        {
            var items = Context.MEspecialidad
                              .AsNoTracking()
                              .Where(i => i.Id == id);

 
            OnGetMEspecialidadById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnMEspecialidadGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnMEspecialidadCreated(Reincarapp.Models.reincardb.MEspecialidad item);
        partial void OnAfterMEspecialidadCreated(Reincarapp.Models.reincardb.MEspecialidad item);

        public async Task<Reincarapp.Models.reincardb.MEspecialidad> CreateMEspecialidad(Reincarapp.Models.reincardb.MEspecialidad mespecialidad)
        {
            OnMEspecialidadCreated(mespecialidad);

            var existingItem = Context.MEspecialidad
                              .Where(i => i.Id == mespecialidad.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.MEspecialidad.Add(mespecialidad);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(mespecialidad).State = EntityState.Detached;
                throw;
            }

            OnAfterMEspecialidadCreated(mespecialidad);

            return mespecialidad;
        }

        public async Task<Reincarapp.Models.reincardb.MEspecialidad> CancelMEspecialidadChanges(Reincarapp.Models.reincardb.MEspecialidad item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnMEspecialidadUpdated(Reincarapp.Models.reincardb.MEspecialidad item);
        partial void OnAfterMEspecialidadUpdated(Reincarapp.Models.reincardb.MEspecialidad item);

        public async Task<Reincarapp.Models.reincardb.MEspecialidad> UpdateMEspecialidad(long id, Reincarapp.Models.reincardb.MEspecialidad mespecialidad)
        {
            OnMEspecialidadUpdated(mespecialidad);

            var itemToUpdate = Context.MEspecialidad
                              .Where(i => i.Id == mespecialidad.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(mespecialidad);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterMEspecialidadUpdated(mespecialidad);

            return mespecialidad;
        }

        partial void OnMEspecialidadDeleted(Reincarapp.Models.reincardb.MEspecialidad item);
        partial void OnAfterMEspecialidadDeleted(Reincarapp.Models.reincardb.MEspecialidad item);

        public async Task<Reincarapp.Models.reincardb.MEspecialidad> DeleteMEspecialidad(long id)
        {
            var itemToDelete = Context.MEspecialidad
                              .Where(i => i.Id == id)
                              .Include(i => i.MCita)
                              .Include(i => i.MEspecialidadMedico)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnMEspecialidadDeleted(itemToDelete);


            Context.MEspecialidad.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterMEspecialidadDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportMEspecialidadMedicoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/mespecialidadmedico/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/mespecialidadmedico/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportMEspecialidadMedicoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/mespecialidadmedico/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/mespecialidadmedico/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnMEspecialidadMedicoRead(ref IQueryable<Reincarapp.Models.reincardb.MEspecialidadMedico> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.MEspecialidadMedico>> GetMEspecialidadMedico(Query query = null)
        {
            var items = Context.MEspecialidadMedico.AsQueryable();

            items = items.Include(i => i.MEspecialidad);
            items = items.Include(i => i.MMedico);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnMEspecialidadMedicoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnMEspecialidadMedicoGet(Reincarapp.Models.reincardb.MEspecialidadMedico item);
        partial void OnGetMEspecialidadMedicoById(ref IQueryable<Reincarapp.Models.reincardb.MEspecialidadMedico> items);


        public async Task<Reincarapp.Models.reincardb.MEspecialidadMedico> GetMEspecialidadMedicoById(long id)
        {
            var items = Context.MEspecialidadMedico
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.MEspecialidad);
            items = items.Include(i => i.MMedico);
 
            OnGetMEspecialidadMedicoById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnMEspecialidadMedicoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnMEspecialidadMedicoCreated(Reincarapp.Models.reincardb.MEspecialidadMedico item);
        partial void OnAfterMEspecialidadMedicoCreated(Reincarapp.Models.reincardb.MEspecialidadMedico item);

        public async Task<Reincarapp.Models.reincardb.MEspecialidadMedico> CreateMEspecialidadMedico(Reincarapp.Models.reincardb.MEspecialidadMedico mespecialidadmedico)
        {
            OnMEspecialidadMedicoCreated(mespecialidadmedico);

            var existingItem = Context.MEspecialidadMedico
                              .Where(i => i.Id == mespecialidadmedico.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.MEspecialidadMedico.Add(mespecialidadmedico);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(mespecialidadmedico).State = EntityState.Detached;
                throw;
            }

            OnAfterMEspecialidadMedicoCreated(mespecialidadmedico);

            return mespecialidadmedico;
        }

        public async Task<Reincarapp.Models.reincardb.MEspecialidadMedico> CancelMEspecialidadMedicoChanges(Reincarapp.Models.reincardb.MEspecialidadMedico item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnMEspecialidadMedicoUpdated(Reincarapp.Models.reincardb.MEspecialidadMedico item);
        partial void OnAfterMEspecialidadMedicoUpdated(Reincarapp.Models.reincardb.MEspecialidadMedico item);

        public async Task<Reincarapp.Models.reincardb.MEspecialidadMedico> UpdateMEspecialidadMedico(long id, Reincarapp.Models.reincardb.MEspecialidadMedico mespecialidadmedico)
        {
            OnMEspecialidadMedicoUpdated(mespecialidadmedico);

            var itemToUpdate = Context.MEspecialidadMedico
                              .Where(i => i.Id == mespecialidadmedico.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(mespecialidadmedico);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterMEspecialidadMedicoUpdated(mespecialidadmedico);

            return mespecialidadmedico;
        }

        partial void OnMEspecialidadMedicoDeleted(Reincarapp.Models.reincardb.MEspecialidadMedico item);
        partial void OnAfterMEspecialidadMedicoDeleted(Reincarapp.Models.reincardb.MEspecialidadMedico item);

        public async Task<Reincarapp.Models.reincardb.MEspecialidadMedico> DeleteMEspecialidadMedico(long id)
        {
            var itemToDelete = Context.MEspecialidadMedico
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnMEspecialidadMedicoDeleted(itemToDelete);


            Context.MEspecialidadMedico.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterMEspecialidadMedicoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportMEstadoCitaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/mestadocita/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/mestadocita/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportMEstadoCitaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/mestadocita/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/mestadocita/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnMEstadoCitaRead(ref IQueryable<Reincarapp.Models.reincardb.MEstadoCita> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.MEstadoCita>> GetMEstadoCita(Query query = null)
        {
            var items = Context.MEstadoCita.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnMEstadoCitaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnMEstadoCitaGet(Reincarapp.Models.reincardb.MEstadoCita item);
        partial void OnGetMEstadoCitaById(ref IQueryable<Reincarapp.Models.reincardb.MEstadoCita> items);


        public async Task<Reincarapp.Models.reincardb.MEstadoCita> GetMEstadoCitaById(long id)
        {
            var items = Context.MEstadoCita
                              .AsNoTracking()
                              .Where(i => i.Id == id);

 
            OnGetMEstadoCitaById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnMEstadoCitaGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnMEstadoCitaCreated(Reincarapp.Models.reincardb.MEstadoCita item);
        partial void OnAfterMEstadoCitaCreated(Reincarapp.Models.reincardb.MEstadoCita item);

        public async Task<Reincarapp.Models.reincardb.MEstadoCita> CreateMEstadoCita(Reincarapp.Models.reincardb.MEstadoCita mestadocita)
        {
            OnMEstadoCitaCreated(mestadocita);

            var existingItem = Context.MEstadoCita
                              .Where(i => i.Id == mestadocita.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.MEstadoCita.Add(mestadocita);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(mestadocita).State = EntityState.Detached;
                throw;
            }

            OnAfterMEstadoCitaCreated(mestadocita);

            return mestadocita;
        }

        public async Task<Reincarapp.Models.reincardb.MEstadoCita> CancelMEstadoCitaChanges(Reincarapp.Models.reincardb.MEstadoCita item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnMEstadoCitaUpdated(Reincarapp.Models.reincardb.MEstadoCita item);
        partial void OnAfterMEstadoCitaUpdated(Reincarapp.Models.reincardb.MEstadoCita item);

        public async Task<Reincarapp.Models.reincardb.MEstadoCita> UpdateMEstadoCita(long id, Reincarapp.Models.reincardb.MEstadoCita mestadocita)
        {
            OnMEstadoCitaUpdated(mestadocita);

            var itemToUpdate = Context.MEstadoCita
                              .Where(i => i.Id == mestadocita.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(mestadocita);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterMEstadoCitaUpdated(mestadocita);

            return mestadocita;
        }

        partial void OnMEstadoCitaDeleted(Reincarapp.Models.reincardb.MEstadoCita item);
        partial void OnAfterMEstadoCitaDeleted(Reincarapp.Models.reincardb.MEstadoCita item);

        public async Task<Reincarapp.Models.reincardb.MEstadoCita> DeleteMEstadoCita(long id)
        {
            var itemToDelete = Context.MEstadoCita
                              .Where(i => i.Id == id)
                              .Include(i => i.MCita)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnMEstadoCitaDeleted(itemToDelete);


            Context.MEstadoCita.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterMEstadoCitaDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportMMedicoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/mmedico/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/mmedico/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportMMedicoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/mmedico/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/mmedico/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnMMedicoRead(ref IQueryable<Reincarapp.Models.reincardb.MMedico> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.MMedico>> GetMMedico(Query query = null)
        {
            var items = Context.MMedico.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnMMedicoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnMMedicoGet(Reincarapp.Models.reincardb.MMedico item);
        partial void OnGetMMedicoById(ref IQueryable<Reincarapp.Models.reincardb.MMedico> items);


        public async Task<Reincarapp.Models.reincardb.MMedico> GetMMedicoById(long id)
        {
            var items = Context.MMedico
                              .AsNoTracking()
                              .Where(i => i.Id == id);

 
            OnGetMMedicoById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnMMedicoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnMMedicoCreated(Reincarapp.Models.reincardb.MMedico item);
        partial void OnAfterMMedicoCreated(Reincarapp.Models.reincardb.MMedico item);

        public async Task<Reincarapp.Models.reincardb.MMedico> CreateMMedico(Reincarapp.Models.reincardb.MMedico mmedico)
        {
            OnMMedicoCreated(mmedico);

            var existingItem = Context.MMedico
                              .Where(i => i.Id == mmedico.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.MMedico.Add(mmedico);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(mmedico).State = EntityState.Detached;
                throw;
            }

            OnAfterMMedicoCreated(mmedico);

            return mmedico;
        }

        public async Task<Reincarapp.Models.reincardb.MMedico> CancelMMedicoChanges(Reincarapp.Models.reincardb.MMedico item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnMMedicoUpdated(Reincarapp.Models.reincardb.MMedico item);
        partial void OnAfterMMedicoUpdated(Reincarapp.Models.reincardb.MMedico item);

        public async Task<Reincarapp.Models.reincardb.MMedico> UpdateMMedico(long id, Reincarapp.Models.reincardb.MMedico mmedico)
        {
            OnMMedicoUpdated(mmedico);

            var itemToUpdate = Context.MMedico
                              .Where(i => i.Id == mmedico.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(mmedico);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterMMedicoUpdated(mmedico);

            return mmedico;
        }

        partial void OnMMedicoDeleted(Reincarapp.Models.reincardb.MMedico item);
        partial void OnAfterMMedicoDeleted(Reincarapp.Models.reincardb.MMedico item);

        public async Task<Reincarapp.Models.reincardb.MMedico> DeleteMMedico(long id)
        {
            var itemToDelete = Context.MMedico
                              .Where(i => i.Id == id)
                              .Include(i => i.MCita)
                              .Include(i => i.MEspecialidadMedico)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnMMedicoDeleted(itemToDelete);


            Context.MMedico.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterMMedicoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportMSedeToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/msede/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/msede/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportMSedeToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/msede/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/msede/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnMSedeRead(ref IQueryable<Reincarapp.Models.reincardb.MSede> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.MSede>> GetMSede(Query query = null)
        {
            var items = Context.MSede.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnMSedeRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnMSedeGet(Reincarapp.Models.reincardb.MSede item);
        partial void OnGetMSedeById(ref IQueryable<Reincarapp.Models.reincardb.MSede> items);


        public async Task<Reincarapp.Models.reincardb.MSede> GetMSedeById(long id)
        {
            var items = Context.MSede
                              .AsNoTracking()
                              .Where(i => i.Id == id);

 
            OnGetMSedeById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnMSedeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnMSedeCreated(Reincarapp.Models.reincardb.MSede item);
        partial void OnAfterMSedeCreated(Reincarapp.Models.reincardb.MSede item);

        public async Task<Reincarapp.Models.reincardb.MSede> CreateMSede(Reincarapp.Models.reincardb.MSede msede)
        {
            OnMSedeCreated(msede);

            var existingItem = Context.MSede
                              .Where(i => i.Id == msede.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.MSede.Add(msede);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(msede).State = EntityState.Detached;
                throw;
            }

            OnAfterMSedeCreated(msede);

            return msede;
        }

        public async Task<Reincarapp.Models.reincardb.MSede> CancelMSedeChanges(Reincarapp.Models.reincardb.MSede item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnMSedeUpdated(Reincarapp.Models.reincardb.MSede item);
        partial void OnAfterMSedeUpdated(Reincarapp.Models.reincardb.MSede item);

        public async Task<Reincarapp.Models.reincardb.MSede> UpdateMSede(long id, Reincarapp.Models.reincardb.MSede msede)
        {
            OnMSedeUpdated(msede);

            var itemToUpdate = Context.MSede
                              .Where(i => i.Id == msede.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(msede);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterMSedeUpdated(msede);

            return msede;
        }

        partial void OnMSedeDeleted(Reincarapp.Models.reincardb.MSede item);
        partial void OnAfterMSedeDeleted(Reincarapp.Models.reincardb.MSede item);

        public async Task<Reincarapp.Models.reincardb.MSede> DeleteMSede(long id)
        {
            var itemToDelete = Context.MSede
                              .Where(i => i.Id == id)
                              .Include(i => i.MCita)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnMSedeDeleted(itemToDelete);


            Context.MSede.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterMSedeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportMafToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/maf/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/maf/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportMafToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/maf/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/maf/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnMafRead(ref IQueryable<Reincarapp.Models.reincardb.Maf> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Maf>> GetMaf(Query query = null)
        {
            var items = Context.Maf.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnMafRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnMafGet(Reincarapp.Models.reincardb.Maf item);
        partial void OnGetMafByIdMaf(ref IQueryable<Reincarapp.Models.reincardb.Maf> items);


        public async Task<Reincarapp.Models.reincardb.Maf> GetMafByIdMaf(long idmaf)
        {
            var items = Context.Maf
                              .AsNoTracking()
                              .Where(i => i.id_maf == idmaf);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetMafByIdMaf(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnMafGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnMafCreated(Reincarapp.Models.reincardb.Maf item);
        partial void OnAfterMafCreated(Reincarapp.Models.reincardb.Maf item);

        public async Task<Reincarapp.Models.reincardb.Maf> CreateMaf(Reincarapp.Models.reincardb.Maf maf)
        {
            OnMafCreated(maf);

            var existingItem = Context.Maf
                              .Where(i => i.id_maf == maf.id_maf)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Maf.Add(maf);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(maf).State = EntityState.Detached;
                throw;
            }

            OnAfterMafCreated(maf);

            return maf;
        }

        public async Task<Reincarapp.Models.reincardb.Maf> CancelMafChanges(Reincarapp.Models.reincardb.Maf item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnMafUpdated(Reincarapp.Models.reincardb.Maf item);
        partial void OnAfterMafUpdated(Reincarapp.Models.reincardb.Maf item);

        public async Task<Reincarapp.Models.reincardb.Maf> UpdateMaf(long idmaf, Reincarapp.Models.reincardb.Maf maf)
        {
            OnMafUpdated(maf);

            var itemToUpdate = Context.Maf
                              .Where(i => i.id_maf == maf.id_maf)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(maf);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterMafUpdated(maf);

            return maf;
        }

        partial void OnMafDeleted(Reincarapp.Models.reincardb.Maf item);
        partial void OnAfterMafDeleted(Reincarapp.Models.reincardb.Maf item);

        public async Task<Reincarapp.Models.reincardb.Maf> DeleteMaf(long idmaf)
        {
            var itemToDelete = Context.Maf
                              .Where(i => i.id_maf == idmaf)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnMafDeleted(itemToDelete);


            Context.Maf.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterMafDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportMencoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/menco/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/menco/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportMencoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/menco/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/menco/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnMencoRead(ref IQueryable<Reincarapp.Models.reincardb.Menco> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Menco>> GetMenco(Query query = null)
        {
            var items = Context.Menco.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnMencoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnMencoGet(Reincarapp.Models.reincardb.Menco item);
        partial void OnGetMencoByIdMenco(ref IQueryable<Reincarapp.Models.reincardb.Menco> items);


        public async Task<Reincarapp.Models.reincardb.Menco> GetMencoByIdMenco(long idmenco)
        {
            var items = Context.Menco
                              .AsNoTracking()
                              .Where(i => i.id_menco == idmenco);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetMencoByIdMenco(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnMencoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnMencoCreated(Reincarapp.Models.reincardb.Menco item);
        partial void OnAfterMencoCreated(Reincarapp.Models.reincardb.Menco item);

        public async Task<Reincarapp.Models.reincardb.Menco> CreateMenco(Reincarapp.Models.reincardb.Menco menco)
        {
            OnMencoCreated(menco);

            var existingItem = Context.Menco
                              .Where(i => i.id_menco == menco.id_menco)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Menco.Add(menco);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(menco).State = EntityState.Detached;
                throw;
            }

            OnAfterMencoCreated(menco);

            return menco;
        }

        public async Task<Reincarapp.Models.reincardb.Menco> CancelMencoChanges(Reincarapp.Models.reincardb.Menco item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnMencoUpdated(Reincarapp.Models.reincardb.Menco item);
        partial void OnAfterMencoUpdated(Reincarapp.Models.reincardb.Menco item);

        public async Task<Reincarapp.Models.reincardb.Menco> UpdateMenco(long idmenco, Reincarapp.Models.reincardb.Menco menco)
        {
            OnMencoUpdated(menco);

            var itemToUpdate = Context.Menco
                              .Where(i => i.id_menco == menco.id_menco)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(menco);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterMencoUpdated(menco);

            return menco;
        }

        partial void OnMencoDeleted(Reincarapp.Models.reincardb.Menco item);
        partial void OnAfterMencoDeleted(Reincarapp.Models.reincardb.Menco item);

        public async Task<Reincarapp.Models.reincardb.Menco> DeleteMenco(long idmenco)
        {
            var itemToDelete = Context.Menco
                              .Where(i => i.id_menco == idmenco)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnMencoDeleted(itemToDelete);


            Context.Menco.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterMencoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportMunicipioToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/municipio/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/municipio/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportMunicipioToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/municipio/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/municipio/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnMunicipioRead(ref IQueryable<Reincarapp.Models.reincardb.Municipio> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Municipio>> GetMunicipio(Query query = null)
        {
            var items = Context.Municipio.AsQueryable();

            items = items.Include(i => i.Departamento);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnMunicipioRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnMunicipioGet(Reincarapp.Models.reincardb.Municipio item);
        partial void OnGetMunicipioByIdMunicipio(ref IQueryable<Reincarapp.Models.reincardb.Municipio> items);


        public async Task<Reincarapp.Models.reincardb.Municipio> GetMunicipioByIdMunicipio(long idmunicipio)
        {
            var items = Context.Municipio
                              .AsNoTracking()
                              .Where(i => i.Id_Municipio == idmunicipio);

            items = items.Include(i => i.Departamento);
 
            OnGetMunicipioByIdMunicipio(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnMunicipioGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnMunicipioCreated(Reincarapp.Models.reincardb.Municipio item);
        partial void OnAfterMunicipioCreated(Reincarapp.Models.reincardb.Municipio item);

        public async Task<Reincarapp.Models.reincardb.Municipio> CreateMunicipio(Reincarapp.Models.reincardb.Municipio municipio)
        {
            OnMunicipioCreated(municipio);

            var existingItem = Context.Municipio
                              .Where(i => i.Id_Municipio == municipio.Id_Municipio)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Municipio.Add(municipio);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(municipio).State = EntityState.Detached;
                throw;
            }

            OnAfterMunicipioCreated(municipio);

            return municipio;
        }

        public async Task<Reincarapp.Models.reincardb.Municipio> CancelMunicipioChanges(Reincarapp.Models.reincardb.Municipio item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnMunicipioUpdated(Reincarapp.Models.reincardb.Municipio item);
        partial void OnAfterMunicipioUpdated(Reincarapp.Models.reincardb.Municipio item);

        public async Task<Reincarapp.Models.reincardb.Municipio> UpdateMunicipio(long idmunicipio, Reincarapp.Models.reincardb.Municipio municipio)
        {
            OnMunicipioUpdated(municipio);

            var itemToUpdate = Context.Municipio
                              .Where(i => i.Id_Municipio == municipio.Id_Municipio)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(municipio);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterMunicipioUpdated(municipio);

            return municipio;
        }

        partial void OnMunicipioDeleted(Reincarapp.Models.reincardb.Municipio item);
        partial void OnAfterMunicipioDeleted(Reincarapp.Models.reincardb.Municipio item);

        public async Task<Reincarapp.Models.reincardb.Municipio> DeleteMunicipio(long idmunicipio)
        {
            var itemToDelete = Context.Municipio
                              .Where(i => i.Id_Municipio == idmunicipio)
                              .Include(i => i.DatoPersona)
                              .Include(i => i.Rediferido)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnMunicipioDeleted(itemToDelete);


            Context.Municipio.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterMunicipioDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportParametroToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/parametro/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/parametro/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportParametroToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/parametro/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/parametro/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnParametroRead(ref IQueryable<Reincarapp.Models.reincardb.Parametro> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Parametro>> GetParametro(Query query = null)
        {
            var items = Context.Parametro.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnParametroRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnParametroGet(Reincarapp.Models.reincardb.Parametro item);
        partial void OnGetParametroByIdParametro(ref IQueryable<Reincarapp.Models.reincardb.Parametro> items);


        public async Task<Reincarapp.Models.reincardb.Parametro> GetParametroByIdParametro(long idparametro)
        {
            var items = Context.Parametro
                              .AsNoTracking()
                              .Where(i => i.Id_Parametro == idparametro);

 
            OnGetParametroByIdParametro(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnParametroGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnParametroCreated(Reincarapp.Models.reincardb.Parametro item);
        partial void OnAfterParametroCreated(Reincarapp.Models.reincardb.Parametro item);

        public async Task<Reincarapp.Models.reincardb.Parametro> CreateParametro(Reincarapp.Models.reincardb.Parametro parametro)
        {
            OnParametroCreated(parametro);

            var existingItem = Context.Parametro
                              .Where(i => i.Id_Parametro == parametro.Id_Parametro)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Parametro.Add(parametro);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(parametro).State = EntityState.Detached;
                throw;
            }

            OnAfterParametroCreated(parametro);

            return parametro;
        }

        public async Task<Reincarapp.Models.reincardb.Parametro> CancelParametroChanges(Reincarapp.Models.reincardb.Parametro item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnParametroUpdated(Reincarapp.Models.reincardb.Parametro item);
        partial void OnAfterParametroUpdated(Reincarapp.Models.reincardb.Parametro item);

        public async Task<Reincarapp.Models.reincardb.Parametro> UpdateParametro(long idparametro, Reincarapp.Models.reincardb.Parametro parametro)
        {
            OnParametroUpdated(parametro);

            var itemToUpdate = Context.Parametro
                              .Where(i => i.Id_Parametro == parametro.Id_Parametro)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(parametro);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterParametroUpdated(parametro);

            return parametro;
        }

        partial void OnParametroDeleted(Reincarapp.Models.reincardb.Parametro item);
        partial void OnAfterParametroDeleted(Reincarapp.Models.reincardb.Parametro item);

        public async Task<Reincarapp.Models.reincardb.Parametro> DeleteParametro(long idparametro)
        {
            var itemToDelete = Context.Parametro
                              .Where(i => i.Id_Parametro == idparametro)
                              .Include(i => i.ParametroValor)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnParametroDeleted(itemToDelete);


            Context.Parametro.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterParametroDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportParametroValorToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/parametrovalor/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/parametrovalor/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportParametroValorToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/parametrovalor/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/parametrovalor/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnParametroValorRead(ref IQueryable<Reincarapp.Models.reincardb.ParametroValor> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ParametroValor>> GetParametroValor(Query query = null)
        {
            var items = Context.ParametroValor.AsQueryable();

            items = items.Include(i => i.Parametro);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnParametroValorRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnParametroValorGet(Reincarapp.Models.reincardb.ParametroValor item);
        partial void OnGetParametroValorByIdParametroValor(ref IQueryable<Reincarapp.Models.reincardb.ParametroValor> items);


        public async Task<Reincarapp.Models.reincardb.ParametroValor> GetParametroValorByIdParametroValor(long idparametrovalor)
        {
            var items = Context.ParametroValor
                              .AsNoTracking()
                              .Where(i => i.Id_Parametro_Valor == idparametrovalor);

            items = items.Include(i => i.Parametro);
 
            OnGetParametroValorByIdParametroValor(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnParametroValorGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnParametroValorCreated(Reincarapp.Models.reincardb.ParametroValor item);
        partial void OnAfterParametroValorCreated(Reincarapp.Models.reincardb.ParametroValor item);

        public async Task<Reincarapp.Models.reincardb.ParametroValor> CreateParametroValor(Reincarapp.Models.reincardb.ParametroValor parametrovalor)
        {
            OnParametroValorCreated(parametrovalor);

            var existingItem = Context.ParametroValor
                              .Where(i => i.Id_Parametro_Valor == parametrovalor.Id_Parametro_Valor)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ParametroValor.Add(parametrovalor);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(parametrovalor).State = EntityState.Detached;
                throw;
            }

            OnAfterParametroValorCreated(parametrovalor);

            return parametrovalor;
        }

        public async Task<Reincarapp.Models.reincardb.ParametroValor> CancelParametroValorChanges(Reincarapp.Models.reincardb.ParametroValor item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnParametroValorUpdated(Reincarapp.Models.reincardb.ParametroValor item);
        partial void OnAfterParametroValorUpdated(Reincarapp.Models.reincardb.ParametroValor item);

        public async Task<Reincarapp.Models.reincardb.ParametroValor> UpdateParametroValor(long idparametrovalor, Reincarapp.Models.reincardb.ParametroValor parametrovalor)
        {
            OnParametroValorUpdated(parametrovalor);

            var itemToUpdate = Context.ParametroValor
                              .Where(i => i.Id_Parametro_Valor == parametrovalor.Id_Parametro_Valor)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(parametrovalor);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterParametroValorUpdated(parametrovalor);

            return parametrovalor;
        }

        partial void OnParametroValorDeleted(Reincarapp.Models.reincardb.ParametroValor item);
        partial void OnAfterParametroValorDeleted(Reincarapp.Models.reincardb.ParametroValor item);

        public async Task<Reincarapp.Models.reincardb.ParametroValor> DeleteParametroValor(long idparametrovalor)
        {
            var itemToDelete = Context.ParametroValor
                              .Where(i => i.Id_Parametro_Valor == idparametrovalor)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnParametroValorDeleted(itemToDelete);


            Context.ParametroValor.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterParametroValorDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPersonaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/persona/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/persona/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPersonaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/persona/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/persona/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPersonaRead(ref IQueryable<Reincarapp.Models.reincardb.Persona> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Persona>> GetPersona(Query query = null)
        {
            var items = Context.Persona.AsQueryable();

            items = items.Include(i => i.TipoDocumento);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnPersonaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPersonaGet(Reincarapp.Models.reincardb.Persona item);
        partial void OnGetPersonaByIdPersona(ref IQueryable<Reincarapp.Models.reincardb.Persona> items);


        public async Task<Reincarapp.Models.reincardb.Persona> GetPersonaByIdPersona(long idpersona)
        {
            var items = Context.Persona
                              .AsNoTracking()
                              .Where(i => i.Id_Persona == idpersona);

            items = items.Include(i => i.TipoDocumento);
 
            OnGetPersonaByIdPersona(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnPersonaGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPersonaCreated(Reincarapp.Models.reincardb.Persona item);
        partial void OnAfterPersonaCreated(Reincarapp.Models.reincardb.Persona item);

        public async Task<Reincarapp.Models.reincardb.Persona> CreatePersona(Reincarapp.Models.reincardb.Persona persona)
        {
            OnPersonaCreated(persona);

            var existingItem = Context.Persona
                              .Where(i => i.Id_Persona == persona.Id_Persona)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Persona.Add(persona);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(persona).State = EntityState.Detached;
                throw;
            }

            OnAfterPersonaCreated(persona);

            return persona;
        }

        public async Task<Reincarapp.Models.reincardb.Persona> CancelPersonaChanges(Reincarapp.Models.reincardb.Persona item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPersonaUpdated(Reincarapp.Models.reincardb.Persona item);
        partial void OnAfterPersonaUpdated(Reincarapp.Models.reincardb.Persona item);

        public async Task<Reincarapp.Models.reincardb.Persona> UpdatePersona(long idpersona, Reincarapp.Models.reincardb.Persona persona)
        {
            OnPersonaUpdated(persona);

            var itemToUpdate = Context.Persona
                              .Where(i => i.Id_Persona == persona.Id_Persona)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(persona);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPersonaUpdated(persona);

            return persona;
        }

        partial void OnPersonaDeleted(Reincarapp.Models.reincardb.Persona item);
        partial void OnAfterPersonaDeleted(Reincarapp.Models.reincardb.Persona item);

        public async Task<Reincarapp.Models.reincardb.Persona> DeletePersona(long idpersona)
        {
            var itemToDelete = Context.Persona
                              .Where(i => i.Id_Persona == idpersona)
                              .Include(i => i.AsignacionGestor)
                              .Include(i => i.ClienteDeuda)
                              .Include(i => i.DatoPersona)
                              .Include(i => i.MCita)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPersonaDeleted(itemToDelete);


            Context.Persona.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPersonaDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPromotoraToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/promotora/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/promotora/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPromotoraToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/promotora/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/promotora/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPromotoraRead(ref IQueryable<Reincarapp.Models.reincardb.Promotora> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Promotora>> GetPromotora(Query query = null)
        {
            var items = Context.Promotora.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnPromotoraRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPromotoraGet(Reincarapp.Models.reincardb.Promotora item);
        partial void OnGetPromotoraByIdPromotora(ref IQueryable<Reincarapp.Models.reincardb.Promotora> items);


        public async Task<Reincarapp.Models.reincardb.Promotora> GetPromotoraByIdPromotora(long idpromotora)
        {
            var items = Context.Promotora
                              .AsNoTracking()
                              .Where(i => i.id_promotora == idpromotora);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetPromotoraByIdPromotora(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnPromotoraGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPromotoraCreated(Reincarapp.Models.reincardb.Promotora item);
        partial void OnAfterPromotoraCreated(Reincarapp.Models.reincardb.Promotora item);

        public async Task<Reincarapp.Models.reincardb.Promotora> CreatePromotora(Reincarapp.Models.reincardb.Promotora promotora)
        {
            OnPromotoraCreated(promotora);

            var existingItem = Context.Promotora
                              .Where(i => i.id_promotora == promotora.id_promotora)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Promotora.Add(promotora);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(promotora).State = EntityState.Detached;
                throw;
            }

            OnAfterPromotoraCreated(promotora);

            return promotora;
        }

        public async Task<Reincarapp.Models.reincardb.Promotora> CancelPromotoraChanges(Reincarapp.Models.reincardb.Promotora item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPromotoraUpdated(Reincarapp.Models.reincardb.Promotora item);
        partial void OnAfterPromotoraUpdated(Reincarapp.Models.reincardb.Promotora item);

        public async Task<Reincarapp.Models.reincardb.Promotora> UpdatePromotora(long idpromotora, Reincarapp.Models.reincardb.Promotora promotora)
        {
            OnPromotoraUpdated(promotora);

            var itemToUpdate = Context.Promotora
                              .Where(i => i.id_promotora == promotora.id_promotora)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(promotora);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPromotoraUpdated(promotora);

            return promotora;
        }

        partial void OnPromotoraDeleted(Reincarapp.Models.reincardb.Promotora item);
        partial void OnAfterPromotoraDeleted(Reincarapp.Models.reincardb.Promotora item);

        public async Task<Reincarapp.Models.reincardb.Promotora> DeletePromotora(long idpromotora)
        {
            var itemToDelete = Context.Promotora
                              .Where(i => i.id_promotora == idpromotora)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPromotoraDeleted(itemToDelete);


            Context.Promotora.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPromotoraDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportRazontiempofueraToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/razontiempofuera/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/razontiempofuera/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportRazontiempofueraToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/razontiempofuera/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/razontiempofuera/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnRazontiempofueraRead(ref IQueryable<Reincarapp.Models.reincardb.Razontiempofuera> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Razontiempofuera>> GetRazontiempofuera(Query query = null)
        {
            var items = Context.Razontiempofuera.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnRazontiempofueraRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnRazontiempofueraGet(Reincarapp.Models.reincardb.Razontiempofuera item);
        partial void OnGetRazontiempofueraById(ref IQueryable<Reincarapp.Models.reincardb.Razontiempofuera> items);


        public async Task<Reincarapp.Models.reincardb.Razontiempofuera> GetRazontiempofueraById(long id)
        {
            var items = Context.Razontiempofuera
                              .AsNoTracking()
                              .Where(i => i.Id == id);

 
            OnGetRazontiempofueraById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnRazontiempofueraGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnRazontiempofueraCreated(Reincarapp.Models.reincardb.Razontiempofuera item);
        partial void OnAfterRazontiempofueraCreated(Reincarapp.Models.reincardb.Razontiempofuera item);

        public async Task<Reincarapp.Models.reincardb.Razontiempofuera> CreateRazontiempofuera(Reincarapp.Models.reincardb.Razontiempofuera razontiempofuera)
        {
            OnRazontiempofueraCreated(razontiempofuera);

            var existingItem = Context.Razontiempofuera
                              .Where(i => i.Id == razontiempofuera.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Razontiempofuera.Add(razontiempofuera);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(razontiempofuera).State = EntityState.Detached;
                throw;
            }

            OnAfterRazontiempofueraCreated(razontiempofuera);

            return razontiempofuera;
        }

        public async Task<Reincarapp.Models.reincardb.Razontiempofuera> CancelRazontiempofueraChanges(Reincarapp.Models.reincardb.Razontiempofuera item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnRazontiempofueraUpdated(Reincarapp.Models.reincardb.Razontiempofuera item);
        partial void OnAfterRazontiempofueraUpdated(Reincarapp.Models.reincardb.Razontiempofuera item);

        public async Task<Reincarapp.Models.reincardb.Razontiempofuera> UpdateRazontiempofuera(long id, Reincarapp.Models.reincardb.Razontiempofuera razontiempofuera)
        {
            OnRazontiempofueraUpdated(razontiempofuera);

            var itemToUpdate = Context.Razontiempofuera
                              .Where(i => i.Id == razontiempofuera.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(razontiempofuera);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterRazontiempofueraUpdated(razontiempofuera);

            return razontiempofuera;
        }

        partial void OnRazontiempofueraDeleted(Reincarapp.Models.reincardb.Razontiempofuera item);
        partial void OnAfterRazontiempofueraDeleted(Reincarapp.Models.reincardb.Razontiempofuera item);

        public async Task<Reincarapp.Models.reincardb.Razontiempofuera> DeleteRazontiempofuera(long id)
        {
            var itemToDelete = Context.Razontiempofuera
                              .Where(i => i.Id == id)
                              .Include(i => i.Tiempofuera)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnRazontiempofueraDeleted(itemToDelete);


            Context.Razontiempofuera.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterRazontiempofueraDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportRediferidoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/rediferido/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/rediferido/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportRediferidoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/rediferido/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/rediferido/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnRediferidoRead(ref IQueryable<Reincarapp.Models.reincardb.Rediferido> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Rediferido>> GetRediferido(Query query = null)
        {
            var items = Context.Rediferido.AsQueryable();

            items = items.Include(i => i.Municipio);
            items = items.Include(i => i.ClienteDeuda);
            items = items.Include(i => i.Credivalores);
            items = items.Include(i => i.Franja);
            items = items.Include(i => i.TipoRediferido);
            items = items.Include(i => i.Usuario);
            items = items.Include(i => i.Tasa1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnRediferidoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnRediferidoGet(Reincarapp.Models.reincardb.Rediferido item);
        partial void OnGetRediferidoByIdRediferido(ref IQueryable<Reincarapp.Models.reincardb.Rediferido> items);


        public async Task<Reincarapp.Models.reincardb.Rediferido> GetRediferidoByIdRediferido(long idrediferido)
        {
            var items = Context.Rediferido
                              .AsNoTracking()
                              .Where(i => i.id_rediferido == idrediferido);

            items = items.Include(i => i.Municipio);
            items = items.Include(i => i.ClienteDeuda);
            items = items.Include(i => i.Credivalores);
            items = items.Include(i => i.Franja);
            items = items.Include(i => i.TipoRediferido);
            items = items.Include(i => i.Usuario);
            items = items.Include(i => i.Tasa1);
 
            OnGetRediferidoByIdRediferido(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnRediferidoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnRediferidoCreated(Reincarapp.Models.reincardb.Rediferido item);
        partial void OnAfterRediferidoCreated(Reincarapp.Models.reincardb.Rediferido item);

        public async Task<Reincarapp.Models.reincardb.Rediferido> CreateRediferido(Reincarapp.Models.reincardb.Rediferido rediferido)
        {
            OnRediferidoCreated(rediferido);

            var existingItem = Context.Rediferido
                              .Where(i => i.id_rediferido == rediferido.id_rediferido)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Rediferido.Add(rediferido);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(rediferido).State = EntityState.Detached;
                throw;
            }

            OnAfterRediferidoCreated(rediferido);

            return rediferido;
        }

        public async Task<Reincarapp.Models.reincardb.Rediferido> CancelRediferidoChanges(Reincarapp.Models.reincardb.Rediferido item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnRediferidoUpdated(Reincarapp.Models.reincardb.Rediferido item);
        partial void OnAfterRediferidoUpdated(Reincarapp.Models.reincardb.Rediferido item);

        public async Task<Reincarapp.Models.reincardb.Rediferido> UpdateRediferido(long idrediferido, Reincarapp.Models.reincardb.Rediferido rediferido)
        {
            OnRediferidoUpdated(rediferido);

            var itemToUpdate = Context.Rediferido
                              .Where(i => i.id_rediferido == rediferido.id_rediferido)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(rediferido);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterRediferidoUpdated(rediferido);

            return rediferido;
        }

        partial void OnRediferidoDeleted(Reincarapp.Models.reincardb.Rediferido item);
        partial void OnAfterRediferidoDeleted(Reincarapp.Models.reincardb.Rediferido item);

        public async Task<Reincarapp.Models.reincardb.Rediferido> DeleteRediferido(long idrediferido)
        {
            var itemToDelete = Context.Rediferido
                              .Where(i => i.id_rediferido == idrediferido)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnRediferidoDeleted(itemToDelete);


            Context.Rediferido.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterRediferidoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportResEveToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/reseve/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/reseve/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportResEveToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/reseve/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/reseve/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnResEveRead(ref IQueryable<Reincarapp.Models.reincardb.ResEve> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ResEve>> GetResEve(Query query = null)
        {
            var items = Context.ResEve.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnResEveRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportResEveC3ToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/resevec3/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/resevec3/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportResEveC3ToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/resevec3/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/resevec3/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnResEveC3Read(ref IQueryable<Reincarapp.Models.reincardb.ResEveC3> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ResEveC3>> GetResEveC3(Query query = null)
        {
            var items = Context.ResEveC3.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnResEveC3Read(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportResultadoEventoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/resultadoevento/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/resultadoevento/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportResultadoEventoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/resultadoevento/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/resultadoevento/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnResultadoEventoRead(ref IQueryable<Reincarapp.Models.reincardb.ResultadoEvento> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ResultadoEvento>> GetResultadoEvento(Query query = null)
        {
            var items = Context.ResultadoEvento.AsQueryable();

            items = items.Include(i => i.Cliente);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnResultadoEventoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnResultadoEventoGet(Reincarapp.Models.reincardb.ResultadoEvento item);
        partial void OnGetResultadoEventoByIdResultadoEvento(ref IQueryable<Reincarapp.Models.reincardb.ResultadoEvento> items);


        public async Task<Reincarapp.Models.reincardb.ResultadoEvento> GetResultadoEventoByIdResultadoEvento(long idresultadoevento)
        {
            var items = Context.ResultadoEvento
                              .AsNoTracking()
                              .Where(i => i.Id_Resultado_Evento == idresultadoevento);

            items = items.Include(i => i.Cliente);
 
            OnGetResultadoEventoByIdResultadoEvento(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnResultadoEventoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnResultadoEventoCreated(Reincarapp.Models.reincardb.ResultadoEvento item);
        partial void OnAfterResultadoEventoCreated(Reincarapp.Models.reincardb.ResultadoEvento item);

        public async Task<Reincarapp.Models.reincardb.ResultadoEvento> CreateResultadoEvento(Reincarapp.Models.reincardb.ResultadoEvento resultadoevento)
        {
            OnResultadoEventoCreated(resultadoevento);

            var existingItem = Context.ResultadoEvento
                              .Where(i => i.Id_Resultado_Evento == resultadoevento.Id_Resultado_Evento)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ResultadoEvento.Add(resultadoevento);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(resultadoevento).State = EntityState.Detached;
                throw;
            }

            OnAfterResultadoEventoCreated(resultadoevento);

            return resultadoevento;
        }

        public async Task<Reincarapp.Models.reincardb.ResultadoEvento> CancelResultadoEventoChanges(Reincarapp.Models.reincardb.ResultadoEvento item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnResultadoEventoUpdated(Reincarapp.Models.reincardb.ResultadoEvento item);
        partial void OnAfterResultadoEventoUpdated(Reincarapp.Models.reincardb.ResultadoEvento item);

        public async Task<Reincarapp.Models.reincardb.ResultadoEvento> UpdateResultadoEvento(long idresultadoevento, Reincarapp.Models.reincardb.ResultadoEvento resultadoevento)
        {
            OnResultadoEventoUpdated(resultadoevento);

            var itemToUpdate = Context.ResultadoEvento
                              .Where(i => i.Id_Resultado_Evento == resultadoevento.Id_Resultado_Evento)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(resultadoevento);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterResultadoEventoUpdated(resultadoevento);

            return resultadoevento;
        }

        partial void OnResultadoEventoDeleted(Reincarapp.Models.reincardb.ResultadoEvento item);
        partial void OnAfterResultadoEventoDeleted(Reincarapp.Models.reincardb.ResultadoEvento item);

        public async Task<Reincarapp.Models.reincardb.ResultadoEvento> DeleteResultadoEvento(long idresultadoevento)
        {
            var itemToDelete = Context.ResultadoEvento
                              .Where(i => i.Id_Resultado_Evento == idresultadoevento)
                              .Include(i => i.ClienteDeuda)
                              .Include(i => i.ClienteDeuda1)
                              .Include(i => i.DecisionEstado)
                              .Include(i => i.Evento)
                              .Include(i => i.TipoComunicacionResultadoEvento)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnResultadoEventoDeleted(itemToDelete);


            Context.ResultadoEvento.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterResultadoEventoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportRolToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/rol/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/rol/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportRolToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/rol/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/rol/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnRolRead(ref IQueryable<Reincarapp.Models.reincardb.Rol> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Rol>> GetRol(Query query = null)
        {
            var items = Context.Rol.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnRolRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnRolGet(Reincarapp.Models.reincardb.Rol item);
        partial void OnGetRolByIdRol(ref IQueryable<Reincarapp.Models.reincardb.Rol> items);


        public async Task<Reincarapp.Models.reincardb.Rol> GetRolByIdRol(long idrol)
        {
            var items = Context.Rol
                              .AsNoTracking()
                              .Where(i => i.Id_Rol == idrol);

 
            OnGetRolByIdRol(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnRolGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnRolCreated(Reincarapp.Models.reincardb.Rol item);
        partial void OnAfterRolCreated(Reincarapp.Models.reincardb.Rol item);

        public async Task<Reincarapp.Models.reincardb.Rol> CreateRol(Reincarapp.Models.reincardb.Rol rol)
        {
            OnRolCreated(rol);

            var existingItem = Context.Rol
                              .Where(i => i.Id_Rol == rol.Id_Rol)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Rol.Add(rol);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(rol).State = EntityState.Detached;
                throw;
            }

            OnAfterRolCreated(rol);

            return rol;
        }

        public async Task<Reincarapp.Models.reincardb.Rol> CancelRolChanges(Reincarapp.Models.reincardb.Rol item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnRolUpdated(Reincarapp.Models.reincardb.Rol item);
        partial void OnAfterRolUpdated(Reincarapp.Models.reincardb.Rol item);

        public async Task<Reincarapp.Models.reincardb.Rol> UpdateRol(long idrol, Reincarapp.Models.reincardb.Rol rol)
        {
            OnRolUpdated(rol);

            var itemToUpdate = Context.Rol
                              .Where(i => i.Id_Rol == rol.Id_Rol)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(rol);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterRolUpdated(rol);

            return rol;
        }

        partial void OnRolDeleted(Reincarapp.Models.reincardb.Rol item);
        partial void OnAfterRolDeleted(Reincarapp.Models.reincardb.Rol item);

        public async Task<Reincarapp.Models.reincardb.Rol> DeleteRol(long idrol)
        {
            var itemToDelete = Context.Rol
                              .Where(i => i.Id_Rol == idrol)
                              .Include(i => i.UsuarioRol)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnRolDeleted(itemToDelete);


            Context.Rol.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterRolDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportSaludcoopToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/saludcoop/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/saludcoop/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSaludcoopToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/saludcoop/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/saludcoop/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSaludcoopRead(ref IQueryable<Reincarapp.Models.reincardb.Saludcoop> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Saludcoop>> GetSaludcoop(Query query = null)
        {
            var items = Context.Saludcoop.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnSaludcoopRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSaludcoopGet(Reincarapp.Models.reincardb.Saludcoop item);
        partial void OnGetSaludcoopByIdSaludCoop(ref IQueryable<Reincarapp.Models.reincardb.Saludcoop> items);


        public async Task<Reincarapp.Models.reincardb.Saludcoop> GetSaludcoopByIdSaludCoop(long idsaludcoop)
        {
            var items = Context.Saludcoop
                              .AsNoTracking()
                              .Where(i => i.Id_SaludCoop == idsaludcoop);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetSaludcoopByIdSaludCoop(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnSaludcoopGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnSaludcoopCreated(Reincarapp.Models.reincardb.Saludcoop item);
        partial void OnAfterSaludcoopCreated(Reincarapp.Models.reincardb.Saludcoop item);

        public async Task<Reincarapp.Models.reincardb.Saludcoop> CreateSaludcoop(Reincarapp.Models.reincardb.Saludcoop saludcoop)
        {
            OnSaludcoopCreated(saludcoop);

            var existingItem = Context.Saludcoop
                              .Where(i => i.Id_SaludCoop == saludcoop.Id_SaludCoop)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Saludcoop.Add(saludcoop);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(saludcoop).State = EntityState.Detached;
                throw;
            }

            OnAfterSaludcoopCreated(saludcoop);

            return saludcoop;
        }

        public async Task<Reincarapp.Models.reincardb.Saludcoop> CancelSaludcoopChanges(Reincarapp.Models.reincardb.Saludcoop item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSaludcoopUpdated(Reincarapp.Models.reincardb.Saludcoop item);
        partial void OnAfterSaludcoopUpdated(Reincarapp.Models.reincardb.Saludcoop item);

        public async Task<Reincarapp.Models.reincardb.Saludcoop> UpdateSaludcoop(long idsaludcoop, Reincarapp.Models.reincardb.Saludcoop saludcoop)
        {
            OnSaludcoopUpdated(saludcoop);

            var itemToUpdate = Context.Saludcoop
                              .Where(i => i.Id_SaludCoop == saludcoop.Id_SaludCoop)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(saludcoop);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterSaludcoopUpdated(saludcoop);

            return saludcoop;
        }

        partial void OnSaludcoopDeleted(Reincarapp.Models.reincardb.Saludcoop item);
        partial void OnAfterSaludcoopDeleted(Reincarapp.Models.reincardb.Saludcoop item);

        public async Task<Reincarapp.Models.reincardb.Saludcoop> DeleteSaludcoop(long idsaludcoop)
        {
            var itemToDelete = Context.Saludcoop
                              .Where(i => i.Id_SaludCoop == idsaludcoop)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSaludcoopDeleted(itemToDelete);


            Context.Saludcoop.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSaludcoopDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportSaludcoopcdToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/saludcoopcd/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/saludcoopcd/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSaludcoopcdToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/saludcoopcd/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/saludcoopcd/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSaludcoopcdRead(ref IQueryable<Reincarapp.Models.reincardb.Saludcoopcd> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Saludcoopcd>> GetSaludcoopcd(Query query = null)
        {
            var items = Context.Saludcoopcd.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnSaludcoopcdRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSaludcoopcdGet(Reincarapp.Models.reincardb.Saludcoopcd item);
        partial void OnGetSaludcoopcdByIdSaludcoop(ref IQueryable<Reincarapp.Models.reincardb.Saludcoopcd> items);


        public async Task<Reincarapp.Models.reincardb.Saludcoopcd> GetSaludcoopcdByIdSaludcoop(long idsaludcoop)
        {
            var items = Context.Saludcoopcd
                              .AsNoTracking()
                              .Where(i => i.id_saludcoop == idsaludcoop);

 
            OnGetSaludcoopcdByIdSaludcoop(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnSaludcoopcdGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnSaludcoopcdCreated(Reincarapp.Models.reincardb.Saludcoopcd item);
        partial void OnAfterSaludcoopcdCreated(Reincarapp.Models.reincardb.Saludcoopcd item);

        public async Task<Reincarapp.Models.reincardb.Saludcoopcd> CreateSaludcoopcd(Reincarapp.Models.reincardb.Saludcoopcd saludcoopcd)
        {
            OnSaludcoopcdCreated(saludcoopcd);

            var existingItem = Context.Saludcoopcd
                              .Where(i => i.id_saludcoop == saludcoopcd.id_saludcoop)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Saludcoopcd.Add(saludcoopcd);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(saludcoopcd).State = EntityState.Detached;
                throw;
            }

            OnAfterSaludcoopcdCreated(saludcoopcd);

            return saludcoopcd;
        }

        public async Task<Reincarapp.Models.reincardb.Saludcoopcd> CancelSaludcoopcdChanges(Reincarapp.Models.reincardb.Saludcoopcd item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSaludcoopcdUpdated(Reincarapp.Models.reincardb.Saludcoopcd item);
        partial void OnAfterSaludcoopcdUpdated(Reincarapp.Models.reincardb.Saludcoopcd item);

        public async Task<Reincarapp.Models.reincardb.Saludcoopcd> UpdateSaludcoopcd(long idsaludcoop, Reincarapp.Models.reincardb.Saludcoopcd saludcoopcd)
        {
            OnSaludcoopcdUpdated(saludcoopcd);

            var itemToUpdate = Context.Saludcoopcd
                              .Where(i => i.id_saludcoop == saludcoopcd.id_saludcoop)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(saludcoopcd);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterSaludcoopcdUpdated(saludcoopcd);

            return saludcoopcd;
        }

        partial void OnSaludcoopcdDeleted(Reincarapp.Models.reincardb.Saludcoopcd item);
        partial void OnAfterSaludcoopcdDeleted(Reincarapp.Models.reincardb.Saludcoopcd item);

        public async Task<Reincarapp.Models.reincardb.Saludcoopcd> DeleteSaludcoopcd(long idsaludcoop)
        {
            var itemToDelete = Context.Saludcoopcd
                              .Where(i => i.id_saludcoop == idsaludcoop)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSaludcoopcdDeleted(itemToDelete);


            Context.Saludcoopcd.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSaludcoopcdDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportSmsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/sms/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/sms/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSmsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/sms/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/sms/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSmsRead(ref IQueryable<Reincarapp.Models.reincardb.Sms> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Sms>> GetSms(Query query = null)
        {
            var items = Context.Sms.AsQueryable();

            items = items.Include(i => i.Evento);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnSmsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSmsGet(Reincarapp.Models.reincardb.Sms item);
        partial void OnGetSmsByIdSms(ref IQueryable<Reincarapp.Models.reincardb.Sms> items);


        public async Task<Reincarapp.Models.reincardb.Sms> GetSmsByIdSms(long idsms)
        {
            var items = Context.Sms
                              .AsNoTracking()
                              .Where(i => i.Id_Sms == idsms);

            items = items.Include(i => i.Evento);
 
            OnGetSmsByIdSms(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnSmsGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnSmsCreated(Reincarapp.Models.reincardb.Sms item);
        partial void OnAfterSmsCreated(Reincarapp.Models.reincardb.Sms item);

        public async Task<Reincarapp.Models.reincardb.Sms> CreateSms(Reincarapp.Models.reincardb.Sms sms)
        {
            OnSmsCreated(sms);

            var existingItem = Context.Sms
                              .Where(i => i.Id_Sms == sms.Id_Sms)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Sms.Add(sms);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(sms).State = EntityState.Detached;
                throw;
            }

            OnAfterSmsCreated(sms);

            return sms;
        }

        public async Task<Reincarapp.Models.reincardb.Sms> CancelSmsChanges(Reincarapp.Models.reincardb.Sms item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSmsUpdated(Reincarapp.Models.reincardb.Sms item);
        partial void OnAfterSmsUpdated(Reincarapp.Models.reincardb.Sms item);

        public async Task<Reincarapp.Models.reincardb.Sms> UpdateSms(long idsms, Reincarapp.Models.reincardb.Sms sms)
        {
            OnSmsUpdated(sms);

            var itemToUpdate = Context.Sms
                              .Where(i => i.Id_Sms == sms.Id_Sms)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(sms);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterSmsUpdated(sms);

            return sms;
        }

        partial void OnSmsDeleted(Reincarapp.Models.reincardb.Sms item);
        partial void OnAfterSmsDeleted(Reincarapp.Models.reincardb.Sms item);

        public async Task<Reincarapp.Models.reincardb.Sms> DeleteSms(long idsms)
        {
            var itemToDelete = Context.Sms
                              .Where(i => i.Id_Sms == idsms)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSmsDeleted(itemToDelete);


            Context.Sms.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSmsDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportSubrepartoUsuarioToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/subrepartousuario/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/subrepartousuario/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSubrepartoUsuarioToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/subrepartousuario/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/subrepartousuario/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSubrepartoUsuarioRead(ref IQueryable<Reincarapp.Models.reincardb.SubrepartoUsuario> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.SubrepartoUsuario>> GetSubrepartoUsuario(Query query = null)
        {
            var items = Context.SubrepartoUsuario.AsQueryable();

            items = items.Include(i => i.Usuario);
            items = items.Include(i => i.Usuario1);
            items = items.Include(i => i.Usuario2);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnSubrepartoUsuarioRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSubrepartoUsuarioGet(Reincarapp.Models.reincardb.SubrepartoUsuario item);
        partial void OnGetSubrepartoUsuarioByIdSubRepartoUsuario(ref IQueryable<Reincarapp.Models.reincardb.SubrepartoUsuario> items);


        public async Task<Reincarapp.Models.reincardb.SubrepartoUsuario> GetSubrepartoUsuarioByIdSubRepartoUsuario(long idsubrepartousuario)
        {
            var items = Context.SubrepartoUsuario
                              .AsNoTracking()
                              .Where(i => i.IdSubRepartoUsuario == idsubrepartousuario);

            items = items.Include(i => i.Usuario);
            items = items.Include(i => i.Usuario1);
            items = items.Include(i => i.Usuario2);
 
            OnGetSubrepartoUsuarioByIdSubRepartoUsuario(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnSubrepartoUsuarioGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnSubrepartoUsuarioCreated(Reincarapp.Models.reincardb.SubrepartoUsuario item);
        partial void OnAfterSubrepartoUsuarioCreated(Reincarapp.Models.reincardb.SubrepartoUsuario item);

        public async Task<Reincarapp.Models.reincardb.SubrepartoUsuario> CreateSubrepartoUsuario(Reincarapp.Models.reincardb.SubrepartoUsuario subrepartousuario)
        {
            OnSubrepartoUsuarioCreated(subrepartousuario);

            var existingItem = Context.SubrepartoUsuario
                              .Where(i => i.IdSubRepartoUsuario == subrepartousuario.IdSubRepartoUsuario)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.SubrepartoUsuario.Add(subrepartousuario);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(subrepartousuario).State = EntityState.Detached;
                throw;
            }

            OnAfterSubrepartoUsuarioCreated(subrepartousuario);

            return subrepartousuario;
        }

        public async Task<Reincarapp.Models.reincardb.SubrepartoUsuario> CancelSubrepartoUsuarioChanges(Reincarapp.Models.reincardb.SubrepartoUsuario item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSubrepartoUsuarioUpdated(Reincarapp.Models.reincardb.SubrepartoUsuario item);
        partial void OnAfterSubrepartoUsuarioUpdated(Reincarapp.Models.reincardb.SubrepartoUsuario item);

        public async Task<Reincarapp.Models.reincardb.SubrepartoUsuario> UpdateSubrepartoUsuario(long idsubrepartousuario, Reincarapp.Models.reincardb.SubrepartoUsuario subrepartousuario)
        {
            OnSubrepartoUsuarioUpdated(subrepartousuario);

            var itemToUpdate = Context.SubrepartoUsuario
                              .Where(i => i.IdSubRepartoUsuario == subrepartousuario.IdSubRepartoUsuario)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(subrepartousuario);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterSubrepartoUsuarioUpdated(subrepartousuario);

            return subrepartousuario;
        }

        partial void OnSubrepartoUsuarioDeleted(Reincarapp.Models.reincardb.SubrepartoUsuario item);
        partial void OnAfterSubrepartoUsuarioDeleted(Reincarapp.Models.reincardb.SubrepartoUsuario item);

        public async Task<Reincarapp.Models.reincardb.SubrepartoUsuario> DeleteSubrepartoUsuario(long idsubrepartousuario)
        {
            var itemToDelete = Context.SubrepartoUsuario
                              .Where(i => i.IdSubRepartoUsuario == idsubrepartousuario)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSubrepartoUsuarioDeleted(itemToDelete);


            Context.SubrepartoUsuario.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSubrepartoUsuarioDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTareaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tarea/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tarea/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTareaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tarea/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tarea/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTareaRead(ref IQueryable<Reincarapp.Models.reincardb.Tarea> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Tarea>> GetTarea(Query query = null)
        {
            var items = Context.Tarea.AsQueryable();

            items = items.Include(i => i.Aspnetusers);
            items = items.Include(i => i.ClienteDeuda);
            items = items.Include(i => i.Evento1);
            items = items.Include(i => i.TipoComunicacion);
            items = items.Include(i => i.TipoTarea);
            items = items.Include(i => i.Usuario);
            items = items.Include(i => i.Usuario1);
            items = items.Include(i => i.Aspnetusers1);
            items = items.Include(i => i.Aspnetusers2);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTareaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTareaGet(Reincarapp.Models.reincardb.Tarea item);
        partial void OnGetTareaByIdTarea(ref IQueryable<Reincarapp.Models.reincardb.Tarea> items);


        public async Task<Reincarapp.Models.reincardb.Tarea> GetTareaByIdTarea(long idtarea)
        {
            var items = Context.Tarea
                              .AsNoTracking()
                              .Where(i => i.Id_Tarea == idtarea);

            items = items.Include(i => i.Aspnetusers);
            items = items.Include(i => i.ClienteDeuda);
            items = items.Include(i => i.Evento1);
            items = items.Include(i => i.TipoComunicacion);
            items = items.Include(i => i.TipoTarea);
            items = items.Include(i => i.Usuario);
            items = items.Include(i => i.Usuario1);
            items = items.Include(i => i.Aspnetusers1);
            items = items.Include(i => i.Aspnetusers2);
 
            OnGetTareaByIdTarea(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTareaGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTareaCreated(Reincarapp.Models.reincardb.Tarea item);
        partial void OnAfterTareaCreated(Reincarapp.Models.reincardb.Tarea item);

        public async Task<Reincarapp.Models.reincardb.Tarea> CreateTarea(Reincarapp.Models.reincardb.Tarea tarea)
        {
            OnTareaCreated(tarea);

            var existingItem = Context.Tarea
                              .Where(i => i.Id_Tarea == tarea.Id_Tarea)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Tarea.Add(tarea);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tarea).State = EntityState.Detached;
                throw;
            }

            OnAfterTareaCreated(tarea);

            return tarea;
        }

        public async Task<Reincarapp.Models.reincardb.Tarea> CancelTareaChanges(Reincarapp.Models.reincardb.Tarea item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTareaUpdated(Reincarapp.Models.reincardb.Tarea item);
        partial void OnAfterTareaUpdated(Reincarapp.Models.reincardb.Tarea item);

        public async Task<Reincarapp.Models.reincardb.Tarea> UpdateTarea(long idtarea, Reincarapp.Models.reincardb.Tarea tarea)
        {
            OnTareaUpdated(tarea);

            var itemToUpdate = Context.Tarea
                              .Where(i => i.Id_Tarea == tarea.Id_Tarea)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tarea);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTareaUpdated(tarea);

            return tarea;
        }

        partial void OnTareaDeleted(Reincarapp.Models.reincardb.Tarea item);
        partial void OnAfterTareaDeleted(Reincarapp.Models.reincardb.Tarea item);

        public async Task<Reincarapp.Models.reincardb.Tarea> DeleteTarea(long idtarea)
        {
            var itemToDelete = Context.Tarea
                              .Where(i => i.Id_Tarea == idtarea)
                              .Include(i => i.Evento)
                              .Include(i => i.LogDatoPersona)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTareaDeleted(itemToDelete);


            Context.Tarea.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTareaDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTasaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tasa/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tasa/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTasaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tasa/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tasa/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTasaRead(ref IQueryable<Reincarapp.Models.reincardb.Tasa> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Tasa>> GetTasa(Query query = null)
        {
            var items = Context.Tasa.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTasaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTasaGet(Reincarapp.Models.reincardb.Tasa item);
        partial void OnGetTasaByIdTasa(ref IQueryable<Reincarapp.Models.reincardb.Tasa> items);


        public async Task<Reincarapp.Models.reincardb.Tasa> GetTasaByIdTasa(long idtasa)
        {
            var items = Context.Tasa
                              .AsNoTracking()
                              .Where(i => i.id_tasa == idtasa);

 
            OnGetTasaByIdTasa(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTasaGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTasaCreated(Reincarapp.Models.reincardb.Tasa item);
        partial void OnAfterTasaCreated(Reincarapp.Models.reincardb.Tasa item);

        public async Task<Reincarapp.Models.reincardb.Tasa> CreateTasa(Reincarapp.Models.reincardb.Tasa tasa)
        {
            OnTasaCreated(tasa);

            var existingItem = Context.Tasa
                              .Where(i => i.id_tasa == tasa.id_tasa)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Tasa.Add(tasa);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tasa).State = EntityState.Detached;
                throw;
            }

            OnAfterTasaCreated(tasa);

            return tasa;
        }

        public async Task<Reincarapp.Models.reincardb.Tasa> CancelTasaChanges(Reincarapp.Models.reincardb.Tasa item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTasaUpdated(Reincarapp.Models.reincardb.Tasa item);
        partial void OnAfterTasaUpdated(Reincarapp.Models.reincardb.Tasa item);

        public async Task<Reincarapp.Models.reincardb.Tasa> UpdateTasa(long idtasa, Reincarapp.Models.reincardb.Tasa tasa)
        {
            OnTasaUpdated(tasa);

            var itemToUpdate = Context.Tasa
                              .Where(i => i.id_tasa == tasa.id_tasa)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tasa);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTasaUpdated(tasa);

            return tasa;
        }

        partial void OnTasaDeleted(Reincarapp.Models.reincardb.Tasa item);
        partial void OnAfterTasaDeleted(Reincarapp.Models.reincardb.Tasa item);

        public async Task<Reincarapp.Models.reincardb.Tasa> DeleteTasa(long idtasa)
        {
            var itemToDelete = Context.Tasa
                              .Where(i => i.id_tasa == idtasa)
                              .Include(i => i.Rediferido)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTasaDeleted(itemToDelete);


            Context.Tasa.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTasaDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTblDeleteToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tbldelete/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tbldelete/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblDeleteToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tbldelete/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tbldelete/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblDeleteRead(ref IQueryable<Reincarapp.Models.reincardb.TblDelete> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TblDelete>> GetTblDelete(Query query = null)
        {
            var items = Context.TblDelete.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTblDeleteRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblDeleteGet(Reincarapp.Models.reincardb.TblDelete item);
        partial void OnGetTblDeleteByIdSaludcoop(ref IQueryable<Reincarapp.Models.reincardb.TblDelete> items);


        public async Task<Reincarapp.Models.reincardb.TblDelete> GetTblDeleteByIdSaludcoop(long idsaludcoop)
        {
            var items = Context.TblDelete
                              .AsNoTracking()
                              .Where(i => i.id_saludcoop == idsaludcoop);

 
            OnGetTblDeleteByIdSaludcoop(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTblDeleteGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTblDeleteCreated(Reincarapp.Models.reincardb.TblDelete item);
        partial void OnAfterTblDeleteCreated(Reincarapp.Models.reincardb.TblDelete item);

        public async Task<Reincarapp.Models.reincardb.TblDelete> CreateTblDelete(Reincarapp.Models.reincardb.TblDelete tbldelete)
        {
            OnTblDeleteCreated(tbldelete);

            var existingItem = Context.TblDelete
                              .Where(i => i.id_saludcoop == tbldelete.id_saludcoop)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblDelete.Add(tbldelete);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tbldelete).State = EntityState.Detached;
                throw;
            }

            OnAfterTblDeleteCreated(tbldelete);

            return tbldelete;
        }

        public async Task<Reincarapp.Models.reincardb.TblDelete> CancelTblDeleteChanges(Reincarapp.Models.reincardb.TblDelete item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblDeleteUpdated(Reincarapp.Models.reincardb.TblDelete item);
        partial void OnAfterTblDeleteUpdated(Reincarapp.Models.reincardb.TblDelete item);

        public async Task<Reincarapp.Models.reincardb.TblDelete> UpdateTblDelete(long idsaludcoop, Reincarapp.Models.reincardb.TblDelete tbldelete)
        {
            OnTblDeleteUpdated(tbldelete);

            var itemToUpdate = Context.TblDelete
                              .Where(i => i.id_saludcoop == tbldelete.id_saludcoop)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tbldelete);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTblDeleteUpdated(tbldelete);

            return tbldelete;
        }

        partial void OnTblDeleteDeleted(Reincarapp.Models.reincardb.TblDelete item);
        partial void OnAfterTblDeleteDeleted(Reincarapp.Models.reincardb.TblDelete item);

        public async Task<Reincarapp.Models.reincardb.TblDelete> DeleteTblDelete(long idsaludcoop)
        {
            var itemToDelete = Context.TblDelete
                              .Where(i => i.id_saludcoop == idsaludcoop)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblDeleteDeleted(itemToDelete);


            Context.TblDelete.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblDeleteDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTempEveToDeleteToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tempevetodelete/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tempevetodelete/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTempEveToDeleteToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tempevetodelete/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tempevetodelete/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTempEveToDeleteRead(ref IQueryable<Reincarapp.Models.reincardb.TempEveToDelete> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TempEveToDelete>> GetTempEveToDelete(Query query = null)
        {
            var items = Context.TempEveToDelete.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTempEveToDeleteRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportTempEveToUpdToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tempevetoupd/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tempevetoupd/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTempEveToUpdToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tempevetoupd/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tempevetoupd/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTempEveToUpdRead(ref IQueryable<Reincarapp.Models.reincardb.TempEveToUpd> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TempEveToUpd>> GetTempEveToUpd(Query query = null)
        {
            var items = Context.TempEveToUpd.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTempEveToUpdRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTempEveToUpdGet(Reincarapp.Models.reincardb.TempEveToUpd item);
        partial void OnGetTempEveToUpdByIdEvento(ref IQueryable<Reincarapp.Models.reincardb.TempEveToUpd> items);


        public async Task<Reincarapp.Models.reincardb.TempEveToUpd> GetTempEveToUpdByIdEvento(long idevento)
        {
            var items = Context.TempEveToUpd
                              .AsNoTracking()
                              .Where(i => i.id_evento == idevento);

 
            OnGetTempEveToUpdByIdEvento(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTempEveToUpdGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTempEveToUpdCreated(Reincarapp.Models.reincardb.TempEveToUpd item);
        partial void OnAfterTempEveToUpdCreated(Reincarapp.Models.reincardb.TempEveToUpd item);

        public async Task<Reincarapp.Models.reincardb.TempEveToUpd> CreateTempEveToUpd(Reincarapp.Models.reincardb.TempEveToUpd tempevetoupd)
        {
            OnTempEveToUpdCreated(tempevetoupd);

            var existingItem = Context.TempEveToUpd
                              .Where(i => i.id_evento == tempevetoupd.id_evento)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TempEveToUpd.Add(tempevetoupd);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tempevetoupd).State = EntityState.Detached;
                throw;
            }

            OnAfterTempEveToUpdCreated(tempevetoupd);

            return tempevetoupd;
        }

        public async Task<Reincarapp.Models.reincardb.TempEveToUpd> CancelTempEveToUpdChanges(Reincarapp.Models.reincardb.TempEveToUpd item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTempEveToUpdUpdated(Reincarapp.Models.reincardb.TempEveToUpd item);
        partial void OnAfterTempEveToUpdUpdated(Reincarapp.Models.reincardb.TempEveToUpd item);

        public async Task<Reincarapp.Models.reincardb.TempEveToUpd> UpdateTempEveToUpd(long idevento, Reincarapp.Models.reincardb.TempEveToUpd tempevetoupd)
        {
            OnTempEveToUpdUpdated(tempevetoupd);

            var itemToUpdate = Context.TempEveToUpd
                              .Where(i => i.id_evento == tempevetoupd.id_evento)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tempevetoupd);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTempEveToUpdUpdated(tempevetoupd);

            return tempevetoupd;
        }

        partial void OnTempEveToUpdDeleted(Reincarapp.Models.reincardb.TempEveToUpd item);
        partial void OnAfterTempEveToUpdDeleted(Reincarapp.Models.reincardb.TempEveToUpd item);

        public async Task<Reincarapp.Models.reincardb.TempEveToUpd> DeleteTempEveToUpd(long idevento)
        {
            var itemToDelete = Context.TempEveToUpd
                              .Where(i => i.id_evento == idevento)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTempEveToUpdDeleted(itemToDelete);


            Context.TempEveToUpd.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTempEveToUpdDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTempIdcoomulstrasanToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tempidcoomulstrasan/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tempidcoomulstrasan/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTempIdcoomulstrasanToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tempidcoomulstrasan/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tempidcoomulstrasan/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTempIdcoomulstrasanRead(ref IQueryable<Reincarapp.Models.reincardb.TempIdcoomulstrasan> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TempIdcoomulstrasan>> GetTempIdcoomulstrasan(Query query = null)
        {
            var items = Context.TempIdcoomulstrasan.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTempIdcoomulstrasanRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportTempIdcoomulstrasan2ToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tempidcoomulstrasan2/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tempidcoomulstrasan2/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTempIdcoomulstrasan2ToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tempidcoomulstrasan2/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tempidcoomulstrasan2/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTempIdcoomulstrasan2Read(ref IQueryable<Reincarapp.Models.reincardb.TempIdcoomulstrasan2> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TempIdcoomulstrasan2>> GetTempIdcoomulstrasan2(Query query = null)
        {
            var items = Context.TempIdcoomulstrasan2.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTempIdcoomulstrasan2Read(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportTiempoEventoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tiempoevento/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tiempoevento/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTiempoEventoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tiempoevento/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tiempoevento/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTiempoEventoRead(ref IQueryable<Reincarapp.Models.reincardb.TiempoEvento> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TiempoEvento>> GetTiempoEvento(Query query = null)
        {
            var items = Context.TiempoEvento.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTiempoEventoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTiempoEventoGet(Reincarapp.Models.reincardb.TiempoEvento item);
        partial void OnGetTiempoEventoByIdTiempoEvento(ref IQueryable<Reincarapp.Models.reincardb.TiempoEvento> items);


        public async Task<Reincarapp.Models.reincardb.TiempoEvento> GetTiempoEventoByIdTiempoEvento(long idtiempoevento)
        {
            var items = Context.TiempoEvento
                              .AsNoTracking()
                              .Where(i => i.id_tiempo_evento == idtiempoevento);

 
            OnGetTiempoEventoByIdTiempoEvento(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTiempoEventoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTiempoEventoCreated(Reincarapp.Models.reincardb.TiempoEvento item);
        partial void OnAfterTiempoEventoCreated(Reincarapp.Models.reincardb.TiempoEvento item);

        public async Task<Reincarapp.Models.reincardb.TiempoEvento> CreateTiempoEvento(Reincarapp.Models.reincardb.TiempoEvento tiempoevento)
        {
            OnTiempoEventoCreated(tiempoevento);

            var existingItem = Context.TiempoEvento
                              .Where(i => i.id_tiempo_evento == tiempoevento.id_tiempo_evento)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TiempoEvento.Add(tiempoevento);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tiempoevento).State = EntityState.Detached;
                throw;
            }

            OnAfterTiempoEventoCreated(tiempoevento);

            return tiempoevento;
        }

        public async Task<Reincarapp.Models.reincardb.TiempoEvento> CancelTiempoEventoChanges(Reincarapp.Models.reincardb.TiempoEvento item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTiempoEventoUpdated(Reincarapp.Models.reincardb.TiempoEvento item);
        partial void OnAfterTiempoEventoUpdated(Reincarapp.Models.reincardb.TiempoEvento item);

        public async Task<Reincarapp.Models.reincardb.TiempoEvento> UpdateTiempoEvento(long idtiempoevento, Reincarapp.Models.reincardb.TiempoEvento tiempoevento)
        {
            OnTiempoEventoUpdated(tiempoevento);

            var itemToUpdate = Context.TiempoEvento
                              .Where(i => i.id_tiempo_evento == tiempoevento.id_tiempo_evento)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tiempoevento);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTiempoEventoUpdated(tiempoevento);

            return tiempoevento;
        }

        partial void OnTiempoEventoDeleted(Reincarapp.Models.reincardb.TiempoEvento item);
        partial void OnAfterTiempoEventoDeleted(Reincarapp.Models.reincardb.TiempoEvento item);

        public async Task<Reincarapp.Models.reincardb.TiempoEvento> DeleteTiempoEvento(long idtiempoevento)
        {
            var itemToDelete = Context.TiempoEvento
                              .Where(i => i.id_tiempo_evento == idtiempoevento)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTiempoEventoDeleted(itemToDelete);


            Context.TiempoEvento.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTiempoEventoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTiempofueraToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tiempofuera/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tiempofuera/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTiempofueraToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tiempofuera/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tiempofuera/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTiempofueraRead(ref IQueryable<Reincarapp.Models.reincardb.Tiempofuera> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Tiempofuera>> GetTiempofuera(Query query = null)
        {
            var items = Context.Tiempofuera.AsQueryable();

            items = items.Include(i => i.Razontiempofuera);
            items = items.Include(i => i.Usuario);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTiempofueraRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTiempofueraGet(Reincarapp.Models.reincardb.Tiempofuera item);
        partial void OnGetTiempofueraById(ref IQueryable<Reincarapp.Models.reincardb.Tiempofuera> items);


        public async Task<Reincarapp.Models.reincardb.Tiempofuera> GetTiempofueraById(long id)
        {
            var items = Context.Tiempofuera
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Razontiempofuera);
            items = items.Include(i => i.Usuario);
 
            OnGetTiempofueraById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTiempofueraGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTiempofueraCreated(Reincarapp.Models.reincardb.Tiempofuera item);
        partial void OnAfterTiempofueraCreated(Reincarapp.Models.reincardb.Tiempofuera item);

        public async Task<Reincarapp.Models.reincardb.Tiempofuera> CreateTiempofuera(Reincarapp.Models.reincardb.Tiempofuera tiempofuera)
        {
            OnTiempofueraCreated(tiempofuera);

            var existingItem = Context.Tiempofuera
                              .Where(i => i.Id == tiempofuera.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Tiempofuera.Add(tiempofuera);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tiempofuera).State = EntityState.Detached;
                throw;
            }

            OnAfterTiempofueraCreated(tiempofuera);

            return tiempofuera;
        }

        public async Task<Reincarapp.Models.reincardb.Tiempofuera> CancelTiempofueraChanges(Reincarapp.Models.reincardb.Tiempofuera item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTiempofueraUpdated(Reincarapp.Models.reincardb.Tiempofuera item);
        partial void OnAfterTiempofueraUpdated(Reincarapp.Models.reincardb.Tiempofuera item);

        public async Task<Reincarapp.Models.reincardb.Tiempofuera> UpdateTiempofuera(long id, Reincarapp.Models.reincardb.Tiempofuera tiempofuera)
        {
            OnTiempofueraUpdated(tiempofuera);

            var itemToUpdate = Context.Tiempofuera
                              .Where(i => i.Id == tiempofuera.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tiempofuera);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTiempofueraUpdated(tiempofuera);

            return tiempofuera;
        }

        partial void OnTiempofueraDeleted(Reincarapp.Models.reincardb.Tiempofuera item);
        partial void OnAfterTiempofueraDeleted(Reincarapp.Models.reincardb.Tiempofuera item);

        public async Task<Reincarapp.Models.reincardb.Tiempofuera> DeleteTiempofuera(long id)
        {
            var itemToDelete = Context.Tiempofuera
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTiempofueraDeleted(itemToDelete);


            Context.Tiempofuera.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTiempofueraDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTipoArchivoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tipoarchivo/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tipoarchivo/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTipoArchivoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tipoarchivo/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tipoarchivo/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTipoArchivoRead(ref IQueryable<Reincarapp.Models.reincardb.TipoArchivo> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TipoArchivo>> GetTipoArchivo(Query query = null)
        {
            var items = Context.TipoArchivo.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTipoArchivoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTipoArchivoGet(Reincarapp.Models.reincardb.TipoArchivo item);
        partial void OnGetTipoArchivoByIdTipoArchivo(ref IQueryable<Reincarapp.Models.reincardb.TipoArchivo> items);


        public async Task<Reincarapp.Models.reincardb.TipoArchivo> GetTipoArchivoByIdTipoArchivo(long idtipoarchivo)
        {
            var items = Context.TipoArchivo
                              .AsNoTracking()
                              .Where(i => i.id_tipo_archivo == idtipoarchivo);

 
            OnGetTipoArchivoByIdTipoArchivo(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTipoArchivoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTipoArchivoCreated(Reincarapp.Models.reincardb.TipoArchivo item);
        partial void OnAfterTipoArchivoCreated(Reincarapp.Models.reincardb.TipoArchivo item);

        public async Task<Reincarapp.Models.reincardb.TipoArchivo> CreateTipoArchivo(Reincarapp.Models.reincardb.TipoArchivo tipoarchivo)
        {
            OnTipoArchivoCreated(tipoarchivo);

            var existingItem = Context.TipoArchivo
                              .Where(i => i.id_tipo_archivo == tipoarchivo.id_tipo_archivo)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TipoArchivo.Add(tipoarchivo);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tipoarchivo).State = EntityState.Detached;
                throw;
            }

            OnAfterTipoArchivoCreated(tipoarchivo);

            return tipoarchivo;
        }

        public async Task<Reincarapp.Models.reincardb.TipoArchivo> CancelTipoArchivoChanges(Reincarapp.Models.reincardb.TipoArchivo item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTipoArchivoUpdated(Reincarapp.Models.reincardb.TipoArchivo item);
        partial void OnAfterTipoArchivoUpdated(Reincarapp.Models.reincardb.TipoArchivo item);

        public async Task<Reincarapp.Models.reincardb.TipoArchivo> UpdateTipoArchivo(long idtipoarchivo, Reincarapp.Models.reincardb.TipoArchivo tipoarchivo)
        {
            OnTipoArchivoUpdated(tipoarchivo);

            var itemToUpdate = Context.TipoArchivo
                              .Where(i => i.id_tipo_archivo == tipoarchivo.id_tipo_archivo)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tipoarchivo);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTipoArchivoUpdated(tipoarchivo);

            return tipoarchivo;
        }

        partial void OnTipoArchivoDeleted(Reincarapp.Models.reincardb.TipoArchivo item);
        partial void OnAfterTipoArchivoDeleted(Reincarapp.Models.reincardb.TipoArchivo item);

        public async Task<Reincarapp.Models.reincardb.TipoArchivo> DeleteTipoArchivo(long idtipoarchivo)
        {
            var itemToDelete = Context.TipoArchivo
                              .Where(i => i.id_tipo_archivo == idtipoarchivo)
                              .Include(i => i.EventoArchivo)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTipoArchivoDeleted(itemToDelete);


            Context.TipoArchivo.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTipoArchivoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTipoClasificacionAdicionalToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tipoclasificacionadicional/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tipoclasificacionadicional/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTipoClasificacionAdicionalToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tipoclasificacionadicional/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tipoclasificacionadicional/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTipoClasificacionAdicionalRead(ref IQueryable<Reincarapp.Models.reincardb.TipoClasificacionAdicional> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TipoClasificacionAdicional>> GetTipoClasificacionAdicional(Query query = null)
        {
            var items = Context.TipoClasificacionAdicional.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTipoClasificacionAdicionalRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTipoClasificacionAdicionalGet(Reincarapp.Models.reincardb.TipoClasificacionAdicional item);
        partial void OnGetTipoClasificacionAdicionalByIdTipoClasificacionAdicional(ref IQueryable<Reincarapp.Models.reincardb.TipoClasificacionAdicional> items);


        public async Task<Reincarapp.Models.reincardb.TipoClasificacionAdicional> GetTipoClasificacionAdicionalByIdTipoClasificacionAdicional(int idtipoclasificacionadicional)
        {
            var items = Context.TipoClasificacionAdicional
                              .AsNoTracking()
                              .Where(i => i.Id_Tipo_Clasificacion_Adicional == idtipoclasificacionadicional);

 
            OnGetTipoClasificacionAdicionalByIdTipoClasificacionAdicional(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTipoClasificacionAdicionalGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTipoClasificacionAdicionalCreated(Reincarapp.Models.reincardb.TipoClasificacionAdicional item);
        partial void OnAfterTipoClasificacionAdicionalCreated(Reincarapp.Models.reincardb.TipoClasificacionAdicional item);

        public async Task<Reincarapp.Models.reincardb.TipoClasificacionAdicional> CreateTipoClasificacionAdicional(Reincarapp.Models.reincardb.TipoClasificacionAdicional tipoclasificacionadicional)
        {
            OnTipoClasificacionAdicionalCreated(tipoclasificacionadicional);

            var existingItem = Context.TipoClasificacionAdicional
                              .Where(i => i.Id_Tipo_Clasificacion_Adicional == tipoclasificacionadicional.Id_Tipo_Clasificacion_Adicional)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TipoClasificacionAdicional.Add(tipoclasificacionadicional);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tipoclasificacionadicional).State = EntityState.Detached;
                throw;
            }

            OnAfterTipoClasificacionAdicionalCreated(tipoclasificacionadicional);

            return tipoclasificacionadicional;
        }

        public async Task<Reincarapp.Models.reincardb.TipoClasificacionAdicional> CancelTipoClasificacionAdicionalChanges(Reincarapp.Models.reincardb.TipoClasificacionAdicional item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTipoClasificacionAdicionalUpdated(Reincarapp.Models.reincardb.TipoClasificacionAdicional item);
        partial void OnAfterTipoClasificacionAdicionalUpdated(Reincarapp.Models.reincardb.TipoClasificacionAdicional item);

        public async Task<Reincarapp.Models.reincardb.TipoClasificacionAdicional> UpdateTipoClasificacionAdicional(int idtipoclasificacionadicional, Reincarapp.Models.reincardb.TipoClasificacionAdicional tipoclasificacionadicional)
        {
            OnTipoClasificacionAdicionalUpdated(tipoclasificacionadicional);

            var itemToUpdate = Context.TipoClasificacionAdicional
                              .Where(i => i.Id_Tipo_Clasificacion_Adicional == tipoclasificacionadicional.Id_Tipo_Clasificacion_Adicional)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tipoclasificacionadicional);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTipoClasificacionAdicionalUpdated(tipoclasificacionadicional);

            return tipoclasificacionadicional;
        }

        partial void OnTipoClasificacionAdicionalDeleted(Reincarapp.Models.reincardb.TipoClasificacionAdicional item);
        partial void OnAfterTipoClasificacionAdicionalDeleted(Reincarapp.Models.reincardb.TipoClasificacionAdicional item);

        public async Task<Reincarapp.Models.reincardb.TipoClasificacionAdicional> DeleteTipoClasificacionAdicional(int idtipoclasificacionadicional)
        {
            var itemToDelete = Context.TipoClasificacionAdicional
                              .Where(i => i.Id_Tipo_Clasificacion_Adicional == idtipoclasificacionadicional)
                              .Include(i => i.ClasificacionAdicional)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTipoClasificacionAdicionalDeleted(itemToDelete);


            Context.TipoClasificacionAdicional.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTipoClasificacionAdicionalDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTipoClienteToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tipocliente/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tipocliente/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTipoClienteToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tipocliente/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tipocliente/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTipoClienteRead(ref IQueryable<Reincarapp.Models.reincardb.TipoCliente> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TipoCliente>> GetTipoCliente(Query query = null)
        {
            var items = Context.TipoCliente.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTipoClienteRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTipoClienteGet(Reincarapp.Models.reincardb.TipoCliente item);
        partial void OnGetTipoClienteByIdTipoCliente(ref IQueryable<Reincarapp.Models.reincardb.TipoCliente> items);


        public async Task<Reincarapp.Models.reincardb.TipoCliente> GetTipoClienteByIdTipoCliente(long idtipocliente)
        {
            var items = Context.TipoCliente
                              .AsNoTracking()
                              .Where(i => i.id_tipo_cliente == idtipocliente);

 
            OnGetTipoClienteByIdTipoCliente(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTipoClienteGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTipoClienteCreated(Reincarapp.Models.reincardb.TipoCliente item);
        partial void OnAfterTipoClienteCreated(Reincarapp.Models.reincardb.TipoCliente item);

        public async Task<Reincarapp.Models.reincardb.TipoCliente> CreateTipoCliente(Reincarapp.Models.reincardb.TipoCliente tipocliente)
        {
            OnTipoClienteCreated(tipocliente);

            var existingItem = Context.TipoCliente
                              .Where(i => i.id_tipo_cliente == tipocliente.id_tipo_cliente)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TipoCliente.Add(tipocliente);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tipocliente).State = EntityState.Detached;
                throw;
            }

            OnAfterTipoClienteCreated(tipocliente);

            return tipocliente;
        }

        public async Task<Reincarapp.Models.reincardb.TipoCliente> CancelTipoClienteChanges(Reincarapp.Models.reincardb.TipoCliente item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTipoClienteUpdated(Reincarapp.Models.reincardb.TipoCliente item);
        partial void OnAfterTipoClienteUpdated(Reincarapp.Models.reincardb.TipoCliente item);

        public async Task<Reincarapp.Models.reincardb.TipoCliente> UpdateTipoCliente(long idtipocliente, Reincarapp.Models.reincardb.TipoCliente tipocliente)
        {
            OnTipoClienteUpdated(tipocliente);

            var itemToUpdate = Context.TipoCliente
                              .Where(i => i.id_tipo_cliente == tipocliente.id_tipo_cliente)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tipocliente);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTipoClienteUpdated(tipocliente);

            return tipocliente;
        }

        partial void OnTipoClienteDeleted(Reincarapp.Models.reincardb.TipoCliente item);
        partial void OnAfterTipoClienteDeleted(Reincarapp.Models.reincardb.TipoCliente item);

        public async Task<Reincarapp.Models.reincardb.TipoCliente> DeleteTipoCliente(long idtipocliente)
        {
            var itemToDelete = Context.TipoCliente
                              .Where(i => i.id_tipo_cliente == idtipocliente)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTipoClienteDeleted(itemToDelete);


            Context.TipoCliente.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTipoClienteDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTipoComunicacionToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tipocomunicacion/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tipocomunicacion/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTipoComunicacionToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tipocomunicacion/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tipocomunicacion/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTipoComunicacionRead(ref IQueryable<Reincarapp.Models.reincardb.TipoComunicacion> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TipoComunicacion>> GetTipoComunicacion(Query query = null)
        {
            var items = Context.TipoComunicacion.AsQueryable();

            items = items.Include(i => i.Cliente);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTipoComunicacionRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTipoComunicacionGet(Reincarapp.Models.reincardb.TipoComunicacion item);
        partial void OnGetTipoComunicacionByIdTipoComunicacion(ref IQueryable<Reincarapp.Models.reincardb.TipoComunicacion> items);


        public async Task<Reincarapp.Models.reincardb.TipoComunicacion> GetTipoComunicacionByIdTipoComunicacion(long idtipocomunicacion)
        {
            var items = Context.TipoComunicacion
                              .AsNoTracking()
                              .Where(i => i.Id_Tipo_Comunicacion == idtipocomunicacion);

            items = items.Include(i => i.Cliente);
 
            OnGetTipoComunicacionByIdTipoComunicacion(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTipoComunicacionGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTipoComunicacionCreated(Reincarapp.Models.reincardb.TipoComunicacion item);
        partial void OnAfterTipoComunicacionCreated(Reincarapp.Models.reincardb.TipoComunicacion item);

        public async Task<Reincarapp.Models.reincardb.TipoComunicacion> CreateTipoComunicacion(Reincarapp.Models.reincardb.TipoComunicacion tipocomunicacion)
        {
            OnTipoComunicacionCreated(tipocomunicacion);

            var existingItem = Context.TipoComunicacion
                              .Where(i => i.Id_Tipo_Comunicacion == tipocomunicacion.Id_Tipo_Comunicacion)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TipoComunicacion.Add(tipocomunicacion);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tipocomunicacion).State = EntityState.Detached;
                throw;
            }

            OnAfterTipoComunicacionCreated(tipocomunicacion);

            return tipocomunicacion;
        }

        public async Task<Reincarapp.Models.reincardb.TipoComunicacion> CancelTipoComunicacionChanges(Reincarapp.Models.reincardb.TipoComunicacion item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTipoComunicacionUpdated(Reincarapp.Models.reincardb.TipoComunicacion item);
        partial void OnAfterTipoComunicacionUpdated(Reincarapp.Models.reincardb.TipoComunicacion item);

        public async Task<Reincarapp.Models.reincardb.TipoComunicacion> UpdateTipoComunicacion(long idtipocomunicacion, Reincarapp.Models.reincardb.TipoComunicacion tipocomunicacion)
        {
            OnTipoComunicacionUpdated(tipocomunicacion);

            var itemToUpdate = Context.TipoComunicacion
                              .Where(i => i.Id_Tipo_Comunicacion == tipocomunicacion.Id_Tipo_Comunicacion)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tipocomunicacion);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTipoComunicacionUpdated(tipocomunicacion);

            return tipocomunicacion;
        }

        partial void OnTipoComunicacionDeleted(Reincarapp.Models.reincardb.TipoComunicacion item);
        partial void OnAfterTipoComunicacionDeleted(Reincarapp.Models.reincardb.TipoComunicacion item);

        public async Task<Reincarapp.Models.reincardb.TipoComunicacion> DeleteTipoComunicacion(long idtipocomunicacion)
        {
            var itemToDelete = Context.TipoComunicacion
                              .Where(i => i.Id_Tipo_Comunicacion == idtipocomunicacion)
                              .Include(i => i.DecisionEstado)
                              .Include(i => i.Evento)
                              .Include(i => i.Tarea)
                              .Include(i => i.TipoComunicacionResultadoEvento)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTipoComunicacionDeleted(itemToDelete);


            Context.TipoComunicacion.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTipoComunicacionDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTipoComunicacionResultadoEventoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tipocomunicacionresultadoevento/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tipocomunicacionresultadoevento/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTipoComunicacionResultadoEventoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tipocomunicacionresultadoevento/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tipocomunicacionresultadoevento/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTipoComunicacionResultadoEventoRead(ref IQueryable<Reincarapp.Models.reincardb.TipoComunicacionResultadoEvento> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TipoComunicacionResultadoEvento>> GetTipoComunicacionResultadoEvento(Query query = null)
        {
            var items = Context.TipoComunicacionResultadoEvento.AsQueryable();

            items = items.Include(i => i.Cliente);
            items = items.Include(i => i.ResultadoEvento);
            items = items.Include(i => i.TipoComunicacion);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTipoComunicacionResultadoEventoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTipoComunicacionResultadoEventoGet(Reincarapp.Models.reincardb.TipoComunicacionResultadoEvento item);
        partial void OnGetTipoComunicacionResultadoEventoByIdTipoComunicacionResultadoEvento(ref IQueryable<Reincarapp.Models.reincardb.TipoComunicacionResultadoEvento> items);


        public async Task<Reincarapp.Models.reincardb.TipoComunicacionResultadoEvento> GetTipoComunicacionResultadoEventoByIdTipoComunicacionResultadoEvento(long idtipocomunicacionresultadoevento)
        {
            var items = Context.TipoComunicacionResultadoEvento
                              .AsNoTracking()
                              .Where(i => i.id_tipo_comunicacion_resultado_evento == idtipocomunicacionresultadoevento);

            items = items.Include(i => i.Cliente);
            items = items.Include(i => i.ResultadoEvento);
            items = items.Include(i => i.TipoComunicacion);
 
            OnGetTipoComunicacionResultadoEventoByIdTipoComunicacionResultadoEvento(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTipoComunicacionResultadoEventoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTipoComunicacionResultadoEventoCreated(Reincarapp.Models.reincardb.TipoComunicacionResultadoEvento item);
        partial void OnAfterTipoComunicacionResultadoEventoCreated(Reincarapp.Models.reincardb.TipoComunicacionResultadoEvento item);

        public async Task<Reincarapp.Models.reincardb.TipoComunicacionResultadoEvento> CreateTipoComunicacionResultadoEvento(Reincarapp.Models.reincardb.TipoComunicacionResultadoEvento tipocomunicacionresultadoevento)
        {
            OnTipoComunicacionResultadoEventoCreated(tipocomunicacionresultadoevento);

            var existingItem = Context.TipoComunicacionResultadoEvento
                              .Where(i => i.id_tipo_comunicacion_resultado_evento == tipocomunicacionresultadoevento.id_tipo_comunicacion_resultado_evento)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TipoComunicacionResultadoEvento.Add(tipocomunicacionresultadoevento);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tipocomunicacionresultadoevento).State = EntityState.Detached;
                throw;
            }

            OnAfterTipoComunicacionResultadoEventoCreated(tipocomunicacionresultadoevento);

            return tipocomunicacionresultadoevento;
        }

        public async Task<Reincarapp.Models.reincardb.TipoComunicacionResultadoEvento> CancelTipoComunicacionResultadoEventoChanges(Reincarapp.Models.reincardb.TipoComunicacionResultadoEvento item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTipoComunicacionResultadoEventoUpdated(Reincarapp.Models.reincardb.TipoComunicacionResultadoEvento item);
        partial void OnAfterTipoComunicacionResultadoEventoUpdated(Reincarapp.Models.reincardb.TipoComunicacionResultadoEvento item);

        public async Task<Reincarapp.Models.reincardb.TipoComunicacionResultadoEvento> UpdateTipoComunicacionResultadoEvento(long idtipocomunicacionresultadoevento, Reincarapp.Models.reincardb.TipoComunicacionResultadoEvento tipocomunicacionresultadoevento)
        {
            OnTipoComunicacionResultadoEventoUpdated(tipocomunicacionresultadoevento);

            var itemToUpdate = Context.TipoComunicacionResultadoEvento
                              .Where(i => i.id_tipo_comunicacion_resultado_evento == tipocomunicacionresultadoevento.id_tipo_comunicacion_resultado_evento)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tipocomunicacionresultadoevento);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTipoComunicacionResultadoEventoUpdated(tipocomunicacionresultadoevento);

            return tipocomunicacionresultadoevento;
        }

        partial void OnTipoComunicacionResultadoEventoDeleted(Reincarapp.Models.reincardb.TipoComunicacionResultadoEvento item);
        partial void OnAfterTipoComunicacionResultadoEventoDeleted(Reincarapp.Models.reincardb.TipoComunicacionResultadoEvento item);

        public async Task<Reincarapp.Models.reincardb.TipoComunicacionResultadoEvento> DeleteTipoComunicacionResultadoEvento(long idtipocomunicacionresultadoevento)
        {
            var itemToDelete = Context.TipoComunicacionResultadoEvento
                              .Where(i => i.id_tipo_comunicacion_resultado_evento == idtipocomunicacionresultadoevento)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTipoComunicacionResultadoEventoDeleted(itemToDelete);


            Context.TipoComunicacionResultadoEvento.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTipoComunicacionResultadoEventoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTipoDatoPersonaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tipodatopersona/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tipodatopersona/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTipoDatoPersonaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tipodatopersona/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tipodatopersona/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTipoDatoPersonaRead(ref IQueryable<Reincarapp.Models.reincardb.TipoDatoPersona> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TipoDatoPersona>> GetTipoDatoPersona(Query query = null)
        {
            var items = Context.TipoDatoPersona.AsQueryable();

            items = items.Include(i => i.Cliente);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTipoDatoPersonaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTipoDatoPersonaGet(Reincarapp.Models.reincardb.TipoDatoPersona item);
        partial void OnGetTipoDatoPersonaByIdTipoDatoPersona(ref IQueryable<Reincarapp.Models.reincardb.TipoDatoPersona> items);


        public async Task<Reincarapp.Models.reincardb.TipoDatoPersona> GetTipoDatoPersonaByIdTipoDatoPersona(long idtipodatopersona)
        {
            var items = Context.TipoDatoPersona
                              .AsNoTracking()
                              .Where(i => i.Id_Tipo_Dato_Persona == idtipodatopersona);

            items = items.Include(i => i.Cliente);
 
            OnGetTipoDatoPersonaByIdTipoDatoPersona(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTipoDatoPersonaGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTipoDatoPersonaCreated(Reincarapp.Models.reincardb.TipoDatoPersona item);
        partial void OnAfterTipoDatoPersonaCreated(Reincarapp.Models.reincardb.TipoDatoPersona item);

        public async Task<Reincarapp.Models.reincardb.TipoDatoPersona> CreateTipoDatoPersona(Reincarapp.Models.reincardb.TipoDatoPersona tipodatopersona)
        {
            OnTipoDatoPersonaCreated(tipodatopersona);

            var existingItem = Context.TipoDatoPersona
                              .Where(i => i.Id_Tipo_Dato_Persona == tipodatopersona.Id_Tipo_Dato_Persona)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TipoDatoPersona.Add(tipodatopersona);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tipodatopersona).State = EntityState.Detached;
                throw;
            }

            OnAfterTipoDatoPersonaCreated(tipodatopersona);

            return tipodatopersona;
        }

        public async Task<Reincarapp.Models.reincardb.TipoDatoPersona> CancelTipoDatoPersonaChanges(Reincarapp.Models.reincardb.TipoDatoPersona item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTipoDatoPersonaUpdated(Reincarapp.Models.reincardb.TipoDatoPersona item);
        partial void OnAfterTipoDatoPersonaUpdated(Reincarapp.Models.reincardb.TipoDatoPersona item);

        public async Task<Reincarapp.Models.reincardb.TipoDatoPersona> UpdateTipoDatoPersona(long idtipodatopersona, Reincarapp.Models.reincardb.TipoDatoPersona tipodatopersona)
        {
            OnTipoDatoPersonaUpdated(tipodatopersona);

            var itemToUpdate = Context.TipoDatoPersona
                              .Where(i => i.Id_Tipo_Dato_Persona == tipodatopersona.Id_Tipo_Dato_Persona)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tipodatopersona);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTipoDatoPersonaUpdated(tipodatopersona);

            return tipodatopersona;
        }

        partial void OnTipoDatoPersonaDeleted(Reincarapp.Models.reincardb.TipoDatoPersona item);
        partial void OnAfterTipoDatoPersonaDeleted(Reincarapp.Models.reincardb.TipoDatoPersona item);

        public async Task<Reincarapp.Models.reincardb.TipoDatoPersona> DeleteTipoDatoPersona(long idtipodatopersona)
        {
            var itemToDelete = Context.TipoDatoPersona
                              .Where(i => i.Id_Tipo_Dato_Persona == idtipodatopersona)
                              .Include(i => i.DatoPersona)
                              .Include(i => i.LogDatoPersona)
                              .Include(i => i.LogDatoPersona1)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTipoDatoPersonaDeleted(itemToDelete);


            Context.TipoDatoPersona.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTipoDatoPersonaDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTipoDocumentoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tipodocumento/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tipodocumento/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTipoDocumentoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tipodocumento/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tipodocumento/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTipoDocumentoRead(ref IQueryable<Reincarapp.Models.reincardb.TipoDocumento> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TipoDocumento>> GetTipoDocumento(Query query = null)
        {
            var items = Context.TipoDocumento.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTipoDocumentoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTipoDocumentoGet(Reincarapp.Models.reincardb.TipoDocumento item);
        partial void OnGetTipoDocumentoByIdTipoDocumento(ref IQueryable<Reincarapp.Models.reincardb.TipoDocumento> items);


        public async Task<Reincarapp.Models.reincardb.TipoDocumento> GetTipoDocumentoByIdTipoDocumento(long idtipodocumento)
        {
            var items = Context.TipoDocumento
                              .AsNoTracking()
                              .Where(i => i.Id_Tipo_Documento == idtipodocumento);

 
            OnGetTipoDocumentoByIdTipoDocumento(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTipoDocumentoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTipoDocumentoCreated(Reincarapp.Models.reincardb.TipoDocumento item);
        partial void OnAfterTipoDocumentoCreated(Reincarapp.Models.reincardb.TipoDocumento item);

        public async Task<Reincarapp.Models.reincardb.TipoDocumento> CreateTipoDocumento(Reincarapp.Models.reincardb.TipoDocumento tipodocumento)
        {
            OnTipoDocumentoCreated(tipodocumento);

            var existingItem = Context.TipoDocumento
                              .Where(i => i.Id_Tipo_Documento == tipodocumento.Id_Tipo_Documento)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TipoDocumento.Add(tipodocumento);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tipodocumento).State = EntityState.Detached;
                throw;
            }

            OnAfterTipoDocumentoCreated(tipodocumento);

            return tipodocumento;
        }

        public async Task<Reincarapp.Models.reincardb.TipoDocumento> CancelTipoDocumentoChanges(Reincarapp.Models.reincardb.TipoDocumento item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTipoDocumentoUpdated(Reincarapp.Models.reincardb.TipoDocumento item);
        partial void OnAfterTipoDocumentoUpdated(Reincarapp.Models.reincardb.TipoDocumento item);

        public async Task<Reincarapp.Models.reincardb.TipoDocumento> UpdateTipoDocumento(long idtipodocumento, Reincarapp.Models.reincardb.TipoDocumento tipodocumento)
        {
            OnTipoDocumentoUpdated(tipodocumento);

            var itemToUpdate = Context.TipoDocumento
                              .Where(i => i.Id_Tipo_Documento == tipodocumento.Id_Tipo_Documento)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tipodocumento);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTipoDocumentoUpdated(tipodocumento);

            return tipodocumento;
        }

        partial void OnTipoDocumentoDeleted(Reincarapp.Models.reincardb.TipoDocumento item);
        partial void OnAfterTipoDocumentoDeleted(Reincarapp.Models.reincardb.TipoDocumento item);

        public async Task<Reincarapp.Models.reincardb.TipoDocumento> DeleteTipoDocumento(long idtipodocumento)
        {
            var itemToDelete = Context.TipoDocumento
                              .Where(i => i.Id_Tipo_Documento == idtipodocumento)
                              .Include(i => i.Persona)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTipoDocumentoDeleted(itemToDelete);


            Context.TipoDocumento.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTipoDocumentoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTipoRecaudoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tiporecaudo/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tiporecaudo/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTipoRecaudoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tiporecaudo/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tiporecaudo/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTipoRecaudoRead(ref IQueryable<Reincarapp.Models.reincardb.TipoRecaudo> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TipoRecaudo>> GetTipoRecaudo(Query query = null)
        {
            var items = Context.TipoRecaudo.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTipoRecaudoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTipoRecaudoGet(Reincarapp.Models.reincardb.TipoRecaudo item);
        partial void OnGetTipoRecaudoByIdTipoRecaudo(ref IQueryable<Reincarapp.Models.reincardb.TipoRecaudo> items);


        public async Task<Reincarapp.Models.reincardb.TipoRecaudo> GetTipoRecaudoByIdTipoRecaudo(long idtiporecaudo)
        {
            var items = Context.TipoRecaudo
                              .AsNoTracking()
                              .Where(i => i.id_tipo_recaudo == idtiporecaudo);

 
            OnGetTipoRecaudoByIdTipoRecaudo(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTipoRecaudoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTipoRecaudoCreated(Reincarapp.Models.reincardb.TipoRecaudo item);
        partial void OnAfterTipoRecaudoCreated(Reincarapp.Models.reincardb.TipoRecaudo item);

        public async Task<Reincarapp.Models.reincardb.TipoRecaudo> CreateTipoRecaudo(Reincarapp.Models.reincardb.TipoRecaudo tiporecaudo)
        {
            OnTipoRecaudoCreated(tiporecaudo);

            var existingItem = Context.TipoRecaudo
                              .Where(i => i.id_tipo_recaudo == tiporecaudo.id_tipo_recaudo)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TipoRecaudo.Add(tiporecaudo);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tiporecaudo).State = EntityState.Detached;
                throw;
            }

            OnAfterTipoRecaudoCreated(tiporecaudo);

            return tiporecaudo;
        }

        public async Task<Reincarapp.Models.reincardb.TipoRecaudo> CancelTipoRecaudoChanges(Reincarapp.Models.reincardb.TipoRecaudo item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTipoRecaudoUpdated(Reincarapp.Models.reincardb.TipoRecaudo item);
        partial void OnAfterTipoRecaudoUpdated(Reincarapp.Models.reincardb.TipoRecaudo item);

        public async Task<Reincarapp.Models.reincardb.TipoRecaudo> UpdateTipoRecaudo(long idtiporecaudo, Reincarapp.Models.reincardb.TipoRecaudo tiporecaudo)
        {
            OnTipoRecaudoUpdated(tiporecaudo);

            var itemToUpdate = Context.TipoRecaudo
                              .Where(i => i.id_tipo_recaudo == tiporecaudo.id_tipo_recaudo)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tiporecaudo);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTipoRecaudoUpdated(tiporecaudo);

            return tiporecaudo;
        }

        partial void OnTipoRecaudoDeleted(Reincarapp.Models.reincardb.TipoRecaudo item);
        partial void OnAfterTipoRecaudoDeleted(Reincarapp.Models.reincardb.TipoRecaudo item);

        public async Task<Reincarapp.Models.reincardb.TipoRecaudo> DeleteTipoRecaudo(long idtiporecaudo)
        {
            var itemToDelete = Context.TipoRecaudo
                              .Where(i => i.id_tipo_recaudo == idtiporecaudo)
                              .Include(i => i.HonorarioAvvillas)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTipoRecaudoDeleted(itemToDelete);


            Context.TipoRecaudo.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTipoRecaudoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTipoRediferidoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tiporediferido/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tiporediferido/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTipoRediferidoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tiporediferido/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tiporediferido/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTipoRediferidoRead(ref IQueryable<Reincarapp.Models.reincardb.TipoRediferido> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TipoRediferido>> GetTipoRediferido(Query query = null)
        {
            var items = Context.TipoRediferido.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTipoRediferidoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTipoRediferidoGet(Reincarapp.Models.reincardb.TipoRediferido item);
        partial void OnGetTipoRediferidoByIdTipoRediferido(ref IQueryable<Reincarapp.Models.reincardb.TipoRediferido> items);


        public async Task<Reincarapp.Models.reincardb.TipoRediferido> GetTipoRediferidoByIdTipoRediferido(long idtiporediferido)
        {
            var items = Context.TipoRediferido
                              .AsNoTracking()
                              .Where(i => i.id_tipo_rediferido == idtiporediferido);

 
            OnGetTipoRediferidoByIdTipoRediferido(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTipoRediferidoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTipoRediferidoCreated(Reincarapp.Models.reincardb.TipoRediferido item);
        partial void OnAfterTipoRediferidoCreated(Reincarapp.Models.reincardb.TipoRediferido item);

        public async Task<Reincarapp.Models.reincardb.TipoRediferido> CreateTipoRediferido(Reincarapp.Models.reincardb.TipoRediferido tiporediferido)
        {
            OnTipoRediferidoCreated(tiporediferido);

            var existingItem = Context.TipoRediferido
                              .Where(i => i.id_tipo_rediferido == tiporediferido.id_tipo_rediferido)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TipoRediferido.Add(tiporediferido);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tiporediferido).State = EntityState.Detached;
                throw;
            }

            OnAfterTipoRediferidoCreated(tiporediferido);

            return tiporediferido;
        }

        public async Task<Reincarapp.Models.reincardb.TipoRediferido> CancelTipoRediferidoChanges(Reincarapp.Models.reincardb.TipoRediferido item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTipoRediferidoUpdated(Reincarapp.Models.reincardb.TipoRediferido item);
        partial void OnAfterTipoRediferidoUpdated(Reincarapp.Models.reincardb.TipoRediferido item);

        public async Task<Reincarapp.Models.reincardb.TipoRediferido> UpdateTipoRediferido(long idtiporediferido, Reincarapp.Models.reincardb.TipoRediferido tiporediferido)
        {
            OnTipoRediferidoUpdated(tiporediferido);

            var itemToUpdate = Context.TipoRediferido
                              .Where(i => i.id_tipo_rediferido == tiporediferido.id_tipo_rediferido)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tiporediferido);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTipoRediferidoUpdated(tiporediferido);

            return tiporediferido;
        }

        partial void OnTipoRediferidoDeleted(Reincarapp.Models.reincardb.TipoRediferido item);
        partial void OnAfterTipoRediferidoDeleted(Reincarapp.Models.reincardb.TipoRediferido item);

        public async Task<Reincarapp.Models.reincardb.TipoRediferido> DeleteTipoRediferido(long idtiporediferido)
        {
            var itemToDelete = Context.TipoRediferido
                              .Where(i => i.id_tipo_rediferido == idtiporediferido)
                              .Include(i => i.Rediferido)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTipoRediferidoDeleted(itemToDelete);


            Context.TipoRediferido.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTipoRediferidoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTipoTareaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tipotarea/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tipotarea/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTipoTareaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tipotarea/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tipotarea/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTipoTareaRead(ref IQueryable<Reincarapp.Models.reincardb.TipoTarea> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TipoTarea>> GetTipoTarea(Query query = null)
        {
            var items = Context.TipoTarea.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTipoTareaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTipoTareaGet(Reincarapp.Models.reincardb.TipoTarea item);
        partial void OnGetTipoTareaByIdTipoTarea(ref IQueryable<Reincarapp.Models.reincardb.TipoTarea> items);


        public async Task<Reincarapp.Models.reincardb.TipoTarea> GetTipoTareaByIdTipoTarea(long idtipotarea)
        {
            var items = Context.TipoTarea
                              .AsNoTracking()
                              .Where(i => i.id_tipo_tarea == idtipotarea);

 
            OnGetTipoTareaByIdTipoTarea(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTipoTareaGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTipoTareaCreated(Reincarapp.Models.reincardb.TipoTarea item);
        partial void OnAfterTipoTareaCreated(Reincarapp.Models.reincardb.TipoTarea item);

        public async Task<Reincarapp.Models.reincardb.TipoTarea> CreateTipoTarea(Reincarapp.Models.reincardb.TipoTarea tipotarea)
        {
            OnTipoTareaCreated(tipotarea);

            var existingItem = Context.TipoTarea
                              .Where(i => i.id_tipo_tarea == tipotarea.id_tipo_tarea)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TipoTarea.Add(tipotarea);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tipotarea).State = EntityState.Detached;
                throw;
            }

            OnAfterTipoTareaCreated(tipotarea);

            return tipotarea;
        }

        public async Task<Reincarapp.Models.reincardb.TipoTarea> CancelTipoTareaChanges(Reincarapp.Models.reincardb.TipoTarea item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTipoTareaUpdated(Reincarapp.Models.reincardb.TipoTarea item);
        partial void OnAfterTipoTareaUpdated(Reincarapp.Models.reincardb.TipoTarea item);

        public async Task<Reincarapp.Models.reincardb.TipoTarea> UpdateTipoTarea(long idtipotarea, Reincarapp.Models.reincardb.TipoTarea tipotarea)
        {
            OnTipoTareaUpdated(tipotarea);

            var itemToUpdate = Context.TipoTarea
                              .Where(i => i.id_tipo_tarea == tipotarea.id_tipo_tarea)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tipotarea);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTipoTareaUpdated(tipotarea);

            return tipotarea;
        }

        partial void OnTipoTareaDeleted(Reincarapp.Models.reincardb.TipoTarea item);
        partial void OnAfterTipoTareaDeleted(Reincarapp.Models.reincardb.TipoTarea item);

        public async Task<Reincarapp.Models.reincardb.TipoTarea> DeleteTipoTarea(long idtipotarea)
        {
            var itemToDelete = Context.TipoTarea
                              .Where(i => i.id_tipo_tarea == idtipotarea)
                              .Include(i => i.Tarea)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTipoTareaDeleted(itemToDelete);


            Context.TipoTarea.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTipoTareaDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTipoViaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tipovia/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tipovia/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTipoViaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tipovia/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tipovia/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTipoViaRead(ref IQueryable<Reincarapp.Models.reincardb.TipoVia> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TipoVia>> GetTipoVia(Query query = null)
        {
            var items = Context.TipoVia.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTipoViaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTipoViaGet(Reincarapp.Models.reincardb.TipoVia item);
        partial void OnGetTipoViaByIdTipoVia(ref IQueryable<Reincarapp.Models.reincardb.TipoVia> items);


        public async Task<Reincarapp.Models.reincardb.TipoVia> GetTipoViaByIdTipoVia(int idtipovia)
        {
            var items = Context.TipoVia
                              .AsNoTracking()
                              .Where(i => i.Id_Tipo_Via == idtipovia);

 
            OnGetTipoViaByIdTipoVia(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTipoViaGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTipoViaCreated(Reincarapp.Models.reincardb.TipoVia item);
        partial void OnAfterTipoViaCreated(Reincarapp.Models.reincardb.TipoVia item);

        public async Task<Reincarapp.Models.reincardb.TipoVia> CreateTipoVia(Reincarapp.Models.reincardb.TipoVia tipovia)
        {
            OnTipoViaCreated(tipovia);

            var existingItem = Context.TipoVia
                              .Where(i => i.Id_Tipo_Via == tipovia.Id_Tipo_Via)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TipoVia.Add(tipovia);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tipovia).State = EntityState.Detached;
                throw;
            }

            OnAfterTipoViaCreated(tipovia);

            return tipovia;
        }

        public async Task<Reincarapp.Models.reincardb.TipoVia> CancelTipoViaChanges(Reincarapp.Models.reincardb.TipoVia item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTipoViaUpdated(Reincarapp.Models.reincardb.TipoVia item);
        partial void OnAfterTipoViaUpdated(Reincarapp.Models.reincardb.TipoVia item);

        public async Task<Reincarapp.Models.reincardb.TipoVia> UpdateTipoVia(int idtipovia, Reincarapp.Models.reincardb.TipoVia tipovia)
        {
            OnTipoViaUpdated(tipovia);

            var itemToUpdate = Context.TipoVia
                              .Where(i => i.Id_Tipo_Via == tipovia.Id_Tipo_Via)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tipovia);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTipoViaUpdated(tipovia);

            return tipovia;
        }

        partial void OnTipoViaDeleted(Reincarapp.Models.reincardb.TipoVia item);
        partial void OnAfterTipoViaDeleted(Reincarapp.Models.reincardb.TipoVia item);

        public async Task<Reincarapp.Models.reincardb.TipoVia> DeleteTipoVia(int idtipovia)
        {
            var itemToDelete = Context.TipoVia
                              .Where(i => i.Id_Tipo_Via == idtipovia)
                              .Include(i => i.DatoPersona)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTipoViaDeleted(itemToDelete);


            Context.TipoVia.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTipoViaDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTipobaseToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tipobase/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tipobase/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTipobaseToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tipobase/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tipobase/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTipobaseRead(ref IQueryable<Reincarapp.Models.reincardb.Tipobase> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Tipobase>> GetTipobase(Query query = null)
        {
            var items = Context.Tipobase.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTipobaseRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTipobaseGet(Reincarapp.Models.reincardb.Tipobase item);
        partial void OnGetTipobaseById(ref IQueryable<Reincarapp.Models.reincardb.Tipobase> items);


        public async Task<Reincarapp.Models.reincardb.Tipobase> GetTipobaseById(long id)
        {
            var items = Context.Tipobase
                              .AsNoTracking()
                              .Where(i => i.Id == id);

 
            OnGetTipobaseById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTipobaseGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTipobaseCreated(Reincarapp.Models.reincardb.Tipobase item);
        partial void OnAfterTipobaseCreated(Reincarapp.Models.reincardb.Tipobase item);

        public async Task<Reincarapp.Models.reincardb.Tipobase> CreateTipobase(Reincarapp.Models.reincardb.Tipobase tipobase)
        {
            OnTipobaseCreated(tipobase);

            var existingItem = Context.Tipobase
                              .Where(i => i.Id == tipobase.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Tipobase.Add(tipobase);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tipobase).State = EntityState.Detached;
                throw;
            }

            OnAfterTipobaseCreated(tipobase);

            return tipobase;
        }

        public async Task<Reincarapp.Models.reincardb.Tipobase> CancelTipobaseChanges(Reincarapp.Models.reincardb.Tipobase item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTipobaseUpdated(Reincarapp.Models.reincardb.Tipobase item);
        partial void OnAfterTipobaseUpdated(Reincarapp.Models.reincardb.Tipobase item);

        public async Task<Reincarapp.Models.reincardb.Tipobase> UpdateTipobase(long id, Reincarapp.Models.reincardb.Tipobase tipobase)
        {
            OnTipobaseUpdated(tipobase);

            var itemToUpdate = Context.Tipobase
                              .Where(i => i.Id == tipobase.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tipobase);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTipobaseUpdated(tipobase);

            return tipobase;
        }

        partial void OnTipobaseDeleted(Reincarapp.Models.reincardb.Tipobase item);
        partial void OnAfterTipobaseDeleted(Reincarapp.Models.reincardb.Tipobase item);

        public async Task<Reincarapp.Models.reincardb.Tipobase> DeleteTipobase(long id)
        {
            var itemToDelete = Context.Tipobase
                              .Where(i => i.Id == id)
                              .Include(i => i.Base)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTipobaseDeleted(itemToDelete);


            Context.Tipobase.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTipobaseDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTmpClienteDeudaDicToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tmpclientedeudadic/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tmpclientedeudadic/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTmpClienteDeudaDicToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tmpclientedeudadic/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tmpclientedeudadic/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTmpClienteDeudaDicRead(ref IQueryable<Reincarapp.Models.reincardb.TmpClienteDeudaDic> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TmpClienteDeudaDic>> GetTmpClienteDeudaDic(Query query = null)
        {
            var items = Context.TmpClienteDeudaDic.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTmpClienteDeudaDicRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTmpClienteDeudaDicGet(Reincarapp.Models.reincardb.TmpClienteDeudaDic item);
        partial void OnGetTmpClienteDeudaDicById(ref IQueryable<Reincarapp.Models.reincardb.TmpClienteDeudaDic> items);


        public async Task<Reincarapp.Models.reincardb.TmpClienteDeudaDic> GetTmpClienteDeudaDicById(long id)
        {
            var items = Context.TmpClienteDeudaDic
                              .AsNoTracking()
                              .Where(i => i.id == id);

 
            OnGetTmpClienteDeudaDicById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTmpClienteDeudaDicGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTmpClienteDeudaDicCreated(Reincarapp.Models.reincardb.TmpClienteDeudaDic item);
        partial void OnAfterTmpClienteDeudaDicCreated(Reincarapp.Models.reincardb.TmpClienteDeudaDic item);

        public async Task<Reincarapp.Models.reincardb.TmpClienteDeudaDic> CreateTmpClienteDeudaDic(Reincarapp.Models.reincardb.TmpClienteDeudaDic tmpclientedeudadic)
        {
            OnTmpClienteDeudaDicCreated(tmpclientedeudadic);

            var existingItem = Context.TmpClienteDeudaDic
                              .Where(i => i.id == tmpclientedeudadic.id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TmpClienteDeudaDic.Add(tmpclientedeudadic);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tmpclientedeudadic).State = EntityState.Detached;
                throw;
            }

            OnAfterTmpClienteDeudaDicCreated(tmpclientedeudadic);

            return tmpclientedeudadic;
        }

        public async Task<Reincarapp.Models.reincardb.TmpClienteDeudaDic> CancelTmpClienteDeudaDicChanges(Reincarapp.Models.reincardb.TmpClienteDeudaDic item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTmpClienteDeudaDicUpdated(Reincarapp.Models.reincardb.TmpClienteDeudaDic item);
        partial void OnAfterTmpClienteDeudaDicUpdated(Reincarapp.Models.reincardb.TmpClienteDeudaDic item);

        public async Task<Reincarapp.Models.reincardb.TmpClienteDeudaDic> UpdateTmpClienteDeudaDic(long id, Reincarapp.Models.reincardb.TmpClienteDeudaDic tmpclientedeudadic)
        {
            OnTmpClienteDeudaDicUpdated(tmpclientedeudadic);

            var itemToUpdate = Context.TmpClienteDeudaDic
                              .Where(i => i.id == tmpclientedeudadic.id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tmpclientedeudadic);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTmpClienteDeudaDicUpdated(tmpclientedeudadic);

            return tmpclientedeudadic;
        }

        partial void OnTmpClienteDeudaDicDeleted(Reincarapp.Models.reincardb.TmpClienteDeudaDic item);
        partial void OnAfterTmpClienteDeudaDicDeleted(Reincarapp.Models.reincardb.TmpClienteDeudaDic item);

        public async Task<Reincarapp.Models.reincardb.TmpClienteDeudaDic> DeleteTmpClienteDeudaDic(long id)
        {
            var itemToDelete = Context.TmpClienteDeudaDic
                              .Where(i => i.id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTmpClienteDeudaDicDeleted(itemToDelete);


            Context.TmpClienteDeudaDic.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTmpClienteDeudaDicDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTmpClienteDeudaEstadoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tmpclientedeudaestado/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tmpclientedeudaestado/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTmpClienteDeudaEstadoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tmpclientedeudaestado/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tmpclientedeudaestado/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTmpClienteDeudaEstadoRead(ref IQueryable<Reincarapp.Models.reincardb.TmpClienteDeudaEstado> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TmpClienteDeudaEstado>> GetTmpClienteDeudaEstado(Query query = null)
        {
            var items = Context.TmpClienteDeudaEstado.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTmpClienteDeudaEstadoRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportTmpDatoPerBorToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tmpdatoperbor/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tmpdatoperbor/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTmpDatoPerBorToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tmpdatoperbor/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tmpdatoperbor/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTmpDatoPerBorRead(ref IQueryable<Reincarapp.Models.reincardb.TmpDatoPerBor> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TmpDatoPerBor>> GetTmpDatoPerBor(Query query = null)
        {
            var items = Context.TmpDatoPerBor.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTmpDatoPerBorRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportTmpDatoPersonaToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tmpdatopersona/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tmpdatopersona/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTmpDatoPersonaToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tmpdatopersona/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tmpdatopersona/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTmpDatoPersonaRead(ref IQueryable<Reincarapp.Models.reincardb.TmpDatoPersona> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TmpDatoPersona>> GetTmpDatoPersona(Query query = null)
        {
            var items = Context.TmpDatoPersona.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTmpDatoPersonaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTmpDatoPersonaGet(Reincarapp.Models.reincardb.TmpDatoPersona item);
        partial void OnGetTmpDatoPersonaByIdDatoPersona(ref IQueryable<Reincarapp.Models.reincardb.TmpDatoPersona> items);


        public async Task<Reincarapp.Models.reincardb.TmpDatoPersona> GetTmpDatoPersonaByIdDatoPersona(long iddatopersona)
        {
            var items = Context.TmpDatoPersona
                              .AsNoTracking()
                              .Where(i => i.id_dato_persona == iddatopersona);

 
            OnGetTmpDatoPersonaByIdDatoPersona(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTmpDatoPersonaGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTmpDatoPersonaCreated(Reincarapp.Models.reincardb.TmpDatoPersona item);
        partial void OnAfterTmpDatoPersonaCreated(Reincarapp.Models.reincardb.TmpDatoPersona item);

        public async Task<Reincarapp.Models.reincardb.TmpDatoPersona> CreateTmpDatoPersona(Reincarapp.Models.reincardb.TmpDatoPersona tmpdatopersona)
        {
            OnTmpDatoPersonaCreated(tmpdatopersona);

            var existingItem = Context.TmpDatoPersona
                              .Where(i => i.id_dato_persona == tmpdatopersona.id_dato_persona)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TmpDatoPersona.Add(tmpdatopersona);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tmpdatopersona).State = EntityState.Detached;
                throw;
            }

            OnAfterTmpDatoPersonaCreated(tmpdatopersona);

            return tmpdatopersona;
        }

        public async Task<Reincarapp.Models.reincardb.TmpDatoPersona> CancelTmpDatoPersonaChanges(Reincarapp.Models.reincardb.TmpDatoPersona item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTmpDatoPersonaUpdated(Reincarapp.Models.reincardb.TmpDatoPersona item);
        partial void OnAfterTmpDatoPersonaUpdated(Reincarapp.Models.reincardb.TmpDatoPersona item);

        public async Task<Reincarapp.Models.reincardb.TmpDatoPersona> UpdateTmpDatoPersona(long iddatopersona, Reincarapp.Models.reincardb.TmpDatoPersona tmpdatopersona)
        {
            OnTmpDatoPersonaUpdated(tmpdatopersona);

            var itemToUpdate = Context.TmpDatoPersona
                              .Where(i => i.id_dato_persona == tmpdatopersona.id_dato_persona)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tmpdatopersona);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTmpDatoPersonaUpdated(tmpdatopersona);

            return tmpdatopersona;
        }

        partial void OnTmpDatoPersonaDeleted(Reincarapp.Models.reincardb.TmpDatoPersona item);
        partial void OnAfterTmpDatoPersonaDeleted(Reincarapp.Models.reincardb.TmpDatoPersona item);

        public async Task<Reincarapp.Models.reincardb.TmpDatoPersona> DeleteTmpDatoPersona(long iddatopersona)
        {
            var itemToDelete = Context.TmpDatoPersona
                              .Where(i => i.id_dato_persona == iddatopersona)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTmpDatoPersonaDeleted(itemToDelete);


            Context.TmpDatoPersona.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTmpDatoPersonaDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTmpDecEstToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tmpdecest/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tmpdecest/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTmpDecEstToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tmpdecest/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tmpdecest/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTmpDecEstRead(ref IQueryable<Reincarapp.Models.reincardb.TmpDecEst> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TmpDecEst>> GetTmpDecEst(Query query = null)
        {
            var items = Context.TmpDecEst.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTmpDecEstRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportTmpEventoSaludcoopToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tmpeventosaludcoop/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tmpeventosaludcoop/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTmpEventoSaludcoopToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tmpeventosaludcoop/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tmpeventosaludcoop/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTmpEventoSaludcoopRead(ref IQueryable<Reincarapp.Models.reincardb.TmpEventoSaludcoop> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TmpEventoSaludcoop>> GetTmpEventoSaludcoop(Query query = null)
        {
            var items = Context.TmpEventoSaludcoop.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTmpEventoSaludcoopRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportTmpGestCooJurToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tmpgestcoojur/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tmpgestcoojur/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTmpGestCooJurToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tmpgestcoojur/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tmpgestcoojur/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTmpGestCooJurRead(ref IQueryable<Reincarapp.Models.reincardb.TmpGestCooJur> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TmpGestCooJur>> GetTmpGestCooJur(Query query = null)
        {
            var items = Context.TmpGestCooJur.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTmpGestCooJurRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportTmpUsuarioToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tmpusuario/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tmpusuario/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTmpUsuarioToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tmpusuario/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tmpusuario/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTmpUsuarioRead(ref IQueryable<Reincarapp.Models.reincardb.TmpUsuario> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.TmpUsuario>> GetTmpUsuario(Query query = null)
        {
            var items = Context.TmpUsuario.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTmpUsuarioRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportTmpcambiotipToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tmpcambiotip/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tmpcambiotip/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTmpcambiotipToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/tmpcambiotip/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/tmpcambiotip/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTmpcambiotipRead(ref IQueryable<Reincarapp.Models.reincardb.Tmpcambiotip> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Tmpcambiotip>> GetTmpcambiotip(Query query = null)
        {
            var items = Context.Tmpcambiotip.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTmpcambiotipRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportTransitoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/transito/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/transito/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTransitoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/transito/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/transito/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTransitoRead(ref IQueryable<Reincarapp.Models.reincardb.Transito> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Transito>> GetTransito(Query query = null)
        {
            var items = Context.Transito.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTransitoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTransitoGet(Reincarapp.Models.reincardb.Transito item);
        partial void OnGetTransitoByIdTransito(ref IQueryable<Reincarapp.Models.reincardb.Transito> items);


        public async Task<Reincarapp.Models.reincardb.Transito> GetTransitoByIdTransito(long idtransito)
        {
            var items = Context.Transito
                              .AsNoTracking()
                              .Where(i => i.ID_TRANSITO == idtransito);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetTransitoByIdTransito(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTransitoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTransitoCreated(Reincarapp.Models.reincardb.Transito item);
        partial void OnAfterTransitoCreated(Reincarapp.Models.reincardb.Transito item);

        public async Task<Reincarapp.Models.reincardb.Transito> CreateTransito(Reincarapp.Models.reincardb.Transito transito)
        {
            OnTransitoCreated(transito);

            var existingItem = Context.Transito
                              .Where(i => i.ID_TRANSITO == transito.ID_TRANSITO)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Transito.Add(transito);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(transito).State = EntityState.Detached;
                throw;
            }

            OnAfterTransitoCreated(transito);

            return transito;
        }

        public async Task<Reincarapp.Models.reincardb.Transito> CancelTransitoChanges(Reincarapp.Models.reincardb.Transito item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTransitoUpdated(Reincarapp.Models.reincardb.Transito item);
        partial void OnAfterTransitoUpdated(Reincarapp.Models.reincardb.Transito item);

        public async Task<Reincarapp.Models.reincardb.Transito> UpdateTransito(long idtransito, Reincarapp.Models.reincardb.Transito transito)
        {
            OnTransitoUpdated(transito);

            var itemToUpdate = Context.Transito
                              .Where(i => i.ID_TRANSITO == transito.ID_TRANSITO)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(transito);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTransitoUpdated(transito);

            return transito;
        }

        partial void OnTransitoDeleted(Reincarapp.Models.reincardb.Transito item);
        partial void OnAfterTransitoDeleted(Reincarapp.Models.reincardb.Transito item);

        public async Task<Reincarapp.Models.reincardb.Transito> DeleteTransito(long idtransito)
        {
            var itemToDelete = Context.Transito
                              .Where(i => i.ID_TRANSITO == idtransito)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTransitoDeleted(itemToDelete);


            Context.Transito.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTransitoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTransitobucToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/transitobuc/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/transitobuc/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTransitobucToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/transitobuc/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/transitobuc/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTransitobucRead(ref IQueryable<Reincarapp.Models.reincardb.Transitobuc> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Transitobuc>> GetTransitobuc(Query query = null)
        {
            var items = Context.Transitobuc.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTransitobucRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTransitobucGet(Reincarapp.Models.reincardb.Transitobuc item);
        partial void OnGetTransitobucByIdTransitoBuc(ref IQueryable<Reincarapp.Models.reincardb.Transitobuc> items);


        public async Task<Reincarapp.Models.reincardb.Transitobuc> GetTransitobucByIdTransitoBuc(long idtransitobuc)
        {
            var items = Context.Transitobuc
                              .AsNoTracking()
                              .Where(i => i.id_transito_buc == idtransitobuc);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetTransitobucByIdTransitoBuc(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTransitobucGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTransitobucCreated(Reincarapp.Models.reincardb.Transitobuc item);
        partial void OnAfterTransitobucCreated(Reincarapp.Models.reincardb.Transitobuc item);

        public async Task<Reincarapp.Models.reincardb.Transitobuc> CreateTransitobuc(Reincarapp.Models.reincardb.Transitobuc transitobuc)
        {
            OnTransitobucCreated(transitobuc);

            var existingItem = Context.Transitobuc
                              .Where(i => i.id_transito_buc == transitobuc.id_transito_buc)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Transitobuc.Add(transitobuc);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(transitobuc).State = EntityState.Detached;
                throw;
            }

            OnAfterTransitobucCreated(transitobuc);

            return transitobuc;
        }

        public async Task<Reincarapp.Models.reincardb.Transitobuc> CancelTransitobucChanges(Reincarapp.Models.reincardb.Transitobuc item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTransitobucUpdated(Reincarapp.Models.reincardb.Transitobuc item);
        partial void OnAfterTransitobucUpdated(Reincarapp.Models.reincardb.Transitobuc item);

        public async Task<Reincarapp.Models.reincardb.Transitobuc> UpdateTransitobuc(long idtransitobuc, Reincarapp.Models.reincardb.Transitobuc transitobuc)
        {
            OnTransitobucUpdated(transitobuc);

            var itemToUpdate = Context.Transitobuc
                              .Where(i => i.id_transito_buc == transitobuc.id_transito_buc)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(transitobuc);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTransitobucUpdated(transitobuc);

            return transitobuc;
        }

        partial void OnTransitobucDeleted(Reincarapp.Models.reincardb.Transitobuc item);
        partial void OnAfterTransitobucDeleted(Reincarapp.Models.reincardb.Transitobuc item);

        public async Task<Reincarapp.Models.reincardb.Transitobuc> DeleteTransitobuc(long idtransitobuc)
        {
            var itemToDelete = Context.Transitobuc
                              .Where(i => i.id_transito_buc == idtransitobuc)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTransitobucDeleted(itemToDelete);


            Context.Transitobuc.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTransitobucDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTransitofloToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/transitoflo/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/transitoflo/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTransitofloToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/transitoflo/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/transitoflo/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTransitofloRead(ref IQueryable<Reincarapp.Models.reincardb.Transitoflo> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Transitoflo>> GetTransitoflo(Query query = null)
        {
            var items = Context.Transitoflo.AsQueryable();

            items = items.Include(i => i.ClienteDeuda);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnTransitofloRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTransitofloGet(Reincarapp.Models.reincardb.Transitoflo item);
        partial void OnGetTransitofloByIdTransitoFlo(ref IQueryable<Reincarapp.Models.reincardb.Transitoflo> items);


        public async Task<Reincarapp.Models.reincardb.Transitoflo> GetTransitofloByIdTransitoFlo(long idtransitoflo)
        {
            var items = Context.Transitoflo
                              .AsNoTracking()
                              .Where(i => i.id_transito_flo == idtransitoflo);

            items = items.Include(i => i.ClienteDeuda);
 
            OnGetTransitofloByIdTransitoFlo(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnTransitofloGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTransitofloCreated(Reincarapp.Models.reincardb.Transitoflo item);
        partial void OnAfterTransitofloCreated(Reincarapp.Models.reincardb.Transitoflo item);

        public async Task<Reincarapp.Models.reincardb.Transitoflo> CreateTransitoflo(Reincarapp.Models.reincardb.Transitoflo transitoflo)
        {
            OnTransitofloCreated(transitoflo);

            var existingItem = Context.Transitoflo
                              .Where(i => i.id_transito_flo == transitoflo.id_transito_flo)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Transitoflo.Add(transitoflo);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(transitoflo).State = EntityState.Detached;
                throw;
            }

            OnAfterTransitofloCreated(transitoflo);

            return transitoflo;
        }

        public async Task<Reincarapp.Models.reincardb.Transitoflo> CancelTransitofloChanges(Reincarapp.Models.reincardb.Transitoflo item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTransitofloUpdated(Reincarapp.Models.reincardb.Transitoflo item);
        partial void OnAfterTransitofloUpdated(Reincarapp.Models.reincardb.Transitoflo item);

        public async Task<Reincarapp.Models.reincardb.Transitoflo> UpdateTransitoflo(long idtransitoflo, Reincarapp.Models.reincardb.Transitoflo transitoflo)
        {
            OnTransitofloUpdated(transitoflo);

            var itemToUpdate = Context.Transitoflo
                              .Where(i => i.id_transito_flo == transitoflo.id_transito_flo)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(transitoflo);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTransitofloUpdated(transitoflo);

            return transitoflo;
        }

        partial void OnTransitofloDeleted(Reincarapp.Models.reincardb.Transitoflo item);
        partial void OnAfterTransitofloDeleted(Reincarapp.Models.reincardb.Transitoflo item);

        public async Task<Reincarapp.Models.reincardb.Transitoflo> DeleteTransitoflo(long idtransitoflo)
        {
            var itemToDelete = Context.Transitoflo
                              .Where(i => i.id_transito_flo == idtransitoflo)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTransitofloDeleted(itemToDelete);


            Context.Transitoflo.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTransitofloDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportUsuarioToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/usuario/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/usuario/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportUsuarioToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/usuario/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/usuario/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnUsuarioRead(ref IQueryable<Reincarapp.Models.reincardb.Usuario> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Usuario>> GetUsuario(Query query = null)
        {
            var items = Context.Usuario.AsQueryable();

            items = items.Include(i => i.EstadoUsuario);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnUsuarioRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnUsuarioGet(Reincarapp.Models.reincardb.Usuario item);
        partial void OnGetUsuarioByIdUsuario(ref IQueryable<Reincarapp.Models.reincardb.Usuario> items);


        public async Task<Reincarapp.Models.reincardb.Usuario> GetUsuarioByIdUsuario(long idusuario)
        {
            var items = Context.Usuario
                              .AsNoTracking()
                              .Where(i => i.Id_Usuario == idusuario);

            items = items.Include(i => i.EstadoUsuario);
 
            OnGetUsuarioByIdUsuario(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnUsuarioGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnUsuarioCreated(Reincarapp.Models.reincardb.Usuario item);
        partial void OnAfterUsuarioCreated(Reincarapp.Models.reincardb.Usuario item);

        public async Task<Reincarapp.Models.reincardb.Usuario> CreateUsuario(Reincarapp.Models.reincardb.Usuario usuario)
        {
            OnUsuarioCreated(usuario);

            var existingItem = Context.Usuario
                              .Where(i => i.Id_Usuario == usuario.Id_Usuario)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Usuario.Add(usuario);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(usuario).State = EntityState.Detached;
                throw;
            }

            OnAfterUsuarioCreated(usuario);

            return usuario;
        }

        public async Task<Reincarapp.Models.reincardb.Usuario> CancelUsuarioChanges(Reincarapp.Models.reincardb.Usuario item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnUsuarioUpdated(Reincarapp.Models.reincardb.Usuario item);
        partial void OnAfterUsuarioUpdated(Reincarapp.Models.reincardb.Usuario item);

        public async Task<Reincarapp.Models.reincardb.Usuario> UpdateUsuario(long idusuario, Reincarapp.Models.reincardb.Usuario usuario)
        {
            OnUsuarioUpdated(usuario);

            var itemToUpdate = Context.Usuario
                              .Where(i => i.Id_Usuario == usuario.Id_Usuario)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(usuario);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterUsuarioUpdated(usuario);

            return usuario;
        }

        partial void OnUsuarioDeleted(Reincarapp.Models.reincardb.Usuario item);
        partial void OnAfterUsuarioDeleted(Reincarapp.Models.reincardb.Usuario item);

        public async Task<Reincarapp.Models.reincardb.Usuario> DeleteUsuario(long idusuario)
        {
            var itemToDelete = Context.Usuario
                              .Where(i => i.Id_Usuario == idusuario)
                              .Include(i => i.AsignacionGestor)
                              .Include(i => i.AsignacionGestor1)
                              .Include(i => i.Base)
                              .Include(i => i.Base1)
                              .Include(i => i.Bloqueocontacto)
                              .Include(i => i.ClienteDeuda)
                              .Include(i => i.ClienteDeuda1)
                              .Include(i => i.ClienteDeudaHonorario)
                              .Include(i => i.ClienteDeudaUsuario)
                              .Include(i => i.ClienteDeudaUsuario1)
                              .Include(i => i.DecisionEstado)
                              .Include(i => i.Evento)
                              .Include(i => i.Evento1)
                              .Include(i => i.HonorarioAvvillas)
                              .Include(i => i.LogDatoPersona)
                              .Include(i => i.Rediferido)
                              .Include(i => i.SubrepartoUsuario)
                              .Include(i => i.SubrepartoUsuario1)
                              .Include(i => i.SubrepartoUsuario2)
                              .Include(i => i.Tarea)
                              .Include(i => i.Tarea1)
                              .Include(i => i.Tiempofuera)
                              .Include(i => i.UsuarioCliente)
                              .Include(i => i.UsuarioRol)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnUsuarioDeleted(itemToDelete);


            Context.Usuario.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterUsuarioDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportUsuarioClienteToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/usuariocliente/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/usuariocliente/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportUsuarioClienteToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/usuariocliente/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/usuariocliente/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnUsuarioClienteRead(ref IQueryable<Reincarapp.Models.reincardb.UsuarioCliente> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.UsuarioCliente>> GetUsuarioCliente(Query query = null)
        {
            var items = Context.UsuarioCliente.AsQueryable();

            items = items.Include(i => i.Aspnetusers);
            items = items.Include(i => i.Cliente);
            items = items.Include(i => i.Usuario);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnUsuarioClienteRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnUsuarioClienteGet(Reincarapp.Models.reincardb.UsuarioCliente item);
        partial void OnGetUsuarioClienteByIdUsuarioCliente(ref IQueryable<Reincarapp.Models.reincardb.UsuarioCliente> items);


        public async Task<Reincarapp.Models.reincardb.UsuarioCliente> GetUsuarioClienteByIdUsuarioCliente(long idusuariocliente)
        {
            var items = Context.UsuarioCliente
                              .AsNoTracking()
                              .Where(i => i.Id_Usuario_Cliente == idusuariocliente);

            items = items.Include(i => i.Aspnetusers);
            items = items.Include(i => i.Cliente);
            items = items.Include(i => i.Usuario);
 
            OnGetUsuarioClienteByIdUsuarioCliente(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnUsuarioClienteGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnUsuarioClienteCreated(Reincarapp.Models.reincardb.UsuarioCliente item);
        partial void OnAfterUsuarioClienteCreated(Reincarapp.Models.reincardb.UsuarioCliente item);

        public async Task<Reincarapp.Models.reincardb.UsuarioCliente> CreateUsuarioCliente(Reincarapp.Models.reincardb.UsuarioCliente usuariocliente)
        {
            OnUsuarioClienteCreated(usuariocliente);

            var existingItem = Context.UsuarioCliente
                              .Where(i => i.Id_Usuario_Cliente == usuariocliente.Id_Usuario_Cliente)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.UsuarioCliente.Add(usuariocliente);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(usuariocliente).State = EntityState.Detached;
                throw;
            }

            OnAfterUsuarioClienteCreated(usuariocliente);

            return usuariocliente;
        }

        public async Task<Reincarapp.Models.reincardb.UsuarioCliente> CancelUsuarioClienteChanges(Reincarapp.Models.reincardb.UsuarioCliente item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnUsuarioClienteUpdated(Reincarapp.Models.reincardb.UsuarioCliente item);
        partial void OnAfterUsuarioClienteUpdated(Reincarapp.Models.reincardb.UsuarioCliente item);

        public async Task<Reincarapp.Models.reincardb.UsuarioCliente> UpdateUsuarioCliente(long idusuariocliente, Reincarapp.Models.reincardb.UsuarioCliente usuariocliente)
        {
            OnUsuarioClienteUpdated(usuariocliente);

            var itemToUpdate = Context.UsuarioCliente
                              .Where(i => i.Id_Usuario_Cliente == usuariocliente.Id_Usuario_Cliente)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(usuariocliente);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterUsuarioClienteUpdated(usuariocliente);

            return usuariocliente;
        }

        partial void OnUsuarioClienteDeleted(Reincarapp.Models.reincardb.UsuarioCliente item);
        partial void OnAfterUsuarioClienteDeleted(Reincarapp.Models.reincardb.UsuarioCliente item);

        public async Task<Reincarapp.Models.reincardb.UsuarioCliente> DeleteUsuarioCliente(long idusuariocliente)
        {
            var itemToDelete = Context.UsuarioCliente
                              .Where(i => i.Id_Usuario_Cliente == idusuariocliente)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnUsuarioClienteDeleted(itemToDelete);


            Context.UsuarioCliente.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterUsuarioClienteDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportUsuarioRolToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/usuariorol/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/usuariorol/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportUsuarioRolToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/usuariorol/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/usuariorol/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnUsuarioRolRead(ref IQueryable<Reincarapp.Models.reincardb.UsuarioRol> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.UsuarioRol>> GetUsuarioRol(Query query = null)
        {
            var items = Context.UsuarioRol.AsQueryable();

            items = items.Include(i => i.Rol);
            items = items.Include(i => i.Usuario);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnUsuarioRolRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnUsuarioRolGet(Reincarapp.Models.reincardb.UsuarioRol item);
        partial void OnGetUsuarioRolByIdUsuarioRol(ref IQueryable<Reincarapp.Models.reincardb.UsuarioRol> items);


        public async Task<Reincarapp.Models.reincardb.UsuarioRol> GetUsuarioRolByIdUsuarioRol(long idusuariorol)
        {
            var items = Context.UsuarioRol
                              .AsNoTracking()
                              .Where(i => i.Id_Usuario_Rol == idusuariorol);

            items = items.Include(i => i.Rol);
            items = items.Include(i => i.Usuario);
 
            OnGetUsuarioRolByIdUsuarioRol(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnUsuarioRolGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnUsuarioRolCreated(Reincarapp.Models.reincardb.UsuarioRol item);
        partial void OnAfterUsuarioRolCreated(Reincarapp.Models.reincardb.UsuarioRol item);

        public async Task<Reincarapp.Models.reincardb.UsuarioRol> CreateUsuarioRol(Reincarapp.Models.reincardb.UsuarioRol usuariorol)
        {
            OnUsuarioRolCreated(usuariorol);

            var existingItem = Context.UsuarioRol
                              .Where(i => i.Id_Usuario_Rol == usuariorol.Id_Usuario_Rol)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.UsuarioRol.Add(usuariorol);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(usuariorol).State = EntityState.Detached;
                throw;
            }

            OnAfterUsuarioRolCreated(usuariorol);

            return usuariorol;
        }

        public async Task<Reincarapp.Models.reincardb.UsuarioRol> CancelUsuarioRolChanges(Reincarapp.Models.reincardb.UsuarioRol item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnUsuarioRolUpdated(Reincarapp.Models.reincardb.UsuarioRol item);
        partial void OnAfterUsuarioRolUpdated(Reincarapp.Models.reincardb.UsuarioRol item);

        public async Task<Reincarapp.Models.reincardb.UsuarioRol> UpdateUsuarioRol(long idusuariorol, Reincarapp.Models.reincardb.UsuarioRol usuariorol)
        {
            OnUsuarioRolUpdated(usuariorol);

            var itemToUpdate = Context.UsuarioRol
                              .Where(i => i.Id_Usuario_Rol == usuariorol.Id_Usuario_Rol)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(usuariorol);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterUsuarioRolUpdated(usuariorol);

            return usuariorol;
        }

        partial void OnUsuarioRolDeleted(Reincarapp.Models.reincardb.UsuarioRol item);
        partial void OnAfterUsuarioRolDeleted(Reincarapp.Models.reincardb.UsuarioRol item);

        public async Task<Reincarapp.Models.reincardb.UsuarioRol> DeleteUsuarioRol(long idusuariorol)
        {
            var itemToDelete = Context.UsuarioRol
                              .Where(i => i.Id_Usuario_Rol == idusuariorol)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnUsuarioRolDeleted(itemToDelete);


            Context.UsuarioRol.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterUsuarioRolDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportZonaUbicacionToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/zonaubicacion/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/zonaubicacion/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportZonaUbicacionToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/zonaubicacion/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/zonaubicacion/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnZonaUbicacionRead(ref IQueryable<Reincarapp.Models.reincardb.ZonaUbicacion> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ZonaUbicacion>> GetZonaUbicacion(Query query = null)
        {
            var items = Context.ZonaUbicacion.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnZonaUbicacionRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnZonaUbicacionGet(Reincarapp.Models.reincardb.ZonaUbicacion item);
        partial void OnGetZonaUbicacionByIdZonaUbicacion(ref IQueryable<Reincarapp.Models.reincardb.ZonaUbicacion> items);


        public async Task<Reincarapp.Models.reincardb.ZonaUbicacion> GetZonaUbicacionByIdZonaUbicacion(int idzonaubicacion)
        {
            var items = Context.ZonaUbicacion
                              .AsNoTracking()
                              .Where(i => i.Id_Zona_Ubicacion == idzonaubicacion);

 
            OnGetZonaUbicacionByIdZonaUbicacion(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnZonaUbicacionGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnZonaUbicacionCreated(Reincarapp.Models.reincardb.ZonaUbicacion item);
        partial void OnAfterZonaUbicacionCreated(Reincarapp.Models.reincardb.ZonaUbicacion item);

        public async Task<Reincarapp.Models.reincardb.ZonaUbicacion> CreateZonaUbicacion(Reincarapp.Models.reincardb.ZonaUbicacion zonaubicacion)
        {
            OnZonaUbicacionCreated(zonaubicacion);

            var existingItem = Context.ZonaUbicacion
                              .Where(i => i.Id_Zona_Ubicacion == zonaubicacion.Id_Zona_Ubicacion)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ZonaUbicacion.Add(zonaubicacion);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(zonaubicacion).State = EntityState.Detached;
                throw;
            }

            OnAfterZonaUbicacionCreated(zonaubicacion);

            return zonaubicacion;
        }

        public async Task<Reincarapp.Models.reincardb.ZonaUbicacion> CancelZonaUbicacionChanges(Reincarapp.Models.reincardb.ZonaUbicacion item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnZonaUbicacionUpdated(Reincarapp.Models.reincardb.ZonaUbicacion item);
        partial void OnAfterZonaUbicacionUpdated(Reincarapp.Models.reincardb.ZonaUbicacion item);

        public async Task<Reincarapp.Models.reincardb.ZonaUbicacion> UpdateZonaUbicacion(int idzonaubicacion, Reincarapp.Models.reincardb.ZonaUbicacion zonaubicacion)
        {
            OnZonaUbicacionUpdated(zonaubicacion);

            var itemToUpdate = Context.ZonaUbicacion
                              .Where(i => i.Id_Zona_Ubicacion == zonaubicacion.Id_Zona_Ubicacion)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(zonaubicacion);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterZonaUbicacionUpdated(zonaubicacion);

            return zonaubicacion;
        }

        partial void OnZonaUbicacionDeleted(Reincarapp.Models.reincardb.ZonaUbicacion item);
        partial void OnAfterZonaUbicacionDeleted(Reincarapp.Models.reincardb.ZonaUbicacion item);

        public async Task<Reincarapp.Models.reincardb.ZonaUbicacion> DeleteZonaUbicacion(int idzonaubicacion)
        {
            var itemToDelete = Context.ZonaUbicacion
                              .Where(i => i.Id_Zona_Ubicacion == idzonaubicacion)
                              .Include(i => i.DatoPersona)
                              .Include(i => i.DatoPersona1)
                              .Include(i => i.DatoPersona2)
                              .Include(i => i.DatoPersona3)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnZonaUbicacionDeleted(itemToDelete);


            Context.ZonaUbicacion.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterZonaUbicacionDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportZzzProcAvvToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/zzzprocavv/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/zzzprocavv/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportZzzProcAvvToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/zzzprocavv/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/zzzprocavv/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnZzzProcAvvRead(ref IQueryable<Reincarapp.Models.reincardb.ZzzProcAvv> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ZzzProcAvv>> GetZzzProcAvv(Query query = null)
        {
            var items = Context.ZzzProcAvv.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnZzzProcAvvRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportZzzTmpBorrarAvvillasToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/zzztmpborraravvillas/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/zzztmpborraravvillas/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportZzzTmpBorrarAvvillasToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/zzztmpborraravvillas/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/zzztmpborraravvillas/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnZzzTmpBorrarAvvillasRead(ref IQueryable<Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas>> GetZzzTmpBorrarAvvillas(Query query = null)
        {
            var items = Context.ZzzTmpBorrarAvvillas.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnZzzTmpBorrarAvvillasRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task ExportZzzTmpBorrarAvvillas1ToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/zzztmpborraravvillas1/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/zzztmpborraravvillas1/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportZzzTmpBorrarAvvillas1ToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/zzztmpborraravvillas1/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/zzztmpborraravvillas1/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnZzzTmpBorrarAvvillas1Read(ref IQueryable<Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas1> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas1>> GetZzzTmpBorrarAvvillas1(Query query = null)
        {
            var items = Context.ZzzTmpBorrarAvvillas1.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnZzzTmpBorrarAvvillas1Read(ref items);

            return await Task.FromResult(items);
        }

        partial void OnZzzTmpBorrarAvvillas1Get(Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas1 item);
        partial void OnGetZzzTmpBorrarAvvillas1ByIdClienteDeuda(ref IQueryable<Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas1> items);


        public async Task<Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas1> GetZzzTmpBorrarAvvillas1ByIdClienteDeuda(long idclientedeuda)
        {
            var items = Context.ZzzTmpBorrarAvvillas1
                              .AsNoTracking()
                              .Where(i => i.id_cliente_deuda == idclientedeuda);

 
            OnGetZzzTmpBorrarAvvillas1ByIdClienteDeuda(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnZzzTmpBorrarAvvillas1Get(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnZzzTmpBorrarAvvillas1Created(Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas1 item);
        partial void OnAfterZzzTmpBorrarAvvillas1Created(Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas1 item);

        public async Task<Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas1> CreateZzzTmpBorrarAvvillas1(Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas1 zzztmpborraravvillas1)
        {
            OnZzzTmpBorrarAvvillas1Created(zzztmpborraravvillas1);

            var existingItem = Context.ZzzTmpBorrarAvvillas1
                              .Where(i => i.id_cliente_deuda == zzztmpborraravvillas1.id_cliente_deuda)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ZzzTmpBorrarAvvillas1.Add(zzztmpborraravvillas1);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(zzztmpborraravvillas1).State = EntityState.Detached;
                throw;
            }

            OnAfterZzzTmpBorrarAvvillas1Created(zzztmpborraravvillas1);

            return zzztmpborraravvillas1;
        }

        public async Task<Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas1> CancelZzzTmpBorrarAvvillas1Changes(Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas1 item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnZzzTmpBorrarAvvillas1Updated(Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas1 item);
        partial void OnAfterZzzTmpBorrarAvvillas1Updated(Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas1 item);

        public async Task<Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas1> UpdateZzzTmpBorrarAvvillas1(long idclientedeuda, Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas1 zzztmpborraravvillas1)
        {
            OnZzzTmpBorrarAvvillas1Updated(zzztmpborraravvillas1);

            var itemToUpdate = Context.ZzzTmpBorrarAvvillas1
                              .Where(i => i.id_cliente_deuda == zzztmpborraravvillas1.id_cliente_deuda)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(zzztmpborraravvillas1);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterZzzTmpBorrarAvvillas1Updated(zzztmpborraravvillas1);

            return zzztmpborraravvillas1;
        }

        partial void OnZzzTmpBorrarAvvillas1Deleted(Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas1 item);
        partial void OnAfterZzzTmpBorrarAvvillas1Deleted(Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas1 item);

        public async Task<Reincarapp.Models.reincardb.ZzzTmpBorrarAvvillas1> DeleteZzzTmpBorrarAvvillas1(long idclientedeuda)
        {
            var itemToDelete = Context.ZzzTmpBorrarAvvillas1
                              .Where(i => i.id_cliente_deuda == idclientedeuda)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnZzzTmpBorrarAvvillas1Deleted(itemToDelete);


            Context.ZzzTmpBorrarAvvillas1.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterZzzTmpBorrarAvvillas1Deleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportZzzTmpToDelTransitoToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/zzztmptodeltransito/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/zzztmptodeltransito/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportZzzTmpToDelTransitoToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/zzztmptodeltransito/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/zzztmptodeltransito/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnZzzTmpToDelTransitoRead(ref IQueryable<Reincarapp.Models.reincardb.ZzzTmpToDelTransito> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.ZzzTmpToDelTransito>> GetZzzTmpToDelTransito(Query query = null)
        {
            var items = Context.ZzzTmpToDelTransito.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnZzzTmpToDelTransitoRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnZzzTmpToDelTransitoGet(Reincarapp.Models.reincardb.ZzzTmpToDelTransito item);
        partial void OnGetZzzTmpToDelTransitoByIdEvento(ref IQueryable<Reincarapp.Models.reincardb.ZzzTmpToDelTransito> items);


        public async Task<Reincarapp.Models.reincardb.ZzzTmpToDelTransito> GetZzzTmpToDelTransitoByIdEvento(long idevento)
        {
            var items = Context.ZzzTmpToDelTransito
                              .AsNoTracking()
                              .Where(i => i.id_evento == idevento);

 
            OnGetZzzTmpToDelTransitoByIdEvento(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnZzzTmpToDelTransitoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnZzzTmpToDelTransitoCreated(Reincarapp.Models.reincardb.ZzzTmpToDelTransito item);
        partial void OnAfterZzzTmpToDelTransitoCreated(Reincarapp.Models.reincardb.ZzzTmpToDelTransito item);

        public async Task<Reincarapp.Models.reincardb.ZzzTmpToDelTransito> CreateZzzTmpToDelTransito(Reincarapp.Models.reincardb.ZzzTmpToDelTransito zzztmptodeltransito)
        {
            OnZzzTmpToDelTransitoCreated(zzztmptodeltransito);

            var existingItem = Context.ZzzTmpToDelTransito
                              .Where(i => i.id_evento == zzztmptodeltransito.id_evento)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ZzzTmpToDelTransito.Add(zzztmptodeltransito);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(zzztmptodeltransito).State = EntityState.Detached;
                throw;
            }

            OnAfterZzzTmpToDelTransitoCreated(zzztmptodeltransito);

            return zzztmptodeltransito;
        }

        public async Task<Reincarapp.Models.reincardb.ZzzTmpToDelTransito> CancelZzzTmpToDelTransitoChanges(Reincarapp.Models.reincardb.ZzzTmpToDelTransito item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnZzzTmpToDelTransitoUpdated(Reincarapp.Models.reincardb.ZzzTmpToDelTransito item);
        partial void OnAfterZzzTmpToDelTransitoUpdated(Reincarapp.Models.reincardb.ZzzTmpToDelTransito item);

        public async Task<Reincarapp.Models.reincardb.ZzzTmpToDelTransito> UpdateZzzTmpToDelTransito(long idevento, Reincarapp.Models.reincardb.ZzzTmpToDelTransito zzztmptodeltransito)
        {
            OnZzzTmpToDelTransitoUpdated(zzztmptodeltransito);

            var itemToUpdate = Context.ZzzTmpToDelTransito
                              .Where(i => i.id_evento == zzztmptodeltransito.id_evento)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(zzztmptodeltransito);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterZzzTmpToDelTransitoUpdated(zzztmptodeltransito);

            return zzztmptodeltransito;
        }

        partial void OnZzzTmpToDelTransitoDeleted(Reincarapp.Models.reincardb.ZzzTmpToDelTransito item);
        partial void OnAfterZzzTmpToDelTransitoDeleted(Reincarapp.Models.reincardb.ZzzTmpToDelTransito item);

        public async Task<Reincarapp.Models.reincardb.ZzzTmpToDelTransito> DeleteZzzTmpToDelTransito(long idevento)
        {
            var itemToDelete = Context.ZzzTmpToDelTransito
                              .Where(i => i.id_evento == idevento)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnZzzTmpToDelTransitoDeleted(itemToDelete);


            Context.ZzzTmpToDelTransito.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterZzzTmpToDelTransitoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAspnetusersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/aspnetusers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/aspnetusers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAspnetusersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/reincardb/aspnetusers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/reincardb/aspnetusers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAspnetusersRead(ref IQueryable<Reincarapp.Models.reincardb.Aspnetusers> items);

        public async Task<IQueryable<Reincarapp.Models.reincardb.Aspnetusers>> GetAspnetusers(Query query = null)
        {
            var items = Context.Aspnetusers.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnAspnetusersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAspnetusersGet(Reincarapp.Models.reincardb.Aspnetusers item);
        partial void OnGetAspnetusersById(ref IQueryable<Reincarapp.Models.reincardb.Aspnetusers> items);


        public async Task<Reincarapp.Models.reincardb.Aspnetusers> GetAspnetusersById(string id)
        {
            var items = Context.Aspnetusers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

 
            OnGetAspnetusersById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnAspnetusersGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAspnetusersCreated(Reincarapp.Models.reincardb.Aspnetusers item);
        partial void OnAfterAspnetusersCreated(Reincarapp.Models.reincardb.Aspnetusers item);

        public async Task<Reincarapp.Models.reincardb.Aspnetusers> CreateAspnetusers(Reincarapp.Models.reincardb.Aspnetusers aspnetusers)
        {
            OnAspnetusersCreated(aspnetusers);

            var existingItem = Context.Aspnetusers
                              .Where(i => i.Id == aspnetusers.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Aspnetusers.Add(aspnetusers);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(aspnetusers).State = EntityState.Detached;
                throw;
            }

            OnAfterAspnetusersCreated(aspnetusers);

            return aspnetusers;
        }

        public async Task<Reincarapp.Models.reincardb.Aspnetusers> CancelAspnetusersChanges(Reincarapp.Models.reincardb.Aspnetusers item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAspnetusersUpdated(Reincarapp.Models.reincardb.Aspnetusers item);
        partial void OnAfterAspnetusersUpdated(Reincarapp.Models.reincardb.Aspnetusers item);

        public async Task<Reincarapp.Models.reincardb.Aspnetusers> UpdateAspnetusers(string id, Reincarapp.Models.reincardb.Aspnetusers aspnetusers)
        {
            OnAspnetusersUpdated(aspnetusers);

            var itemToUpdate = Context.Aspnetusers
                              .Where(i => i.Id == aspnetusers.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(aspnetusers);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAspnetusersUpdated(aspnetusers);

            return aspnetusers;
        }

        partial void OnAspnetusersDeleted(Reincarapp.Models.reincardb.Aspnetusers item);
        partial void OnAfterAspnetusersDeleted(Reincarapp.Models.reincardb.Aspnetusers item);

        public async Task<Reincarapp.Models.reincardb.Aspnetusers> DeleteAspnetusers(string id)
        {
            var itemToDelete = Context.Aspnetusers
                              .Where(i => i.Id == id)
                              .Include(i => i.Evento)
                              .Include(i => i.Evento1)
                              .Include(i => i.Tarea)
                              .Include(i => i.Tarea1)
                              .Include(i => i.Tarea2)
                              .Include(i => i.UsuarioCliente)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAspnetusersDeleted(itemToDelete);


            Context.Aspnetusers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAspnetusersDeleted(itemToDelete);

            return itemToDelete;
        }
        }
}